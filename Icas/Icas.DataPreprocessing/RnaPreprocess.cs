using Icas.Common;
using Icas.ViennaRnaWrapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Icas.DataPreprocessing
{
    public static class RnaPreprocess
    {

        private static string workingDir
        {
            get
            {
                return $"{Config.WorkingFolder}\\cs_rna_struct";
            }

        }

        public static void Process()
        {
            int[] lengths = new int[] { 71, 121 };
            DegradomeType[] degradomes = EnumUtil.GetValues<DegradomeType>();
            foreach (var degradomeType in degradomes)
            {
                foreach (var length in lengths)
                {
                    string structFile = $"{workingDir}\\cs_structure_{length}_{degradomeType}.txt";
                    string matrixFile = $"{workingDir}\\cs_structure_{length}_{degradomeType}_distance_matrix.txt";
                    string triangleFile = $"{workingDir}\\cs_structure_{length}_{degradomeType}_distance_triangle.txt";
                    string[] lines = FileExtension.ReadList(structFile);
                    var results = GetMatrixAndTriangle(lines);
                    FileExtension.SaveMatrix(matrixFile, results.Item1);
                    FileExtension.SaveList(triangleFile, results.Item2);
                }
            }
        }

        private static Tuple<int[,], int[]> GetMatrixAndTriangle(string[] lines)
        {
            int[,] matrix = new int[lines.Length, lines.Length];
            List<int> triangle = new List<int>();

            for (int i = 0; i < lines.Length; i++)
            {
                int[] ds = RnaDistance.Distance(lines[i], lines.Skip(i + 1).ToArray());
                for (int j = i + 1; j < lines.Length; j++)
                {
                    int d = ds[j - i - 1];
                    matrix[i, j] = d;
                    matrix[j, i] = d;
                    triangle.Add(d);
                }
            }
            return new Tuple<int[,], int[]>(matrix, triangle.ToArray());
        }

        private static Tuple<int[,], int[]> GetMatrixAndTriangle2(string[] lines)
        {

            List<string> dbn1s = new List<string>();
            List<string> dbn2s = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = i + 1; j < lines.Length; j++)
                {
                    dbn1s.Add(lines[i]);
                    dbn2s.Add(lines[j]);
                }
            }
            int[] upperTriangle = RnaDistance.Distance(dbn1s.ToArray(), dbn2s.ToArray());

            int[,] matrix = new int[lines.Length, lines.Length];
            int index = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = i + 1; j < lines.Length; j++)
                {
                    matrix[i, j] = upperTriangle[index];
                    matrix[j, i] = upperTriangle[index];
                    index++;
                }
            }

            return new Tuple<int[,], int[]>(matrix, upperTriangle);
        }
    }
}
