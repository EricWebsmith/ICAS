using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Icas.DataPreprocessing;
using System.Diagnostics;

namespace Icas.Test
{
    [TestClass]
    public class GeneTest
    {
        [TestMethod]
        public void TestCount()
        {
            Assert.AreEqual(Gene.GetCount("AT4G32850.1").ToString().Length, 2665);
            
        }
    }
}
