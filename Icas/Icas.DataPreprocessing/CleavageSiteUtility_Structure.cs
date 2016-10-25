using Icas.Common;
using Icas.ViennaRnaWrapper;
using Svg;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Icas.DataPreprocessing
{
    public static partial class CleavageSiteUtility
    {
        public static void GenerateRnaStructPlots()
        {
            foreach (var deg in EnumUtil.GetValues<DegradomeType>())
            {
                foreach (var length in new int[] { 71, 121 })
                {
                    string structFile = $"{Config.WorkingFolder}\\cs_rna_struct\\cs_structure_{length}_{deg}.txt";
                    int index = 0;
                    using (StreamReader sr = new StreamReader(structFile))
                    {
                        while (!sr.EndOfStream)
                        {
                            string rnaStruct = sr.ReadLine();
                            string seq = GetSequence(deg, length, index);
                            //with nt
                            {
                                string outputFile = RnaPlotWrapper.Plot(rnaStruct, seq);
                                string svgFile = $"{Config.WorkingFolder}\\cs_rna_struct\\{deg}\\{length}\\{index}.svg";
                                File.Copy(outputFile, svgFile, true);
                                SvgDocument doc = SvgDocument.Open(outputFile);
                                string pngFile = $"{Config.WorkingFolder}\\cs_rna_struct\\{deg}\\{length}\\{index}.png";
                                File.Delete(pngFile);
                                doc.Draw().Save(pngFile);
                            }

                            //with out nt
                            {
                                string outputFile = RnaPlotWrapper.Plot(rnaStruct);
                                string svgFile = $"{Config.WorkingFolder}\\cs_rna_struct\\{deg}\\{length}\\{index}_no_nt.svg";
                                File.Copy(outputFile, svgFile, true);
                                SvgDocument doc = SvgDocument.Open(outputFile);
                                string pngFile = $"{Config.WorkingFolder}\\cs_rna_struct\\{deg}\\{length}\\{index}_no_nt.png";
                                File.Delete(pngFile);
                                doc.Draw().Save(pngFile);
                            }


                            index++;
                        }
                    }
                }
            }
        }

        private static string GetSequence(DegradomeType deg, int length, int index)
        {
            string seqFile = $"{Config.WorkingFolder}\\cs_rna_struct\\{deg}\\{length}\\{index}.seq";
            return FileExtension.ReadList(seqFile).Last();
        }

        public static void GenerateRnaStructPlots_Old()
        {
            foreach (var deg in EnumUtil.GetValues<DegradomeType>())
            {
                foreach (var length in new int[] { 71, 121 })
                {
                    string structFile = $"{Config.WorkingFolder}\\cs_rna_struct\\cs_structure_{length}_{deg}.txt";
                    int index = 0;
                    using (StreamReader sr = new StreamReader(structFile))
                    {
                        while (!sr.EndOfStream)
                        {
                            string rnaStruct = sr.ReadLine();
                            string outputFile = RnaPlotWrapper.Plot(rnaStruct);
                            index++;
                            string svgFile = $"{Config.WorkingFolder}\\cs_rna_struct\\plot\\{deg}_{length}_{index}.svg";

                            File.Copy(outputFile, svgFile, true);
                            SvgDocument doc = SvgDocument.Open(outputFile);
                            string pngFile = $"{Config.WorkingFolder}\\cs_rna_struct\\plot\\{deg}_{length}_{index}.png";
                            File.Delete(pngFile);
                            doc.Draw().Save(pngFile);
                        }
                    }
                }
            }
        }

        public static void GenerateStructureFiles()
        {
            if (!Directory.Exists(Config.CsStrucFolder))
            {
                Directory.CreateDirectory(Config.CsStrucFolder);
            }

            foreach (DegradomeType dType in EnumUtil.GetValues<DegradomeType>())
            {
                string degDir = Config.CsStrucFolder + dType.ToString();
                if (!Directory.Exists(degDir))
                {
                    Directory.CreateDirectory(degDir);
                }

                string[] cleavageSiteSList = FileExtension.ReadList($"{Config.WorkingFolder}\\cleavage_site_{dType}.csv");
                foreach (int extend in new int[] { 25, 50 })
                {
                    int length = extend * 2 + 21;
                    //$"{dir}\\{length}
                    string lengthDir = $"{degDir}\\{length}";
                    if (!Directory.Exists(lengthDir))
                    {
                        Directory.CreateDirectory(lengthDir);
                    }
                    List<string> dotBrackets = new List<string>();
                    for (int i = 0; i < cleavageSiteSList.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(cleavageSiteSList[i]))
                        {
                            continue;
                        }

                        CleavageSite site = CleavageSite.Parse(cleavageSiteSList[i]);


                        //Generate .seq file
                        int startAt = site.StartAt - 1 - extend;

                        //Check if the extended cleavage site is available
                        //(the start and ending points are legal)
                        if (startAt < 0)
                        {
                            Console.WriteLine(startAt);
                            continue;
                        }

                        int endAt = site.StartAt - 1 + extend + 21;
                        string fullSequence = Gene.GetSequence(site.Gene);
                        //check if the ending point is reasonable
                        if (endAt > fullSequence.Length)
                        {
                            Console.WriteLine(endAt);
                            continue;
                        }

                        string cleavageSiteSequence = fullSequence.Substring(startAt, endAt - startAt);
                        string seqFileContent = $">{site.Gene}[{startAt},{endAt}]\r\n{cleavageSiteSequence.Replace("U", "T")}";
                        FileExtension.Save(seqFileContent, $"{degDir}\\{length}\\{i}.seq");

                        //generate the .shape file
                        GenerateShapeFile(site, startAt, endAt, $"{degDir}\\{length}\\{i}.shape");
                        //generate .db file
                        //Use ViennaRNA/RNAFold to do that.
                        //RNAFold--shape = ap2.shape < ap2.seq
                        string dotBracket = RnaFoldWrapper.Fold($"{degDir}\\{length}\\{i}.shape", $"{degDir}\\{length}\\{i}.seq");
                        dotBrackets.Add(dotBracket);
                        //availableCleavageSites.Add(cleavage_site_sList[i]);

                    }
                    FileExtension.SaveList($"{Config.CsStrucFolder}\\cs_structure_{length}_{dType}.txt", dotBrackets);

                }
            }
            GenerateRnaStructPlots();
        }

        private static void GenerateShapeFile(CleavageSite site, int startAt, int endAt, string fileName)
        {
            string content = string.Empty;
            for (int position = startAt; position < endAt; position++)
            {
                content += $"{position - startAt + 1} {Reactivity.GetReactivity(site.Gene, position)}\r\n";
            }
            FileExtension.Save(content, fileName);
        }

        //private static void GenerateSeqFile(string seqFileName)

        public static void Fold(string seqFile, string ctFile, string shapeFile, string workingDirectory)
        {
            Process p = new Process();
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c fold " + seqFile + " " + ctFile + " --dms " + shapeFile); ;
            processInfo.WorkingDirectory = "F:\\JIC\\FoldTest\\";
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***  
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            p.StartInfo = processInfo;
            p.Start();
            p.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();

            int exitCode = p.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            p.Close();
        }

        public static void Fold()
        {
            Process p = new Process();
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + "fold AP2.seq AP2.ct --dms AP2.shape"); ;
            processInfo.WorkingDirectory = "F:\\JIC\\FoldTest\\";
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            p.StartInfo = processInfo;
            p.Start();
            p.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();

            int exitCode = p.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            p.Close();
        }
    }
}
