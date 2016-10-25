namespace Icas.UI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PositionHolderAlgorithmComboBox = new Icas.UI.Controls.AlgorithmComboBox();
            this.SuspendLayout();
            // 
            // PositionHolderAlgorithmComboBox
            // 
            this.PositionHolderAlgorithmComboBox.FormattingEnabled = true;
            this.PositionHolderAlgorithmComboBox.Location = new System.Drawing.Point(45, 183);
            this.PositionHolderAlgorithmComboBox.Name = "PositionHolderAlgorithmComboBox";
            this.PositionHolderAlgorithmComboBox.Size = new System.Drawing.Size(190, 21);
            this.PositionHolderAlgorithmComboBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.PositionHolderAlgorithmComboBox);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private Controls.AlgorithmComboBox PositionHolderAlgorithmComboBox;
    }
}