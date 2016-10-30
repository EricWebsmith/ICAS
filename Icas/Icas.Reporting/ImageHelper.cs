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
        public static void Thumbnails(string imageFolder, string outputFile, int width = 150, int height = 150,
            int rows = 5, int cols = 4)
        {
            string[] imageFiles = Directory.GetFiles(imageFolder, "*.png");
            Thumbnails(imageFiles, outputFile, width, height, rows, cols);
        }

        public static void Thumbnails(IEnumerable<string> imageFiles, string outputFile, int width = 150,
            int height = 150, int rows = 4, int cols = 5)
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

        public static Bitmap[] Read(string[] bitmapFiles, int witdh, int height)
        {
            List<Bitmap> bitmaps = new List<Bitmap>();
            foreach (var bitmapFile in bitmapFiles)
            {
                Bitmap imgBitmap = new Bitmap(Image.FromFile(bitmapFile), witdh, height);
                bitmaps.Add(imgBitmap);
            }
            return bitmaps.ToArray();
        }

        //public static Bitmap Read(string bitmapFile)
        //{
        //    List<Bitmap> bitmaps = new List<Bitmap>();
        //    foreach (var bitmapFile in bitmapFiles)
        //    {
        //        Bitmap imgBitmap = new Bitmap(Image.FromFile(bitmapFile));
        //        bitmaps.Add(imgBitmap);
        //    }
        //    return bitmaps.ToArray();
        //}




        public static void DistanceTriangle(string outputFile, string[] bitmapFiles, double[] distranceUpperTriangle)
        {
            Bitmap[] bitmaps = Read(bitmapFiles, 100, 100);
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
            DrawString(g, distranceUpperTriangle[0].ToString(), font, centre0.MidPoint(centre1));
            //1 3
            DrawString(g, distranceUpperTriangle[1].ToString(), font, centre0.MidPoint(centre2));
            //2 3
            DrawString(g, distranceUpperTriangle[2].ToString(), font, centre1.MidPoint(centre2));
            //Images
            g.DrawImage(bitmaps[0], centre0.X - itemLength / 2, centre0.Y - itemLength / 2, itemLength, itemLength);
            g.DrawImage(bitmaps[1], centre1.X - itemLength / 2, centre1.Y - itemLength / 2, itemLength, itemLength);
            g.DrawImage(bitmaps[2], centre2.X - itemLength / 2, centre2.Y - itemLength / 2, itemLength, itemLength);
            //Annotation
            DrawString(g, "Cluster 0", font, centre0.X - itemLength / 2, centre0.Y + itemLength / 2);
            DrawString(g, "Cluster 1", font, centre1.X - itemLength / 2, centre1.Y + itemLength / 2);
            DrawString(g, "Cluster 2", font, centre2.X - itemLength / 2, centre2.Y + itemLength / 2);
            chartBitmap.Save(outputFile, ImageFormat.Png);
            g.Save();
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

        /// <summary>
        /// plot the structure and 3 centers and the distances.
        /// </summary>
        /// <param name="outputFile"></param>
        /// <param name="centerBitmap"></param>
        /// <param name="remoteBitmaps">Must be three centres</param>
        /// <param name="distances"></param>
        public static void Star(string outputFile, string centerBitmapFile, string centerAnnotation,
            string[] remoteBitmapFiles,
            string[] remoteAnnotation, float[] distances, int chartWidth = 550, int itemLength = 100, int fontSize = 12)
        {
            Bitmap centerBitmap = new Bitmap(Image.FromFile(centerBitmapFile), itemLength, itemLength);
            Bitmap[] remoteBitmaps = Read(remoteBitmapFiles, itemLength, itemLength);
            Star(outputFile, centerBitmap, centerAnnotation, remoteBitmaps, remoteAnnotation, distances, chartWidth,
                itemLength, fontSize);
        }

        /// <summary>
        /// plot the structure and 3 centers and the distances.
        /// </summary>
        /// <param name="outputFile"></param>
        /// <param name="centerBitmap"></param>
        /// <param name="remoteBitmaps">Must be three centres</param>
        /// <param name="distances"></param>
        public static void Star(string outputFile, Bitmap centerBitmap, string centerAnnotation, Bitmap[] remoteBitmaps,
            string[] remoteAnnotation, float[] distances, int chartWidth = 550, int itemLength = 100, int fontSize = 12)
        {



            float scaling = (float)((chartWidth - itemLength) / Math.Cos(Math.PI / 6) / (distances[1] + distances[2]));
            //a, b and c are image distances
            float a = scaling * distances[0];
            float b = scaling * distances[1];
            float c = scaling * distances[2];

            //calcuate the center of the four objects where the centerBitmap has a center (0,0)
            PointF center = new PointF(0, 0);
            PointF[] remotePoints = new PointF[3];
            remotePoints[0] = new PointF(0, -a);
            remotePoints[1] = new PointF((float)(-b * Math.Cos(Math.PI / 6)), (float)(b * Math.Sin(Math.PI / 6)));
            remotePoints[2] = new PointF((float)(c * Math.Cos(Math.PI / 6)), (float)(c * Math.Sin(Math.PI / 6)));

            //Offset each points
            float xMin = remotePoints[1].X - itemLength / 2;
            float xMax = remotePoints[2].X + itemLength / 2;
            float yMin = -a - itemLength / 2;
            float yMax = Math.Max(remotePoints[1].Y, remotePoints[2].Y) + itemLength / 2 + fontSize * 2;

            int chartHeight = (int)(yMax - yMin);

            center = center.OffSet(-xMin, -yMin);
            for (int i = 0; i < 3; i++)
            {
                remotePoints[i] = remotePoints[i].OffSet(-xMin, -yMin);
            }

            //draw chart
            Font font = new Font(FontFamily.GenericMonospace, fontSize);
            Bitmap chartBitmap = new Bitmap(chartWidth, chartHeight);
            Graphics g = Graphics.FromImage(chartBitmap);
            g.FillRectangle(Brushes.White, 0, 0, chartWidth, chartHeight);

            for (int i = 0; i < 3; i++)
            {
                //draw connections
                g.DrawLine(Pens.Black, center, remotePoints[i]);
                //distance annotation
                //g.DrawString(distances[i].ToString(), font, Brushes.Black, center.MidPoint(remotePoints[i]));
                DrawString(g, distances[i].ToString(), font, center.MidPoint(remotePoints[i]));
                //draw bitmaps
                g.DrawImage(remoteBitmaps[i], remotePoints[i].OffSet(-itemLength / 2f, -itemLength / 2f));
                //annotation for the bitmap
                if (!string.IsNullOrWhiteSpace(remoteAnnotation[i]))
                {
                    DrawString(g, remoteAnnotation[i], font, remotePoints[i].OffSet(-itemLength / 2f, +itemLength / 2f));
                }
            }


            //draw center bitmaps
            g.DrawImage(centerBitmap, center.OffSet(-itemLength / 2f, -itemLength / 2f));
            if (!string.IsNullOrWhiteSpace(centerAnnotation))
            {
                DrawString(g, centerAnnotation, font, center.OffSet(-itemLength / 2f, +itemLength / 2f));
            }

            chartBitmap.Save(outputFile, ImageFormat.Png);
            g.Save();
        }

        private static void DrawString(Graphics g, string s, Font font, PointF point)
        {
            DrawString(g, s, font, point.X, point.Y);
        }

        private static void DrawString(Graphics g, string s, Font font, float x, float y)
        {
            var size = g.MeasureString(s, font);
            g.FillRectangle(Brushes.White, x, y, size.Width, size.Height);
            g.DrawString(s, font, Brushes.Black, x, y);
        }
    }
}
