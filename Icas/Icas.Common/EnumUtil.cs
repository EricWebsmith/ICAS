using System;
using System.Linq;

namespace Icas.Common
{
    public static class EnumUtil
    {
        public static T[] GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        }
    }
}
