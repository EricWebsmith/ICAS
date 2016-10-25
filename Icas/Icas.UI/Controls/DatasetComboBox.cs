using Icas.Common;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Icas.UI.Controls
{
    sealed class DatasetComboBox : ComboBox
    {
        public DatasetComboBox()
        {
            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (designMode)
            {

            }
            else
            {
                DataSource = MiSettings.Datasets;
            }
            //
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.Width = 300;
        }



        [DefaultValue(ComboBoxStyle.DropDownList)]
        public new ComboBoxStyle DropDownStyle
        {
            set { base.DropDownStyle = value; Invalidate(); }
            get { return base.DropDownStyle; }
        }

        public DatasetCsv SelectedDataset
        {
            get
            {
                if (SelectedItem != null)
                {
                    return (DatasetCsv)SelectedItem;
                }
                return null;
            }
        }

        public void Filter(AlgorithmCsv algorithm)
        {
            var all = MiSettings.Datasets;
            var filtered = all.Where(c => c.Feature == algorithm.Feature);
            if (!string.IsNullOrWhiteSpace(algorithm.Transformation))
            {
                filtered = filtered.Where(c => c.Transformation == algorithm.Transformation);
            }
            this.DataSource = filtered.ToArray();
        }

    }
}
