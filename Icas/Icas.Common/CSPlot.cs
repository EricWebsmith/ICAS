using Icas.ViennaRnaWrapper;
using Svg;
using System.IO;

namespace Icas.Common
{
    public static class CSPlot
    {
        public static void Generate(DegradomeType dType, int length, int index)
        {
            string dotBracket = GetStruct(dType, length, index);
            string outputFile = RnaPlotWrapper.Plot(dotBracket);

            File.Copy(outputFile, $"{Config.WorkingFolder}\\cs_rna_struct\\plot\\{dType}_{length}_{index}.svg");
            Svg.SvgDocument doc = SvgDocument.Open(outputFile);
            doc.Draw().Save($"{Config.WorkingFolder}\\cs_rna_struct\\plot\\{dType}_{length}_{index}.png");
        }

        private static string GetStruct(DegradomeType dType, int length, int index)
        {
            string structFolder = $"{Config.WorkingFolder}\\cs_rna_struct\\";
            string structFile = $"{structFolder}\\cs_structure_{length}_{dType}.txt";
            string dotBracket = "";
            using (StreamReader sr = new StreamReader(structFile))
            {
                for (int i = 0; i < index; i++)
                {
                    sr.ReadLine();
                }
                dotBracket = sr.ReadLine();
            }
            return dotBracket;
        }
    }
}
