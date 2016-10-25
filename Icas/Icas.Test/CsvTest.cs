using Ezfx.Csv;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Icas.Test
{
    [TestClass]
    public class CsvTest
    {
        [TestMethod]
        public void ReadLine()
        {
           var config = new CsvConfig();
            var a =  CsvContext.ReadLine<Clustering.StatisticalResultCsv>("aa,0.0025", 
                new string[] { "file","oneway","group_count","significant_pairs","pair_count","significant_rate","Compactness","best" }, config);
        }


        [TestMethod]
        public void ReadFile()
        {
            var config = new CsvConfig();
            var a = CsvContext.ReadFile<Clustering.StatisticalResultCsv>(@"C:\JICWork\kmeans_xrn4_121_results.csv");
            //from aa in a where aa.Compactness
        }
    }
}
