using AEDCore.Interfaces;
using AEDCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEDCore.DetectionMethods
{
    public class MinimalDistanceMethod : IDetectionMethod
    {
        public IReadOnlyList<ClusterModel> Detect(IList<EventModel> events, IList<ClusterModel> etanols)
        {
            var result = etanols.Select(e => e.Clone() as ClusterModel).ToList();
            
            foreach (var etanol in result)
            {
                etanol.CalculateCentroid();

                etanol.Events.Clear();
            }

            foreach (var eventModel in events)
                result.OrderBy(etanol => eventModel.SymptomModel.Distance(etanol.Centroid.SymptomModel))
                    .First()
                    .Events.Add(eventModel);
            
            return result.ToList().AsReadOnly();
        }
    }
}
