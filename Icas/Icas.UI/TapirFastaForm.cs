using Icas.DataPreprocessing;
using System;
using System.Windows.Forms;

namespace Icas.UI
{
    public partial class TapirFastaForm : Form
    {
        public TapirFastaForm()
        {
            InitializeComponent();
        }

        private void inputBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                inputTextBox.Text = fbd.FileName;
            }
        }

        private void outputBrowseButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog()==DialogResult.OK)
            {
                outputTextBox.Text = sfd.FileName;
            }
        }

        private void transformButton_Click(object sender, EventArgs e)
        {
            TapirUtility.Convert(
                inputTextBox.Text,
                outputTextBox.Text
                );
        }
    }
}
