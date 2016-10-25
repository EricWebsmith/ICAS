using Ezfx.Csv;

namespace Icas.Clustering
{
    [CsvObject(HasHeader = true, Delimiter = ",")]
    public class StatisticalResultCsv
    {
        [SystemCsvColumn(Name = "DataType", Ordinal = 1)]
        public string DataType { get; set; }

        [SystemCsvColumn(Name = "Method", Ordinal = 1)]
        public string Method { get; set; }

        [SystemCsvColumn(Name = "Degredome", Ordinal = 1)]
        public string Degredome { get; set; }

        [SystemCsvColumn(Name = "Dataset", Ordinal = 1)]
        public string Dataset { get; set; }

        [SystemCsvColumn(Name = "Transformation", Ordinal = 1)]
        public string Transformation { get; set; }

        [SystemCsvColumn(Name = "Length", Ordinal = 1)]
        public int Length { get; set; }

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

        [SystemCsvColumn(Name = "Compactness", Ordinal = 7)]
        public double Compactness { get; set; }

        [SystemCsvColumn(Name = "Best", Ordinal = 7)]
        public bool Best { get; set; }
    }
}
