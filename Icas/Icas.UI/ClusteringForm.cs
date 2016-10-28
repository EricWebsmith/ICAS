using Icas.Common;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Icas.UI
{
    public partial class ClusteringForm : Form
    {

        public ClusteringForm()
        {
            InitializeComponent();
            algorithmComboBox.DataSource = MiSettings.Algorithms;
        }

        private void ClusteringForm_Load(object sender, System.EventArgs e)
        {

        }

        private void algorithmComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var algorithm = (AlgorithmCsv)algorithmComboBox.SelectedItem;
            var datasets = MiSettings.GetDatasets(algorithm);
            datasetListBox.DataSource = datasets;
        }

        private void hpcScriptButton_Click(object sender, System.EventArgs e)
        {
            var algorithm = (AlgorithmCsv)algorithmComboBox.SelectedItem;
            var datasets = GetSelectedDatasets();


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("#!/bin/sh");
            sb.AppendLine("#BSUB -q short");
            sb.AppendLine($"#BSUB -J {algorithm.Name}");
            sb.AppendLine(@"#module add python/2.7.8");
            sb.AppendLine(@"#module add R/3.2.2");
            foreach (var dataset in datasets)
            {
                sb.AppendLine($"#{dataset.Name}");
                sb.AppendLine($"python job_{algorithm.Name}.py {dataset.Name} ");
                sb.AppendLine($"python job_oneway.py {algorithm.Name} {dataset.Name}");
                sb.AppendLine($"Rscript job_pairwise_comparison.R {algorithm.Name} {dataset.Name}");

            }

            string script = sb.Replace("\r", "").ToString();
            Clipboard.SetText(script);
            MessageBox.Show("The script has been copied to clipboard.");
            using (StreamWriter streamWriter = new StreamWriter($"{Config.WorkingFolder}\\job_{algorithm.Name}.bsub"))
            {
                streamWriter.Write(script);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        private  void hpcContinueButton_Click(object sender, System.EventArgs e)
        {
            hpcContinueButton.Enabled = false;
             ContinueFromHpc();
            hpcContinueButton.Enabled = true;
        }

        private  void ContinueFromHpc()
        {
            var algorithm = (AlgorithmCsv)algorithmComboBox.SelectedItem;
            var datasets = GetSelectedDatasets();
            Clustering.Cluster.RunIndividual(algorithm, datasets, false);
            Clustering.Cluster.Summarize(algorithm);
        }

        private async void runButton_Click(object sender, System.EventArgs e)
        {
            runButton.Enabled = false;
            await Run();
            runButton.Enabled = true;
        }

        private async Task Run()
        {
            var algorithm = (AlgorithmCsv)algorithmComboBox.SelectedItem;
            var datasets = GetSelectedDatasets();
            Clustering.Cluster.RunIndividual(algorithm, datasets, true);
            Clustering.Cluster.Summarize(algorithm);
        }

        private DatasetCsv[] GetSelectedDatasets()
        {
            //get the selected datasets
            List<DatasetCsv> datasets = new List<DatasetCsv>();
            foreach (var item in datasetListBox.SelectedItems)
            {
                datasets.Add((DatasetCsv)item);
            }
            return datasets.ToArray();
        }
    }
}
