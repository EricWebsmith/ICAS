namespace Icas.UI
{
    partial class ClusteringForm_old
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
            this.label2 = new System.Windows.Forms.Label();
            this.reactivityRadioButton = new System.Windows.Forms.RadioButton();
            this.rnaDistanceRadioButton = new System.Windows.Forms.RadioButton();
            this.runButton = new System.Windows.Forms.Button();
            this.scriptCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.keysTextBox = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type:";
            // 
            // reactivityRadioButton
            // 
            this.reactivityRadioButton.AutoSize = true;
            this.reactivityRadioButton.Checked = true;
            this.reactivityRadioButton.Location = new System.Drawing.Point(50, 264);
            this.reactivityRadioButton.Name = "reactivityRadioButton";
            this.reactivityRadioButton.Size = new System.Drawing.Size(72, 17);
            this.reactivityRadioButton.TabIndex = 4;
            this.reactivityRadioButton.TabStop = true;
            this.reactivityRadioButton.Text = "Reactivity";
            this.reactivityRadioButton.UseVisualStyleBackColor = true;
            this.reactivityRadioButton.CheckedChanged += new System.EventHandler(this.reactivityRadioButton_CheckedChanged);
            // 
            // rnaDistanceRadioButton
            // 
            this.rnaDistanceRadioButton.AutoSize = true;
            this.rnaDistanceRadioButton.Location = new System.Drawing.Point(128, 264);
            this.rnaDistanceRadioButton.Name = "rnaDistanceRadioButton";
            this.rnaDistanceRadioButton.Size = new System.Drawing.Size(93, 17);
            this.rnaDistanceRadioButton.TabIndex = 5;
            this.rnaDistanceRadioButton.Text = "RNA Distance";
            this.rnaDistanceRadioButton.UseVisualStyleBackColor = true;
            this.rnaDistanceRadioButton.CheckedChanged += new System.EventHandler(this.rnaDistanceRadioButton_CheckedChanged);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(105, 310);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 6;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // scriptCheckBox
            // 
            this.scriptCheckBox.AutoSize = true;
            this.scriptCheckBox.Location = new System.Drawing.Point(13, 287);
            this.scriptCheckBox.Name = "scriptCheckBox";
            this.scriptCheckBox.Size = new System.Drawing.Size(190, 17);
            this.scriptCheckBox.TabIndex = 7;
            this.scriptCheckBox.Text = "I have run the python and r scripts.";
            this.scriptCheckBox.UseVisualStyleBackColor = true;
            this.scriptCheckBox.CheckedChanged += new System.EventHandler(this.scriptCheckBox_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.keysTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(271, 220);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Algorithms";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // keysTextBox
            // 
            this.keysTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keysTextBox.Location = new System.Drawing.Point(3, 3);
            this.keysTextBox.Multiline = true;
            this.keysTextBox.Name = "keysTextBox";
            this.keysTextBox.Size = new System.Drawing.Size(265, 214);
            this.keysTextBox.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fileListBox);
            this.tabPage1.Controls.Add(this.browseButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(271, 220);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Python Scripts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fileListBox
            // 
            this.fileListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.Location = new System.Drawing.Point(3, 31);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(265, 186);
            this.fileListBox.TabIndex = 0;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(191, 6);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(279, 246);
            this.tabControl1.TabIndex = 8;
            // 
            // ClusteringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 345);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.scriptCheckBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.rnaDistanceRadioButton);
            this.Controls.Add(this.reactivityRadioButton);
            this.Controls.Add(this.label2);
            this.Name = "ClusteringForm";
            this.Text = "Clustering";
            this.Load += new System.EventHandler(this.ClusteringForm_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton reactivityRadioButton;
        private System.Windows.Forms.RadioButton rnaDistanceRadioButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.CheckBox scriptCheckBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox keysTextBox;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TabControl tabControl1;
    }
}