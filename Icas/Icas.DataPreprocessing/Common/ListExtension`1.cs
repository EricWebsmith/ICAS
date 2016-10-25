using System.Collections.Generic;

namespace Icas.DataPreprocessing
{
    public static class ListExtension<T>
    {
        public static List<T> Intersect(List<List<T>> listlist)
        {
            int listNumber = listlist.Count;
            List<T> firstList = listlist[0];
            List<T> intersect = new List<T>();
            foreach (T item in firstList)
            {
                int appears = 0;
                foreach (List<T> list in listlist)
                {
                    if (list.Contains(item))
                    {
                        appears += 1;
                    }
                    else
                    {
                        break;
                    }
                }

                if (appears == listNumber)
                {
                    intersect.Add(item);
                }
            }
            return intersect;
        }
    }
}
