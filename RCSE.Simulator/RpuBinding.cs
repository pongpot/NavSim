using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCSE.Data;
using System.Windows.Forms;

namespace RCSE.Simulator
{
    public class RpuBinding
    {
        private RpuBuzzer _RpuBuzzer;
        private RpuDataCom _RpuDataCom;
        private RpuMaintenance _RpuMaintenance;
        private RpuStatus _RpuStatus;
        private GroupBox _RpuBox;
        private Navaid _Navaid;

        public void RpuGetStatus()
        {
            _Navaid.Buzzer = _RpuBuzzer.GetValue();
            _Navaid.DataCom = _RpuDataCom.GetValue();
            _Navaid.Maint = _RpuMaintenance.GetValue();
            _Navaid.Status = _RpuStatus.GetValue();
        }
        public void RpuSetStatus()
        {
            _RpuBuzzer.SetValue(_Navaid.Buzzer);
            _RpuDataCom.SetValue(_Navaid.DataCom);
            _RpuMaintenance.SetValue(_Navaid.Maint);
            _RpuStatus.SetValue(_Navaid.Status);
        }

        public RpuBinding(RpuBuzzer rpubuzzer, RpuDataCom rpudatacom, RpuMaintenance rpumaintenance, RpuStatus rpustatus, GroupBox rpubox, Navaid navaid)
        {
            _RpuBuzzer = rpubuzzer;
            _RpuDataCom = rpudatacom;
            _RpuMaintenance = rpumaintenance;
            _RpuStatus = rpustatus;
            _RpuBox = rpubox;
            _Navaid = navaid;

            if (_Navaid.Enable)
            {
                rpubox.Enabled = true;
            }
            else
            { 
                rpubox.Enabled = false;
            }
        }
    }
    public class RpuDataCom
    {
        private RadioButton DataComFlash, DataComOn, DataComOff;

        public Navaid.DataComType GetValue()
        {
            if (DataComFlash.Checked)
            {
                return Navaid.DataComType.Datacomflash;
            }
            else if (DataComOn.Checked)
            {
                return Navaid.DataComType.Datacom;
            }
            else
            {
                return Navaid.DataComType.Off;
            }
        }

        public void SetValue(Navaid.DataComType status)
        {
            if (status== Navaid.DataComType.Datacomflash)
            {
                DataComFlash.Checked = true;
            }
            else if (status == Navaid.DataComType.Datacom)
            {
                DataComOn.Checked = true;
            }
            else
            {
                DataComOff.Checked = true;
            }
        }
        public RpuDataCom(RadioButton datacomflash, RadioButton datacomon, RadioButton datacomoff)
        {
            DataComFlash = datacomflash;
            DataComOn = datacomon;
            DataComOff = datacomoff;
        }
    }
    public class RpuMaintenance
    {
        private RadioButton MaintFlash, MaintOn, MaintOff;

        public Navaid.MaintType GetValue()
        {
            if (MaintFlash.Checked)
            {
                return Navaid.MaintType.Maintenanceflash;
            }
            else if (MaintOn.Checked)
            {
                return Navaid.MaintType.Maintenance;
            }
            else
            {
                return Navaid.MaintType.Off;
            }
        }
        public void SetValue(Navaid.MaintType status)
        {
            if (status == Navaid.MaintType.Maintenanceflash)
            {
                MaintFlash.Checked = true;
            }
            else if (status == Navaid.MaintType.Maintenance)
            {
                MaintOn.Checked = true;
            }
            else
            {
                MaintOff.Checked = true;
            }
        }
        public RpuMaintenance(RadioButton maintflash, RadioButton mainton, RadioButton maintoff)
        {
            MaintFlash = maintflash;
            MaintOn = mainton;
            MaintOff = maintoff;
        }
    }
    public class RpuStatus
    {
        private RadioButton StatusAlarm, StatusWarning, StatusNormal, StatusOff;

        public Navaid.StatusType GetValue()
        {
            if (StatusAlarm.Checked)
            {
                return Navaid.StatusType.Alarm;
            }
            else if (StatusWarning.Checked)
            {
                return Navaid.StatusType.Warning;
            }
            else if (StatusNormal.Checked)
            {
                return Navaid.StatusType.Normaml;
            }
            else
            {
                return Navaid.StatusType.Off;
            }
        }
        public void SetValue(Navaid.StatusType status)
        {
            if (status == Navaid.StatusType.Alarm)
            {
                StatusAlarm.Checked = true;
            }
            else if (status == Navaid.StatusType.Warning)
            {
                StatusWarning.Checked = true;
            }
            else if (status == Navaid.StatusType.Normaml)
            {
                StatusNormal.Checked = true;
            }
            else
            {
                StatusOff.Checked = true;
            }
        }
        public RpuStatus(RadioButton statusalarm, RadioButton statuswarning, RadioButton statusnormal, RadioButton statusoff)
        {
            StatusAlarm = statusalarm;
            StatusWarning = statuswarning;
            StatusNormal = statusnormal;
            StatusOff = statusoff;
        }
    }
    public class RpuBuzzer
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
        public RpuBuzzer(RadioButton buzzeron, RadioButton buzzeroff)
        {
            BuzzerOn = buzzeron;
            BuzzerOff = buzzeroff;
        }
    }
}
