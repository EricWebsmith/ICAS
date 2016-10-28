using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Icas.ViennaRnaWrapper
{
    public class RnaDistance
    {
        private const string ExecutablePath = @"C:\Program Files (x86)\ViennaRNA Package\RNAdistance.exe";

        public static int Distance(string dbn1, string dbn2)
        {
            string input = Path.GetTempFileName();
            //string output = Path.GetTempFileName();
            Process process = new Process();
            //process.StartInfo.WorkingDirectory =  @"C:\Program Files (x86)\ViennaRNA Package";
            process.StartInfo.FileName = ExecutablePath;
            //process.StartInfo.Arguments = $"<{input} >{output}"; // Note the /c command (*)
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.StandardInput.WriteLine(dbn1);
            process.StandardInput.WriteLine(dbn2);
            process.StandardInput.WriteLine("@");
            string output = process.StandardOutput.ReadToEnd();

            //* Read the output (or the error)
            //string output = process.StandardOutput.ReadToEnd();
            string intString = output.TrimStart(new char[] { 'f', ':' }).TrimEnd();
            return int.Parse(intString);
            //Console.WriteLine(output);
            //string err = process.StandardError.ReadToEnd();
            //Console.WriteLine(err);
            process.WaitForExit();

        }

        public static int[] Distance(string dbn1, string[] dbns)
        {
            List<int> results = new List<int>();
            //string output = Path.GetTempFileName();
            Process process = new Process();
            //process.StartInfo.WorkingDirectory =  @"C:\Program Files (x86)\ViennaRNA Package";
            process.StartInfo.FileName = ExecutablePath;
            //process.StartInfo.Arguments = $"<{input} >{output}"; // Note the /c command (*)
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            foreach (var dbn in dbns)
            {
                process.StandardInput.WriteLine(dbn1);
                process.StandardInput.WriteLine(dbn);
            }

            process.StandardInput.WriteLine("@");
            string[] lines = process.StandardOutput.ReadToEnd().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                string intString = line.TrimStart(new char[] { 'f', ':' }).TrimEnd();
                int d = int.Parse(intString);
                results.Add(d);
            }
            return results.ToArray();
        }

        public static int[] Distance(string[] dbn1s, string[] dbn2s)
        {
            List<int> results = new List<int>();
            //string output = Path.GetTempFileName();
            Process process = new Process();
            //process.StartInfo.WorkingDirectory =  @"C:\Program Files (x86)\ViennaRNA Package";
            process.StartInfo.FileName = ExecutablePath;
            //process.StartInfo.Arguments = $"<{input} >{output}"; // Note the /c command (*)
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            for (int i = 0; i < dbn1s.Length; i++)
            {
                process.StandardInput.WriteLine(dbn1s[i]);
                process.StandardInput.WriteLine(dbn2s[i]);
            }

            process.StandardInput.WriteLine("@");
            string[] lines = process.StandardOutput.ReadToEnd().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                string intString = line.TrimStart(new char[] { 'f', ':' }).TrimEnd();
                int d = int.Parse(intString);
                results.Add(d);
            }
            return results.ToArray();
        }
    }
}
