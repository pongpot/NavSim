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
        };
        public enum MaintType
        {
            Off,
            Maintenance,
            MainOff,
            Maintenanceflash
        };
        public enum DataComType
        {
            Off,
            Datacom,
            DataComOff,
            Datacomflash
        };
        public string Name { get; set; }
        public StatusType Status { get; set; }
        public MaintType Maint { get; set; }
        public DataComType DataCom { get; set; }
        public bool PcControl { get; set; }
        public bool Buzzer { get; set; }
        public bool Enable { get; set; }
        public int RunwayNum { get; set; }
        public int Rpunum { get; set; }
        public Navaid() { }
        public Navaid(string name, StatusType status, MaintType maint, DataComType datacom, bool pccontrol, bool buzzer, bool enable, int runwaynum, int rpunum)
        {
            Name = name;
            Status = status;
            Maint = maint;
            DataCom = datacom;
            PcControl = pccontrol;
            Buzzer = buzzer;
            Enable = enable;
            RunwayNum = runwaynum;
            Rpunum = rpunum;
        }
    }
}
