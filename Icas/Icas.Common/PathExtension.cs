using System;
using System.IO;

namespace Icas.Common
{
    public static class PathExtension
    {
        public static bool AreEqual(this string p1, string p2)
        {
            var path1 = Path.GetFullPath(p1);
            var path2 = Path.GetFullPath(p2);
            return string.Equals(path1, path2, StringComparison.OrdinalIgnoreCase);
        }
    }
}
