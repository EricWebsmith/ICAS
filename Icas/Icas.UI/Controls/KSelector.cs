using System.Windows.Forms;

namespace Icas.UI.Controls
{
    public sealed class KSelector : NumericUpDown
    {
        public KSelector()
        {
            Maximum = 19;
            Minimum = 2;

        }

        //private int _k = 0;
        public int K
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Text)) return 0;
                return int.Parse(Text);
            }
            //set
            //{
            //    if (value == 0)
            //    {
            //        Text = "";
            //    }
            //    else
            //    {
            //        Text = value.ToString();
            //    }

            //    if (value > Maximum || value < Minimum)
            //    {
            //        return;
            //    }

            //    this.Value = value;
            //    this.Text = value.ToString();

            //    //_k = value;
            //}
        }
    }
}
