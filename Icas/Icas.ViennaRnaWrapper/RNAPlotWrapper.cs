using System;
using System.Diagnostics;
using System.IO;

namespace Icas.ViennaRnaWrapper
{
    public static class RnaPlotWrapper
    {
        private const string ExecutablePath = @"C:\Program Files (x86)\ViennaRNA Package\RNAplot.exe";


        public static string Plot(string format, string sequence = null)
        {
            string tempFolder = Path.GetTempPath();
            string tempOutput = Path.GetTempFileName();
            string tempKey = Path.GetFileName(tempOutput);
            tempOutput = $"{tempFolder}\\{tempKey}_ss.svg";
            string tempInput = Path.GetTempFileName();

            if (string.IsNullOrWhiteSpace(sequence))
            {
                sequence = new string('o', format.Length);
            }

            string inputContent = string.Empty;
            inputContent += $">{tempKey}\r\n";
            inputContent += $"{sequence}\r\n";
            inputContent += $"{format}\r\n";
            inputContent += $"@\r\n";
            using (StreamWriter sw = new StreamWriter(tempInput))
            {
                sw.Write(inputContent);
                sw.Flush();
                sw.Close();
            }


            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/c \"{ExecutablePath}\" --output-format=svg < {tempInput}"; // Note the /c command (*)
                process.StartInfo.WorkingDirectory = tempFolder;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
                string errorMessage = process.StandardError.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    throw new Exception(errorMessage);
                }
            }
            File.Delete(tempInput);

            return tempOutput;
        }
    }
}
