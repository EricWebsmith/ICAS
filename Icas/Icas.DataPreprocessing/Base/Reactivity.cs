using Icas.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Icas.DataPreprocessing
{
    public class Reactivity
    {
        static float[][] matrix = null;

        public static string[] GetValidNames()
        {
            HashSet<string> validNames = new HashSet<string>();
            using (StreamReader sr = new StreamReader(Config.ReactivityFile))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Trim();
                    string[] arr = line.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    validNames.Add(arr[0]);
                }
            }
            FileExtension.SaveList(Config.WorkingFolder + "genes_have_reactivity.txt", validNames);
            return validNames.ToArray();
        }

        private static void Load()
        {
            if (matrix == null)
            {
                matrix = Serializer.Deserialize<float[][]>(@"reactivity_matrix.bin");
            }
        }

        public static bool HasReactivity(string gene)
        {
            Load();
            int index = Config.ValidNames.IndexOf(gene);
            return index != -1;
        }

        public static float GetReactivity(string gene, int position)
        {
            Load();
            int index = Config.ValidNames.IndexOf(gene);
            return matrix[index][position];
        }

        public static void Serialise()
        {
            matrix = new float[Config.ValidNames.Count][];
            var names = Config.ValidNames.ToList();
            using (StreamReader sr = new StreamReader(Config.ReactivityFile))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Trim();
                   List< string> arr = line.Replace("NA", "0.0").Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    string gene = arr[0];

                    if (!Config.ValidNames.Contains(gene))
                    {
                        continue;
                    }
                    arr.RemoveAt(0);//remove the gene name.
                    arr.RemoveAt(0);//remove the first number, which is useless.
                    var list = from i in arr select float.Parse(i);

                    matrix[names.IndexOf(gene)] = list.ToArray();
                }
            }

            Serializer.Serialize($"reactivity_matrix.bin", matrix);
        }
    }
}
