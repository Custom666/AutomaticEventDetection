namespace AEDCore.Models
{
    public class SymptomModel
    {
        public int[] Symptom { get; private set; }

        public SymptomModel(int capacity)
        {
            Symptom = new int[capacity];
        }
    }
}
