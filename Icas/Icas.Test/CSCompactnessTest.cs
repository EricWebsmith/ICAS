using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Icas.Test
{
    [TestClass]
    public class CSCompactnessTest
    {
        [TestMethod]
        public void AttachCompactnessTest()
        {
            //string stat_file = @"C:\JICWork\kmeans\length_21\wt\";
            //DegradomeType type = DegradomeType.wt;
            //int length = 21;
            //CSCompactness.AttachCompactness("kmeans",stat_file, type, length, FeatureType.Reactivity);
        }

        [TestMethod]
        public void AttachCompactnessAll()
        {
            ////string[] methods = new string[] { "kmeans", "affinity_propagation", "spectral_clustering" };
            //string[] methods = new string[] { "meanshift" };
            //int[] lengths = new int[] { 21, 71, 121 };
            //DegradomeType[] types = new DegradomeType[] { DegradomeType.wt, DegradomeType.xrn4 };
            //foreach(string method in methods)
            //{
            //    foreach(int l in lengths)
            //    {
            //        foreach(DegradomeType deg in types)
            //        {
            //            string stat_file = $"C:\\JICWork\\{method}\\length_{l}\\{deg}\\";
            //            CSCompactness.AttachCompactness(method, stat_file, deg, l, FeatureType.Reactivity);
            //        }
            //    }
            //}
        }

        //spectral_clustering_xrn4_121_results
        [TestMethod]
        public void AttachCompactnessTest_spectral_clustering_xrn4_121_results()
        {
            //string statFile = @"C:\JICWork\spectral_clustering\length_121\xrn4\";
            //DegradomeType type = DegradomeType.xrn4;
            //int length = 121;
            // CSCompactness.AttachCompactness("spectral_clustering", stat_file, type, length, FeatureType.RnaDistance);
        }
    }
}
