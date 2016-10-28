using Ezfx.Csv;
using Ezfx.Csv.Ex;
using Icas.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Icas.Clustering
{
    public static class CSCompactness
    {

        public static StatisticalResultCsv[] AttachCompactness(AlgorithmCsv algorithm, DatasetCsv dataset)
        {
            List<StatisticalResultCsv> final_results = new List<StatisticalResultCsv>();
            double best_sr = 0;
            double min_compact = 0;
            int min_compact_at = 0;

            string current_folder = $"{Config.WorkingFolder}\\{algorithm.Name}\\{dataset.Name}\\";
            var dataType = FeatureTypeExtension.FromString(dataset.Feature);
            PairwiseComparisonCsv[] pairwiseResults = CsvContext.ReadFile<PairwiseComparisonCsv>(current_folder + Config.PairwiseComparisonCsv);
            if (pairwiseResults.Length == 0)
            {
                return OutputResults(final_results, algorithm.Name, dataset.Name);
            }
            best_sr = pairwiseResults[0].significant_rate;
            min_compact = GetCompactness(current_folder + "\\individuals\\" + pairwiseResults[0].File, dataset);
            PairwiseComparisonCsv[] best_pairwiseResults = pairwiseResults.Where(c => c.significant_rate == best_sr).ToArray();

            for (int i = 0; i < best_pairwiseResults.Length; i++)
            {
                //double compact =
                StatisticalResultCsv finalResult = new StatisticalResultCsv();
                finalResult.DataType = dataType.ToString();
                finalResult.Method = algorithm.Name;
                DatasetCsvToFinalCsv(dataset, finalResult);
                PairCsvToFinalCsv(best_pairwiseResults[i], finalResult);
                finalResult.Compactness = GetCompactness(current_folder + "\\individuals\\" + best_pairwiseResults[i].File, dataset);
                if (finalResult.Compactness < min_compact)
                {
                    min_compact = finalResult.Compactness;
                    min_compact_at = i;
                }
                final_results.Add(finalResult);
            }
            final_results[min_compact_at].Best = true;

            for (int i = best_pairwiseResults.Length; i < best_pairwiseResults.Length + 5 && i < pairwiseResults.Length; i++)
            {
                StatisticalResultCsv finalResult = new StatisticalResultCsv();
                finalResult.DataType = dataType.ToString();
                finalResult.Method = algorithm.Name;
                DatasetCsvToFinalCsv(dataset, finalResult);
                PairCsvToFinalCsv(pairwiseResults[i], finalResult);
                finalResult.Compactness = GetCompactness(current_folder + "\\individuals\\" + pairwiseResults[i].File, dataset);
                final_results.Add(finalResult);
            }

            return OutputResults(final_results, algorithm.Name, dataset.Name);
        }

        private static StatisticalResultCsv[] OutputResults(List<StatisticalResultCsv> final_results, string method, string datasetName)
        {
            string output_file = $"{method}_{datasetName}_results.csv";
            CsvContext.WriteFile($"{method}\\{ datasetName}\\{output_file}", final_results.ToArray(), CsvConfig.Default);
            File.Copy($"{method}\\{ datasetName}\\{output_file}", Config.WorkingFolder + "\\results\\" + output_file, true);
            return final_results.ToArray();
        }

        private static double GetCompactness(string labels_file, DatasetCsv dataset)
        {
            var dataType = FeatureTypeExtension.FromString(dataset.Feature);
            switch (dataType)
            {
                case FeatureType.Reactivity:
                    return GetCompactnessByReactivity(labels_file, dataset);
                case FeatureType.RnaDistance:
                    return GetCompactnessByRnaDistance(labels_file, dataset);
                default:
                    throw new DataTypeNotSupportedException();
            }
        }

        private static double GetCompactnessByRnaDistance(string labels_file, DatasetCsv dataset)
        {
            string d_file = $"{Config.WorkingFolder}\\cs_datasets\\{dataset.XFile}";
            double[,] d = CsvMatrix.Read(d_file);
            int[] y = FileExtension.Readlabels(labels_file);
            return Metrics.CompactnessByDistanceMatrix(d, y);
        }

        private static double GetCompactnessByReactivity(string labels_file, DatasetCsv dataset)
        {
            string x_file = $"{Config.WorkingFolder}\\cs_datasets\\{dataset.XFile}";
            double[,] x = CsvMatrix.Read(x_file);
            int[] y = FileExtension.Readlabels(labels_file);
            return Metrics.Compactness(x, y);
        }

        private static void PairCsvToFinalCsv(PairwiseComparisonCsv pairCsv, StatisticalResultCsv finalResult)
        {
            finalResult.File = pairCsv.File;
            finalResult.group_count = pairCsv.group_count;
            finalResult.Oneway = pairCsv.Oneway;
            finalResult.pair_count = pairCsv.pair_count;
            finalResult.significant_pairs = pairCsv.significant_pairs;
            finalResult.significant_rate = pairCsv.significant_rate;
        }

        private static void DatasetCsvToFinalCsv(DatasetCsv dataset, StatisticalResultCsv finalResult)
        {
            finalResult.Length = dataset.CsLength;
            finalResult.Degredome = dataset.Degradome;
            finalResult.Dataset = dataset.Name;
            finalResult.Transformation = dataset.Transformation;
        }

    }
}
