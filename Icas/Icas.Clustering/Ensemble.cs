using RDotNet;
using System;

namespace Icas.Clustering
{
    public static class Ensemble
    {

        public static double Similarity(SimilarityType type, params string[] files)
        {
            REngine.SetEnvironmentVariables();
            // There are several options to initialize the engine, but by default the following suffice:
            REngine engine = REngine.GetInstance();

            engine.Evaluate("library(clue)");

            string ensemble_statement = "ensemble = cl_ensemble(";
            for (int i = 0; i < files.Length; i++)
            {
                string statement = string.Empty;
                statement += $"array = read.csv(\"{files[i].Replace("\\", "\\\\")}\", header = FALSE)$V1\r\n";
                statement += "if(is.na(array[1])){";
                statement += $"  P{i} = as.cl_partition(read.csv(\"{files[i].Replace("\\", "\\\\")}\", header = TRUE)$V1)";
                statement += "}else{";
                statement += $"  P{i} = as.cl_partition(array)";
                statement += "}";
                engine.Evaluate(statement);
                ensemble_statement += $"P{i},";
            }
            ensemble_statement = ensemble_statement.TrimEnd(new char[] { ',' }) + ")";
            engine.Evaluate(ensemble_statement);
            engine.Evaluate("ag=cl_agreement(ensemble)");
            var ag = engine.Evaluate("ag");
            Console.WriteLine(ag.ToString());
            var mean = engine.Evaluate($"mean(cl_agreement(ensemble, method = \"{type}\"))").AsVector();
            double result = (double)mean[0];

            // you should always dispose of the REngine properly.
            // After disposing of the engine, you cannot reinitialize nor reuse it
            //engine.Dispose();
            return result;
        }
    }
}
