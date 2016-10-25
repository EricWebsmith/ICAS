using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Ezfx.Csv.Ex
{
    public static class CsvMatrix
    {
        public static void Save(float[,] matrix, string file)
        {
            StringBuilder sb = new StringBuilder(matrix.GetLength(1) * matrix.GetLength(0) * 8);
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - 1; j++)
                {
                    sb.Append(matrix[j, i].ToString() + ",");
                }
                sb.Append(matrix[matrix.GetLength(0) - 1, i].ToString() + "\r\n");
            }
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
            }
        }

        public static double[,] Read(string file, string separator = ",")
        {
            string[] lines = null;
            using (StreamReader sr = new StreamReader(file))
            {
                string content = sr.ReadToEnd();
                lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                sr.Close();
            }

            int collumns = lines[0].Split(separator.ToCharArray()).Length;
            int rows = lines.Length;
            double[,] matrix = new double[rows, collumns];
            for (int row = 0; row < rows; row++)
            {
                float[] farray = lines[row].Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => float.Parse(c)).ToArray();
                for (int collumn = 0; collumn < collumns; collumn++)
                {
                    matrix[row, collumn] = farray[collumn];
                }
            }
            return matrix;
        }
    }
}
