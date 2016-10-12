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
        public bool Enable { get; set; }
        public bool Buzzer { get; set; }
        public int RunwayNum { get; set; }
        public CategoryType Category { get; set; }
        public Runway() { }
        public Runway(string name, bool enable, bool buzzer, int runwaynum, CategoryType category)
        {
            Name = name;
            Enable = enable;
            Buzzer = buzzer;
            RunwayNum = runwaynum;
            Category = category;
        }
    }
}
