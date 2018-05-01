using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AEDCore.Models
{
    public class ClusterModel
    {
        public SymptomModel Centroid { get; set; }

        public List<SymptomModel> Symptoms { get; private set; } = new List<SymptomModel>();

        public bool IsDirty { get; private set; } = true;

        public string Name { get; set; }

        public void CalculateCentroid()
        {
            if (Symptoms.Count <= 0)
            {
                IsDirty = false;

                return;
            }

            var tempCentroid = new int[Centroid.Count];

            Centroid.Symptom.CopyTo(tempCentroid, 0);

            // calculate average for every part of centroid symptom
            for (var index = 0; index < Centroid.Count; index++)
            {
                // sumarize parts of symptoms
                Symptoms.ForEach(symptom => Centroid.Symptom[index] += symptom.Symptom[index]);

                // divide sum by symptoms count
                Centroid.Symptom[index] /= Symptoms.Count;
            }

            IsDirty = !Enumerable.SequenceEqual(tempCentroid, Centroid.Symptom);
        }
    }
}
