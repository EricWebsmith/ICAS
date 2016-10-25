using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Icas.Test
{
    [TestClass]
    public class GenerateThumbnails
    {
        [TestMethod]
        public void Thumbnail()
        {
            string[] files = Directory.GetFiles(@"C:\Temp\rna_plot");
            Bitmap bitmap = new Bitmap(600, 400);
            Graphics g = Graphics.FromImage(bitmap);

            for (int i = 0; i < files.Length; i++)
            {
                Bitmap imgBitmap = new Bitmap(Image.FromFile(files[i]), 100, 100);
                g.DrawImage(imgBitmap, new Point(i % 6 * 100, (i / 6) * 100));
            }
            bitmap.Save(@"C:\Temp\rna_plot1.png", ImageFormat.Png);
            g.Save();

        }
    }
}
