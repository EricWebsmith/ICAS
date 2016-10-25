using RDotNet;
using System.Diagnostics;
using System.IO;

namespace Icas.Common
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


    }
}
