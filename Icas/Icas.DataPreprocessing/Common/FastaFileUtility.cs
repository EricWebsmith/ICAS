using System.Collections.Generic;
using System.IO;
using Icas.Common;

namespace Icas.DataPreprocessing
{
    static class FastaFileUtility
    {
        public static void Split(string file, int n)
        {
            string content = string.Empty;
            List<Seq> seqList = new List<Seq>();

            using (StreamReader sr = new StreamReader(file))
            {
                content = sr.ReadToEnd();
                sr.Close();
            }

            int previousEndAt = 0;
            int endAt = 0;
            for (int i = 1; i < n; i++)
            {
                endAt = content.IndexOf(">", i * (content.Length / n));
                string sub_content = content.Substring(previousEndAt, endAt- previousEndAt);
                FileExtension.Save(sub_content, file + "." + i.ToString());
                previousEndAt = endAt;
            }

            string last_sub_content = content.Substring(previousEndAt);
            FileExtension.Save(last_sub_content, file + "." + n.ToString());
        }
    }
}
