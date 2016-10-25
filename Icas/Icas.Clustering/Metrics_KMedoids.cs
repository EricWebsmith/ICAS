using System;
using System.Collections.Generic;
using System.Linq;

namespace Icas.Clustering
{
    public static partial class Metrics
    {
        #region mean squared error
        public static double MeanSquaredErrorByDistance(double[,] distanceMatrix, int[] labels)
        {
            if (distanceMatrix.GetLength(0) != distanceMatrix.GetLength(1))
            {
                throw new Exception("the distance matrix should be squared.");
            }

            if (distanceMatrix.GetLength(0) != labels.Length)
            {
                throw new Exception("x and labels have different length!!!");
            }
            int n = labels.Length;

            double result = 0;


            for (int i = 0; i < n; i++)
            {
                result += Math.Pow(distanceMatrix[i, labels[i]], 2);
            }
            result = result / n;
            return result;
        }
        #endregion

        #region compactness
        public static double CompactnessByDistanceMatrix(double[,] distanceMatrix, int[] labels)
        {
            if (distanceMatrix.GetLength(0) != distanceMatrix.GetLength(1))
            {
                throw new Exception("the distance matrix should be squared.");
            }

            if (distanceMatrix.GetLength(0) != labels.Length)
            {
                throw new Exception("x and labels have different length!!!");
            }
            int n = labels.Length;
            int[] unique = labels.Distinct().ToArray();
            double result = 0;
            foreach (int label in unique)
            {
                result += CompactnessSameLabel(distanceMatrix, labels, label);
            }
            result = result / n;
            return result;
        }

        private static int[] GetIndices(int[] labels, int label)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < labels.Length; i++)
            {
                if (labels[i] == label)
                {
                    indices.Add(i);
                }
            }
            return indices.ToArray();
        }

        private static double CompactnessSameLabel(double[,] distanceMatrix, int[] labels, int label)
        {
            int[] indices = GetIndices(labels, label);
            int n = indices.Length;
            int combination = n * (n - 1) / 2;
            double sum = 0;
            for (int i = 0; i < indices.Length; i++)
            {
                for (int j = i + 1; j < indices.Length; j++)
                {
                    sum += distanceMatrix[i, j];
                }
            }
            return sum * n / combination;
        }
        #endregion
    }
}
