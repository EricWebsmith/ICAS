using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Icas.DataPreprocessing;

namespace Icas.Test
{
    [TestClass]
    public class FastaTest
    {
        [TestMethod]
        public void ReadTest()
        {
           var result = Fasta.Read(@"F:\JICWork\miRNA_no_akr.fasta");
        }
    }
}
