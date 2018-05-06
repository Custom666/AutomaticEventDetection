using System;
using System.Collections.Generic;
using System.Linq;
using AEDCore;
using AEDCore.DetectionMethods;
using AEDCore.Interfaces;
using AEDCore.Models;
using AEDCore.SymptomAlgorithms;

namespace AEDConcole
{
    public class Program
    {
        private static readonly string Help = Strings.Help
            + Environment.NewLine + Environment.NewLine
            + Strings.ExecutionFormat
            + Environment.NewLine + Environment.NewLine
            + Strings.Tweets
            + Environment.NewLine + Environment.NewLine
            + Strings.Bow
            + Environment.NewLine
            + Strings.TFIDF
            + Environment.NewLine
            + Strings.FT
            + Environment.NewLine + Environment.NewLine
            + Strings.MDM
            + Environment.NewLine
            + Strings.KNN
            + Environment.NewLine + Environment.NewLine
            + Strings.Output;

        private static void Main(string[] args)
        {
            if (args.Length < 3 || args.Length > 6)
            {
                Console.WriteLine(Help);

                return;
            }

            var parser = new EventsParser();

            IList<EventModel> events = null;

            try
            {
                events = parser.ParseFromCSV(args[0]);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(Strings.WrongFileFormat);
                Console.WriteLine(Strings.Tweets);

                return;
            }

            if (events == null)
            {
                Console.WriteLine(Strings.FileNotFound);

                return;
            }

            ISymptomAlgorithm symtopmAlgorithm;
            IDetectionMethod method;

            var isFastTest = false;

            switch (args[1].ToLower())
            {
                case "bow":

                    symtopmAlgorithm = new BagOfWords();

                    break;

                case "tf-idf":

                    symtopmAlgorithm = new TermFrequencyInverseDocumentFrequency();

                    break;

                case "ft":

                    isFastTest = true;

                    symtopmAlgorithm = new FastTest(args[2]);

                    break;
                default:

                    Console.WriteLine(Strings.SymptomAlgorithmError);
                    Console.WriteLine(Strings.Bow);

                    return;
            }

            switch (args[isFastTest ? 3 : 2].ToLower())
            {
                case "mdm":

                    method = new MinimalDistanceMethod();

                    break;

                case "knn":

                    if (args.Length < 4 || !int.TryParse(args[isFastTest ? 4 : 3], out var k) || k <= 0)
                    {
                        Console.WriteLine(Strings.PositiveIntegerError);
                        Console.WriteLine(Strings.KNN);

                        return;
                    }

                    method = new KNearestNeighbors(k);

                    break;
                default:

                    Console.WriteLine(Strings.DetectionMethodError);
                    Console.WriteLine(Strings.MDM);

                    return;
            }

            Console.WriteLine("Generating symtoms...");

            symtopmAlgorithm.GenerateSymptoms(events);

            Console.WriteLine("Symptoms generated successfully.");
            Console.WriteLine($"There are { events.Count(s => s.SymptomModel != null) } symptoms.");

            Console.WriteLine("\nMaking etalons...");

            var symptomLength = events[0].SymptomModel.Length;

            var etalons = new List<ClusterModel>();

            foreach (var e in events)
            {
                var exist = etalons.Where(etalon => e.EventType == etalon.Type).FirstOrDefault();

                if (exist != null)
                {
                    exist.Events.Add(e);
                    continue;
                }

                etalons.Add(new ClusterModel
                {
                    Type = e.EventType,
                    Events = new List<EventModel> { e }
                });
            }

            etalons.ForEach(e => Console.WriteLine($"Created etalon { e.Type }"));

            Console.WriteLine("\nDetection...");

            var clusters = method.Detect(events, etalons);

            Console.WriteLine("Detecting done.");

            var output = args.Last();

            if (output.LastIndexOf('.') > 0 && output.Substring(output.LastIndexOf('.')).ToLower().CompareTo(".csv") == 0)
            {
                Console.WriteLine("\nWriting result into csv file...\n");

                var classifiedEvents = clusters.Select(c => c.Clone() as ClusterModel).ToList();

                classifiedEvents.ForEach(c => c.Events.ForEach(e => e.EventType = c.Type));

                try
                {
                    parser.ParseIntoCSV(output, classifiedEvents.SelectMany(c => c.Events.Select(e => e)).ToList());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    return;
                }
            }
            else Console.WriteLine(Environment.NewLine + Strings.OutputError + Environment.NewLine); 

            Console.WriteLine("Results:");

            double correctResults = clusters.Sum(c => c.Events.Count(e => e.EventType == c.Type));

            double all = clusters.Sum(c => c.Events.Count);

            var precision =  correctResults / all;

            var recall = (correctResults / Math.Abs((all - correctResults))) / 100;

            var fMeasure = (2 * (precision * recall)) / (precision + recall);

            Console.WriteLine($"Precision: { precision }\nRecall: { recall }\nF-measure: { fMeasure }\n");
            
            foreach (var c in clusters)
                foreach (var e in c.Events)
                    if (e.EventType != c.Type) Console.WriteLine($"Cluster { c.Type } contain wrong classified { e.EventType }");
        }
    }
}
