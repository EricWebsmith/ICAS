using Ezfx.Csv.Ex;
using Icas.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Icas.DataPreprocessing
{
    public class Degradome
    {
        public static string[] GetValidNames()
        {
            HashSet<string> names = new HashSet<string>();
            foreach (DegradomeType dType in EnumUtil.GetValues<DegradomeType>())
            {
                using (StreamReader sr = new StreamReader(Config.GetDegradomeFile(dType)))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] arr = line?.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        string gene = arr?[0];
                        names.Add(gene);
                    }
                }
            }
            FileExtension.SaveList($"{Config.WorkingFolder}genes_have_cleavage_sites.txt", names);

            return names.ToArray();
        }

        public static void ToCleavageEfficiency()
        {
            var abundance = GetReads(Config.CleavageBaseFile);
            Dictionary<string, float> abundance_per_gene = new Dictionary<string, float>();
            foreach (var kv in abundance)
            {
                abundance_per_gene.Add(kv.Key, kv.Value.Sum());
            }
            float abundance_total = abundance_per_gene.Values.Sum();


            foreach (DegradomeType dType in EnumUtil.GetValues<DegradomeType>())
            {
                var reads = GetReads(Config.GetDegradomeFile(dType));
                Dictionary<string, float[]> ce_dict = new Dictionary<string, float[]>();
                foreach (var kv in reads)
                {
                    if (!Config.ValidNames.Contains(kv.Key))
                    {
                        continue;
                    }

                    if (!abundance.ContainsKey(kv.Key))
                    {
                        continue;
                    }
                    float times = 1.0f / abundance_per_gene[kv.Key] / abundance[kv.Key].Length;

                    float[] values = new float[reads[kv.Key].Length];
                    for (int i = 0; i < reads[kv.Key].Length; i++)
                    {
                        values[i] = reads[kv.Key][i] * times;
                    }
                    ce_dict.Add(kv.Key, values);
                }
                Dictionary<string, Dictionary<int, float>> dict_dict = ListExtension.ToDict(ce_dict);
                Efficiency.dict[dType] = dict_dict;
                Serializer.Serialize($"ce_{dType}_dict.bin", dict_dict);
            }
        }

        #region Merge
        public static float CorrelationTest(string file1, string file2, string arrayFile = "")
        {
            var list1 = DegradomeToRpkm(file1);
            var list2 = DegradomeToRpkm(file2);
            var intersectionKeys = list1.Keys.Intersect(list2.Keys).ToArray();
            float[] farray1 = new float[intersectionKeys.Length];
            float[] farray2 = new float[intersectionKeys.Length];
            for (int i = 0; i < intersectionKeys.Length; i++)
            {
                farray1[i] = list1[intersectionKeys[i]];
                farray2[i] = list2[intersectionKeys[i]];
            }

            if (!string.IsNullOrWhiteSpace(arrayFile))
            {
                float[,] matrix = new float[2, intersectionKeys.Length];
                for (int i = 0; i < intersectionKeys.Length; i++)
                {
                    matrix[0, i] = farray1[i];
                    matrix[1, i] = farray2[i];
                }
                CsvMatrix.Save(matrix, arrayFile);
            }


            return (float)Stats.CorrelationTest(farray1, farray2);
        }

        public static void Merge(string file1, string file2, string mergedFile)
        {
            var reads1 = GetReads(file1);
            var reads2 = GetReads(file2);
            Dictionary<string, float[]> mergedReads = new Dictionary<string, float[]>();
            foreach (var gene in reads1.Keys)
            {
                mergedReads[gene] = reads1[gene];
            }

            foreach (var gene in reads2.Keys)
            {
                if (mergedReads.ContainsKey(gene))
                {
                    for (int i = 0; i < mergedReads[gene].Length; i++)
                    {
                        mergedReads[gene][i] += reads2[gene][i];
                    }
                }
                else
                {
                    mergedReads[gene] = reads2[gene];
                }

            }

            StringBuilder sb = new StringBuilder(mergedReads.Count * mergedReads.Values.First().Length);
            foreach (var kv in mergedReads)
            {
                string values = string.Join("\t", kv.Value);
                sb.AppendLine($"{kv.Key}\t{values}");
            }
            FileExtension.Save(sb.ToString(), mergedFile);
        }

        public static Dictionary<string, float[]> GetReads(string file)
        {
            Dictionary<string, float[]> reads = new Dictionary<string, float[]>();
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    string gene = arr[0];
                    float[] gene_reads = (from item in arr where item != gene select float.Parse(item)).ToArray();
                    reads.Add(gene, gene_reads);
                }
            }
            return reads;
        }

        public static Dictionary<string, float> DegradomeToRpkm(string file)
        {
            Dictionary<string, float> reads = new Dictionary<string, float>();
            Dictionary<string, int> lengths = new Dictionary<string, int>();
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    string gene = arr[0];
                    float read = (from item in arr where item != gene select float.Parse(item)).Sum();
                    reads.Add(gene, read);
                    lengths.Add(gene, arr.Length - 1);
                }
            }

            GC.Collect();
            //convert to rpkm
            Dictionary<string, float> rpkmList = new Dictionary<string, float>();
            float total = reads.Values.Sum();
            foreach (string gene in reads.Keys)
            {
                float rpkm = reads[gene] * (1000000000) / lengths[gene] / total;
                rpkmList.Add(gene, rpkm);
            }
            return rpkmList;
        }
        #endregion merge
    }
}
