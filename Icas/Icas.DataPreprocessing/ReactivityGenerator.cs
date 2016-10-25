using Icas.Common;
using System.Collections.Generic;

namespace Icas.DataPreprocessing
{
    public static class ReactivityGenerator
    {
        public static void Filter()
        {
            var sites = CleavageSiteUtility.Deserialize();
            string deletedCleavageSite = string.Empty;
            List<CleavageSite> toDelete = new List<CleavageSite>();
            foreach(var site in sites)
            {
                if(!Reactivity.HasReactivity(site.Gene))
                {
                    toDelete.Add(site);
                    deletedCleavageSite += site.ToString() + "\r\n";
                }
            }

            foreach(var site in toDelete)
            {
                sites.Remove(site);
            }
            FileExtension.Save(deletedCleavageSite, "CleavageSite_Filtered_by_Reactivity.txt");

            Serializer.Serialize("cleavage_sites.bin", sites);
            //return sites;
        }

        public static void GenerateMatrix()
        {
            var sites = CleavageSiteUtility.Deserialize();
            float[,] matrix = new float[sites.Count, 21];

            for (int i = 0; i < sites.Count; i++)
            {
                System.Console.WriteLine(sites[i].Gene);
                for (int j = 0; j < 21; j++)
                {
                    matrix[i, j] = Reactivity.GetReactivity(sites[i].Gene, sites[i].StartAt + j - 1);
                }
            }

            //print
            string content = string.Empty;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    content += matrix[i, j].ToString() + ",";
                }
                content = content.TrimEnd(',') + "\n";
            }

            FileExtension.Save(content, Config.WorkingFolder+ "cs_21_reactivity.csv");
        }
    }
}
