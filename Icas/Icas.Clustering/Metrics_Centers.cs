using System;
using System.Collections.Generic;
using System.Linq;

namespace Icas.Clustering
{
    public static partial class Metrics
    {
        public static double[,] GetSubDistanceMatrix(double[,] distanceMatrix, int[] points)
        {
            double[,] subMatrix = new double[points.Length, points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    double distance = distanceMatrix[points[i], points[j]];
                    subMatrix[i, j] = distance;
                    subMatrix[j, i] = distance;
                }
            }
            return subMatrix;
        }

        public static Sample[] GetMedoidsByDistanceMatrix(double[,] x, int[] labels)
        {
            throw new NotImplementedException();
        }

        public static Sample[] GetMedoids(double[,] x, int[] labels)
        {
            if (x.GetLength(0) != labels.Length)
            {
                throw new Exception("x and labels have different length!!!");
            }
            int[] unique = labels.Distinct().ToArray();

            List<Sample> medoids = new List<Sample>();

            foreach (int label in unique)
            {
                Sample[] samples = GetSamples(x, labels, label);
                Sample medoid = GetMedoid(samples);
                medoids.Add(medoid);
            }

            return medoids.ToArray();
        }


        private static Sample GetMedoid(Sample[] samples)
        {
            double minDistance = int.MaxValue;
            int minAt = 0;
            for (int i = 0; i < samples.Length; i++)
            {
                double distanceSum = 0;
                for (int j = 0; j < samples.Length; j++)
                {
                    distanceSum += samples[i].Distance(samples[j]);
                }
                if (distanceSum < minDistance)
                {
                    minDistance = distanceSum;
                    minAt = i;
                }
            }
            return samples[minAt];
        }
    }
}
