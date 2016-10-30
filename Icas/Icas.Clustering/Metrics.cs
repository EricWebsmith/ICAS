using System;
using System.Collections.Generic;
using System.Linq;

namespace Icas.Clustering
{
    public static partial class Metrics
    {
        #region mean squared error
        public static double MeanSquaredError(double[,] x, int[] labels)
        {
            if (x.GetLength(0) != labels.Length)
            {
                throw new Exception("x and labels have different length!!!");
            }
            int n = labels.Length;
            int[] unique = labels.Distinct().ToArray();
            double result = 0;
            foreach (int label in unique)
            {
                double[,] sub_x = GetSubX(x, labels, label);
                result += SumSquaredErrorSameLabel(sub_x);
            }
            result = result / n;
            return result;
        }

        private static double SumSquaredErrorSameLabel(double[,] sub_x)
        {
            int n_samples = sub_x.GetLength(0);
            int n_features = sub_x.GetLength(1);
            double[] centroid = new double[n_features];
            double sum = 0;
            for (int i = 0; i < n_samples; i++)
            {
                for (int j = 0; j < n_features; j++)
                {
                    centroid[j] += sub_x[i, j] / n_samples;
                }
            }
            //square error
            for (int i = 0; i < n_samples; i++)
            {
                for (int j = 0; j < n_features; j++)
                {
                    sum += Math.Pow(centroid[j] - sub_x[i, j], 2);
                }
            }
            return sum;
        }
        #endregion

        public static double Compactness(double[,] x, int[] labels)
        {
            if (x.GetLength(0) != labels.Length)
            {
                throw new Exception("x and labels have different length!!!");
            }
            int n = labels.Length;
            int[] unique = labels.Distinct().ToArray();
            double result = 0;
            foreach (int label in unique)
            {
                double[,] subX = GetSubX(x, labels, label);
                result += CompactnessSameLabel(subX);
            }
            result = result / n;
            return result;
        }

        private static double[,] GetSubX(double[,] x, int[] labels, int label)
        {
            int all = labels.Length;
            //int n = 0;
            int n = (from l in labels where l == label select l).Count();
            int nFeature = x.GetLength(1);
            double[,] subX = new double[n, nFeature];
            int index = 0;
            for (int i = 0; i < all; i++)
            {
                if (labels[i] == label)
                {
                    for (int j = 0; j < nFeature; j++)
                    {
                        subX[index, j] = x[i, j];
                    }
                    index++;
                }

            }
            return subX;
        }

        private static Sample[] GetSamples(double[,] x, int[] labels, int label)
        {
            List<Sample> results = new List<Sample>();
            int all = labels.Length;
            int n_feature = x.GetLength(1);
            for (int i = 0; i < all; i++)
            {
                if (labels[i] == label)
                {
                    Sample sample = new Sample();
                    sample.Index = i;
                    sample.Features = new double[n_feature];
                    for (int j = 0; j < n_feature; j++)
                    {
                        sample.Features[j] = x[i, j];
                    }
                    results.Add(sample);
                }
            }
            return results.ToArray();
        }


        private static double CompactnessSameLabel(double[,] x)
        {
            int n = x.GetLength(0);
            int choose = n * (n - 1) / 2;
            double result = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    result = n * Distance(x, i, j) / choose;
                }
            }
            return result;
        }

        private static double Distance(double[,] x, int i, int j)
        {
            double result = 0;
            int demension = x.GetLength(1);
            for (int d = 0; d < demension; d++)
            {
                result += Math.Pow(x[i, d] - x[j, d], 2);
            }
            result = Math.Sqrt(result);
            return result;
        }

        public static int[][] Sample(int[] labels, int sampleSize)
        {
            //int[] groups = labels.Distinct().OrderBy(c => c).ToArray();
            int[][] splits = Split(labels);
            int[][] results = new int[splits.Length][];
            for (int i = 0; i < splits.Length; i++)
            {
                List<int> samples = new List<int>();
                if (splits[i].Length < sampleSize)
                {
                    results[i] = splits[i];
                }
                else
                {
                    results[i] = splits[i].OrderBy(c => Guid.NewGuid()).Take(sampleSize).ToArray();
                }
            }
            return results;
        }

        public static int[][] Split(int[] labels)
        {
            int[] groups = labels.Distinct().OrderBy(c => c).ToArray();
            List<int>[] results = new List<int>[groups.Length];
            for (int i = 0; i < groups.Length; i++)
            {
                results[i] = new List<int>();
            }

            for (int i = 0; i < labels.Length; i++)
            {
                results[GetIndex(groups, labels[i])].Add(i);
            }

            return results.Select(c => c.ToArray()).ToArray();
        }

        private static int GetIndex(int[] groups, int value)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i] == value)
                {
                    return i;
                }
            }
            throw new Exception("Index not found");
        }
    }
}
