using Icas.Clustering;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Icas.UI
{
    public partial class ClusteringForm_old : Form
    {
        FeatureType dataType = FeatureType.Reactivity;
        bool scriptHasRun = false;

        public ClusteringForm_old()
        {
            InitializeComponent();
        }

        public ClusteringForm_old(FeatureType dataType)
        {
            this.dataType = dataType;
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            fileListBox.Items.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Python files|*.py";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileListBox.Items.AddRange(ofd.FileNames);
            }
        }

        private void ClusteringForm_Load(object sender, EventArgs e)
        {
            if (dataType == FeatureType.Reactivity)
            {
                reactivityRadioButton.Checked = true;
                rnaDistanceRadioButton.Checked = false;
            }
            else
            {
                reactivityRadioButton.Checked = false;
                rnaDistanceRadioButton.Checked = true;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string[] items = new string[fileListBox.Items.Count];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = fileListBox.Items[i].ToString();
            }

            string[] methods = keysTextBox.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> results = new List<string>();
            results.AddRange(items);
            results.AddRange(methods);

            //Clustering.Clustering.RunAll(results.ToArray(), !scriptHasRun, dataType);
        }

        private void reactivityRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (reactivityRadioButton.Checked)
            {
                dataType = FeatureType.Reactivity;
            }
        }

        private void rnaDistanceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rnaDistanceRadioButton.Checked)
            {
                dataType = FeatureType.RnaDistance;
            }
        }

        private void scriptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            scriptHasRun = scriptCheckBox.Checked;
        }
    }
}
