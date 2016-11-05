using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCSE.Data;

namespace RCSE.Thales
{
    public class Encode
    {
        public Encode() { }

        public Byte[] EncodeData(Airport _Airport,Byte dataByte6)
        {
            Encode tempdata = new Encode();
            byte[] data = new byte[19];

            data[0] = tempdata.CheckRPUEnable(_Airport);
            data[1] = 0x00;
            data[3] = 0x00;
            data[4] = 0x00;
            data[5] = 0x00;
            data[6] = dataByte6;
            data[7] = 0x0A;
            data[8] = tempdata.RWY_1_2_Status(_Airport);
            data[9] = tempdata.RWY_CAT_Data(_Airport);
            data[10] = tempdata.RWY_ContRPU(_Airport);

            for(int num = 11;num < 19;num++)
            {
                if(_Airport.Navaid[num-11].Enable == true)
                {
                    data[num] = tempdata.RPUConvertData(_Airport, num - 11);
                }
                else
                {
                    data[num] = 0x00;
                }
            }
            return data;
        }

        public byte CheckRPUEnable(Airport _Airport)
        {
            byte data = new byte();

            if(_Airport.Navaid[7].Enable == true)
            {
                data = 0x13;
            }
            else if(_Airport.Navaid[6].Enable == true)
            {
                data = 0x12;
            }
            else if (_Airport.Navaid[5].Enable == true)
            {
                data = 0x11;
            }
            else if (_Airport.Navaid[4].Enable == true)
            {
                data = 0x10;
            }
            else if (_Airport.Navaid[3].Enable == true)
            {
                data = 0x0F;
            }
            else if (_Airport.Navaid[2].Enable == true)
            {
                data = 0x0E;
            }
            else if (_Airport.Navaid[1].Enable == true)
            {
                data = 0x0D;
            }
            else if (_Airport.Navaid[0].Enable == true)
            {
                data = 0x0C;
            }
            return data;
        }

        // ICD 11-18
        public byte RPUConvertData(Airport _Airport, int rpunum)
        {
            int RPU_Buzzer = new int();
            int RPU_DataCom = new int();
            int RPU_Maint = new int();
            int RPU_Status = new int();

            const int RPU_OFF = 0x00;
            const int RPU_BuzzerON = 0x40;
            const int RPU_DataComON = 0x10;
            const int RPU_DataComOFF = 0x40;
            const int RPU_DataComflash = 0x60;
            const int RPU_MaintON = 0x04;
            const int RPU_MaintOFF = 0x08;
            const int RPU_Maintflash = 0x0c;
            const int RPU_StatusNML = 0x01;
            const int RPU_StatusWar = 0x02;
            const int RPU_StatusAlm = 0x03;

            // BUZZER
            if (_Airport.Navaid[rpunum].Buzzer == true)
            {
                RPU_Buzzer = RPU_BuzzerON;
            }
            else
            {
                RPU_Buzzer = RPU_OFF;
            }

            // DATACOM
            if (_Airport.Navaid[rpunum].DataCom == Navaid.DataComType.Datacom)
            {
                RPU_DataCom = RPU_DataComON;
            }
            else if (_Airport.Navaid[rpunum].DataCom == Navaid.DataComType.DataComOff)
            {
                RPU_DataCom = RPU_DataComOFF;
            }
            else if (_Airport.Navaid[rpunum].DataCom == Navaid.DataComType.Datacomflash)
            {
                RPU_DataCom = RPU_DataComflash;
            }

            // MAINTENANCE
            if (_Airport.Navaid[rpunum].Maint == Navaid.MaintType.Maintenance)
            {
                RPU_Maint = RPU_MaintON;
            }
            else if (_Airport.Navaid[rpunum].Maint == Navaid.MaintType.MainOff)
            {
                RPU_Maint = RPU_MaintOFF;
            }
            else if (_Airport.Navaid[rpunum].Maint == Navaid.MaintType.Maintenanceflash)
            {
                RPU_Maint = RPU_Maintflash;
            }

            // STATUS
            if (_Airport.Navaid[rpunum].Status == Navaid.StatusType.Normaml)
            {
                RPU_Status = RPU_StatusNML;
            }
            else if (_Airport.Navaid[rpunum].Status == Navaid.StatusType.Warning)
            {
                RPU_Status = RPU_StatusWar;
            }
            else if (_Airport.Navaid[rpunum].Status == Navaid.StatusType.Alarm)
            {
                RPU_Status = RPU_StatusAlm;
            }

            return (byte)(RPU_Buzzer | RPU_DataCom | RPU_Maint | RPU_Status);
        }

        // ICD BYTE 8 (RWY_STATUS)
        public byte RWY_1_2_Status(Airport _Airport)
        {
            const int RWY_OFF = 0x00;
            const int RWY1_ON = 0x02;
            const int RWY2_ON = 0x08;
            const int History = 0x00;

            int RWY1_Status = new int();
            int RWY2_Status = new int();

            for (int rwynum = 0; rwynum < 2; rwynum++)
            {
                if (_Airport.Runway[rwynum].Status == true)
                {
                    if(rwynum == 0)
                    {
                        RWY1_Status = RWY1_ON;
                    }
                    else if(rwynum == 1)
                    {
                        RWY2_Status = RWY2_ON;
                    }
                }
                else
                {
                    if (rwynum == 0)
                    {
                        RWY1_Status = RWY_OFF;
                    }
                    else if (rwynum == 1)
                    {
                        RWY2_Status = RWY_OFF;
                    } 
                }
            }
                return (Byte)(RWY1_Status| RWY2_Status| History);
        }

        // ICD BYTE 9 (Category, Control Available, Buzzer)
        public byte RWY_CAT_Data(Airport _Airport)
        {
            const int RWY_OFF = 0x00;
            const int RWY1_CAT3 = 0x01;
            const int RWY1_CAT1 = 0x02;
            const int RWY1_CATAlm = 0x03;
            const int RWY1_ContON = 0x04;
            const int RWY1_BuzzON = 0x08;

            const int RWY2_CAT3 = 0x10;
            const int RWY2_CAT1 = 0x20;
            const int RWY2_CATAlm = 0x30;
            const int RWY2_ContON = 0x40;
            const int RWY2_BuzzON = 0x80;

            int RWY1_CAT = new int();
            int RWY1_BUZZ = new int();
            int RWY1_Control = new int();

            int RWY2_CAT = new int();
            int RWY2_BUZZ = new int();
            int RWY2_Control = new int();

            for (int rwynum = 0; rwynum < 2; rwynum++)
            {
                //RUNWAY No. 1
                if (rwynum == 0)
                {
                    // 1. RWY_CATEGORY
                    if (_Airport.Runway[rwynum].Category == Runway.CategoryType.Cat3)
                    {
                        RWY1_CAT = RWY1_CAT3;
                    }
                    else if (_Airport.Runway[rwynum].Category == Runway.CategoryType.Cat1_2)
                    {
                        RWY1_CAT = RWY1_CAT1;
                    }
                    else if (_Airport.Runway[rwynum].Category == Runway.CategoryType.Alarm)
                    {
                        RWY1_CAT = RWY1_CATAlm;
                    }
                    else
                    {
                        RWY1_CAT = RWY_OFF;
                    }

                    // 2. RWY_CONTROL
                    if (_Airport.Runway[rwynum].RwyControl == true)
                    {
                        RWY1_Control = RWY1_ContON;
                    }
                    else
                    {
                        RWY1_Control = RWY_OFF;
                    }

                    // 3. RWY_BUZZER
                    if (_Airport.Runway[rwynum].Buzzer == true)
                    {
                        RWY1_BUZZ = RWY1_BuzzON;
                    }
                    else
                    {
                        RWY1_BUZZ = RWY_OFF;
                    }
                }
                //RUNWAY No. 2
                else if (rwynum == 1)
                {
                    // 1. RWY_CATEGORY
                    if (_Airport.Runway[rwynum].Category == Runway.CategoryType.Cat3)
                    {
                        RWY2_CAT = RWY2_CAT3;
                    }
                    else if (_Airport.Runway[rwynum].Category == Runway.CategoryType.Cat1_2)
                    {
                        RWY2_CAT = RWY2_CAT1;
                    }
                    else if (_Airport.Runway[rwynum].Category == Runway.CategoryType.Alarm)
                    {
                        RWY2_CAT = RWY2_CATAlm;
                    }
                    else
                    {
                        RWY2_CAT = RWY_OFF;
                    }

                    // 2. RWY_CONTROL
                    if (_Airport.Runway[rwynum].RwyControl == true)
                    {
                        RWY2_Control = RWY2_ContON;
                    }
                    else
                    {
                        RWY2_Control = RWY_OFF;
                    }

                    // 3. RWY_BUZZER
                    if (_Airport.Runway[rwynum].Buzzer == true)
                    {
                        RWY2_BUZZ = RWY2_BuzzON;
                    }
                    else
                    {
                        RWY2_BUZZ = RWY_OFF;
                    }
                }
            }
            return (Byte)(RWY1_CAT| RWY1_Control | RWY1_BUZZ | RWY2_CAT| RWY2_Control| RWY2_BUZZ);
        }

        // ICD BYTE 10 (RWY CONTROL RPU)
        public byte RWY_ContRPU(Airport _Airport)
        {
            const int RWY_OFF = 0x00;
            const int RWY1_RPUON = 0x01;
            const int RWY1_RPUOFF = 0x02;
            const int RWY1_RPUFlash = 0x03;

            const int RWY2_RPUON = 0x10;
            const int RWY2_RPUOFF = 0x20;
            const int RWY2_RPUFlash = 0x30;

            int RWY1_ContRPU = new int();
            int RWY2_ContRPU = new int();

            for (int rwynum = 0; rwynum < 2; rwynum++)
            {
                //RUNWAY No. 1
                if (rwynum == 0)
                {
                    if (_Airport.Runway[rwynum].PcControl == Runway.PcConrtrolType.On)
                    {
                        RWY1_ContRPU = RWY1_RPUON;
                    }
                    else if (_Airport.Runway[rwynum].PcControl == Runway.PcConrtrolType.Off)
                    {
                        RWY1_ContRPU = RWY1_RPUOFF;
                    }
                    else if (_Airport.Runway[rwynum].PcControl == Runway.PcConrtrolType.Flash)
                    {
                        RWY1_ContRPU = RWY1_RPUFlash;
                    }
                    else
                    {
                        RWY1_ContRPU = RWY_OFF;
                    }
                }
                //RUNWAY No. 2
                else if (rwynum == 1)
                {
                    if (_Airport.Runway[rwynum].PcControl == Runway.PcConrtrolType.On)
                    {
                        RWY2_ContRPU = RWY2_RPUON;
                    }
                    else if (_Airport.Runway[rwynum].PcControl == Runway.PcConrtrolType.Off)
                    {
                        RWY2_ContRPU = RWY2_RPUOFF;
                    }
                    else if (_Airport.Runway[rwynum].PcControl == Runway.PcConrtrolType.Flash)
                    {
                        RWY2_ContRPU = RWY2_RPUFlash;
                    }
                    else
                    {
                        RWY2_ContRPU = RWY_OFF;
                    }
                }
            }
            return (Byte)(RWY1_ContRPU | RWY2_ContRPU);
        }

    }
}
