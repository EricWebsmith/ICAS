using Icas.DataPreprocessing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Icas.Test
{
    [TestClass]
    public class DegradomeTest
    {
        [TestMethod]
        public void MergeFileTest()
        {
            //Degradome.Merge(
            //    "F:\\JICWork\\Degradome_WT\\Degrad_wt_1_ATCACG_R1_T1\\results.dist.txt",
            //    "F:\\JICWork\\Degradome_WT\\Degrad_wt_1_ATCACG_R1_T2\\results.dist.txt",
            //    "F:\\JICWork\\Degradome_WT\\degrad_wt_1.txt"
            //    );
            Degradome.Merge(
               "F:\\JICWork\\Degradome_WT\\Degrad_wt_2_ACAGTG_R1_T1\\results.dist.txt",
               "F:\\JICWork\\Degradome_WT\\Degrad_wt_2_ACAGTG_R1_T2\\results.dist.txt",
               "F:\\JICWork\\Degradome_WT\\degrad_wt_2.txt"
               );
            Degradome.Merge(
               "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_1_GAGTGG_R1_T1\\results.dist.txt",
               "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_1_GAGTGG_R1_T2\\results.dist.txt",
               "F:\\JICWork\\Degradome_XRN4\\degrad_XRN4_1.txt"
               );
            Degradome.Merge(
                "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_2_ATTCCT_R1_T1\\results.dist.txt",
                "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_2_ATTCCT_R1_T2\\results.dist.txt",
                "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_2.txt"
                );
        }

        [TestMethod]
        public void MergeFileTest2()
        {
            Degradome.Merge(
               "F:\\JICWork\\Degradome_WT\\degrad_wt_1.txt",
               "F:\\JICWork\\Degradome_WT\\Degrad_wt_2.txt",
               "F:\\JICWork\\Degradome_WT\\degrad_wt.txt"
               );
            Degradome.Merge(
               "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_1.txt",
               "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_2.txt",
               "F:\\JICWork\\Degradome_XRN4\\degrad_XRN4.txt"
               );
        }

        [TestMethod]
        public void PearsonTest3()
        {
            var r1 = Degradome.CorrelationTest(
                "F:\\JICWork\\Degradome_WT\\degrad_wt.txt",
                "F:\\JICWork\\Degradome_XRN4\\degrad_XRN4.txt",
                "F:\\JICWork\\Degradome_WT\\cor_wt_xrn4.txt"
                );

            Debug.Print(r1.ToString());
            Debug.Print("done");
        }

        [TestMethod]
        public void PearsonTest2()
        {
            var r1 = Degradome.CorrelationTest(
                "F:\\JICWork\\Degradome_WT\\Degrad_wt_1.txt",
                "F:\\JICWork\\Degradome_WT\\Degrad_wt_2.txt",
                "F:\\JICWork\\Degradome_WT\\cor_wt.txt"
                );
            var r2 = Degradome.CorrelationTest(
                "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_1.txt",
                "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_2.txt",
                "F:\\JICWork\\Degradome_XRN4\\cor_XRN4.txt"
                );
            Debug.Print(r1.ToString());
            Debug.Print(r2.ToString());
            Debug.Print("done");
        }

        [TestMethod]
        public void PearsonTest1()
        {
            var r1 = Degradome.CorrelationTest(
                "F:\\JICWork\\Degradome_WT\\Degrad_wt_1_ATCACG_R1_T1\\results.dist.txt",
                "F:\\JICWork\\Degradome_WT\\Degrad_wt_1_ATCACG_R1_T2\\results.dist.txt",
                "F:\\JICWork\\Degradome_WT\\wt1.txt"
                );
            var r2 = Degradome.CorrelationTest(
                "F:\\JICWork\\Degradome_WT\\Degrad_wt_2_ACAGTG_R1_T1\\results.dist.txt",
                "F:\\JICWork\\Degradome_WT\\Degrad_wt_2_ACAGTG_R1_T2\\results.dist.txt",
                "F:\\JICWork\\Degradome_WT\\wt2.txt"
                );
            var r3 = Degradome.CorrelationTest(
                "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_1_GAGTGG_R1_T1\\results.dist.txt",
                "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_1_GAGTGG_R1_T2\\results.dist.txt",
                "F:\\JICWork\\Degradome_XRN4\\XRN4_1.txt"
                );
            var r4 = Degradome.CorrelationTest(
                "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_2_ATTCCT_R1_T1\\results.dist.txt",
                "F:\\JICWork\\Degradome_XRN4\\Degrad_XRN4_2_ATTCCT_R1_T2\\results.dist.txt",
                "F:\\JICWork\\Degradome_XRN4\\XRN4_2.txt"
                );
            Debug.Print(r1.ToString());
            Debug.Print(r2.ToString());
            Debug.Print(r3.ToString());
            Debug.Print(r4.ToString());
            Debug.Print("done");
        }
    }
}
