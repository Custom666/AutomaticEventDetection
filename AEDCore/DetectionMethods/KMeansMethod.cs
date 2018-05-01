using System;
using System.Collections.Generic;
using System.Linq;
using AEDCore.Interfaces;
using AEDCore.Models;

namespace AEDCore.DetectionMethods
{
    public class KMeansMethod : IClusteringMethod
    {
        public readonly int ClustersCount;

        public IReadOnlyList<ClusterModel> Clusters => _clusters.AsReadOnly();

        private List<ClusterModel> _clusters;
        private Random _random;

        public KMeansMethod(int clustersCount)
        {
            ClustersCount = clustersCount;

            _clusters = new List<ClusterModel>(ClustersCount);

            _random = new Random();
        }

        public void Clusterize(IList<SymptomModel> symptoms)
        {
            // randomly initialize clusters
            for (var index = 0; index < ClustersCount; index++)
            {
                // get random number between 0 inclusive and symptoms count exclusive
                var randomIndex = _random.Next(symptoms.Count);

                // take random symptom as cluster
                _clusters.Add(new ClusterModel
                {
                    Centroid = symptoms[randomIndex],
                    Name = $"Cluster{ index }"
                });
            }

            // until every clusters did change (are dirty)
            while(_clusters.Any(cluster => cluster.IsDirty))
            {
                // clear assigned symptoms in clusters
                _clusters.ForEach(cluster => cluster.Symptoms.Clear());

                // assign each symptom to the closest cluster
                foreach (var symptom in symptoms)
                {
                    var minimumDistance = double.MaxValue;
                    var clusterIndex = -1;

                    // search minimal distance and index of cluster
                    for (var index = 0; index < _clusters.Count; index++)
                    {
                        // calcualte distance between symptom and cluster centroid
                        var distance = symptom.Distance(_clusters[index].Centroid);

                        if (minimumDistance > distance)
                        {
                            minimumDistance = distance;

                            clusterIndex = index;
                        }
                    }

                    // assign to cluster
                    _clusters[clusterIndex].Symptoms.Add(symptom);
                }

                // calculate new centroid for each cluster
                _clusters.ForEach(cluster => cluster.CalculateCentroid());
            }
        }
    }
}
