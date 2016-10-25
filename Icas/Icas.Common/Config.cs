using System;
using System.Collections.Generic;
using System.Linq;

namespace Icas.Common
{
    public static class Config
    {
        public const string JobOnewayPy = "job_oneway.py";
        public const string JobPairwiseComparisonR = "job_pairwise_comparison.R";
        public const string PairwiseComparisonCsv = "pairwise_comparison.csv";

        const string DegradomeWt = "degradome_wt";
        const string DegradomeXrn4 = "degradome_xrn4";
        const string Cdna = "cdna";
        const string CleavageBase = "cleavage_efficiency_base";
        const string MicroRna = "microRNA";
        const string AllCleavageSite = "all_cleavage_site";
        const string Reactivity = "reactivity";

        public static string WorkingFolder
        {
            get
            {
                var keys = System.Configuration.ConfigurationManager.AppSettings.AllKeys;
                if (keys.Contains(Environment.MachineName))
                {
                    return System.Configuration.ConfigurationManager.AppSettings[Environment.MachineName];
                }

                //throw new Exception("Please set up path" + keys.Length.ToString() + string.Join(",", keys));
                return @"C:\Icas.Test";
            }
        }

        public static string CsStrucFolder => $"{WorkingFolder}\\cs_rna_struct\\";


        public static string ReactivityFile
        {
            get
            {
                return WorkingFolder + System.Configuration.ConfigurationManager.AppSettings[Reactivity];
            }
        }

        public static string DegradomeWTFile
        {
            get
            {
                return WorkingFolder + System.Configuration.ConfigurationManager.AppSettings[DegradomeWt];
            }
        }

        public static string DegradomeXrn4File
        {
            get
            {
                return WorkingFolder + System.Configuration.ConfigurationManager.AppSettings[DegradomeXrn4];
            }
        }


        public static string GetDegradomeFile(DegradomeType dType)
        {
            switch (dType)
            {
                case DegradomeType.wt:
                    return DegradomeWTFile;
                case DegradomeType.xrn4:
                    return DegradomeXrn4File;
                default:
                    throw new Exception("wrong degradome type");
            }
        }

        public static string CleavageBaseFile
        {
            get
            {
                return WorkingFolder + System.Configuration.ConfigurationManager.AppSettings[CleavageBase];
            }
        }

        public static string MicroRnaFile
        {
            get
            {
                return WorkingFolder + System.Configuration.ConfigurationManager.AppSettings[MicroRna];
            }
        }

        public static string CdnaFile
        {
            get
            {
                return WorkingFolder + System.Configuration.ConfigurationManager.AppSettings[Cdna];
            }
        }

        public static string AllCleavegSiteFile
        {
            get
            {
                return WorkingFolder + System.Configuration.ConfigurationManager.AppSettings[AllCleavageSite];
            }
        }

        private static List<string> _validNames = null;
        public static List<string> ValidNames
        {
            get
            {
                if (_validNames == null)
                {
                    _validNames = FileExtension.ReadList(Config.WorkingFolder + "genes_have_all.txt").ToList();
                }
                return _validNames;
            }
        }
    }
}
