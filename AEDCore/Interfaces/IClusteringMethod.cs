using AEDCore.Models;
using System.Collections.Generic;

namespace AEDCore.Interfaces
{
    public interface IClusteringMethod
    {
        IReadOnlyList<ClusterModel> Clusters { get; }

        void Clusterize(IList<SymptomModel> symptoms);
    }
}
