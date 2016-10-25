using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Icas.DataPreprocessing;
using System.Diagnostics;
using Icas.Common;

namespace Icas.Test
{
    [TestClass]
    public class CleavageSiteTest
    {
        [TestMethod]
        public void TestZeroBase()
        {
            Random r = new Random(1024);
            int randomNumber = r.Next(100, 5000);

            StreamReader sr = new StreamReader(Config.WorkingFolder + "targetfinder_result.txt");
            for (int i = 0; i < randomNumber; i++)
            {
                sr.ReadLine();
            }
            string line = sr.ReadLine().Trim();
            Debug.Print(line);
            sr.Close();
            string[] arr = line.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            string gene = arr[1];
            int position = int.Parse(arr[2]);
            string gene_seq = Gene.GetSequence(gene);
            Debug.Print(gene_seq.Substring(position-1, 22));
        }
    }
}
