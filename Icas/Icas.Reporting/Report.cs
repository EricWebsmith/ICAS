using Icas.Clustering;
using Icas.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Icas.Reporting
{
    public class Report
    {
        private static string GetMedoidImageString(StatisticalResultCsv item)
        {
            try
            {
                string labelFile =
$"{Config.WorkingFolder}\\{item.Method}\\{item.Dataset}\\individuals\\{item.File}";
                DegradomeType dt;
                Enum.TryParse(item.Degredome, out dt);
                FeatureType ft = FeatureTypeExtension.FromString(item.DataType);
                int[] labels = FileExtension.Readlabels(labelFile);

                int[] medoidIndices = null;
                if (item.Method.ToUpper() == "KMEDOIDS")
                {
                    medoidIndices = labels.Distinct().ToArray();
                }
                else if (ft != FeatureType.Reactivity)
                {
                    medoidIndices = CsMetrics.GetMedoidsByDistanceMatrix(labelFile, item.Dataset).Select(c => c.Index).ToArray();
                }
                else
                {
                    medoidIndices = CsMetrics.GetMedoids(labelFile, item.Dataset).Select(c => c.Index).ToArray();
                }

                medoidIndices = ft == FeatureType.Reactivity ? CsMetrics.GetMedoids(labelFile, item.Dataset).Select(c => c.Index).ToArray() : FileExtension.Readlabels(labelFile).Distinct().ToArray();
                string medoidImageString = "#### Structure\r\n\r\nFor clustering algorithms using reactivity, the structure is for reference only .\r\n\r\n";
                int index = 0;
                foreach (var medoidIndex in medoidIndices)
                {
                    medoidImageString += $"##### Centre of Cluster {index} (Data Point {medoidIndex})\r\n\r\n";
                    medoidImageString +=
                        $"![Cleavage site structure]({Config.CsStrucFolder.Replace("\\", "\\\\")}\\\\{dt}\\\\{item.Length}\\\\{medoidIndex}.png)\r\n\r\n";
                    if (ft == FeatureType.RnaDistance)
                    {
                        string guid = Guid.NewGuid().ToString().Replace("-", "_");
                        string file = $"{Config.WorkingFolder}\\reports\\figure\\{guid}.png";
                        medoidImageString += $"Other structures of the this group:\r\n\r\n";
                        medoidImageString += $"![Cleavage site structure]({file.Replace("\\", "\\\\")})\r\n\r\n";
                        GenerateGroupThumbnails(file, item, labels, medoidIndex);
                    }
                    index++;
                }
                return medoidImageString;
            }
            catch (Exception)
            {
                //throw;
                return string.Empty;
            }
        }

        private static void GenerateGroupThumbnails(string file, StatisticalResultCsv item, int[] labels, int medoidIndex)
        {
            int group = labels[medoidIndex];
            List<string> imageFiles = new List<string>();
            for (int i = 0; i < labels.Length; i++)
            {
                if (labels[i] == group)
                {
                    string imageFile = $"{Config.WorkingFolder}\\cs_rna_struct\\plot\\{item.Degredome}_{item.Length}_{i + 1}.png";
                    imageFiles.Add(imageFile);
                }
                if (imageFiles.Count >= 20)
                {
                    break;
                }
            }
            ThumbnailGenerator.Generate(imageFiles, file);
        }

        public static void Run(StatisticalResultCsv item)
        {
            string labelFile =
                $"{Config.WorkingFolder}\\{item.Method}\\{item.Dataset}\\individuals\\{item.File}";



            //![My Figure](C:\\Users\\nzt15bau\\AppData\\Local\\Temp\\tmp1D9C.tmp_ss.svg)

            string rmdFile = $"{Config.WorkingFolder}\\reports\\{item.File.Replace(".csv", ".Rmd")}";
            using (StreamReader templateStreamReader = new StreamReader($"{Config.WorkingFolder}\\job_report.Rmd"))
            using (StreamWriter rmdStreamWriter = new StreamWriter(rmdFile))
            {
                while (!templateStreamReader.EndOfStream)
                {
                    string line = templateStreamReader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        line = string.Empty;
                    }

                    //group = read.csv("C:\\Icas.Test\\kmedoids\\length_71\\wt\\individuals\\kmedoids_k_3_round_12_labels.csv", header = FALSE)$V1
                    //y = read.csv("C:\\Icas.Test\\cs_efficiency\\cs_efficiency_log_wt.csv", header = FALSE)$V1
                    if (line.StartsWith(@"group = read.csv"))
                    {
                        line = $"group = read.csv(\"{Config.WorkingFolder.Replace("\\", "\\\\")}\\\\{item.Method}\\\\{item.Dataset}\\\\individuals\\\\{item.File}\", header = FALSE)$V1";
                    }
                    else if (line.StartsWith(@"y = read.csv"))
                    {
                        line =
                            $"y =read.csv(\"{Config.WorkingFolder.Replace("\\", "\\\\")}\\\\cs_efficiency\\\\cs_efficiency_log_{item.Degredome}.csv\", header = FALSE)$V1";
                    }
                    else if (line == @"#### Structure")
                    {
                        line = item.Length == 21 ? "" : GetMedoidImageString(item);
                    }
                    else if (line == "date: \"3 October 2016\"")
                    {
                        line = DateTime.Today.ToString("date: \"dd MMM yyyy\"");
                    }
                    else if (line == "csv_data = read.csv(\"cs_datasets/cs_reactivity_wt_21.csv\", sep=\",\", header = FALSE)")
                    {
                        line = $"csv_data = read.csv(\"{Config.WorkingFolder.Replace("\\", "\\\\")}/cs_datasets/cs_reactivity_{item.Degredome}_{item.Length}.csv\", sep=\",\", header = FALSE)";
                    }

                    rmdStreamWriter.WriteLine(line);
                }
                templateStreamReader.Close();
                rmdStreamWriter.Flush();
                rmdStreamWriter.Close();
            }
            Rmd.ToHtml(rmdFile);
        }
    }
}
