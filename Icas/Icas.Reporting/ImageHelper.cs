using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Icas.Reporting
{
    public class ImageHelper
    {
        public static void Thumbnails(string imageFolder, string outputFile, int width = 150, int height = 150, int rows = 5, int cols = 4)
        {
            string[] imageFiles = Directory.GetFiles(imageFolder, "*.png");
            Thumbnails(imageFiles, outputFile, width, height, rows, cols);
        }

        public static void Thumbnails(IEnumerable<string> imageFiles, string outputFile, int width = 150, int height = 150, int rows = 4, int cols = 5)
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

        public static void DistanceChart(Bitmap me, Bitmap[] others)
        {

        }

        public static Bitmap[] Read(string[] bitmapFiles)
        {
            List<Bitmap> bitmaps = new List<Bitmap>();
            foreach (var bitmapFile in bitmapFiles)
            {
                Bitmap imgBitmap = new Bitmap(Image.FromFile(bitmapFile));
                bitmaps.Add(imgBitmap);
            }
            return bitmaps.ToArray();
        }




        public static void DistanceTriangle(string outputFile, string[] bitmapFiles, double[] distranceUpperTriangle)
        {
            Bitmap[] bitmaps = Read(bitmapFiles);
            DistanceTriangle(outputFile, bitmaps, distranceUpperTriangle);
        }

        public static void DistanceTriangle(string outputFile, Bitmap[] bitmaps, double[] distranceUpperTriangle)
        {
            #region math

            int fontSize = 12;
            int itemLength = 100;
            int bolder12 = 400;
            double distanceScaling = bolder12 * 1.0 / distranceUpperTriangle[0];
            int bolder13 = (int)(distranceUpperTriangle[1] * distanceScaling);
            int bolder23 = (int)(distranceUpperTriangle[2] * distanceScaling);


            PointF centre0 = new Point(itemLength / 2, itemLength / 2);
            PointF centre1 = new Point(itemLength / 2 + bolder12, itemLength / 2);
            PointF centre2 = new PointF();
            PointF centre31 = new PointF();
            PointF centre32 = new PointF();

            CircleIntersections(centre0, bolder13, centre1, bolder23, out centre31, out centre32);

            centre2 = centre31.Y > 0 ? centre31 : centre32;

            int chartWidth = (int)(itemLength + Math.Max(centre1.X, centre2.X) + itemLength / 2);
            int chartHeight = (int)(centre2.Y + itemLength / 2) + fontSize * 2;
            #endregion

            Font font = new Font(FontFamily.GenericMonospace, fontSize);
            Bitmap chartBitmap = new Bitmap(chartWidth, chartHeight);
            Graphics g = Graphics.FromImage(chartBitmap);
            g.FillRectangle(Brushes.White, 0, 0, chartWidth, chartHeight);
            //Triangle
            g.DrawLine(Pens.Black, centre0, centre1);
            g.DrawLine(Pens.Black, centre0, centre2);
            g.DrawLine(Pens.Black, centre1, centre2);
            //distance
            //border 1 2
            g.DrawString(distranceUpperTriangle[0].ToString(), font, Brushes.Black, MidPoint(centre0, centre1));
            //1 3
            g.DrawString(distranceUpperTriangle[1].ToString(), font, Brushes.Black, MidPoint(centre0, centre2));
            //2 3
            g.DrawString(distranceUpperTriangle[2].ToString(), font, Brushes.Black, MidPoint(centre1, centre2));
            //Images
            g.DrawImage(bitmaps[0], centre0.X - itemLength / 2, centre0.Y - itemLength / 2, itemLength, itemLength);
            g.DrawImage(bitmaps[1], centre1.X - itemLength / 2, centre1.Y - itemLength / 2, itemLength, itemLength);
            g.DrawImage(bitmaps[2], centre2.X - itemLength / 2, centre2.Y - itemLength / 2, itemLength, itemLength);
            //Annotation
            g.DrawString("Cluster 0", font, Brushes.Black, centre0.X - itemLength / 2, centre0.Y + itemLength / 2);
            g.DrawString("Cluster 1", font, Brushes.Black, centre1.X - itemLength / 2, centre1.Y + itemLength / 2);
            g.DrawString("Cluster 2", font, Brushes.Black, centre2.X - itemLength / 2, centre2.Y + itemLength / 2);
            chartBitmap.Save(outputFile, ImageFormat.Png);
            g.Save();
        }

        private static PointF MidPoint(PointF p1, PointF p2)
        {
            float x = (p1.X + p2.X) / 2;
            float y = (p1.Y + p2.Y) / 2;
            return new PointF(x, y);
        }

        private static PointF OffSet(PointF p, float x, float y)
        {
            return new PointF(p.X + x, p.Y + y);
        }

        // Find the points where the two circles intersect.
        private static int CircleIntersections(
            PointF centre1, float radius0,
            PointF centre2, float radius1,
            out PointF intersection1, out PointF intersection2)
        {
            // Find the distance between the centers.
            float dx = centre1.X - centre2.X;
            float dy = centre1.X - centre2.Y;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            // See how many solutions there are.
            if (dist > radius0 + radius1)
            {
                // No solutions, the circles are too far apart.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }

            if (dist < Math.Abs(radius0 - radius1))
            {
                // No solutions, one circle contains the other.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }

            if ((dist == 0) && (radius0 == radius1))
            {
                // No solutions, the circles coincide.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }


            {
                // Find a and h.
                double a = (radius0 * radius0 -
                    radius1 * radius1 + dist * dist) / (2 * dist);
                double h = Math.Sqrt(radius0 * radius0 - a * a);

                // Find P2.
                double cx2 = centre1.X + a * (centre2.X - centre1.X) / dist;
                double cy2 = centre1.Y + a * (centre2.Y - centre1.Y) / dist;

                // Get the points P3.
                intersection1 = new PointF(
                    (float)(cx2 + h * (centre2.Y - centre1.Y) / dist),
                    (float)(cy2 - h * (centre2.X - centre1.X) / dist));
                intersection2 = new PointF(
                    (float)(cx2 - h * (centre2.Y - centre1.Y) / dist),
                    (float)(cy2 + h * (centre2.X - centre1.X) / dist));

                // See if we have 1 or 2 solutions.
                if (dist == radius0 + radius1) return 1;
                return 2;
            }
        }
    }
}
