using Ezfx.Csv.Ex;
using Icas.Common;

namespace Icas.Clustering
{
    public static class CsMetrics
    {
        public static Sample[] GetMedoids(string labels_file, string dataset)
        {
            string x_file = $"{Config.WorkingFolder}\\cs_datasets\\{dataset}.csv";
            double[,] x = CsvMatrix.Read(x_file);
            int[] y = FileExtension.Readlabels(labels_file);
            return Metrics.GetMedoids(x, y);
        }
    }
}
