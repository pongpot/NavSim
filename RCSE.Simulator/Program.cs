using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCSE.Simulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Configuration globalC;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            globalC = new Configuration("Conf/site.xml");
        }
    }
}
