using Ezfx.Csv;

namespace Icas.Common
{
    [CsvObject(HasHeader = true, Delimiter = ",", MappingType = CsvMappingType.Title)]
    public class ApplicationCsv
    {
        [SystemCsvColumn(Name = "Name", Ordinal = 1)]
        public string Name { get; set; }

        [SystemCsvColumn(Name = "Extension", Ordinal = 2)]
        public string Extension { get; set; }
    }
}
