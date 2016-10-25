using Ezfx.Csv;
using Icas.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Icas.Clustering
{
    public class Cluster
    {
        public static StatisticalResultCsv[] RunIndividual(AlgorithmCsv algorithm, DatasetCsv dataset, int k, bool runScript)
        {
            List<StatisticalResultCsv> finalResults = new List<StatisticalResultCsv>();

            FeatureType dataType = FeatureTypeExtension.FromString(dataset.Feature);
            if (runScript)
            {
                //ProcessExtension.Run("python", $"\"{Config.WorkingFolder}{algorithm.Script}\" {dataset.Name} 10 100");
                ProcessExtension.RunScript($"{Config.WorkingFolder}{algorithm.Script}", $"{dataset.Name} 10 100 {k}");
                //onewan ANOVA
                ProcessExtension.Run("python", $"\"{Config.WorkingFolder}{Config.JobOnewayPy}\" {algorithm.Name} {dataset.Name}");
                //pairwise comparison
                ProcessExtension.Run("RScript", $"\"{Config.WorkingFolder}{Config.JobPairwiseComparisonR}\" {algorithm.Name} {dataset.Name}");
            }

            //compactness

            string folder = $"{Config.WorkingFolder}{algorithm.Name}\\{dataset.Name}\\";
            if (!Directory.Exists(folder))
            {
                throw new FileNotFoundException();
            }

            switch (dataType)
            {
                case FeatureType.Reactivity:
                    finalResults.AddRange(CSCompactness.AttachCompactness(algorithm, dataset));
                    break;
                case FeatureType.RnaDistance:
                    finalResults.AddRange(CSCompactness.AttachCompactness(algorithm, dataset));
                    break;
            }


            return finalResults.ToArray();
        }

        public static StatisticalResultCsv[] RunIndividual(AlgorithmCsv algorithm, DatasetCsv[] datasets, bool runScript)
        {
            List<StatisticalResultCsv> finalResults = new List<StatisticalResultCsv>();
            foreach (var dataset in datasets)
            {
                FeatureType dataType = FeatureTypeExtension.FromString(dataset.Feature);
                if (runScript)
                {
                    //ProcessExtension.Run("python", $"\"{Config.WorkingFolder}{algorithm.Script}\" {dataset.Name} 10 100");
                    ProcessExtension.RunScript($"{Config.WorkingFolder}{algorithm.Script}", $"{dataset.Name} 10 100");
                    //onewan ANOVA
                    ProcessExtension.Run("python", $"\"{Config.WorkingFolder}{Config.JobOnewayPy}\" {algorithm.Name} {dataset.Name}");
                    //pairwise comparison
                    ProcessExtension.Run("RScript", $"\"{Config.WorkingFolder}{Config.JobPairwiseComparisonR}\" {algorithm.Name} {dataset.Name}");
                }

                //compactness

                string folder = $"{Config.WorkingFolder}{algorithm.Name}\\{dataset.Name}\\";
                if (!Directory.Exists(folder))
                {
                    continue;
                }

                switch (dataType)
                {
                    case FeatureType.Reactivity:
                        finalResults.AddRange(CSCompactness.AttachCompactness(algorithm, dataset));
                        break;
                    case FeatureType.RnaDistance:
                        finalResults.AddRange(CSCompactness.AttachCompactness(algorithm, dataset));
                        break;
                }

            }
            return finalResults.ToArray();
        }

        public static void Summarize(AlgorithmCsv algorithm)
        {
            //string[] files = Directory.GetFiles($"{Config.WorkingFolder}\\results\\", "*_all.csv");
            List<StatisticalResultCsv> results = new List<StatisticalResultCsv>();
            string[] subFolders = Directory.GetDirectories($"{Config.WorkingFolder}\\{algorithm.Name}\\");
            foreach (var subFolder in subFolders)
            {
                foreach (var file in Directory.GetFiles(subFolder))
                {
                    var fi = new System.IO.FileInfo(file);
                    if (fi.Name.StartsWith(algorithm.Name) && fi.Name.EndsWith("_results.csv"))
                    {
                        results.AddRange(CsvContext.ReadFile<StatisticalResultCsv>(file));
                    }
                }
            }
            CsvContext.WriteFile($"{Config.WorkingFolder}\\results\\{algorithm}_all.csv", results, CsvConfig.Default);
            StatisticalResultCsv[] best_results = results.Where(c => c.Best).ToArray();
            CsvContext.WriteFile($"{Config.WorkingFolder}\\results\\{algorithm}_summary.csv", best_results, CsvConfig.Default);
        }

        public static void Summarize()
        {
            string[] files = Directory.GetFiles($"{Config.WorkingFolder}\\results\\", "*_all.csv");
            List<StatisticalResultCsv> results = new List<StatisticalResultCsv>();
            foreach (string file in files)
            {
                results.AddRange(CsvContext.ReadFile<StatisticalResultCsv>(file));
            }
            CsvContext.WriteFile($"{Config.WorkingFolder}\\results\\all.csv", results, CsvConfig.Default);
            StatisticalResultCsv[] best_results = results.Where(c => c.Best).ToArray();
            CsvContext.WriteFile($"{Config.WorkingFolder}\\results\\summary.csv", best_results, CsvConfig.Default);
        }
    }
}
