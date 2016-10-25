using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCSE.Data;
using System.Windows.Forms;

namespace RCSE.Simulator
{
    public class RwyBinding
    {
        private RwyBuzzer _RwyBuzzer;
        private RwyCat _RwyCat;
        private RwyPcControl _RwyPcControl;
        private RwyControl _RwyControl;
        private RwyStatus _RwyStatus;
        private GroupBox _RwyBox;
        private Runway _Runway;

        public void RwyGetStatus()
        {
            _Runway.Buzzer = _RwyBuzzer.GetValue();
            _Runway.Category = _RwyCat.GetValue();
            _Runway.PcControl = _RwyPcControl.GetValue();
            _Runway.RwyControl = _RwyControl.GetValue();
            _Runway.Status = _RwyStatus.GetValue();
        }
        public void RwySetStatus()
        {
            _RwyBuzzer.SetValue(_Runway.Buzzer);
            _RwyCat.SetValue(_Runway.Category);
            _RwyPcControl.SetValue(_Runway.PcControl);
            _RwyControl.SetValue(_Runway.RwyControl);
            _RwyStatus.SetValue(_Runway.Status);
        }

        public RwyBinding(RwyBuzzer rwybuzzer, RwyCat rwycat, RwyPcControl rwypccontrol, RwyControl rwycontrol, RwyStatus rwystatus, GroupBox rwybox, Runway runway)
        {
            _RwyBuzzer = rwybuzzer;
            _RwyCat = rwycat;
            _RwyPcControl = rwypccontrol;
            _RwyControl = rwycontrol;
            _RwyStatus = rwystatus;
            _RwyBox = rwybox;
            _Runway = runway;

            rwybox.Text = rwybox.Text + " " + runway.Name;

            if (_Runway.Enable)
            {
                rwybox.Enabled = true;
            }
            else
            {
                rwybox.Enabled = false;
            }
        }
    }
    public class RwyStatus
    {
        private RadioButton StatusOn, StatusOff;

        public bool GetValue()
        {
            if (StatusOn.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetValue(bool status)
        {
            if (status)
            {
                StatusOn.Checked = true;
            }
            else
            {
                StatusOff.Checked = true;
            }
        }
        public RwyStatus(RadioButton statuson, RadioButton statusoff)
        {
            StatusOn = statuson;
            StatusOff = statusoff;
        }
    }
    public class RwyControl
    {
        private RadioButton ControlOn, ControlOff;

        public bool GetValue()
        {
            if (ControlOn.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetValue(bool status)
        {
            if (status)
            {
                ControlOn.Checked = true;
            }
            else
            {
                ControlOff.Checked = true;
            }
        }
        public RwyControl(RadioButton controlon, RadioButton controloff)
        {
            ControlOn= controlon;
            ControlOff = controloff;
        }
    }
    public class RwyCat
    {
        private RadioButton CatAlarm, CatI_II, CatIII, CatNoRwy;

        public Runway.CategoryType GetValue()
        {
            if (CatAlarm.Checked)
            {
                return Runway.CategoryType.Alarm;
            }
            else if (CatI_II.Checked)
            {
                return Runway.CategoryType.Cat1_2;
            }
            else if (CatIII.Checked)
            {
                return Runway.CategoryType.Cat3;
            }
            else
            {
                return Runway.CategoryType.NoRunway;
            }
        }
        public void SetValue(Runway.CategoryType status)
        {
            if (status == Runway.CategoryType.Alarm)
            {
                CatAlarm.Checked = true;
            }
            else if (status == Runway.CategoryType.Cat1_2)
            {
                CatI_II.Checked = true;
            }
            else if (status == Runway.CategoryType.Cat3)
            {
                CatIII.Checked = true;
            }
            else
            {
                CatNoRwy.Checked = true;
            }
        }
        public RwyCat (RadioButton catalarm, RadioButton catiii, RadioButton cati_ii, RadioButton catoff)
        {
            CatAlarm = catalarm;
            CatIII = catiii;
            CatI_II = cati_ii;
            CatNoRwy = catoff;
        }
    }
    public class RwyPcControl
    {
        private RadioButton PcFlash, PcOn, PcOff;

        public Runway.PcConrtrolType GetValue()
        {
            if (PcFlash.Checked)
            {
                return Runway.PcConrtrolType.Flash;
            }
            else if (PcOn.Checked)
            {
                return Runway.PcConrtrolType.On;
            }
            else
            {
                return Runway.PcConrtrolType.Off;
            }
        }
        public void SetValue(Runway.PcConrtrolType status)
        {
            if (status == Runway.PcConrtrolType.Flash)
            {
                PcFlash.Checked = true;
            }
            else if (status == Runway.PcConrtrolType.On)
            {
                PcOn.Checked = true;
            }
            else
            {
                PcOff.Checked = true;
            }
        }
        public RwyPcControl(RadioButton pcflash, RadioButton pcon, RadioButton pcoff)
        {
            PcFlash = pcflash;
            PcOn = pcon;
            PcOff = pcoff;
        }
    }
    public class RwyBuzzer
    {
        private RadioButton BuzzerOn, BuzzerOff;

        public bool GetValue()
        {
            if (BuzzerOn.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetValue(bool status)
        {
            if (status)
            {
                BuzzerOn.Checked = true;
            }
            else
            {
                BuzzerOff.Checked = true;
            }
        }
        public RwyBuzzer(RadioButton buzzeron, RadioButton buzzeroff)
        {
            BuzzerOn = buzzeron;
            BuzzerOff = buzzeroff;
        }
    }
}
