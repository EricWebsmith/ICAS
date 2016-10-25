namespace Icas.UI
{
    partial class DegradomeMergeForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveRpkmButton = new System.Windows.Forms.Button();
            this.rpkmFileTextBox = new System.Windows.Forms.TextBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.degradomeFile2button = new System.Windows.Forms.Button();
            this.degradomeFile2TextBox = new System.Windows.Forms.TextBox();
            this.degradomeFile1button = new System.Windows.Forms.Button();
            this.degradomeFile1TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mergedFileBrowseButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.mergeButton = new System.Windows.Forms.Button();
            this.mergedFileTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.saveRpkmButton);
            this.groupBox1.Controls.Add(this.rpkmFileTextBox);
            this.groupBox1.Controls.Add(this.copyButton);
            this.groupBox1.Controls.Add(this.resultTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.testButton);
            this.groupBox1.Controls.Add(this.degradomeFile2button);
            this.groupBox1.Controls.Add(this.degradomeFile2TextBox);
            this.groupBox1.Controls.Add(this.degradomeFile1button);
            this.groupBox1.Controls.Add(this.degradomeFile1TextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 175);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Correlation Test";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(429, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Optional. Save RPKM of the two degradome files and form a 2 by n matrix. This is " +
    "for plots";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Save RPKM:";
            // 
            // saveRpkmButton
            // 
            this.saveRpkmButton.Location = new System.Drawing.Point(449, 72);
            this.saveRpkmButton.Name = "saveRpkmButton";
            this.saveRpkmButton.Size = new System.Drawing.Size(75, 23);
            this.saveRpkmButton.TabIndex = 25;
            this.saveRpkmButton.Text = "Browse...";
            this.saveRpkmButton.UseVisualStyleBackColor = true;
            this.saveRpkmButton.Click += new System.EventHandler(this.saveRpkmButton_Click);
            // 
            // rpkmFileTextBox
            // 
            this.rpkmFileTextBox.Location = new System.Drawing.Point(86, 74);
            this.rpkmFileTextBox.Name = "rpkmFileTextBox";
            this.rpkmFileTextBox.Size = new System.Drawing.Size(357, 20);
            this.rpkmFileTextBox.TabIndex = 24;
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(449, 140);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 23;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Enabled = false;
            this.resultTextBox.Location = new System.Drawing.Point(86, 142);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(357, 20);
            this.resultTextBox.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Result:";
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(9, 113);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(515, 23);
            this.testButton.TabIndex = 20;
            this.testButton.Text = "Pearson Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // degradomeFile2button
            // 
            this.degradomeFile2button.Location = new System.Drawing.Point(449, 46);
            this.degradomeFile2button.Name = "degradomeFile2button";
            this.degradomeFile2button.Size = new System.Drawing.Size(75, 23);
            this.degradomeFile2button.TabIndex = 19;
            this.degradomeFile2button.Text = "Browse...";
            this.degradomeFile2button.UseVisualStyleBackColor = true;
            this.degradomeFile2button.Click += new System.EventHandler(this.degradomeFile2button_Click);
            // 
            // degradomeFile2TextBox
            // 
            this.degradomeFile2TextBox.Location = new System.Drawing.Point(86, 48);
            this.degradomeFile2TextBox.Name = "degradomeFile2TextBox";
            this.degradomeFile2TextBox.Size = new System.Drawing.Size(357, 20);
            this.degradomeFile2TextBox.TabIndex = 18;
            // 
            // degradomeFile1button
            // 
            this.degradomeFile1button.Location = new System.Drawing.Point(449, 20);
            this.degradomeFile1button.Name = "degradomeFile1button";
            this.degradomeFile1button.Size = new System.Drawing.Size(75, 23);
            this.degradomeFile1button.TabIndex = 17;
            this.degradomeFile1button.Text = "Browse...";
            this.degradomeFile1button.UseVisualStyleBackColor = true;
            this.degradomeFile1button.Click += new System.EventHandler(this.degradomeFile1button_Click);
            // 
            // degradomeFile1TextBox
            // 
            this.degradomeFile1TextBox.Location = new System.Drawing.Point(86, 22);
            this.degradomeFile1TextBox.Name = "degradomeFile1TextBox";
            this.degradomeFile1TextBox.Size = new System.Drawing.Size(357, 20);
            this.degradomeFile1TextBox.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Degradome 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Degradome 1:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mergedFileBrowseButton);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.mergeButton);
            this.groupBox2.Controls.Add(this.mergedFileTextBox);
            this.groupBox2.Location = new System.Drawing.Point(15, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 86);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Merge";
            // 
            // mergedFileBrowseButton
            // 
            this.mergedFileBrowseButton.Location = new System.Drawing.Point(449, 24);
            this.mergedFileBrowseButton.Name = "mergedFileBrowseButton";
            this.mergedFileBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.mergedFileBrowseButton.TabIndex = 23;
            this.mergedFileBrowseButton.Text = "Browse...";
            this.mergedFileBrowseButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Merged File:";
            // 
            // mergeButton
            // 
            this.mergeButton.Location = new System.Drawing.Point(9, 52);
            this.mergeButton.Name = "mergeButton";
            this.mergeButton.Size = new System.Drawing.Size(515, 23);
            this.mergeButton.TabIndex = 21;
            this.mergeButton.Text = "Merge";
            this.mergeButton.UseVisualStyleBackColor = true;
            this.mergeButton.Click += new System.EventHandler(this.mergeButton_Click);
            // 
            // mergedFileTextBox
            // 
            this.mergedFileTextBox.Location = new System.Drawing.Point(86, 26);
            this.mergedFileTextBox.Name = "mergedFileTextBox";
            this.mergedFileTextBox.Size = new System.Drawing.Size(357, 20);
            this.mergedFileTextBox.TabIndex = 22;
            // 
            // DegradomeMergeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 287);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DegradomeMergeForm";
            this.Text = "Degradome Merge";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveRpkmButton;
        private System.Windows.Forms.TextBox rpkmFileTextBox;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button degradomeFile2button;
        private System.Windows.Forms.TextBox degradomeFile2TextBox;
        private System.Windows.Forms.Button degradomeFile1button;
        private System.Windows.Forms.TextBox degradomeFile1TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button mergedFileBrowseButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button mergeButton;
        private System.Windows.Forms.TextBox mergedFileTextBox;
    }
}