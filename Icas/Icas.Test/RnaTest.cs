using Icas.DataPreprocessing;
using Icas.ViennaRnaWrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Icas.Test
{
    [TestClass]
    public class RnaDistanceTest
    {


        [TestMethod]
        public void DistTest1()
        {
            string dbn1 = "(((...((((((........))))))................(((......))).......))).......";
            string dbn2 = ".(((....(((((....)))))....)))..........................................";
            int expected = 36;
            int actual = RnaDistance.Distance(dbn1, dbn2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DistTest2()
        {
            string dbn1 = "(((.((.(((((((((((.((......))..)))))))..))))..)).)))..(((((....)))))...";
            string dbn2 = "(((((((((((.(((.(((((.((((....)).)))))))...))).)))).))))).))...........";
            int expected = 36;
            int actual = RnaDistance.Distance(dbn1, dbn2);
            Assert.AreEqual(expected, actual);
        }

        //wt 71 1 and 4
        [TestMethod]
        public void DistTest3()
        {
            string dbn1 = "(((.((.(((((((((((.((......))..)))))))..))))..)).)))..(((((....)))))...";
            string dbn2 = ".(((((....))))).(((((....)))))..((((..((((...((((((...))))))...))))))))";
            int expected = 64;
            int actual = RnaDistance.Distance(dbn1, dbn2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process()
        {
            RnaDistancePreprocess.Process();
        }
    }
}
