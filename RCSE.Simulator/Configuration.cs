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
        private Airport _airport;

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
        public Airport Airport {
            get { return _airport; }
            private set { _airport = value; }
        }
        private Navaid XmlNavaidToData (string rpuname, XElement navaidElem)
        {
            String _buf;
            Navaid _rpu = new Navaid();

            _rpu.Name = navaidElem.Element("airport").Element("navaids").Element(rpuname).Element("name").Value;

            _buf = navaidElem.Element("airport").Element("navaids").Element(rpuname).Element("runwaynum").Value;
            if (_buf.Length != 0)
            {
                _rpu.RunwayNum = Int32.Parse(_buf);
            }

            _buf = navaidElem.Element("airport").Element("navaids").Element(rpuname).Element("enable").Value;
            if (string.Compare(_buf.ToLower(), "on") == 0)
            {
                _rpu.Enable = true;
            }
            else
            {
                _rpu.Enable = false;
            }

            _rpu.Rpunum = (int)Char.GetNumericValue(rpuname[rpuname.Length - 1]);

            return _rpu;
        }
        private Runway XmlRunwayToData(string rnyname, XElement runwayElem)
        {
            String _buf;
            Runway _runway = new Runway();

            _runway.Name = runwayElem.Element("airport").Element("runway").Element(rnyname).Element("name").Value;

            _buf = runwayElem.Element("airport").Element("runway").Element(rnyname).Element("category").Value;
            if (_buf.Length != 0)
            {
                if (Int32.Parse(_buf) == 1 || Int32.Parse(_buf) == 2)
                {
                    _runway.Category = Runway.CategoryType.Cat1_2;
                }
                else if (Int32.Parse(_buf) == 3)
                {
                    _runway.Category = Runway.CategoryType.Cat3;
                }
                else
                {
                    _runway.Category = Runway.CategoryType.NoRunway;
                }
            }

            _buf = runwayElem.Element("airport").Element("runway").Element(rnyname).Element("enable").Value;
            if (string.Compare(_buf.ToLower(), "on") == 0)
            {
                _runway.Enable = true;
            }
            else
            {
                _runway.Enable = false;
            }

            _runway.RunwayNum = (int)Char.GetNumericValue(rnyname[rnyname.Length - 1]);

            return _runway;
        }
        public Configuration(string cFile)
        {
            XDocument rDoc = XDocument.Load(cFile);

            XElement siteElem = rDoc.Element("site");

            // Upload TX configurations
            _tx = new TxC();
            _tx.RemoteIP = siteElem.Element("tx").Element("remoteIP").Value;
            _tx.RemotePort = siteElem.Element("tx").Element("remotePort").Value;

            _airport = new Airport();

            _airport.Navaid.Add(XmlNavaidToData("rpu1", siteElem));
            _airport.Navaid.Add(XmlNavaidToData("rpu2", siteElem));
            _airport.Navaid.Add(XmlNavaidToData("rpu3", siteElem));
            _airport.Navaid.Add(XmlNavaidToData("rpu4", siteElem));
            _airport.Navaid.Add(XmlNavaidToData("rpu5", siteElem));
            _airport.Navaid.Add(XmlNavaidToData("rpu6", siteElem));
            _airport.Navaid.Add(XmlNavaidToData("rpu7", siteElem));
            _airport.Navaid.Add(XmlNavaidToData("rpu8", siteElem));

            _airport.Runway.Add(XmlRunwayToData("rny1", siteElem));
            _airport.Runway.Add(XmlRunwayToData("rny2", siteElem));
        }
    }
    public class TxC
    {
        public string RemoteIP { get; set; }
        public string RemotePort { get; set; }
    }
}
