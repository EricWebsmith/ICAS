using Icas.Common;
using System;
using System.Windows.Forms;

namespace Icas.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Environment.CurrentDirectory = Config.WorkingFolder;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Application.Run(new Form1());
            //Application.Run(new EnsembleForm());
        }
    }
}
