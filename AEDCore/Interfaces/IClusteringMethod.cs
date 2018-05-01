using AEDCore.Models;
using System.Collections.Generic;

namespace AEDCore.Interfaces
{
    public interface IClusteringMethod
    {
        IList<ClusterModel> Clusterize(IList<SymptomModel> symptoms);
    }
}
