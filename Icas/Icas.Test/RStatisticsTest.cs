using Microsoft.VisualStudio.TestTools.UnitTesting;
using Icas.Clustering;
using System;

namespace Icas.Test
{
    [TestClass]
    public class MiClusterClusteringTest
    {
        [TestMethod]
        public void SmockingTest()
        {
            Icas.Clustering.Statistics.Test();
        }

        [TestMethod]
        public void Similarity()
        {
            Console.WriteLine("start");
            double result = Ensemble.Similarity(SimilarityType.Euclidean, System.IO.Directory.GetFiles(@"U:\JICWork\ensemble\xrn4_kmeans_k_4_init_random\", "*labels.csv"));
            Console.WriteLine(result);
        }
    }
}
