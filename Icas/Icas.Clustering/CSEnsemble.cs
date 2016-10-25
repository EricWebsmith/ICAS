using Icas.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Icas.Clustering
{
    public class CSEnsemble
    {
        public static StatisticalResultCsv[] Run(string name, string method, int ke, int keep, IEnumerable<StatisticalResultCsv> selectedMembers)
        {
            string methodFolder = $"{Config.WorkingFolder}\\{name}";
            Directory.CreateDirectory(methodFolder);
            string candidatesFolder = $"{Config.WorkingFolder}\\{name}\\candidates\\";
            Directory.CreateDirectory(candidatesFolder);
            foreach (var member in selectedMembers)
            {
                File.Copy($"{Config.WorkingFolder}\\{member.Method}\\{member.Dataset}\\individuals\\{member.File}", $"{candidatesFolder}\\{member.File}", true);
            }
            Icas.Common.ProcessExtension.Run("RScript", $"job_ensemble.R {name} {method} {selectedMembers.First().Dataset} {selectedMembers.First().Degredome} {keep}");
            FeatureType dt = FeatureType.Reactivity;
            FeatureType.TryParse(selectedMembers.First().DataType, out dt);

            ProcessExtension.Run("Python", $"{Config.JobOnewayPy} {name} {selectedMembers.First().Dataset}");
            ProcessExtension.Run("RScript", $"{Config.JobPairwiseComparisonR} {name} {selectedMembers.First().Dataset}");
            AlgorithmCsv algorithm = new AlgorithmCsv();
            algorithm.Name = name;
            algorithm.Feature = selectedMembers.First().DataType;
            DatasetCsv dataset = MiSettings.Datasets.First(c => c.Name == selectedMembers.First().Dataset);
            var results = Icas.Clustering.Cluster.RunIndividual(algorithm, new[] { dataset }, false);
            Icas.Clustering.Cluster.Summarize(algorithm);
            return results;
        }
    }
}
