using System;
using System.Linq;

namespace AEDCore.Models
{
    public class SymptomModel : ICloneable
    {
        public double[] Symptom { get; private set; }

        public readonly int Length;

        public SymptomModel(int length)
        {
            Length = length;

            Symptom = new double[length];
        }

        /// <summary>
        /// Eucleides metric /* Cosine similatiry */
        /// </summary>
        public double Distance(SymptomModel symptom)
        {
            var sum = 0d;

            for (var index = 0; index < Length; index++)
                sum += Math.Pow(Symptom[index] - symptom.Symptom[index], 2);

            return Math.Sqrt(sum);

            //var dotProduct = DotProduct(Symptom, symptom.Symptom);
            //var thisSymptomMagnitude = Math.Sqrt(DotProduct(Symptom, Symptom));
            //var otherSymptomMagnitude = Math.Sqrt(DotProduct(symptom.Symptom, symptom.Symptom));

            //return dotProduct / (thisSymptomMagnitude * otherSymptomMagnitude);
        }
        
        private double DotProduct(double[] vecA, double[] vecB)
        {   
            double dotProduct = 0;

            for (var i = 0; i < vecA.Length; i++) dotProduct += (vecA[i] * vecB[i]);
            
            return dotProduct;
        }

        public object Clone()
        {
            var symptom = new SymptomModel(Length);

            Symptom.CopyTo(symptom.Symptom, 0);

            return symptom;
        }
    }
}
