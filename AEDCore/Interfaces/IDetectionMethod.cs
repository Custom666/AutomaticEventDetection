using AEDCore.Models;
using System.Collections.Generic;

namespace AEDCore.Interfaces
{
    public interface IDetectionMethod
    {
        IReadOnlyList<ClusterModel> Detect(IList<EventModel> events, IList<ClusterModel> etanols);
    }
}
