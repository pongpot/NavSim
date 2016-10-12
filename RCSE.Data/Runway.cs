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

        public string Name { get; set; }
        public bool RunwayEnable { get; set; }
        public bool Buzzer { get; set; }
        public int RunwayNum { get; set; }
        public CategoryType Category { get; set; }
        public Runway() { }
        public Runway(string name, bool runwayenable, bool buzzer, int runwaynum, CategoryType category)
        {
            Name = name;
            RunwayEnable = runwayenable;
            Buzzer = buzzer;
            RunwayNum = runwaynum;
            Category = category;
        }
    }
}
