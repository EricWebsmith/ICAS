using System;
using System.Collections.Generic;
using System.IO;

namespace Icas.DataPreprocessing
{
    public class Targetfinder
    {
        public static void Convert(string inputFolder, string outputFile)
        {
            HashSet<String> keys = new HashSet<string>();

            var di = new DirectoryInfo(inputFolder);

            foreach (FileInfo file in di.GetFiles())
            {
                string miRNA = file.Name.Replace(".txt", "");
                Console.WriteLine(file.Name);
                using (StreamReader sr = file.OpenText())
                {
                    string content = sr.ReadToEnd();
                    var lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        string gene = line.Substring(0, 11);

                        if (gene.Equals("No results "))
                        {
                            continue;
                        }

                        string startIndicator = "targetfinder\trna_target";
                        int startAt = line.IndexOf(startIndicator);
                        string startString = line.Substring(startAt + startIndicator.Length);
                        string[] arr = startString.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        startString = arr[0];
                        string endingString = arr[1];
                        if (startString == endingString)
                        {
                            continue;
                        }
                        string key = miRNA + "," + gene + "," + startString;
                        keys.Add(key);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                foreach (var k in keys)
                {
                    sw.WriteLine(k);
                }
                sw.Flush();
                sw.Close();
            }
        }
    }
}
