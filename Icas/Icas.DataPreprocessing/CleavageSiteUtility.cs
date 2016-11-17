using Ezfx.Csv.Ex;
using Icas.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Icas.DataPreprocessing
{
    public static partial class CleavageSiteUtility
    {
        public static void GenerateAll()
        {
            GetValidNamesAll();
            Degradome.ToCleavageEfficiency();
            Reactivity.Serialise();
            Gene.Serialise();
            GenerateCleavegeSites();
            GenerateCleavageSiteFiles();
            GenerateAverageReactivity();
            GenerateStructureFiles();
            // step 9
            GenerateRnaStructPlots();
            // step 10
            RnaDistancePreprocess.Process();
        }

        public static void GenerateAverageReactivity()
        {
            foreach (DegradomeType dType in EnumUtil.GetValues<DegradomeType>())
            {
                double[,] matrix = CsvMatrix.Read($"{Config.WorkingFolder}cs_reactivity_{dType}_50.csv");
                double[] average = new double[matrix.GetLength(1)];
                double[] sdvArr = new double[matrix.GetLength(1)];
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    //float sum = 0;
                    List<double> iCol = new List<double>();
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        iCol.Add(matrix[row, col]);
                        //sum += matrix[row, col];
                    }
                    average[col] = iCol.Average();// sum / matrix.GetLength(0);
                    sdvArr[col] = iCol.StandardDeviation();
                }
                //save file
                FileExtension.SaveList($"{Config.WorkingFolder}cs_reactivity_avg_{dType}_50.csv", average);
                FileExtension.SaveList($"{Config.WorkingFolder}cs_reactivity_std_{dType}_50.csv", average);
            }
        }

        /// <summary>
        /// Genes that can be found in the cleavage efficiency files and the reactivity file.
        /// </summary>
        public static string[] GetValidNamesAll()
        {
            if (File.Exists(Config.WorkingFolder + "genes_have_all.txt"))
            {
                return FileExtension.ReadList(Config.WorkingFolder + "genes_have_all.txt");
            }
            string[] csNames = GetValidNames();
            string[] eNames = Degradome.GetValidNames();
            string[] rNames = Reactivity.GetValidNames();
            string[] intersection = csNames.Intersect(eNames).Intersect(rNames).ToArray();
            FileExtension.SaveList(Config.WorkingFolder + "genes_have_all.txt", intersection);
            return intersection;
        }

        public static string[] GetValidNames()
        {
            string[] lines = FileExtension.ReadList(Config.AllCleavegSiteFile);
            HashSet<string> hash = new HashSet<string>();
            foreach (string line in lines)
            {
                string[] arr = line.Split(new char[] { '_', ',' }, StringSplitOptions.RemoveEmptyEntries);
                hash.Add(arr[1]);
            }
            var array = hash.ToArray();
            FileExtension.SaveList($"{Config.WorkingFolder}genes_have_cleavage_sites.txt", array);
            return array;
        }

        public static void Intersection(params string[] files)
        {
            List<List<string>> listlist = new List<List<string>>();
            foreach (string file in files)
            {
                List<string> cleavagelist = new List<string>();
                using (StreamReader sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        cleavagelist.Add(line);
                    }
                }
                listlist.Add(cleavagelist);
            }

            var intersect = ListExtension<string>.Intersect(listlist);
            using (StreamWriter sw = new StreamWriter(@"F:\JIC\Arabidopsis\CleavageSites\intersect.txt"))
            {
                foreach (string key in intersect)
                {
                    sw.WriteLine(key);
                }
                sw.Flush();
                sw.Close();
            }
        }

        public static void ToFasta(string keyFile, string fastaFile)
        {
            List<CleavageSite> sites = new List<CleavageSite>();
            string content = string.Empty;
            using (StreamReader sr = new StreamReader(keyFile))
            {
                content = sr.ReadToEnd();
            }

            var lines = content.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                var arr = line.Split('_');
                if (!arr[2].IsDigit())
                {
                    continue;
                }

                CleavageSite site = new CleavageSite();
                site.MiRNA = arr[0];
                site.Gene = arr[1];
                site.StartAt = int.Parse(arr[2]);
                sites.Add(site);
            }

            using (StreamWriter sr = new StreamWriter(fastaFile))
            {
                foreach (CleavageSite site in sites)
                {
                    string id = ">" + site.MiRNA + ":[" + site.StartAt.ToString() + "," + site.EndAt.ToString() + "]";
                }
            }
        }

        /// <summary>
        /// Generate the cleavage sites and sort it by the extendability
        /// </summary>
        public static void GenerateCleavegeSites()
        {
            string[] lines = FileExtension.ReadList(Config.AllCleavegSiteFile);
            Console.WriteLine($"Total Cleavage Sites:{lines.Length}");

            List<CleavageSite> sites = new List<CleavageSite>();
            foreach (string line in lines)
            {
                var arr = line.Split('_');
                if (!arr[2].IsDigit())
                {
                    continue;
                }

                if (!Config.ValidNames.Contains(arr[1]))
                {
                    continue;
                }

                CleavageSite site = new CleavageSite();
                site.MiRNA = arr[0];
                site.Gene = arr[1];
                site.StartAt = int.Parse(arr[2]);
                int extendLeft = site.StartAt - 1;
                int extendRight = Gene.GetCount(site.Gene) - (site.StartAt - 1 + 21);
                site.Extendability = Math.Min(extendLeft, extendRight);
                sites.Add(site);
            }

            sites.Sort((a, b) => -a.Extendability.CompareTo(b.Extendability));

            //create file
            StringBuilder site_content = new StringBuilder();
            foreach (var site in sites)
            {
                site_content.AppendLine(site.ToString());
            }

            FileExtension.Save(site_content.ToString(), Config.WorkingFolder + "\\cleavage_sites_repeat.csv");

            List<CleavageSite> combinedSites = Combine(sites);
            //create file
            StringBuilder combined_site_content = new StringBuilder();
            foreach (var site in combinedSites)
            {
                combined_site_content.AppendLine(site.ToString());
            }

            FileExtension.Save(combined_site_content.ToString(), Config.WorkingFolder + "\\cleavage_sites.csv");
        }

        private static List<CleavageSite> Combine(List<CleavageSite> sites)
        {
            List<CleavageSite> result = new List<CleavageSite>();
            var groups = from site in sites group site by site.Gene + site.StartAt into newGroup select newGroup;
            foreach (var group in groups)
            {
                CleavageSite cs = new CleavageSite();
                cs.Extendability = group.First().Extendability;
                cs.EndAt = group.First().EndAt;
                cs.Gene = group.First().Gene;
                cs.StartAt = group.First().StartAt;
                cs.MiRNA = string.Join("|", group.ToList().Select(c => c.MiRNA));
                result.Add(cs);
            }
            return result;
        }

        public static void GenerateCleavageSiteFiles()
        {
            List<CleavageSite> sites = new List<CleavageSite>();
            string[] lines = FileExtension.ReadList(Config.WorkingFolder + "cleavage_sites.csv");
            Console.WriteLine($"Total Cleavage Sites:{lines.Length}");
            foreach (string line in lines)
            {
                var arr = line.Split('_');
                CleavageSite site = CleavageSite.Parse(line);
                sites.Add(site);
            }
            Console.WriteLine($"After filtered by cleavage efficiency and reactivity:{sites.Count}");

            //Generate 4 files filtered by 4 degradome datasets.
            foreach (DegradomeType dType in EnumUtil.GetValues<DegradomeType>())
            {
                string site_content = string.Empty;
                string efficiency_content = string.Empty;
                string efficiency_log_content = string.Empty;
                string reactivity_content = string.Empty;
                string reactivity_25_content = string.Empty;
                string reactivity_50_content = string.Empty;
                //string reactivity_75_content = string.Empty;
                //string reactivity_100_content = string.Empty;

                foreach (CleavageSite site in sites)
                {
                    if (site.Extendability < 50)
                    {
                        break;
                    }

                    //if the cleavage efficiency is zero,
                    //we can say that this is not a cleavage site.
                    //filter it out.
                    float efficiency = Efficiency.GetEfficiency(site, dType);
                    if (efficiency == 0)
                    {
                        continue;
                    }

                    site_content += site.ToString() + "\n";
                    efficiency_content += efficiency.ToString() + "\n";
                    efficiency_log_content += Math.Log(efficiency).ToString() + "\n";
                    for (int j = 0; j < 21; j++)
                    {
                        reactivity_content += Reactivity.GetReactivity(site.Gene, site.StartAt - 1 + j) + ",";
                    }

                    for (int j = 0 - 25; j < 21 + 25; j++)
                    {
                        reactivity_25_content += Reactivity.GetReactivity(site.Gene, site.StartAt - 1 + j) + ",";
                    }

                    for (int j = 0 - 50; j < 21 + 50; j++)
                    {
                        reactivity_50_content += Reactivity.GetReactivity(site.Gene, site.StartAt - 1 + j) + ",";
                    }

                    reactivity_content = reactivity_content.TrimEnd(',') + "\n";
                    reactivity_25_content = reactivity_25_content.TrimEnd(',') + "\n";
                    reactivity_50_content = reactivity_50_content.TrimEnd(',') + "\n";
                }
                FileExtension.Save(site_content, Config.WorkingFolder + "\\cleavage_site_" + dType + ".csv");
                FileExtension.Save(efficiency_content, Config.WorkingFolder + "\\cs_efficiencies_" + dType + ".csv");
                FileExtension.Save(efficiency_log_content, Config.WorkingFolder + "\\cs_efficiencies_log_" + dType + ".csv");
                FileExtension.Save(reactivity_content, Config.WorkingFolder + "\\cs_reactivity_" + dType + ".csv");
                FileExtension.Save(reactivity_25_content, Config.WorkingFolder + "\\cs_reactivity_" + dType + "_25.csv");
                FileExtension.Save(reactivity_50_content, Config.WorkingFolder + "\\cs_reactivity_" + dType + "_50.csv");
                //FileExtension.Save(reactivity_75_content, Config.WorkingFoler + "\\cs_reactivity_" + dType + "_75.csv");
                //FileExtension.Save(reactivity_100_content, Config.WorkingFoler + "\\cs_reactivity_" + dType + "_100.csv");
            }
        }

        public static List<CleavageSite> Deserialize()
        {
            return Serializer.Deserialize<List<CleavageSite>>("cleavage_sites.bin");
        }

        [Obsolete]
        public static void GenerateEfficiencies()
        {
            var sites = CleavageSiteUtility.Deserialize();
            foreach (var type in EnumUtil.GetValues<DegradomeType>())
            {
                float[] efficiencies = new float[sites.Count];

                for (int i = 0; i < sites.Count; i++)
                {
                    efficiencies[i] = Efficiency.GetEfficiency(sites[i].Gene, sites[i].StartAt - 1 + 10, sites[i].StartAt - 1 + 20, type);
                }

                //print
                string content = string.Empty;
                for (int i = 0; i < efficiencies.Length; i++)
                {
                    content += efficiencies[i].ToString() + "\n";
                }

                FileExtension.Save(content, Config.WorkingFolder + "cs_efficiencies_" + type.ToString() + ".csv");
            }
        }

        public static List<CleavageSite> ReadCleavageSite(string file)
        {
            string[] lines = FileExtension.ReadList(file);

            List<CleavageSite> sites = new List<CleavageSite>();
            foreach (string line in lines)
            {
                var arr = line.Split(',');
                if (!arr[2].IsDigit())
                {
                    continue;
                }

                CleavageSite site = new CleavageSite();
                site.MiRNA = arr[0];
                site.Gene = arr[1];
                site.StartAt = int.Parse(arr[2]);
                //int extendLeft = site.StartAt - 1;
                //int extendRight = Gene.GetCount(site.Gene) - (site.StartAt - 1 + 21);
                //site.Extendability = Math.Min(extendLeft, extendRight);
                sites.Add(site);
            }

            return sites;
        }
    }
}
