using Icas.DataPreprocessing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Icas.Common.Tests
{
    [TestClass()]
    public class CSPlotTests
    {
        [TestMethod()]
        public void GenerateTest()
        {
            CleavageSiteUtility.GenerateRnaStructPlots();
        }
    }
}