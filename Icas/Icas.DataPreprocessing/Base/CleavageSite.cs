using System;
using System.Collections.Generic;

namespace Icas.DataPreprocessing
{
    [System.Serializable]
    public class CleavageSite
    {
        public string MiRNA { get; set; }
        public string Gene { get; set; }

        /// <summary>
        /// Do not forget to subtract one.
        /// this is not zero based.
        /// </summary>
        public int StartAt { get; set; }
        public int EndAt { get; set; }
        public int Extendability { get; set; }

        public override string ToString() => $"{MiRNA},{Gene},{StartAt},{Extendability}";

        public string ToStringWithMiRNANames()
        {
            string[] arr = MiRNA.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> names = new List<string>();
            foreach (string sequence in arr)
            {
                names.AddRange(MicroRna.GetNames(sequence));
            }
            string namesString = string.Join("; ", names);
            //names.Add()
            return $"{MiRNA},{Gene},{StartAt},{namesString}";
        }

        public static CleavageSite Parse(string s)
        {
            CleavageSite site = new CleavageSite();
            var arr = s.Split(new char[] { '_', ',' });
            site.MiRNA = arr[0];
            site.Gene = arr[1];
            site.StartAt = int.Parse(arr[2]);
            if (arr.Length > 3)
            {
                site.Extendability = int.Parse(arr[3]);
            }
            return site;
        }
    }

    public class CleavageSiteComparer : Comparer<CleavageSite>
    {
        public override int Compare(CleavageSite x, CleavageSite y)
        {
            string a = x.MiRNA + x.Gene + x.StartAt.ToString();
            string b = y.MiRNA + y.Gene + y.StartAt.ToString();
            return a.CompareTo(b);
        }
    }

    public class CleavageSiteEqualityComparer : IEqualityComparer<CleavageSite>
    {
        public bool Equals(CleavageSite x, CleavageSite y)
        {
            string a = x.MiRNA + x.Gene + x.StartAt.ToString();
            string b = y.MiRNA + y.Gene + y.StartAt.ToString();
            return a.Equals(b);
        }

        public int GetHashCode(CleavageSite obj)
        {
            string a = obj.MiRNA + obj.Gene + obj.StartAt.ToString();
            return a.GetHashCode();
        }
    }
}
