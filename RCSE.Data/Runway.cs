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
        public bool Runwayon { get; set; }
        public bool Buzzer { get; set; }
        public CategoryType Category { get; set; }
        public Runway() { }
        public Runway(string name, bool runwayon, bool buzzer, CategoryType category)
        {
            Name = name;
            Runwayon = runwayon;
            Buzzer = buzzer;
            Category = category;
        }
    }
}
