using Ezfx.Csv;

namespace Icas.Clustering
{
    [CsvObject(HasHeader = true, Delimiter = ",", MappingType =CsvMappingType.Title)]
    public class PairwiseComparisonCsv
    {
        [SystemCsvColumn(Name = "file", Ordinal = 1)]
        public string File { get; set; }

        [SystemCsvColumn(Name = "oneway", Ordinal = 2)]
        public double Oneway { get; set; }

        [SystemCsvColumn(Name = "group_count", Ordinal = 3)]
        public int group_count { get; set; }

        [SystemCsvColumn(Name = "significant_pairs", Ordinal = 4)]
        public int significant_pairs { get; set; }

        [SystemCsvColumn(Name = "pair_count", Ordinal = 5)]
        public int pair_count { get; set; }

        [SystemCsvColumn(Name = "significant_rate", Ordinal = 6)]
        public double significant_rate { get; set; }
    }
}
