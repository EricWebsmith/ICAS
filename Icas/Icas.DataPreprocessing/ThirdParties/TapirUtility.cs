using System.Collections.Generic;
using System.IO;

namespace Icas.DataPreprocessing
{
   public class TapirUtility
    {
        public static void Convert(string inputFile, string outputFile)
        {
            var hash = new HashSet<string>();

            using (StreamReader sr = new StreamReader(inputFile))
            {
                string gene = string.Empty;
                string miRNASequence = string.Empty;
                string startAt = string.Empty;
                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    if (line.Equals("//"))
                    {
                        hash.Add(miRNASequence + "_" + gene + "_" + startAt);
                        continue;
                    }

                    string name = line.Substring(0, 14).Trim();
                    string value = line.Substring(14).Trim();
                    switch (name)
                    {
                        case "target":
                            gene = value;
                            break;
                        case "miRNA_3'":
                            miRNASequence = value.Replace("-","").Replace("U", "T").Reverse();
                            break;
                        case "start":
                            startAt = value;
                            break;
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                foreach (var k in hash)
                {
                    sw.WriteLine(k);
                }
                sw.Flush();
                sw.Close();
            }
        }
    }
}
