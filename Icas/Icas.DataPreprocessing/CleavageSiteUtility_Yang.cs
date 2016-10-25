using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Icas.Common;

namespace Icas.DataPreprocessing
{
    public static partial class CleavageSiteUtility
    {
        const int AVG = 0;
        const int SD = 1;

        /// <summary>
        /// Generate the cleavage sites and sort it by the extendability
        /// </summary>
        public static void GenerateCleavegeSites_Yang()
        {
            string[] lines = FileExtension.ReadList(Config.WorkingFolder + "targetfinder_result.txt");
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


        public static void GenerateCleavageSiteFiles_Yang()
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
            Console.WriteLine($"After filtered by clevage efficiency and reactivity:{sites.Count}");

            //Generate 4 files filtered by 4 degradome datasets.
            foreach (DegradomeType dType in EnumUtil.GetValues<DegradomeType>())
            {
                StringBuilder site_content_1 = new StringBuilder();
                StringBuilder site_content_3 = new StringBuilder();
                StringBuilder site_content_4 = new StringBuilder();

                foreach (CleavageSite site in sites)
                {
                    //if (site.Extendability < 50)
                    //{
                    //    break;
                    //}

                    float efficiency = Efficiency.GetEfficiency(site, dType);
                    if (efficiency > 0)
                    {
                        site_content_1.AppendLine(site.ToStringWithMiRNANames());
                    }
                    else if (Efficiency.HasEfficiency_21(site, dType))
                    {
                        site_content_3.AppendLine(site.ToStringWithMiRNANames());
                    }
                    else if (Efficiency.HasEfficiency_Gene(site, dType))
                    {
                        site_content_4.AppendLine(site.ToStringWithMiRNANames());
                    }
                }

                FileExtension.Save(site_content_1.ToString(), Config.WorkingFolder + "\\cleavage_sites_" + dType + "_1.csv");
                FileExtension.Save(site_content_3.ToString(), Config.WorkingFolder + "\\cleavage_sites_" + dType + "_3.csv");
                FileExtension.Save(site_content_4.ToString(), Config.WorkingFolder + "\\cleavage_sites_" + dType + "_4.csv");
            }
        }

        public static void GenerateCleavageSiteFiles_5_Yang()
        {
            foreach (DegradomeType dType in EnumUtil.GetValues<DegradomeType>())
            {
                var all = ReadCleavageSite(Config.WorkingFolder + "targetfinder_result.txt");
                var list1 = ReadCleavageSite(Config.WorkingFolder + "\\cleavage_sites_" + dType + "_1.csv");
                var list3 = ReadCleavageSite(Config.WorkingFolder + "\\cleavage_sites_" + dType + "_3.csv");
                var list4 = ReadCleavageSite(Config.WorkingFolder + "\\cleavage_sites_" + dType + "_4.csv");
                var rest = list1.Union(list3).Union(list4);
                var list5 = from cs in all where !rest.Contains(cs, new CleavageSiteEqualityComparer()) select cs;
                StringBuilder content = new StringBuilder();
                foreach (var cs in list5)
                {
                    content.AppendLine(cs.ToStringWithMiRNANames());
                }
                FileExtension.Save(content.ToString(), Config.WorkingFolder + "\\cleavage_sites_" + dType + "_5.csv");
            }
        }

        public static void Yang_GenerateReactivity()
        {
            foreach (DegradomeType dType in EnumUtil.GetValues<DegradomeType>())
            {
                for(int datasetIndex=3; datasetIndex <= 5; datasetIndex++)
                {
                    float[][] avg_sdv3 = GetAverageAndStandardDeviation(datasetIndex, dType);
                    string avg_content = string.Empty;
                    string sd_content = string.Empty;
                    for(int i=0;i<21;i++)
                    {
                        avg_content += $"{avg_sdv3[AVG][i]}\n";
                        sd_content += $"{avg_sdv3[SD][i]}\n";
                    }
                    FileExtension.Save(avg_content, $"{Config.WorkingFolder}\\cs_reactivity_{dType}_{datasetIndex}_avg.csv");
                    FileExtension.Save(sd_content, $"{Config.WorkingFolder}\\cs_reactivity_{dType}_{datasetIndex}_sd.csv");
                }
            }
        }

        private static float[][] GetAverageAndStandardDeviation(int datasetIndex, DegradomeType dType)
        {
            var list = ReadCleavageSite($"{Config.WorkingFolder}\\cleavage_sites_{dType}_{datasetIndex}.csv");
            float[][] matrix = new float[21][];
            float[][] stats = new float[2][];
            //average

            stats[AVG] = new float[21];
            //StandardDeviation
            
            stats[SD] = new float[21];

            for (int col = 0; col < 21; col++)
            {
                matrix[col] = new float[list.Count];
                for (int row = 0; row < list.Count; row++)
                {
                    try
                    {
                        var site = list[row];
                        matrix[col][row] = Reactivity.GetReactivity(site.Gene, site.StartAt - 1 + col);
                    }
                    catch
                    {

                    }
                }
            }

            for (int col = 0; col < 21; col++)
            {
                stats[AVG][col] = matrix[col].Average();
                stats[SD][col] = (float)matrix[col].StandardDeviation();
            }

            return stats;
        }
    }
}
