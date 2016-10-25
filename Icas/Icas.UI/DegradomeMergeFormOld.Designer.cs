namespace Icas.UI
{
    partial class DegradomeMergeFormOld
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
            this.degradomeFile1TextBox = new System.Windows.Forms.TextBox();
            this.degradomeFile1button = new System.Windows.Forms.Button();
            this.degradomeFile2TextBox = new System.Windows.Forms.TextBox();
            this.degradomeFile2button = new System.Windows.Forms.Button();
            this.mergeButton = new System.Windows.Forms.Button();
            this.mergedFileTextBox = new System.Windows.Forms.TextBox();
            this.mergedFileBrowseButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Degradome 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Degradome 2:";
            // 
            // degradomeFile1TextBox
            // 
            this.degradomeFile1TextBox.Location = new System.Drawing.Point(92, 6);
            this.degradomeFile1TextBox.Name = "degradomeFile1TextBox";
            this.degradomeFile1TextBox.Size = new System.Drawing.Size(357, 20);
            this.degradomeFile1TextBox.TabIndex = 2;
            // 
            // degradomeFile1button
            // 
            this.degradomeFile1button.Location = new System.Drawing.Point(455, 4);
            this.degradomeFile1button.Name = "degradomeFile1button";
            this.degradomeFile1button.Size = new System.Drawing.Size(75, 23);
            this.degradomeFile1button.TabIndex = 3;
            this.degradomeFile1button.Text = "Browse...";
            this.degradomeFile1button.UseVisualStyleBackColor = true;
            this.degradomeFile1button.Click += new System.EventHandler(this.degradomeFile1button_Click);
            // 
            // degradomeFile2TextBox
            // 
            this.degradomeFile2TextBox.Location = new System.Drawing.Point(92, 32);
            this.degradomeFile2TextBox.Name = "degradomeFile2TextBox";
            this.degradomeFile2TextBox.Size = new System.Drawing.Size(357, 20);
            this.degradomeFile2TextBox.TabIndex = 4;
            // 
            // degradomeFile2button
            // 
            this.degradomeFile2button.Location = new System.Drawing.Point(455, 30);
            this.degradomeFile2button.Name = "degradomeFile2button";
            this.degradomeFile2button.Size = new System.Drawing.Size(75, 23);
            this.degradomeFile2button.TabIndex = 5;
            this.degradomeFile2button.Text = "Browse...";
            this.degradomeFile2button.UseVisualStyleBackColor = true;
            this.degradomeFile2button.Click += new System.EventHandler(this.degradomeFile2button_Click);
            // 
            // mergeButton
            // 
            this.mergeButton.Location = new System.Drawing.Point(15, 84);
            this.mergeButton.Name = "mergeButton";
            this.mergeButton.Size = new System.Drawing.Size(515, 23);
            this.mergeButton.TabIndex = 6;
            this.mergeButton.Text = "Merge";
            this.mergeButton.UseVisualStyleBackColor = true;
            this.mergeButton.Click += new System.EventHandler(this.mergeButton_Click);
            // 
            // mergedFileTextBox
            // 
            this.mergedFileTextBox.Location = new System.Drawing.Point(92, 58);
            this.mergedFileTextBox.Name = "mergedFileTextBox";
            this.mergedFileTextBox.Size = new System.Drawing.Size(357, 20);
            this.mergedFileTextBox.TabIndex = 10;
            // 
            // mergedFileBrowseButton
            // 
            this.mergedFileBrowseButton.Location = new System.Drawing.Point(455, 56);
            this.mergedFileBrowseButton.Name = "mergedFileBrowseButton";
            this.mergedFileBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.mergedFileBrowseButton.TabIndex = 11;
            this.mergedFileBrowseButton.Text = "Browse...";
            this.mergedFileBrowseButton.UseVisualStyleBackColor = true;
            this.mergedFileBrowseButton.Click += new System.EventHandler(this.mergedFileBrowseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Merged File:";
            // 
            // DegradomeMergeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 115);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mergedFileBrowseButton);
            this.Controls.Add(this.mergedFileTextBox);
            this.Controls.Add(this.mergeButton);
            this.Controls.Add(this.degradomeFile2button);
            this.Controls.Add(this.degradomeFile2TextBox);
            this.Controls.Add(this.degradomeFile1button);
            this.Controls.Add(this.degradomeFile1TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DegradomeMergeForm";
            this.Text = "DegradomeCorrelationTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox degradomeFile1TextBox;
        private System.Windows.Forms.Button degradomeFile1button;
        private System.Windows.Forms.TextBox degradomeFile2TextBox;
        private System.Windows.Forms.Button degradomeFile2button;
        private System.Windows.Forms.Button mergeButton;
        private System.Windows.Forms.TextBox mergedFileTextBox;
        private System.Windows.Forms.Button mergedFileBrowseButton;
        private System.Windows.Forms.Label label4;
    }
}