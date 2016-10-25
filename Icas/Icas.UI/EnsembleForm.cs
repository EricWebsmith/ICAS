using Ezfx.Csv;
using Icas.Clustering;
using Icas.Common;
using Icas.Reporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Icas.UI
{
    public partial class EnsembleForm : Form
    {
        StatisticalResultCsv[] clusterings = null;

        public EnsembleForm()
        {
            Clustering.Cluster.Summarize();
            clusterings = CsvContext.ReadFile<StatisticalResultCsv>($"{Config.WorkingFolder}\\results\\all.csv");
            clusterings = clusterings.OrderByDescending(c => c.significant_rate).ToArray();
            InitializeComponent();
        }

        private void EnsembleForm_Load(object sender, EventArgs e)
        {
            datasetComboBox.DataSource = MiSettings.Datasets;
            ensembleMethodcomboBox.DataSource = MiSettings.EnsembleMethods;
            ensembleNameTextBox.Text = GetEnsembleFolderName();
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            string dataset = datasetComboBox.SelectedItem.ToString();
            IOrderedEnumerable<StatisticalResultCsv> query = null;
            if (kiSelector.K == 0)
            {
                query = from d in clusterings where d.Dataset == dataset orderby d.Compactness orderby d.significant_rate descending select d;
            }
            else
            {
                query = from d in clusterings where d.Dataset == dataset && d.group_count == kiSelector.K orderby d.Compactness orderby d.significant_rate descending select d;
            }
            candidateDataGridView.DataSource = query.ToArray();
        }

        private async void ensembleButton_Click(object sender, EventArgs e)
        {
            if (candidateDataGridView.SelectedRows.Count < 3)
            {
                MessageBox.Show("Please select at least 3 rows!");
                return;
            }

            ensembleButton.Enabled = false;
            await EnsembleTask();
            ensembleNameTextBox.Text = GetEnsembleFolderName();
            //reload data source
            Clustering.Cluster.Summarize();
            clusterings = CsvContext.ReadFile<StatisticalResultCsv>($"{Config.WorkingFolder}\\results\\all.csv");
            clusterings = clusterings.OrderByDescending(c => c.significant_rate).ToArray();
            //re-search
            searchButton_Click(null, null);
            ensembleButton.Enabled = true;
        }

        private async Task EnsembleTask()
        {
            List<StatisticalResultCsv> selectedMembers = new List<StatisticalResultCsv>();
            for (int i = 0; i < candidateDataGridView.SelectedRows.Count; i++)
            {
                StatisticalResultCsv item = (StatisticalResultCsv)candidateDataGridView.SelectedRows[i].DataBoundItem;
                selectedMembers.Add(item);
            }
            int keep = 0;
            int.TryParse(keepNumericUpDown.Text, out keep);
            NameAlias na = (NameAlias)ensembleMethodcomboBox.SelectedItem;
            CSEnsemble.Run(ensembleNameTextBox.Text, na.Alias, keSelector.K, keep, selectedMembers);
        }

        private async void reportOkayButton_Click(object sender, EventArgs e)
        {
            if (candidateDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select one row!");
                return;
            }
            reportOkayButton.Enabled = false;
            StatisticalResultCsv item = (StatisticalResultCsv)candidateDataGridView.SelectedRows[0].DataBoundItem;
            Task t = new Task(() =>
            {
                Report.Run(item);
                if (InvokeRequired) // Line #1
                {
                    this.Invoke(new MethodInvoker(() => reportOkayButton.Enabled = true));
                    return;
                }
                else
                {
                    reportOkayButton.Enabled = true;
                }

            });

            t.Start();
            //reportOkayButton.Enabled = true;
        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (currenttb.Text == "")
            {

                MessageBox.Show(string.Format("Empty field {0}", currenttb.Name.Substring(3)));
                e.Cancel = true;
            }
            else

            {
                e.Cancel = false;
            }
        }


        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(keepNumericUpDown.Text))
            {
                keepNumericUpDown.BorderStyle = BorderStyle.None;
                Pen p = new Pen(Color.Red);
                Graphics g = e.Graphics;
                int variance = 4;
                g.DrawRectangle(p, new Rectangle(keepNumericUpDown.Location.X - variance, keepNumericUpDown.Location.Y - variance, keepNumericUpDown.Width + variance, keepNumericUpDown.Height + variance));
            }
            else
            {
                keepNumericUpDown.BorderStyle = BorderStyle.FixedSingle;
            }
        }
    }
}
