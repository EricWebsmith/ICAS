using Icas.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace Icas.DataPreprocessing
{
    public static class MicroRna
    {
        private static List<NameSequence> _MicroRnaList = null;
        public static List<NameSequence> MicroRnaList
        {
            get
            {
                if(_MicroRnaList==null)
                {
                    _MicroRnaList = Fasta.Read(Config.MicroRnaFile);
                }
                return _MicroRnaList;
            }
        }

        public static List<string> GetNames(string sequence)
        {
            List<string> result = new List<string>();
            foreach (NameSequence ns in MicroRnaList)
            {
                if(ns.Sequence==sequence)
                {
                    result.Add(ns.Name);
                }
            }
            return result;
        }

        public static List<string> GetNamesNoArk(string sequence)
        {
            List<string> result = new List<string>();
            foreach (NameSequence ns in MicroRnaList)
            {
                if (ns.Sequence == sequence)
                {
                    result.Add(ns.Name);
                }
            }
            return result;
        }

        public static void Filter()
        {
            string content = string.Empty;
            List<Seq> seqList = new List<Seq>();

            using (StreamReader sr = new StreamReader(Config.WorkingFolder+ @"miRNA sequences from PMRD.fasta"))
            {
                content = sr.ReadToEnd();
                sr.Close();
            }

            var sequances = content.Split(new char[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in sequances)
            {
                var arr = s.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr[0].EndsWith("-akr"))
                {
                    break;
                }
                Seq aSeq = new Seq();
                aSeq.Name = arr[0];
                aSeq.Sequence = arr[1];
                seqList.Add(aSeq);
            }

            using (StreamWriter sw = new StreamWriter(Config.WorkingFolder + @"miRNA_no_akr.fasta"))
            {
                foreach (Seq aSeq in seqList)
                {
                    sw.WriteLine(">" + aSeq.Name);
                    sw.WriteLine(aSeq.Sequence);
                }
                sw.Flush();
                sw.Close();
            }
        }

        public static void Filter2()
        {
            var hash = new HashSet<string>();

            string content = string.Empty;

            using (StreamReader sr = new StreamReader(@"F:\JIC\Scan2\miRNA_no_akr.fasta"))
            {
                content = sr.ReadToEnd();
                sr.Close();
            }

            var sequances = content.Split(new char[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in sequances)
            {
                var arr = s.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr[0].EndsWith("-akr"))
                {
                    break;
                }
                hash.Add(arr[1]);
            }

            using (StreamWriter sw = new StreamWriter(@"F:\JIC\Arabidopsis\Control\miRNA_no_akr_no_dup.fasta"))
            {
                foreach (var s in hash)
                {
                    sw.WriteLine(">" + s);
                    sw.WriteLine(s);
                }
                sw.Flush();
                sw.Close();
            }
        }
    }
}
