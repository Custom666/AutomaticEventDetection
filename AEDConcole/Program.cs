using System;
using AEDCore;
using AEDCore.DetectionMethods;
using AEDCore.Interfaces;
using AEDCore.SymptomAlgorithms;

namespace AEDConcole
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 3 || args.Length > 3) return;

            var parser = new EventsParser();

            var events = parser.ParseCSV(args[0]);

            if (events == null) return;

            ISymptomAlgorithm symtopmAlgorithm;
            IClusteringMethod method;

            switch (args[1].ToLower())
            {
                case "bow":

                    symtopmAlgorithm = new BagOfWords();

                    break;
                default:

                    Console.WriteLine("There is no such symtoms algorithm that you requested!");

                    return;
            }

            switch (args[2].ToLower())
            {
                case "km":

                    method = new KMeansMethod(Enum.GetValues(typeof(EventType)).Length);

                    break;
                default:

                    Console.WriteLine("There is no such clustering method that you requested!");

                    return;
            }

            Console.WriteLine("Generating symtoms...");

            var symptoms = symtopmAlgorithm.GenerateSymptoms(events);

            Console.WriteLine("Symptoms generated successfully.");
            Console.WriteLine($"There are { symptoms.Count } symptoms.");

            Console.WriteLine("Clustering...");

            method.Clusterize(symptoms);

            Console.WriteLine("Clustering done.");

            foreach (var cluster in method.Clusters)
                Console.WriteLine($"Cluster { cluster.Name } has { cluster.Symptoms.Count } symptoms.");
            
            Console.ReadKey();
        }
    }
}
