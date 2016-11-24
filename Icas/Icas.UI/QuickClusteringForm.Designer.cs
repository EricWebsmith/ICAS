namespace Icas.UI
{
    partial class QuickClusteringForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.myDatasetComboBox = new Icas.UI.Controls.DatasetComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.myKSelector = new Icas.UI.Controls.KSelector();
            this.positionHolderAlgorithmComboBox = new Icas.UI.Controls.AlgorithmComboBox();
            this.runButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myKSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Algorithm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dataset:";
            // 
            // myDatasetComboBox
            // 
            this.myDatasetComboBox.FormattingEnabled = true;
            this.myDatasetComboBox.Location = new System.Drawing.Point(81, 39);
            this.myDatasetComboBox.Name = "myDatasetComboBox";
            this.myDatasetComboBox.Size = new System.Drawing.Size(340, 21);
            this.myDatasetComboBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "K(Clusters):";
            // 
            // myKSelector
            // 
            this.myKSelector.Location = new System.Drawing.Point(371, 13);
            this.myKSelector.Maximum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.myKSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.myKSelector.Name = "myKSelector";
            this.myKSelector.Size = new System.Drawing.Size(50, 20);
            this.myKSelector.TabIndex = 5;
            this.myKSelector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // positionHolderAlgorithmComboBox
            // 
            this.positionHolderAlgorithmComboBox.FormattingEnabled = true;
            this.positionHolderAlgorithmComboBox.Location = new System.Drawing.Point(81, 12);
            this.positionHolderAlgorithmComboBox.Name = "positionHolderAlgorithmComboBox";
            this.positionHolderAlgorithmComboBox.Size = new System.Drawing.Size(215, 21);
            this.positionHolderAlgorithmComboBox.TabIndex = 6;
            this.positionHolderAlgorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.fixedKAlgorithmComboBox_SelectedIndexChanged);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(181, 66);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // QuickClusteringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 93);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.positionHolderAlgorithmComboBox);
            this.Controls.Add(this.myKSelector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.myDatasetComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QuickClusteringForm";
            this.Text = "Quick Clustering";
            ((System.ComponentModel.ISupportInitialize)(this.myKSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controls.DatasetComboBox myDatasetComboBox;
        private System.Windows.Forms.Label label3;
        private Controls.KSelector myKSelector;
        private Controls.AlgorithmComboBox positionHolderAlgorithmComboBox;
        private System.Windows.Forms.Button runButton;
    }
}