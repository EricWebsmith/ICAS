using Icas.UI.Controls;
using System;
using System.Windows.Forms;

namespace Icas.UI
{
    public partial class Form1 : Form
    {

        private AlgorithmComboBox fixedKAlgorithmComboBox;

        public Form1()
        {
            InitializeComponent();
            var holder = PositionHolderAlgorithmComboBox;
            holder.Visible = false;
            fixedKAlgorithmComboBox = new Icas.UI.Controls.AlgorithmComboBox(c => c.CanFixK);
            fixedKAlgorithmComboBox.Name = "fixedKAlgorithmComboBox";
            fixedKAlgorithmComboBox.Location = holder.Location;
            fixedKAlgorithmComboBox.Size = new System.Drawing.Size(holder.Width, holder.Height);
            holder.Parent.Controls.Add(fixedKAlgorithmComboBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kSelector1_ValueChanged(object sender, EventArgs e)
        {
            CausesValidation = true;
            Validate();
            Form1_Paint(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
