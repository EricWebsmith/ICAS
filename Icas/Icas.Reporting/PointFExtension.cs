using System.Drawing;

namespace Icas.Reporting
{
    public static class PointFExtension
    {
        public static PointF OffSet(this PointF p, float x, float y)
        {
            return new PointF(p.X + x, p.Y + y);
        }

        public static PointF MidPoint(this PointF p1, PointF p2)
        {
            float x = (p1.X + p2.X) / 2;
            float y = (p1.Y + p2.Y) / 2;
            return new PointF(x, y);
        }
    }
}
