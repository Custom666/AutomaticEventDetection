using System;
using System.Collections.Generic;
using System.Text;

namespace AEDCore.Interfaces
{
    public interface IDetectionMethod
    {
        void Learn(IList<EventModel> models);

        IList<EventModel> Detect(IList<int[]> symptoms);
    }
}
