using System.Collections.Generic;
using System.IO;

namespace Icas.DataPreprocessing
{
    public class Fasta
    {
        public static List<NameSequence> Read(string file)
        {
            List<NameSequence> result = new List<NameSequence>();
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    NameSequence ns = new NameSequence();
                    ns.Name = sr.ReadLine().TrimStart(new char[] { '>' });
                    if (sr.EndOfStream)
                    {
                        break;
                    }
                    ns.Sequence = sr.ReadLine();
                    result.Add(ns);
                }
            }
            return result;
        }
    }
}
