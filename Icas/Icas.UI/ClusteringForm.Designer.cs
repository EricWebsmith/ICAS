namespace Icas.UI
{
    partial class ClusteringForm
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
            this.algorithmComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hpcContinueButton = new System.Windows.Forms.Button();
            this.hpcScriptButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.datasetListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.runButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // algorithmComboBox
            // 
            this.algorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algorithmComboBox.FormattingEnabled = true;
            this.algorithmComboBox.Location = new System.Drawing.Point(66, 6);
            this.algorithmComboBox.Name = "algorithmComboBox";
            this.algorithmComboBox.Size = new System.Drawing.Size(225, 21);
            this.algorithmComboBox.TabIndex = 8;
            this.algorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.algorithmComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Algorithm:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hpcContinueButton);
            this.groupBox1.Controls.Add(this.hpcScriptButton);
            this.groupBox1.Location = new System.Drawing.Point(10, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 52);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Run with HPC";
            // 
            // hpcContinueButton
            // 
            this.hpcContinueButton.Location = new System.Drawing.Point(141, 19);
            this.hpcContinueButton.Name = "hpcContinueButton";
            this.hpcContinueButton.Size = new System.Drawing.Size(134, 23);
            this.hpcContinueButton.TabIndex = 1;
            this.hpcContinueButton.Text = "Continue From HPC";
            this.hpcContinueButton.UseVisualStyleBackColor = true;
            this.hpcContinueButton.Click += new System.EventHandler(this.hpcContinueButton_Click);
            // 
            // hpcScriptButton
            // 
            this.hpcScriptButton.Location = new System.Drawing.Point(9, 19);
            this.hpcScriptButton.Name = "hpcScriptButton";
            this.hpcScriptButton.Size = new System.Drawing.Size(126, 23);
            this.hpcScriptButton.TabIndex = 0;
            this.hpcScriptButton.Text = "Generate HPC Script";
            this.hpcScriptButton.UseVisualStyleBackColor = true;
            this.hpcScriptButton.Click += new System.EventHandler(this.hpcScriptButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Datasets:";
            // 
            // datasetListBox
            // 
            this.datasetListBox.FormattingEnabled = true;
            this.datasetListBox.Location = new System.Drawing.Point(10, 52);
            this.datasetListBox.Name = "datasetListBox";
            this.datasetListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.datasetListBox.Size = new System.Drawing.Size(281, 199);
            this.datasetListBox.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.runButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 51);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Run without HPC";
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(7, 19);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(266, 23);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // ClusteringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 370);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.datasetListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.algorithmComboBox);
            this.Name = "ClusteringForm";
            this.Text = "Clustering";
            this.Load += new System.EventHandler(this.ClusteringForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox algorithmComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button hpcContinueButton;
        private System.Windows.Forms.Button hpcScriptButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox datasetListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button runButton;
    }
}