using System;
using System.Diagnostics;

namespace Icas.ViennaRnaWrapper
{
    public static class RnaFoldWrapper
    {
        public static string Fold(string shapeFile, string seqFile)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c RNAFold --shape={shapeFile} < {seqFile}"; // Note the /c command (*)
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            //* Read the output (or the error)
            string output = process.StandardOutput.ReadToEnd();
            //Console.WriteLine(output);
            //string err = process.StandardError.ReadToEnd();
            //Console.WriteLine(err);
            process.WaitForExit();

            string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string lastLine = lines[2];
            return lastLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }
    }
}
