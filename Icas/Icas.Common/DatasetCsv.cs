using Ezfx.Csv;

namespace Icas.Common
{

    [CsvObject(HasHeader = true, Delimiter = ",", MappingType = CsvMappingType.Title)]
    public class DatasetCsv
    {
        [SystemCsvColumn(Name = "Name", Ordinal = 1)]
        public string Name { get; set; }

        [SystemCsvColumn(Name = "Feature", Ordinal = 3)]
        public string Feature { get; set; }

        [SystemCsvColumn(Name = "Transformation", Ordinal = 4)]
        public string Transformation { get; set; }

        [SystemCsvColumn(Name = "Degradome")]
        public string Degradome { get; set; }


        [SystemCsvColumn(Name = "CS_Length")]
        public int CsLength { get; set; }


        [SystemCsvColumn(Name = "X_File")]
        public string XFile { get; set; }


        [SystemCsvColumn(Name = "CE_File")]
        public string CeFile { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
