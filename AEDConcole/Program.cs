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
            if(args.Length < 3 || args.Length > 3) return;

            var parser = new EventsParser();

            var events = parser.ParseCSV(args[0]);

            if (events == null) return;

            ISymptomAlgorithm symtopmAlgorithm;
            IClusteringMethod detectionMethod;
            
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
                case "mdm":

                    detectionMethod = new MinimalDistanceMethod();

                    break;
                default:

                    Console.WriteLine("There is no such detection method that you requested!");

                    return;
            }

            Console.WriteLine("Generating symtoms...");

            symtopmAlgorithm.GenerateSymptoms(events);

            Console.WriteLine("Symptoms generated successfully.");

            Console.WriteLine("Learning...");

            detectionMethod.Learn(events);

            Console.WriteLine("Learning done.");

            Console.ReadKey();
        }
    }
}
