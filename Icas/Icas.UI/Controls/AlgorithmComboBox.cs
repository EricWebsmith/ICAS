using Icas.Common;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Icas.UI.Controls
{
    class AlgorithmComboBox : ComboBox
    {

        public AlgorithmComboBox()
        {
            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (designMode)
            {

            }
            else
            {

                DataSource = MiSettings.Algorithms;
            }
            //
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.Width = 300;
        }

        /// <summary>
        /// This cannot be used in Designer.
        /// </summary>
        /// <param name="predicate"></param>
        public AlgorithmComboBox(Func<AlgorithmCsv, bool> predicate)
        {
            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (designMode)
            {

            }
            else
            {
                DataSource = MiSettings.Algorithms.Where(predicate).ToArray();
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

        public AlgorithmCsv SelectedAlgorithm
        {
            get
            {
                if (SelectedItem != null)
                {
                    return (AlgorithmCsv)SelectedItem;
                }
                return null;
            }
        }

    }
}
