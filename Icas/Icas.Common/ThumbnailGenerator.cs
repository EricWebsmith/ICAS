using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Icas.Common
{
    public class ThumbnailGenerator
    {
        public static void Generate(string imageFolder, string outputFile, int width = 150, int height = 150, int rows = 5, int cols = 4)
        {
            string[] imageFiles = Directory.GetFiles(imageFolder, "*.png");
            Generate(imageFiles, outputFile, width, height, rows, cols);
        }

        public static void Generate(IEnumerable<string> imageFiles, string outputFile, int width = 150, int height = 150, int rows = 4, int cols = 5)
        {
            //string[] files = imageFiles.ToArray();
            //rearrange rows and cols
            int count = imageFiles.Count();
            rows = (int)Math.Ceiling(count * 1.0 / cols);
            if (rows == 1) cols = count;

            Bitmap bitmap = new Bitmap(width * cols, height * rows);
            Graphics g = Graphics.FromImage(bitmap);

            int index = 0;
            foreach (var imageFile in imageFiles)
            {
                Bitmap imgBitmap = new Bitmap(Image.FromFile(imageFile), width, height);
                g.DrawImage(imgBitmap, new Point(index % cols * width, (index / cols) * height));
                index++;
            }

            bitmap.Save(outputFile, ImageFormat.Png);
            g.Save();
        }
    }
}
