using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Icas.Test
{
    [TestClass]
    public class ClusteringTest
    {
        [TestMethod]
        public void Summarise()
        {
            Clustering.Cluster.Summarize();
        }
    }
}
