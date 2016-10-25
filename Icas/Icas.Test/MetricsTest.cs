using Icas.Clustering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Icas.Test
{
    [TestClass]
    public class MetricsTest
    {
        [TestMethod]
        public void CompactnessTest()
        {
            Random r = new Random();
            double[,] x = new double[100, 5];
            int[] labels = new int[100];
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    x[i, j] = r.NextDouble();
                }
                labels[i] = i % 5;
            }
            Console.WriteLine(Metrics.Compactness(x, labels));
        }

        [TestMethod]
        public void CompactnessTest_Zero()
        {
            Random r = new Random();
            double[,] x = new double[100, 5];
            int[] labels = new int[100];
            Assert.AreEqual(Metrics.Compactness(x, labels), 0);
        }

        [TestMethod]
        public void CompactnessTest_0011()
        {
            Random r = new Random();
            double[,] x = new double[2, 2] { { 0, 0 }, { 1, 1 } };
            int[] labels = new int[2];
            Assert.AreEqual(Metrics.Compactness(x, labels), 1);
        }

        [TestMethod]
        public void CompactnessTest_001122()
        {
            Random r = new Random();
            double[,] x = new double[3, 2] { { 0, 0 }, { 1, 1 }, { 2, 2 } };
            int[] labels = new int[3];
            Assert.AreEqual(Math.Round(Metrics.Compactness(x, labels), 2), 0.47);
        }

        [TestMethod]
        public void CompactnessTestSquare()
        {
            Random r = new Random();
            double[,] x = new double[4, 2] { { 0, 0 }, { 1, 1 }, { 0, 1 }, { 1, 0 } };
            int[] labels = new int[4];
            Assert.AreEqual(Math.Round(Metrics.Compactness(x, labels), 2), 0.24);
        }
    }
}
