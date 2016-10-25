using Icas.Common;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Icas.UI.Controls
{
    sealed class QuickAlgorithmComboBox : AlgorithmComboBox
    {
        public QuickAlgorithmComboBox()
        {
            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (designMode)
            {

            }
            else
            {
                DataSource = MiSettings.Algorithms.Where(c => c.CanFixK).ToArray();
            }
            //
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.Width = 300;
        }



        //[DefaultValue(ComboBoxStyle.DropDownList)]
        //public new ComboBoxStyle DropDownStyle
        //{
        //    set { base.DropDownStyle = value; Invalidate(); }
        //    get { return base.DropDownStyle; }
        //}

        //public AlgorithmCsv SelectedAlgorithm
        //{
        //    get
        //    {
        //        if (SelectedItem != null)
        //        {
        //            return (AlgorithmCsv)SelectedItem;
        //        }
        //        return null;
        //    }
        //}

    }
}
