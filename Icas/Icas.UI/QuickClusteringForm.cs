using Icas.Clustering;
using Icas.Common;
using Icas.Reporting;
using Icas.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Icas.UI
{
    public partial class QuickClusteringForm : Form
    {
        private AlgorithmComboBox fixedKAlgorithmComboBox;
        public QuickClusteringForm()
        {
            InitializeComponent();
            var holder = positionHolderAlgorithmComboBox;
            holder.Visible = false;
            fixedKAlgorithmComboBox = new AlgorithmComboBox(c => c.CanFixK);
            fixedKAlgorithmComboBox.Name = "fixedKAlgorithmComboBox";
            fixedKAlgorithmComboBox.Location = holder.Location;
            fixedKAlgorithmComboBox.Size = new System.Drawing.Size(holder.Width, holder.Height);
            fixedKAlgorithmComboBox.SelectedIndexChanged += this.fixedKAlgorithmComboBox_SelectedIndexChanged;

            holder.Parent.Controls.Add(fixedKAlgorithmComboBox);
        }

        private void fixedKAlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            myDatasetComboBox.Filter(fixedKAlgorithmComboBox.SelectedAlgorithm);
        }

        private async void runButton_Click(object sender, EventArgs e)
        {
            runButton.Enabled = false;
            await Run();
            runButton.Enabled = true;
        }

        private async Task Run()
        {
            var results = Clustering.Cluster.RunIndividual(fixedKAlgorithmComboBox.SelectedAlgorithm,
                myDatasetComboBox.SelectedDataset, myKSelector.K, true);
            var individualResults = results.Where(c => c.group_count == myKSelector.K).Where(c => c.significant_rate > results.First().significant_rate - 0.05).ToArray();
            if (individualResults.Length == 0)
            {
                MessageBox.Show("Failed to find any clustering that meets the criterion");
            }


            if (individualResults.Length == 1)
            {
                Report.Run(individualResults[0]);
                return;
            }

            var ensembleRusults = CSEnsemble.Run(GetEnsembleFolderName(), "HE", myKSelector.K, 5, individualResults.ToArray());
            List<StatisticalResultCsv> all = new List<StatisticalResultCsv>();
            all.AddRange(individualResults);
            all.AddRange(ensembleRusults);
            all = all.OrderBy(c => c.significant_rate).ThenBy(c => c.Compactness).ToList();
            Report.Run(all.First());
        }

        private string GetEnsembleFolderName()
        {
            int index = 1;
            while (Directory.Exists($"{Config.WorkingFolder}\\ensemble{index}\\"))
            {
                index++;
            }
            return $"ensemble{index}";
        }
    }
}
