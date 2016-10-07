using MSDIS.Transmitters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTxConsole
{
    public class Program
    {
        static Configuration globalC;
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            globalC = new Configuration("Conf/site.xml");

            Console.Write("Enter HEX data [Ex. 02:7f:fa] : ");
            string text = Console.ReadLine();

            Console.WriteLine("Prepared data : {0}", text);

            byte[] data = null;

            try
            {
                data = Text2Data(text);
            }
            catch (Exception)
            {
                Console.WriteLine("Enter invalid HEX format.");
                Console.Read();
                return;
            }

            BcastTransmitter bTx = new BcastTransmitter(
                "TX01", globalC.Tx.RemoteIP, Convert.ToInt32(globalC.Tx.RemotePort));

            Console.Write("Press any key to send data...");
            Console.ReadLine();

            bTx.Transmit(data);

            Console.WriteLine("Data has been sent.");
            Console.Write("Press any key to exit...");
            Console.Read();
        }
        static byte[] Text2Data(string text)
        {
            string[] txtSplit = text.Split(':');
            byte[] data = new byte[txtSplit.Length];

            for (int i=0; i<data.Length; i++)
                data[i] = Convert.ToByte(txtSplit[i], 16);

            return data;
        }
    }
}
