using System;

namespace AEDCore.Models
{
    public class SymptomModel
    {
        public int[] Symptom { get; private set; }

        public readonly int Count;

        public SymptomModel(int count)
        {
            Count = count;

            Symptom = new int[count];
        }

        /// <summary>
        /// Euclidean  
        /// </summary>
        public double Distance(SymptomModel symptom)
        {
            var sum = 0d;

            for (var index = 0; index < Count; index++)
                sum += Math.Pow(Symptom[index] - symptom.Symptom[index], 2);
            
            return Math.Sqrt(sum);
        }
    }
}
