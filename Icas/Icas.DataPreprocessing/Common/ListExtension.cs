using System.Collections.Generic;

namespace Icas.DataPreprocessing
{
    public static class ListExtension
    {
        public static Dictionary<string, Dictionary<int, float>> ToDict(Dictionary<string, float[]> list_dict)
        {
            var result = new Dictionary<string, Dictionary<int, float>>();
            foreach (var kv in list_dict)
            {
                Dictionary<int, float> newValue = new Dictionary<int, float>();
                for (int i = 0; i < kv.Value.Length; i++)
                {
                    if (kv.Value[i] != 0)
                    {
                        newValue.Add(i, kv.Value[i]);
                    }
                }
                result.Add(kv.Key, newValue);
            }
            return result;
        }
    }
}
