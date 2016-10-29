using RDotNet;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Icas.Reporting
{
    public class Rmd
    {
        /*
         * require(knitr) # required for knitting from rmd to md
            require(markdown) # required for md to html 
            knit('job_report.Rmd', 'job_report.md') # creates md file
            markdownToHTML('job_report.md', 'job_report.html') # creates html file
            browseURL(paste('file://', file.path(getwd(),'job_report.html'), sep='')) # open file in browser
         * 
         */
        public static void ToHtml(string file)
        {
            //prepare parameters
            string ext = Path.GetExtension(file);
            string rmdFile = file.Replace("\\", "\\\\");
            string mdFile = file.Replace(ext, ".md").Replace("\\", "\\\\");
            string htmlFile = file.Replace(ext, ".html").Replace("\\", "/");

            REngine.SetEnvironmentVariables();
            // There are several options to initialize the engine, but by default the following suffice:
            REngine engine = REngine.GetInstance();

            engine.Evaluate("require(knitr)");
            engine.Evaluate("require(markdown)");
            var e = engine.Evaluate($"knit('{rmdFile}', '{mdFile}')");

            engine.Evaluate($"markdownToHTML('{mdFile}', '{htmlFile}', options=c('use_xhtml', 'base64_images'))");

            //engine.Evaluate($"browseURL(paste('file:///', file.path('{htmlFile}'), sep=''))");


            // you should always dispose of the REngine properly.
            // After disposing of the engine, you cannot reinitialize nor reuse it
            //engine.Dispose();
            Process.Start(htmlFile);
        }

        /// <summary>
        /// A = matrix( 
        ///+    c(2, 4, 3, 1, 5, 7), # the data elements 
        ///+    nrow=2,              # number of rows 
        ///+    ncol=3,              # number of columns 
        ///+    byrow = TRUE)        # fill matrix by rows 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static string PrintMatrix(double[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("matrix(c(");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j]);
                    sb.Append(", ");
                }
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append($"),nrow={matrix.GetLength(0)},ncol={matrix.GetLength(1)}, byrow = TRUE)\r\n");
            return sb.ToString();
        }

        public static string StartRBlock(string blockName)
        {
            return $"\r\n```{{r {blockName}}}\r\n";
        }

        public static string EndRBlock()
        {
            return "\r\n```\r\n";
        }

        public static string RComment(string comment)
        {
            return $"\r\n#{comment}\r\n";
        }

        public static string InsertImage(string file, string message = null)
        {
            return $"![{message}]({file.Replace("\\", "/")})\r\n\r\n";
        }
    }
}
