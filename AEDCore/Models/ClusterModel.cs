using System;
using System.Collections.Generic;
using System.Text;

namespace AEDCore.Models
{
    public class ClusterModel
    {
        public SymptomModel Centroid { get; set; }

        public List<SymptomModel> Symptoms { get; set; }
    }
}
