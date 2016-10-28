using Icas.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Icas.Test
{
    [TestClass]
    public class ThumbnailsTest
    {
        [TestMethod]
        public void Thumbnail()
        {
            ThumbnailGenerator.Generate(@"C:\Temp\rna_plot", @"C:\Temp\cs_structs.png");

            //int width = 150;
            //int height = 150;
            //int rows = 5;
            //int cols = 4;
            //string[] files = Directory.GetFiles(@"C:\Temp\rna_plot");
            //Bitmap bitmap = new Bitmap(width * rows, height * cols);
            //Graphics g = Graphics.FromImage(bitmap);

            //for (int i = 0; i < files.Length || i < rows * cols; i++)
            //{
            //    Bitmap imgBitmap = new Bitmap(Image.FromFile(files[i]), width, height);
            //    g.DrawImage(imgBitmap, new Point(i % rows * width, (i / rows) * height));
            //}
            //bitmap.Save(@"C:\Temp\cs_structs.png", ImageFormat.Png);
            //g.Save();

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
            ThumbnailGenerator.Generate(imageFiles, @"C:\Temp\kmedoids_wt_71_medoids.png", 200, 200);
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
            ThumbnailGenerator.Generate(imageFiles, @"C:\Temp\sc_wt_71_groups.png", 300, 200, 2, 2);
        }
    }
}
