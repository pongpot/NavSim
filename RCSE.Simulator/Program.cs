using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCSE.Data;

namespace RCSE.Simulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Configuration globalConfig;
        public static Airport airportConfig;
        public static AptBinding airportBinding;
        [STAThread]
        static void Main()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            globalConfig = new Configuration("Conf/site.xml");
            airportConfig = globalConfig.Airport;
            airportBinding = new AptBinding();

            Console.WriteLine(globalConfig.Tx.RemoteIP);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
