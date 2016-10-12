using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE.Data
{
    public class Navaid
    {
        public enum StatusType
        {
            Off,
            Normaml,
            Warning,
            Alarm,
            Maintenance,
            Maintenanceflash,
            Datacom,
            Datacomflash
        };

        public string Name { get; set; }
        public StatusType Status { get; set; }
        public bool Control { get; set; }
        public bool Buzzer { get; set; }
        public int Runway { get; set; }
        public int Rpunum { get; set; }
        public Navaid() { }
        public Navaid(string name, StatusType status, bool control, int runway, int rpunum, bool buzzer)
        {
            Name = name;
            Status = status;
            Control = control;
            Runway = runway;
            Rpunum = rpunum;
            Buzzer = buzzer;
        }
    }
}
