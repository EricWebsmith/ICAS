using System;

namespace Icas.Clustering
{
    public class Sample
    {
        public int Index { get; set; }
        public double[] Features { get; set; }

        public double SquaredDistance(Sample otherSample)
        {
            if (Features.Length != otherSample.Features.Length)
            {
                throw new Exception("The feature numbers are different!");
            }

            double sd = 0;
            for (int i = 0; i < Features.Length; i++)
            {
                sd += Math.Pow(Features[i] - otherSample.Features[i], 2);
            }
            return sd;
        }

        public double Distance(Sample otherSample)
        {
            if (Features.Length != otherSample.Features.Length)
            {
                throw new Exception("The feature numbers are different!");
            }

            double sd = 0;
            for (int i = 0; i < Features.Length; i++)
            {
                sd += Math.Pow(Features[i] - otherSample.Features[i], 2);
            }
            return Math.Sqrt(sd);
        }
    }
}
