using Ezfx.Csv;
using System.Linq;

namespace Icas.Common
{
    public static class MiSettings
    {
        private static readonly string SettingsFolder = $"{Config.WorkingFolder}\\settings\\";

        #region Applications
        private static ApplicationCsv[] _applications;

        public static ApplicationCsv[] Applications
        {
            get { return _applications; }
            private set { _applications = value; }
        }

        private static ApplicationCsv[] GetApplications()
        {
            return CsvContext.ReadFile<ApplicationCsv>($"{SettingsFolder}applications.csv");
        }
        #endregion

        #region Algorithms
        private static AlgorithmCsv[] _algorithms;

        public static AlgorithmCsv[] Algorithms
        {
            get { return _algorithms; }
            private set { _algorithms = value; }
        }

        private static AlgorithmCsv[] GetAlgorithms()
        {
            return CsvContext.ReadFile<AlgorithmCsv>($"{SettingsFolder}algorithms.csv");
        }
        #endregion

        #region Datasets
        private static DatasetCsv[] _datasets;

        public static DatasetCsv[] Datasets
        {
            get { return _datasets; }
            private set { _datasets = value; }
        }

        private static DatasetCsv[] GetDatasets()
        {
            return CsvContext.ReadFile<DatasetCsv>($"{SettingsFolder}datasets.csv");
        }

        public static DatasetCsv[] GetDatasets(AlgorithmCsv algorithm)
        {
            var results = Datasets.Where(c => c.Feature == algorithm.Feature);
            if (!string.IsNullOrWhiteSpace(algorithm.Transformation))
            {
                results = results.Where(c => c.Transformation == algorithm.Transformation);
            }
            return results.ToArray();
        }
        #endregion

        #region EnsembleMethods

        private static NameAlias[] _ensembleMethods;

        public static NameAlias[] EnsembleMethods
        {
            get { return _ensembleMethods; }
            set { _ensembleMethods = value; }
        }

        public static NameAlias[] GetEnsembleMethods()
        {
            NameAlias he = new NameAlias() { Name = "Hard/Euclidean", Alias = "HE" };
            NameAlias gv1 = new NameAlias() { Name = "GV1", Alias = "GV1" };
            NameAlias gv3 = new NameAlias() { Name = "GV3", Alias = "GV3" };
            NameAlias hm = new NameAlias() { Name = "Hard/Manhattan", Alias = "hm" };
            //NameAlias hs = new NameAlias() { Name = "Hard/Symdiff", Alias = "hard/symdiff" };
            NameAlias[] results = new[] { he, gv1, gv3, hm };
            return results;
        }

        #endregion

        static MiSettings()
        {
            Algorithms = GetAlgorithms();
            Datasets = GetDatasets();
            EnsembleMethods = GetEnsembleMethods();
            Applications = GetApplications();
        }

    }
}
