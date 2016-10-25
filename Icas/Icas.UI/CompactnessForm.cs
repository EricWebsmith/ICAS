using Ezfx.Csv.Ex;
using Icas.Clustering;
using Icas.Common;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Icas.UI
{
    public partial class CompactnessForm : Form
    {
        private string[] files = null;

        public CompactnessForm()
        {
            InitializeComponent();
        }

        private void xBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                xTextBox.Text = ofd.FileName;
            }
        }

        private void labelsBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                labelsTextBox.Text = string.Join(";", ofd.FileNames);
                files = ofd.FileNames;
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            //Compactness
            double[,] x = CsvMatrix.Read(xTextBox.Text);
            double[] compactnessArr = new double[files.Length];
            resultTextBox.Text = string.Empty;
            double[] mseArr = new double[files.Length];
            mseResultTextBox.Text = string.Empty;
            for (int i = 0; i < files.Length; i++)
            {
                int[] labels = FileExtension.Readlabels(files[i]);
                compactnessArr[i] = Metrics.Compactness(x, labels);
                mseArr[i] = Metrics.MeanSquaredError(x, labels);
                resultTextBox.Text += compactnessArr[i].ToString() + "\r\n";
                mseResultTextBox.Text += mseArr[i].ToString("0.00000000") + "\r\n";
            }

            if (files.Length > 1)
            {
                resultTextBox.Text += "Avg:" + compactnessArr.Average().ToString("0.00000000");
                mseResultTextBox.Text += "Avg:" + mseArr.Average().ToString("0.00000000");
            }

            Clipboard.SetText(resultTextBox.Text + "\r\n" + mseResultTextBox.Text);
            //Mean Squared Error


        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(resultTextBox.Text);
        }

        private void mseCopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(mseResultTextBox.Text);
        }
    }
}
