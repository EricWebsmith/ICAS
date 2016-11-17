using Icas.DataPreprocessing;
using System;
using System.Windows.Forms;

namespace Icas.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void correlationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DegradomeMergeForm form = new DegradomeMergeForm();
            form.ShowDialog();
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DegradomeMergeFormOld form = new DegradomeMergeFormOld();
            form.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Reactivity.Serialise();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm form = new OptionsForm();
            form.ShowDialog();
        }

        private void runAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleavageSiteUtility.GenerateAll();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CleavageSiteUtility.GetValidNamesAll();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Degradome.ToCleavageEfficiency();
        }

        private void genePreprocessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gene.Serialise();
        }

        private void generateCleavageSitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleavageSiteUtility.GenerateCleavegeSites();
        }

        private void generateCleavageSiteFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleavageSiteUtility.GenerateCleavageSiteFiles();
        }

        private void generateAverageReactivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleavageSiteUtility.GenerateAverageReactivity();
        }

        private void generateStructureFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleavageSiteUtility.GenerateStructureFiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CleavageSiteUtility.GenerateAll();
        }

        private void transformTargetfinderFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TargetfinderForm form = new TargetfinderForm();
            form.ShowDialog();
        }

        private void externalEvaluationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClusteringSimilarityForm form = new ClusteringSimilarityForm();
            form.ShowDialog();
        }

        private void internalEvaluationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CompactnessForm form = new CompactnessForm();
            form.ShowDialog();
        }

        private void clusteringByReactivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClusteringForm form = new ClusteringForm();
            form.ShowDialog();
        }

        private void ensembleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnsembleForm form = new EnsembleForm();
            form.ShowDialog();
        }

        private void quickClusteringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuickClusteringForm form = new QuickClusteringForm();
            form.ShowDialog();
        }

        private void generateStructurePlotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleavageSiteUtility.GenerateRnaStructPlots();
        }

        private void cSDistanceMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RnaDistancePreprocess.Process();
        }
    }
}
