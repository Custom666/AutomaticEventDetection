using AEDCore.Interfaces;
using AEDCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEDCore.DetectionMethods
{
    public class KNearestNeighbors : IDetectionMethod
    {
        public readonly int NeighborsCount;

        public KNearestNeighbors(int neighborsCount)
        {
            NeighborsCount = neighborsCount;
        }

        public IReadOnlyList<ClusterModel> Detect(IList<EventModel> events, IList<ClusterModel> etanols)
        {
            var clusters = etanols.Select(e => e.Clone() as ClusterModel).ToList();

            clusters.ForEach(c => c.Events.Clear());

            foreach(var eventModel in events)
            {
                var nearest = events.OrderBy(e => eventModel.SymptomModel.Distance(e.SymptomModel))
                    .Take(NeighborsCount)
                    .GroupBy(n => n.EventType)
                    .ToList();
                
                if(nearest.Count == NeighborsCount)
                {
                    clusters.First(c => c.Type == nearest.First().First().EventType).Events.Add(eventModel);

                    continue;
                }

                var max = nearest.Max(n => n.Count());

                var nearestType = nearest.First(n => n.Count() == max).First().EventType;

                clusters.First(c => c.Type == nearestType).Events.Add(eventModel);
            }

            return clusters.AsReadOnly();
        }
    }
}
