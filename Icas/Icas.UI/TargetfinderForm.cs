using Icas.DataPreprocessing;
using System;
using System.Windows.Forms;

namespace Icas.UI
{
    public partial class TargetfinderForm : Form
    {
        public TargetfinderForm()
        {
            InitializeComponent();
        }

        private void inputBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                inputTextBox.Text = fbd.SelectedPath;
            }
        }

        private void outputBrowseButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                outputTextBox.Text = sfd.FileName;
            }
        }

        private void transformButton_Click(object sender, EventArgs e)
        {
            Targetfinder.Convert(
                inputTextBox.Text,
                outputTextBox.Text
                );
        }
    }
}
