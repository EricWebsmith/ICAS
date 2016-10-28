using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Icas.Common
{
    public static class FileExtension
    {
        public static void Save(string content, string file)
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.Write(content);
                sw.Flush();
                sw.Close();
            }
        }

        public static string LoadText(string file)
        {
            string content = string.Empty;
            using (StreamReader sr = new StreamReader(file))
            {
                content = sr.ReadToEnd();
                sr.Close();
            }
            return content;
        }

        public static string[] ReadList(string file)
        {
            string content = LoadText(file);
            return content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static void SaveList(string file, IEnumerable<string> list)
        {
            StringBuilder sb = new StringBuilder(list.Count() * list.First().Length);
            foreach (string line in list)
            {
                sb.AppendLine(line);
            }
            Save(sb.ToString(), file);
        }

        public static void SaveMatrix(string file, int[,] matrix, string separator = ",")
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    sb.Append($"{matrix[i, j]},");
                }
                sb.Append($"{matrix[i, matrix.GetLength(1) - 1]}\r\n");
            }
            Save(sb.ToString(), file);
        }

        public static void SaveList<T>(string file, IEnumerable<T> list)
        {
            StringBuilder sb = new StringBuilder(list.Count() * list.First().ToString().Length);
            foreach (T line in list)
            {
                sb.AppendLine(line.ToString());
            }
            Save(sb.ToString(), file);
        }

        public static float[] ReadArray(string file)
        {
            string content = LoadText(file);
            float[] farray = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(c => float.Parse(c)).ToArray();
            return farray;
        }

        public static int[] Readlabels(string file)
        {
            string content = LoadText(file);
            if (content.StartsWith("\"\",\"V1\""))
            {
                List<int> result = new List<int>();
                string[] lines = content.Replace("\"\",\"V1\"", string.Empty).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string[] arr = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    result.Add(int.Parse(arr[1]));
                }
                return result.ToArray();
            }
            else
            {
                int[] int_array = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToArray();
                return int_array;
            }

        }
    }
}
