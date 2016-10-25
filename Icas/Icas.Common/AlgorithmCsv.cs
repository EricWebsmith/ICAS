using Ezfx.Csv;

namespace Icas.Common
{


    [CsvObject(HasHeader = true, Delimiter = ",", MappingType = CsvMappingType.Title)]
    public class AlgorithmCsv
    {
        [SystemCsvColumn(Name = "Name", Ordinal = 1)]
        public string Name { get; set; }

        [SystemCsvColumn(Name = "Script", Ordinal = 2)]
        public string Script { get; set; }

        [SystemCsvColumn(Name = "Feature", Ordinal = 3)]
        public string Feature { get; set; }

        [SystemCsvColumn(Name = "Transformation", Ordinal = 4)]
        public string Transformation { get; set; }


        [SystemCsvColumn(Name = "CanFixK", Ordinal = 5)]
        public bool CanFixK { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
