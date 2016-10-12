using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCSE.Data;
using System.Xml.Linq;

namespace RCSE.Simulator
{
    public class Configuration
    {
        private int _id;
        private string _code;
        private TxC _tx;

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string Code
        {
            get { return _code; }
            private set { _code = value; }
        }
        public TxC Tx
        {
            get { return _tx; }
            private set { _tx = value; }
        }
        public Airport Airport { get; set; }
        public Configuration(string cFile)
        {
            XDocument rDoc = XDocument.Load(cFile);

            XElement siteElem = rDoc.Element("site");

            // Upload TX configurations
            _tx = new TxC();
            _tx.RemoteIP = siteElem.Element("tx").Element("remoteIP").Value;
            _tx.RemotePort = siteElem.Element("tx").Element("remotePort").Value;

            Airport = new Airport();

            Navaid rpu1 = new Navaid();
            rpu1.Name = siteElem.Element("airport").Element("navaids").Element("rpu1").Element("name").Value;
            String Runway = siteElem.Element("airport").Element("navaids").Element("rpu1").Element("name").Value;
            rpu1.
        }
    }
    public class TxC
    {
        public string RemoteIP { get; set; }
        public string RemotePort { get; set; }
    }
}
