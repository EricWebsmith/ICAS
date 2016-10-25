using Icas.Clustering;
using System;
using System.Windows.Forms;

namespace Icas.UI
{
    public partial class ClusteringSimilarityForm : Form
    {
        public ClusteringSimilarityForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            //fileListBox.Items.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                fileListBox.Items.AddRange(ofd.FileNames);
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            string[] items = new string[fileListBox.Items.Count];
            for(int i=0;i<items.Length;i++)
            {
                items[i] = fileListBox.Items[i].ToString();
            }
            SimilarityType type = SimilarityType.Euclidean;
            Enum.TryParse<SimilarityType>(similarityTypeComboBox.SelectedValue.ToString(), out type);
            resultTextBox.Text = Ensemble.Similarity(type, items).ToString("0.00000");
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(resultTextBox.Text);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            fileListBox.Items.Clear();
        }

        private void ClusteringSimilarityForm_Load(object sender, EventArgs e)
        {
            similarityTypeComboBox.DataSource = Enum.GetValues(typeof(SimilarityType));
        }
    }
}
