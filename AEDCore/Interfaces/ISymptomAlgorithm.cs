using System;
using System.Collections.Generic;
using System.Text;

namespace AEDCore.Interfaces
{
    /// <summary>
    /// Interface for algorithms that handle process generating list of symptoms from list of models
    /// </summary>
    public interface ISymptomAlgorithm
    {
        /// <summary>
        /// Generate symptom from every given <see cref="EventModel"/>
        /// </summary>
        /// <param name="models">List of input event models</param>
        void GenerateSymptoms(IList<EventModel> models);
    }
}
