using Icas.ViennaRnaWrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Icas.Test
{
    [TestClass]
    public class RNAPlotWrapperTest
    {

        [TestMethod]
        public void PlotTest()
        {
            string temp = RnaPlotWrapper.Plot(".....(((...(((...(((...)))...))).......)))...",
                                             "ACTGACTGACTGACTGACTGACTGACTGACTGACTGACTGACTGA");
            Process.Start(temp);
        }
    }
}
