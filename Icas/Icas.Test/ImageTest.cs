using Icas.Reporting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Icas.Test
{
    [TestClass]
    public class ImageTest
    {
        [TestMethod]
        public void Thumbnail()
        {
            ImageHelper.Thumbnails(@"C:\Temp\rna_plot", @"C:\Temp\cs_structs.png");
        }

        [TestMethod]
        public void MedoidsThumbnail()
        {
            string[] imageFiles = new[]
            {
                @"C:\Icas.Test\cs_rna_struct\plot\wt_71_31.png",
                @"C:\Icas.Test\cs_rna_struct\plot\wt_71_175.png",
                @"C:\Icas.Test\cs_rna_struct\plot\wt_71_319.png"
            };
            ImageHelper.Thumbnails(imageFiles, @"C:\Temp\kmedoids_wt_71_medoids.png", 200, 200);
        }

        //C:\Dropbox\Dropbox\Dissertation

        [TestMethod]
        public void ReactivityThumbnail()
        {
            string[] imageFiles = new[]
            {
                @"C:\Dropbox\Dropbox\Dissertation\sc_wt_71_group0.png",
                @"C:\Dropbox\Dropbox\Dissertation\sc_wt_71_group1.png",
                @"C:\Dropbox\Dropbox\Dissertation\sc_wt_71_group2.png"
            };
            ImageHelper.Thumbnails(imageFiles, @"C:\Temp\sc_wt_71_groups.png", 300, 200, 2, 2);
        }

        [TestMethod]
        public void MedoidTriangle()
        {
            string[] imageFiles = new[]
{
                @"C:\Dropbox\Dissertation\sc_wt_71_group0.png",
                @"C:\Dropbox\Dissertation\sc_wt_71_group1.png",
                @"C:\Dropbox\Dissertation\sc_wt_71_group2.png"
            };
            ImageHelper.DistanceTriangle(@"C:\Temp\1.png", imageFiles, new double[] { 50, 60, 70 });
            System.Diagnostics.Process.Start(@"C:\Temp\1.png");
        }
    }
}
