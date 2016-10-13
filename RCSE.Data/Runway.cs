using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE.Data
{
    public class Runway
    {
        public enum CategoryType
        {
            NoRunway,
            Cat3,
            Cat1_2,
            Alarm
        };
        public enum PcConrtrolType
        {
            Off,
            On,
            PcControlOff,
            Flash
        };

        public string Name { get; set; }
        public bool Enable { get; set; }
        public bool Status { get; set; }
        public bool Buzzer { get; set; }
        public bool RwyControl { get; set; }
        public int RunwayNum { get; set; }
        public CategoryType Category { get; set; }
        public PcConrtrolType PcControl { get; set; }
        public Runway() { }
        public Runway(string name, bool enable, bool status, bool buzzer, bool rwycontrol, int runwaynum, CategoryType category, PcConrtrolType pccontrol)
        {
            Name = name;
            Enable = enable;
            Status = status;
            Buzzer = buzzer;
            RwyControl = rwycontrol;
            RunwayNum = runwaynum;
            Category = category;
            PcControl = pccontrol;
        }
    }
}
