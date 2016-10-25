using System.Linq;

namespace Icas.DataPreprocessing
{
    public static class StringExtension
    {
        public static string Reverse(this string s)
        {
            return new string(s.ToCharArray().Reverse().ToArray());
        }

        public static bool IsDigit(this string s)
        {
            foreach(char c in s)
            {
                if(! char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
