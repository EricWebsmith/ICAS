namespace Icas.UI
{
    partial class CompactnessForm
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
            this.labelsLabel = new System.Windows.Forms.Label();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.labelsTextBox = new System.Windows.Forms.TextBox();
            this.xBrowseButton = new System.Windows.Forms.Button();
            this.labelsBrowseButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mseCopyButton = new System.Windows.Forms.Button();
            this.mseResultTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "x:";
            // 
            // labelsLabel
            // 
            this.labelsLabel.AutoSize = true;
            this.labelsLabel.Location = new System.Drawing.Point(12, 41);
            this.labelsLabel.Name = "labelsLabel";
            this.labelsLabel.Size = new System.Drawing.Size(37, 13);
            this.labelsLabel.TabIndex = 1;
            this.labelsLabel.Text = "labels:";
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(98, 12);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(310, 20);
            this.xTextBox.TabIndex = 2;
            this.xTextBox.Text = "C:\\JICWork\\cs_reactivity_wt_121.csv";
            // 
            // labelsTextBox
            // 
            this.labelsTextBox.Location = new System.Drawing.Point(98, 38);
            this.labelsTextBox.Name = "labelsTextBox";
            this.labelsTextBox.Size = new System.Drawing.Size(310, 20);
            this.labelsTextBox.TabIndex = 3;
            this.labelsTextBox.Text = "C:\\JICWork\\kmeans\\length_71\\wt\\individuals\\kmeans_k_3_init_k-means++_round_1_labe" +
    "ls.csv";
            // 
            // xBrowseButton
            // 
            this.xBrowseButton.Location = new System.Drawing.Point(414, 10);
            this.xBrowseButton.Name = "xBrowseButton";
            this.xBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.xBrowseButton.TabIndex = 4;
            this.xBrowseButton.Text = "Browse...";
            this.xBrowseButton.UseVisualStyleBackColor = true;
            this.xBrowseButton.Click += new System.EventHandler(this.xBrowseButton_Click);
            // 
            // labelsBrowseButton
            // 
            this.labelsBrowseButton.Location = new System.Drawing.Point(414, 36);
            this.labelsBrowseButton.Name = "labelsBrowseButton";
            this.labelsBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.labelsBrowseButton.TabIndex = 5;
            this.labelsBrowseButton.Text = "Browse...";
            this.labelsBrowseButton.UseVisualStyleBackColor = true;
            this.labelsBrowseButton.Click += new System.EventHandler(this.labelsBrowseButton_Click);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(216, 64);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 6;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.copyButton);
            this.groupBox1.Controls.Add(this.resultTextBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 381);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compactness";
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(6, 352);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 12;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(6, 19);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(222, 327);
            this.resultTextBox.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mseCopyButton);
            this.groupBox2.Controls.Add(this.mseResultTextBox);
            this.groupBox2.Location = new System.Drawing.Point(255, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 381);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mean Square Error";
            // 
            // mseCopyButton
            // 
            this.mseCopyButton.Location = new System.Drawing.Point(6, 352);
            this.mseCopyButton.Name = "mseCopyButton";
            this.mseCopyButton.Size = new System.Drawing.Size(75, 23);
            this.mseCopyButton.TabIndex = 12;
            this.mseCopyButton.Text = "Copy";
            this.mseCopyButton.UseVisualStyleBackColor = true;
            this.mseCopyButton.Click += new System.EventHandler(this.mseCopyButton_Click);
            // 
            // mseResultTextBox
            // 
            this.mseResultTextBox.Location = new System.Drawing.Point(6, 19);
            this.mseResultTextBox.Multiline = true;
            this.mseResultTextBox.Name = "mseResultTextBox";
            this.mseResultTextBox.Size = new System.Drawing.Size(222, 327);
            this.mseResultTextBox.TabIndex = 11;
            // 
            // CompactnessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 487);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.labelsBrowseButton);
            this.Controls.Add(this.xBrowseButton);
            this.Controls.Add(this.labelsTextBox);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.labelsLabel);
            this.Controls.Add(this.label1);
            this.Name = "CompactnessForm";
            this.Text = "Compactness and Mean Squared Error";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelsLabel;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox labelsTextBox;
        private System.Windows.Forms.Button xBrowseButton;
        private System.Windows.Forms.Button labelsBrowseButton;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button mseCopyButton;
        private System.Windows.Forms.TextBox mseResultTextBox;
    }
}