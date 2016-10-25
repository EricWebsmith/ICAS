using Icas.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EfficiencyDict = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<int, float>>;

namespace Icas.DataPreprocessing
{
    /// <summary>
    /// Cleavage Efficiency
    /// </summary>
    public static class Efficiency
    {

        public static Dictionary<DegradomeType, EfficiencyDict> dict = new Dictionary<DegradomeType, EfficiencyDict>();

        private static Dictionary<string, Dictionary<int, float>> LoadDict(DegradomeType type)
        {
            if (dict.ContainsKey(type))
            {
                return dict[type];
            }

            var subdict = Serializer.Deserialize<Dictionary<string, Dictionary<int, float>>>($"ce_{type}_dict.bin");
            dict[type] = subdict;
            return subdict;
        }

        private static void LoadAll()
        {
            foreach (DegradomeType dType in EnumUtil.GetValues<DegradomeType>())
            {
                dict[dType] = Serializer.Deserialize<Dictionary<string, Dictionary<int, float>>>($"ce_{dType}_dict.bin"); ;
            }
        }

        public static float GetEfficiency(string gene, int position, DegradomeType dType)
        {
            var dict = LoadDict(dType);
            if (!dict[gene].ContainsKey(position))
            {
                return 0;
            }
            return dict[gene][position];
        }

        public static float GetEfficiency(CleavageSite site, DegradomeType dType)
        {
            return GetEfficiency(site.Gene, site.StartAt - 1 + 10, site.StartAt - 1 + 11, dType);
        }

        public static bool HasEfficiency_21(CleavageSite site, DegradomeType dType)
        {
            var dict = LoadDict(dType);
            for (int i = 0; i <= 21; i++)
            {
                if (dict[site.Gene].ContainsKey(site.StartAt - 1 + i))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool HasEfficiency_Gene(CleavageSite site, DegradomeType dType)
        {
            var dict = LoadDict(dType);
            return dict[site.Gene].Count > 0;
        }

        public static float GetEfficiency(string gene, int start, int endAt, DegradomeType dType)
        {
            var dict = LoadDict(dType);
            float sum = 0;
            for (int i = start; i <= endAt; i++)
            {
                if (dict[gene].ContainsKey(i))
                {
                    sum += dict[gene][i];
                }
            }
            return sum;
        }

        public static void Serialize()
        {
            foreach (string deg in new string[] { "wt", "xrn4" })
            {

                EfficiencyDict dict = new EfficiencyDict();
                using (StreamReader sr = new StreamReader($"{ Config.WorkingFolder }ce_{deg}_dict.txt"))
                {
                    string content = sr.ReadToEnd();
                    string[] subdicts = content.Split(new string[] { "Gene:" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string subdictString in subdicts)
                    {
                        string[] lines = subdictString.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        Dictionary<int, float> subdict = new Dictionary<int, float>();
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] pe = lines[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                            int position = int.Parse(pe[0]);
                            float efficiency = float.Parse(pe[1]);
                            subdict.Add(position, efficiency);
                        }
                        dict.Add(lines[0], subdict);
                    }
                }
                Serializer.Serialize("ce_" + deg + "_dict.bin", dict);
            }
        }

        public static float[,] Correlate(EfficiencyDict dict1, EfficiencyDict dict2)
        {
            //get points
            var list1 = new List<float>();
            var list2 = new List<float>();
            foreach (var gene in dict1.Keys)
            {
                Console.WriteLine(gene);
                //if they do not have the same gene, 
                //there is no correlation
                if (!dict2.ContainsKey(gene))
                {
                    continue;
                }

                List<int> union = dict1[gene].Keys.Union(dict2[gene].Keys).ToList();
                foreach (var u_key in union)
                {
                    //dict 1
                    if (dict1[gene].ContainsKey(u_key))
                    {
                        list1.Add(dict1[gene][u_key]);
                    }
                    else
                    {
                        list1.Add(0);
                    }

                    //dict 2
                    if (dict2[gene].ContainsKey(u_key))
                    {
                        list2.Add(dict2[gene][u_key]);
                    }
                    else
                    {
                        list2.Add(0);
                    }
                }
            }


            //save points
            float[,] result = new float[2, list1.Count];
            for (int i = 0; i < list1.Count; i++)
            {
                result[0, i] = list1[i];
                result[1, i] = list2[i];
            }
            return result;
        }

        public static string[] GetGeneNames()
        {
            var dict1 = Serializer.Deserialize<Dictionary<string, Dictionary<int, float>>>(@"ce_wt_dict.bin");
            var dict3 = Serializer.Deserialize<Dictionary<string, Dictionary<int, float>>>(@"ce_xrn4_dict.bin");


            var names1 = dict1.Keys.ToArray();
            var names3 = dict3.Keys.ToArray();

            List<string> intersection = names1.Intersect(names3).ToList();

            string content = string.Join("\n", intersection.ToArray());

            FileExtension.Save(content, Config.WorkingFolder + "genes_have_efficiencies.txt");
            return intersection.ToArray();
        }
    }
}
