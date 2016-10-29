using System.Collections.Generic;

namespace Icas.Common
{
    public static class MathEx
    {
        public static double[] DistanceMatrixToTriangle(double[,] matrix)
        {
            List<double> trangle = new List<double>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    trangle.Add(matrix[i, j]);
                }
            }
            return trangle.ToArray();
        }
    }
}
