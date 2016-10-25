using Ezfx.Csv.Ex;
using Icas.Clustering;
using Icas.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Icas.Test
{
    [TestClass]
    public class MetricsByDistanceMatrixTest
    {
        [TestMethod]
        public void wt_3()
        {
            string[] files = new string[] {
                @"U:\JICWork\kmedoids\length_71\wt\kmedoids_k_3_round_16_labels.csv",
                @"U:\JICWork\kmedoids\length_71\wt\kmedoids_k_3_round_18_labels.csv",
                @"U:\JICWork\kmedoids\length_71\wt\kmedoids_k_3_round_63_labels.csv",
                @"U:\JICWork\kmedoids\length_71\wt\kmedoids_k_3_round_120_labels.csv",
                @"U:\JICWork\kmedoids\length_71\wt\kmedoids_k_3_round_175_labels.csv"
            };

            string distanceMatrixFile = @"U:\JICWork\rna_distance_matrix_71_wt.txt";
            double[,] distanceMatrix = CsvMatrix.Read(distanceMatrixFile, " ");
            Console.WriteLine("File, Compactness, Mean Squared Error");
            foreach (string file in files)
            {

                int[] labels = FileExtension.Readlabels(file);

                Console.Write(file);
                Console.Write(",");
                Console.Write(Metrics.CompactnessByDistanceMatrix(distanceMatrix, labels).ToString("0.000000"));
                Console.Write(",");
                Console.WriteLine(Metrics.MeanSquaredErrorByDistance(distanceMatrix, labels).ToString("0.000000"));
                Console.Write("\r\n");
            }
        }
    }
}
