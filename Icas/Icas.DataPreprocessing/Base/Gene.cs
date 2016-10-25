using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using Icas.Common;

namespace Icas.DataPreprocessing
{
    public class Gene
    {
        private static StringDictionary dict = null;
        private static Dictionary<string, int> count_dict = null;

        //static string file = $"{Config.WorkingFoler}cdna.txt";
        static string bin_file = $"{Config.WorkingFolder}dna.bin";
        static string count_bin_file = $"{Config.WorkingFolder}dna_count.bin";

        private static void Load()
        {
            if (dict == null)
            {
                using (FileStream fs = new FileStream(bin_file, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    object o = bf.Deserialize(fs);
                    dict = (StringDictionary)o;
                    fs.Close();
                }
            }
        }

        private static void LoadCount()
        {
            if (count_dict == null)
            {
                using (FileStream fs = new FileStream(count_bin_file, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    object o = bf.Deserialize(fs);
                    count_dict = (Dictionary<string, int>)o;
                    fs.Close();
                }
            }
        }

        public static int GetCount(string name)
        {
            LoadCount();
            return count_dict[name];
        }

        public static string GetSequence(string name)
        {
            Load();
            return dict[name];
        }

        public static bool HasGene(string name)
        {
            LoadCount();
            return count_dict.ContainsKey(name);
        }
        
        public static void Serialise()
        {
            StringDictionary dict = new StringDictionary();
            Dictionary<string, int> count_dict = new Dictionary<string, int>();
            using (StreamReader sr = new StreamReader(Config.CdnaFile))
            {
                string line = sr.ReadLine().Trim();
                string name = GetNameFromLine(line);
                string seq = string.Empty;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine().Trim();
                    if (line.StartsWith(">"))
                    {
                        if(Config.ValidNames.Contains(name))
                        {
                            dict.Add(name, seq);
                            count_dict.Add(name, seq.Length);
                        }
                        //after adding
                        name = GetNameFromLine(line);
                        seq = string.Empty;
                    }
                    else
                    {
                        seq += line;
                    }
                }
            }

            using (FileStream fs = new FileStream(bin_file, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, dict);
                fs.Close();
            }

            using (FileStream fs = new FileStream(count_bin_file, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, count_dict);
                fs.Close();
            }
        }

        private static string GetNameFromLine(string line)
        {
            return line.Substring(1).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).First().Trim();
        }
    }
}
