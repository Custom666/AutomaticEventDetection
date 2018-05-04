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
        private static void Main(string[] args)
        {
            if (args.Length < 3 || args.Length > 3) return;

            var parser = new EventsParser();

            var events = parser.ParseCSV(args[0]);

            if (events == null) return;

            ISymptomAlgorithm symtopmAlgorithm;
            IDetectionMethod method;

            switch (args[1].ToLower())
            {
                case "bow":

                    symtopmAlgorithm = new BagOfWords();

                    break;

                case "tf-idf":

                    symtopmAlgorithm = new TermFrequencyInverseDocumentFrequency();

                    break;
                default:

                    Console.WriteLine("There is no such symtoms algorithm that you requested!");

                    return;
            }

            switch (args[2].ToLower())
            {
                case "mdm":

                    method = new MinimalDistanceMethod();
                    
                    break;
                default:

                    Console.WriteLine("There is no such clustering method that you requested!");

                    return;
            }

            Console.WriteLine("Generating symtoms...");

            symtopmAlgorithm.GenerateSymptoms(events);

            Console.WriteLine("Symptoms generated successfully.");
            Console.WriteLine($"There are { events.Count(s => s.SymptomModel != null) } symptoms.");

            Console.WriteLine("Making etalons...");

            var symptomLength = events[0].SymptomModel.Length;

            var etalons = new List<ClusterModel>
            {
                new ClusterModel
                {
                    Type = EventType.Agriculture,
                    Centroid = new EventModel() { SymptomModel = new SymptomModel(symptomLength) },
                    Events = events.Where(e => e.EventType == EventType.Agriculture).ToList()
                },
                new ClusterModel
                {
                    Type = EventType.Crimes,
                    Centroid = new EventModel() { SymptomModel = new SymptomModel(symptomLength) },
                    Events = events.Where(e => e.EventType == EventType.Crimes).ToList()
                },
                new ClusterModel
                {
                    Type = EventType.Culture,
                    Centroid = new EventModel() { SymptomModel = new SymptomModel(symptomLength) },
                    Events = events.Where(e => e.EventType == EventType.Culture).ToList()
                },
                new ClusterModel
                {
                    Type = EventType.Industry,
                    Centroid = new EventModel() { SymptomModel = new SymptomModel(symptomLength) },
                    Events = events.Where(e => e.EventType == EventType.Industry).ToList()
                },
                //new ClusterModel
                //{
                //    Type = EventType.None,
                //    Centroid = new EventModel() { SymptomModel = new SymptomModel(symptomLength) },
                //    Events = events.Where(e => e.EventType == EventType.None).ToList()
                //},
                new ClusterModel
                {
                    Type = EventType.Other,
                    Centroid = new EventModel() { SymptomModel = new SymptomModel(symptomLength) },
                    Events = events.Where(e => e.EventType == EventType.Other).ToList()
                },
                new ClusterModel
                {
                    Type = EventType.Politics,
                    Centroid = new EventModel() { SymptomModel = new SymptomModel(symptomLength) },
                    Events = events.Where(e => e.EventType == EventType.Politics).ToList()
                },
                new ClusterModel
                {
                    Type = EventType.Sport,
                    Centroid = new EventModel() { SymptomModel = new SymptomModel(symptomLength) },
                    Events = events.Where(e => e.EventType == EventType.Sport).ToList()
                },
                new ClusterModel
                {
                    Type = EventType.Weather,
                    Centroid = new EventModel() { SymptomModel = new SymptomModel(symptomLength) },
                    Events = events.Where(e => e.EventType == EventType.Weather).ToList()
                },
            };

            Console.WriteLine("Detection...");

            var clusters = method.Detect(events, etalons);

            Console.WriteLine("Detecting done.");

            for (var index = 0; index < clusters.Count; index++)
                Console.WriteLine($"Cluster { clusters[index].Type } contain { clusters[index].Events.Count } symptoms and it should have { etalons[index].Events.Count }");
        }
    }
}
