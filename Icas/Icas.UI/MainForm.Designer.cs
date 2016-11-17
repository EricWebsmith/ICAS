namespace Icas.UI
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stepsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.genePreprocessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateCleavageSitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateCleavageSiteFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateAverageReactivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateStructureFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateStructurePlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.runAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clusteringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clusteringByReactivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ensembleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quickClusteringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.degradomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.correlationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformTargetfinderFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clusteringToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.externalEvaluationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.internalEvaluationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.cSDistanceMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stepsToolStripMenuItem,
            this.clusteringToolStripMenuItem,
            this.degradomeToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(395, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stepsToolStripMenuItem
            // 
            this.stepsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.genePreprocessToolStripMenuItem,
            this.generateCleavageSitesToolStripMenuItem,
            this.generateCleavageSiteFilesToolStripMenuItem,
            this.generateAverageReactivityToolStripMenuItem,
            this.generateStructureFilesToolStripMenuItem,
            this.generateStructurePlotsToolStripMenuItem,
            this.cSDistanceMatrixToolStripMenuItem,
            this.toolStripSeparator1,
            this.runAllToolStripMenuItem});
            this.stepsToolStripMenuItem.Name = "stepsToolStripMenuItem";
            this.stepsToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.stepsToolStripMenuItem.Text = "&Data Pre-processing";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem2.Text = "&1. Get Valid Genes";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem3.Text = "&2. Generate Cleavage Efficiency";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem4.Text = "&3. Reactivity Preprocess";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // genePreprocessToolStripMenuItem
            // 
            this.genePreprocessToolStripMenuItem.Name = "genePreprocessToolStripMenuItem";
            this.genePreprocessToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.genePreprocessToolStripMenuItem.Text = "&4. Gene Preprocess";
            this.genePreprocessToolStripMenuItem.Click += new System.EventHandler(this.genePreprocessToolStripMenuItem_Click);
            // 
            // generateCleavageSitesToolStripMenuItem
            // 
            this.generateCleavageSitesToolStripMenuItem.Name = "generateCleavageSitesToolStripMenuItem";
            this.generateCleavageSitesToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.generateCleavageSitesToolStripMenuItem.Text = "&5. Generate Cleavage Sites";
            this.generateCleavageSitesToolStripMenuItem.Click += new System.EventHandler(this.generateCleavageSitesToolStripMenuItem_Click);
            // 
            // generateCleavageSiteFilesToolStripMenuItem
            // 
            this.generateCleavageSiteFilesToolStripMenuItem.Name = "generateCleavageSiteFilesToolStripMenuItem";
            this.generateCleavageSiteFilesToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.generateCleavageSiteFilesToolStripMenuItem.Text = "&6. Generate Cleavage Site Files";
            this.generateCleavageSiteFilesToolStripMenuItem.Click += new System.EventHandler(this.generateCleavageSiteFilesToolStripMenuItem_Click);
            // 
            // generateAverageReactivityToolStripMenuItem
            // 
            this.generateAverageReactivityToolStripMenuItem.Name = "generateAverageReactivityToolStripMenuItem";
            this.generateAverageReactivityToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.generateAverageReactivityToolStripMenuItem.Text = "&7. Generate Average Reactivity";
            this.generateAverageReactivityToolStripMenuItem.Click += new System.EventHandler(this.generateAverageReactivityToolStripMenuItem_Click);
            // 
            // generateStructureFilesToolStripMenuItem
            // 
            this.generateStructureFilesToolStripMenuItem.Name = "generateStructureFilesToolStripMenuItem";
            this.generateStructureFilesToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.generateStructureFilesToolStripMenuItem.Text = "&8. Generate Structure Files";
            this.generateStructureFilesToolStripMenuItem.Click += new System.EventHandler(this.generateStructureFilesToolStripMenuItem_Click);
            // 
            // generateStructurePlotsToolStripMenuItem
            // 
            this.generateStructurePlotsToolStripMenuItem.Name = "generateStructurePlotsToolStripMenuItem";
            this.generateStructurePlotsToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.generateStructurePlotsToolStripMenuItem.Text = "9. Generate Structure Plots";
            this.generateStructurePlotsToolStripMenuItem.Click += new System.EventHandler(this.generateStructurePlotsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(235, 6);
            // 
            // runAllToolStripMenuItem
            // 
            this.runAllToolStripMenuItem.Name = "runAllToolStripMenuItem";
            this.runAllToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.runAllToolStripMenuItem.Text = "Run &All";
            this.runAllToolStripMenuItem.Click += new System.EventHandler(this.runAllToolStripMenuItem_Click);
            // 
            // clusteringToolStripMenuItem
            // 
            this.clusteringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clusteringByReactivityToolStripMenuItem,
            this.ensembleToolStripMenuItem,
            this.toolStripSeparator2,
            this.quickClusteringToolStripMenuItem});
            this.clusteringToolStripMenuItem.Name = "clusteringToolStripMenuItem";
            this.clusteringToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.clusteringToolStripMenuItem.Text = "&Clustering";
            // 
            // clusteringByReactivityToolStripMenuItem
            // 
            this.clusteringByReactivityToolStripMenuItem.Name = "clusteringByReactivityToolStripMenuItem";
            this.clusteringByReactivityToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.clusteringByReactivityToolStripMenuItem.Text = "&Individual Algorithm...";
            this.clusteringByReactivityToolStripMenuItem.Click += new System.EventHandler(this.clusteringByReactivityToolStripMenuItem_Click);
            // 
            // ensembleToolStripMenuItem
            // 
            this.ensembleToolStripMenuItem.Name = "ensembleToolStripMenuItem";
            this.ensembleToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ensembleToolStripMenuItem.Text = "&Ensemble Clustering...";
            this.ensembleToolStripMenuItem.Click += new System.EventHandler(this.ensembleToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // quickClusteringToolStripMenuItem
            // 
            this.quickClusteringToolStripMenuItem.Name = "quickClusteringToolStripMenuItem";
            this.quickClusteringToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.quickClusteringToolStripMenuItem.Text = "&Quick Clustering...";
            this.quickClusteringToolStripMenuItem.Click += new System.EventHandler(this.quickClusteringToolStripMenuItem_Click);
            // 
            // degradomeToolStripMenuItem
            // 
            this.degradomeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.correlationToolStripMenuItem,
            this.transformTargetfinderFilesToolStripMenuItem,
            this.clusteringToolStripMenuItem1});
            this.degradomeToolStripMenuItem.Name = "degradomeToolStripMenuItem";
            this.degradomeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.degradomeToolStripMenuItem.Text = "&Tools";
            // 
            // correlationToolStripMenuItem
            // 
            this.correlationToolStripMenuItem.Name = "correlationToolStripMenuItem";
            this.correlationToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.correlationToolStripMenuItem.Text = "Degradome &Merge...";
            this.correlationToolStripMenuItem.Click += new System.EventHandler(this.correlationToolStripMenuItem_Click);
            // 
            // transformTargetfinderFilesToolStripMenuItem
            // 
            this.transformTargetfinderFilesToolStripMenuItem.Name = "transformTargetfinderFilesToolStripMenuItem";
            this.transformTargetfinderFilesToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.transformTargetfinderFilesToolStripMenuItem.Text = "&Targetfinder data transformation...";
            this.transformTargetfinderFilesToolStripMenuItem.Click += new System.EventHandler(this.transformTargetfinderFilesToolStripMenuItem_Click);
            // 
            // clusteringToolStripMenuItem1
            // 
            this.clusteringToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.externalEvaluationToolStripMenuItem1,
            this.internalEvaluationToolStripMenuItem1});
            this.clusteringToolStripMenuItem1.Name = "clusteringToolStripMenuItem1";
            this.clusteringToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            this.clusteringToolStripMenuItem1.Text = "&Clustering";
            // 
            // externalEvaluationToolStripMenuItem1
            // 
            this.externalEvaluationToolStripMenuItem1.Name = "externalEvaluationToolStripMenuItem1";
            this.externalEvaluationToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.externalEvaluationToolStripMenuItem1.Text = "&External Evaluation...";
            this.externalEvaluationToolStripMenuItem1.Click += new System.EventHandler(this.externalEvaluationToolStripMenuItem1_Click);
            // 
            // internalEvaluationToolStripMenuItem1
            // 
            this.internalEvaluationToolStripMenuItem1.Name = "internalEvaluationToolStripMenuItem1";
            this.internalEvaluationToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.internalEvaluationToolStripMenuItem1.Text = "&Internal Evaluation...";
            this.internalEvaluationToolStripMenuItem1.Click += new System.EventHandler(this.internalEvaluationToolStripMenuItem1_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.中文ToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItem1.Text = "English";
            // 
            // 中文ToolStripMenuItem
            // 
            this.中文ToolStripMenuItem.Name = "中文ToolStripMenuItem";
            this.中文ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.中文ToolStripMenuItem.Text = "中文";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(45, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(295, 79);
            this.button1.TabIndex = 1;
            this.button1.Text = "One-Click Preprocess";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cSDistanceMatrixToolStripMenuItem
            // 
            this.cSDistanceMatrixToolStripMenuItem.Name = "cSDistanceMatrixToolStripMenuItem";
            this.cSDistanceMatrixToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.cSDistanceMatrixToolStripMenuItem.Text = "10. CS Distance Matrix";
            this.cSDistanceMatrixToolStripMenuItem.Click += new System.EventHandler(this.cSDistanceMatrixToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 233);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Integrated Clustering Analysis System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem degradomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem correlationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem genePreprocessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateCleavageSitesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateCleavageSiteFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateAverageReactivityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateStructureFilesToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem runAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transformTargetfinderFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clusteringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clusteringToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem externalEvaluationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem internalEvaluationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clusteringByReactivityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ensembleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quickClusteringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 中文ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateStructurePlotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSDistanceMatrixToolStripMenuItem;
    }
}

