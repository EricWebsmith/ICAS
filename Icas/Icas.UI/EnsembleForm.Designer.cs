using Icas.UI.Controls;

namespace Icas.UI
{
    partial class EnsembleForm
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
            this.components = new System.ComponentModel.Container();
            this.candidateDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statisticalResultCsvBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ensembleButton = new System.Windows.Forms.Button();
            this.ensembleNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.datasetComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ensembleMethodcomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.keepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.reportOkayButton = new System.Windows.Forms.Button();
            this.keSelector = new Icas.UI.Controls.KSelector();
            this.kiSelector = new Icas.UI.Controls.KSelector();
            ((System.ComponentModel.ISupportInitialize)(this.candidateDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticalResultCsvBindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keepNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // candidateDataGridView
            // 
            this.candidateDataGridView.AllowUserToAddRows = false;
            this.candidateDataGridView.AllowUserToDeleteRows = false;
            this.candidateDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.candidateDataGridView.AutoGenerateColumns = false;
            this.candidateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.candidateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Method,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.candidateDataGridView.DataSource = this.statisticalResultCsvBindingSource1;
            this.candidateDataGridView.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.candidateDataGridView.Location = new System.Drawing.Point(0, 124);
            this.candidateDataGridView.Name = "candidateDataGridView";
            this.candidateDataGridView.ReadOnly = true;
            this.candidateDataGridView.Size = new System.Drawing.Size(947, 423);
            this.candidateDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "File";
            this.dataGridViewTextBoxColumn2.HeaderText = "File";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Method
            // 
            this.Method.DataPropertyName = "Method";
            this.Method.HeaderText = "Method";
            this.Method.Name = "Method";
            this.Method.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Oneway";
            this.dataGridViewTextBoxColumn3.HeaderText = "Oneway";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "group_count";
            this.dataGridViewTextBoxColumn4.HeaderText = "group_count";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "significant_pairs";
            this.dataGridViewTextBoxColumn5.HeaderText = "significant_pairs";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "pair_count";
            this.dataGridViewTextBoxColumn6.HeaderText = "pair_count";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "significant_rate";
            this.dataGridViewTextBoxColumn7.HeaderText = "significant_rate";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Compactness";
            this.dataGridViewTextBoxColumn8.HeaderText = "Compactness";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // statisticalResultCsvBindingSource1
            // 
            this.statisticalResultCsvBindingSource1.DataSource = typeof(Icas.Clustering.StatisticalResultCsv);
            // 
            // ensembleButton
            // 
            this.ensembleButton.Location = new System.Drawing.Point(742, 17);
            this.ensembleButton.Name = "ensembleButton";
            this.ensembleButton.Size = new System.Drawing.Size(168, 23);
            this.ensembleButton.TabIndex = 10;
            this.ensembleButton.Text = "Generate Ensembles";
            this.ensembleButton.UseVisualStyleBackColor = true;
            this.ensembleButton.Click += new System.EventHandler(this.ensembleButton_Click);
            // 
            // ensembleNameTextBox
            // 
            this.ensembleNameTextBox.Enabled = false;
            this.ensembleNameTextBox.Location = new System.Drawing.Point(665, 19);
            this.ensembleNameTextBox.Name = "ensembleNameTextBox";
            this.ensembleNameTextBox.ReadOnly = true;
            this.ensembleNameTextBox.Size = new System.Drawing.Size(71, 20);
            this.ensembleNameTextBox.TabIndex = 11;
            this.ensembleNameTextBox.Text = "ensemble1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(572, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ensemble Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kiSelector);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.searchButton);
            this.groupBox1.Controls.Add(this.datasetComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 50);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ensemble memebers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(537, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "k:";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(605, 17);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(128, 23);
            this.searchButton.TabIndex = 16;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // datasetComboBox
            // 
            this.datasetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.datasetComboBox.FormattingEnabled = true;
            this.datasetComboBox.Location = new System.Drawing.Point(58, 19);
            this.datasetComboBox.Name = "datasetComboBox";
            this.datasetComboBox.Size = new System.Drawing.Size(473, 21);
            this.datasetComboBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dataset:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ensembleMethodcomboBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.keepNumericUpDown);
            this.groupBox2.Controls.Add(this.keSelector);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ensembleNameTextBox);
            this.groupBox2.Controls.Add(this.ensembleButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(923, 50);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ensemble";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // ensembleMethodcomboBox
            // 
            this.ensembleMethodcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ensembleMethodcomboBox.FormattingEnabled = true;
            this.ensembleMethodcomboBox.Location = new System.Drawing.Point(358, 19);
            this.ensembleMethodcomboBox.Name = "ensembleMethodcomboBox";
            this.ensembleMethodcomboBox.Size = new System.Drawing.Size(208, 21);
            this.ensembleMethodcomboBox.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Consensus method:";
            // 
            // keepNumericUpDown
            // 
            this.keepNumericUpDown.Location = new System.Drawing.Point(203, 20);
            this.keepNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.keepNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.keepNumericUpDown.Name = "keepNumericUpDown";
            this.keepNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.keepNumericUpDown.TabIndex = 21;
            this.keepNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "After dissimilar test keep:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "k:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.reportOkayButton);
            this.groupBox3.Location = new System.Drawing.Point(782, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(153, 50);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generate report";
            // 
            // reportOkayButton
            // 
            this.reportOkayButton.Location = new System.Drawing.Point(6, 17);
            this.reportOkayButton.Name = "reportOkayButton";
            this.reportOkayButton.Size = new System.Drawing.Size(134, 23);
            this.reportOkayButton.TabIndex = 3;
            this.reportOkayButton.Text = "Generate Report";
            this.reportOkayButton.UseVisualStyleBackColor = true;
            this.reportOkayButton.Click += new System.EventHandler(this.reportOkayButton_Click);
            // 
            // keSelector
            // 
            this.keSelector.Text = "";
            this.keSelector.Location = new System.Drawing.Point(28, 20);
            this.keSelector.Maximum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.keSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.keSelector.Name = "keSelector";
            this.keSelector.Size = new System.Drawing.Size(40, 20);
            this.keSelector.TabIndex = 20;
            this.keSelector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // kiSelector
            // 
            this.kiSelector.Text = "";
            this.kiSelector.Location = new System.Drawing.Point(559, 20);
            this.kiSelector.Maximum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.kiSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.kiSelector.Name = "kiSelector";
            this.kiSelector.Size = new System.Drawing.Size(40, 20);
            this.kiSelector.TabIndex = 19;
            this.kiSelector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // EnsembleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 547);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.candidateDataGridView);
            this.MaximizeBox = false;
            this.Name = "EnsembleForm";
            this.Text = "Clustering Ensemble";
            this.Load += new System.EventHandler(this.EnsembleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.candidateDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticalResultCsvBindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keepNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.keSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView candidateDataGridView;
        private System.Windows.Forms.Button ensembleButton;
        private System.Windows.Forms.TextBox ensembleNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button reportOkayButton;
        private KSelector kiSelector;
        private System.Windows.Forms.ComboBox datasetComboBox;
        private KSelector keSelector;
        private System.Windows.Forms.NumericUpDown keepNumericUpDown;
        private System.Windows.Forms.BindingSource statisticalResultCsvBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Method;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.ComboBox ensembleMethodcomboBox;
        private System.Windows.Forms.Label label1;
    }
}