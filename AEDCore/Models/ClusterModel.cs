using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEDCore.Models
{
    public class ClusterModel : ICloneable
    {
        public EventModel Centroid { get; set; }
        
        public List<EventModel> Events { get; set; }
        
        public EventType Type { get; set; }

        public void CalculateCentroid()
        {
            if (Events.Count <= 0) return;
            
            // calculate average for every part of centroid symptom
            for (var index = 0; index < Centroid.SymptomModel.Length; index++)
            {
                // sumarize parts of symptoms
                Events.ForEach(symptom => Centroid.SymptomModel.Symptom[index] += symptom.SymptomModel.Symptom[index]);

                // divide sum by symptoms count
                Centroid.SymptomModel.Symptom[index] /= Events.Count;
            }
        }

        public object Clone()
        {
            return new ClusterModel
            {
                Centroid = Centroid.Clone() as EventModel,
                Events = Events.Select(e => e.Clone() as EventModel).ToList(),
                Type = Type
            };
        }
    }
}
