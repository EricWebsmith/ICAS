using System;
using System.Diagnostics;
using System.IO;

namespace Icas.Common
{
    public class ProcessExtension
    {
        /// <summary>
        /// usage ProcessExtension.Plot("RScript", $"{Config.JobPairwiseComparisonR} {name} {selectedMembers[0].Dataset}");
        /// </summary>
        /// <param name="program"></param>
        /// <param name="arguments"></param>
        /// <param name="showErrorMessage"></param>
        public static void Run(string program, string arguments, bool showErrorMessage = false)
        {
            Process process = new Process();
            process.StartInfo.FileName = program;// "cmd.exe";
            process.StartInfo.Arguments = arguments;// $"/c \"{program}\" {arguments}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WorkingDirectory = Config.WorkingFolder;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
            if (showErrorMessage)
            {
                string errorMessage = process.StandardError.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    throw new Exception(errorMessage);
                }
            }

        }

        public static void RunScript(string scriptFile, string arguments)
        {
            FileInfo fi = new FileInfo(scriptFile);
            string extension = fi.Extension.ToUpper();
            string program = GetApplicationByExtension(extension);
            Run(program, $"\"{scriptFile}\" {arguments}");
        }

        private static string GetApplicationByExtension(string extension)
        {
            foreach (var applicationCsv in MiSettings.Applications)
            {
                if (applicationCsv.Extension.ToUpper().TrimStart(new char[] { '.' }) ==
                    extension.ToUpper().TrimStart(new char[] { '.' }))
                {
                    return applicationCsv.Name;
                }
            }
            throw new MiClusterException($"the applicaton for {extension} was not found.");
        }
    }
}
