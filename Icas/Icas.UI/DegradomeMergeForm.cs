using Icas.DataPreprocessing;
using System;
using System.Windows.Forms;

namespace Icas.UI
{
    public partial class DegradomeMergeForm : Form
    {
        public DegradomeMergeForm()
        {
            InitializeComponent();
        }

        private void degradomeFile1button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dialogueResult = ofd.ShowDialog();
            if (dialogueResult == DialogResult.OK)
            {
                degradomeFile1TextBox.Text = ofd.FileName;
            }
        }

        private void degradomeFile2button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dialogueResult = ofd.ShowDialog();
            if (dialogueResult == DialogResult.OK)
            {
                degradomeFile2TextBox.Text = ofd.FileName;
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            float result = Degradome.CorrelationTest(
                degradomeFile1TextBox.Text,
                degradomeFile2TextBox.Text,
                rpkmFileTextBox.Text);
            resultTextBox.Text = result.ToString();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(resultTextBox.Text);
        }

        private void saveRpkmButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            var dialogResult = sfd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                rpkmFileTextBox.Text = sfd.FileName;
            }
        }

        private void mergeButton_Click(object sender, EventArgs e)
        {
            Degradome.Merge(degradomeFile1TextBox.Text,
                degradomeFile2TextBox.Text,
                mergedFileTextBox.Text);
        }
    }
}
