using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCSE.Data;

namespace RCSE.Simulator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class RpuRatioButton
    {
        List<RadioButton> rpuGroup;

        RpuRatioButton() { }
    }

    public class RpuDataCom
    {
        private RadioButton DataComFlash, DataComOn, DataComOff;
        private Navaid _Navaid;

        public Navaid.DataComType GetValue()
        {
            if (DataComFlash.Checked)
            {
                _Navaid.DataCom = Navaid.DataComType.Datacomflash;
            }
            else if (DataComOn.Checked)
            {
                _Navaid.DataCom = Navaid.DataComType.Datacom;
            }
            else
            {
                _Navaid.DataCom = Navaid.DataComType.Off;
            }

            return _Navaid.DataCom;
        }
        public RpuDataCom(RadioButton datacomflash, RadioButton datacomon, RadioButton datacomoff, Navaid navaid)
        {
            DataComFlash = datacomflash;
            DataComOn = datacomon;
            DataComOff = datacomoff;
            _Navaid = navaid;

            if(_Navaid.DataCom == Navaid.DataComType.Datacomflash)
            {
                DataComFlash.Checked = true;
            }
            else if(_Navaid.DataCom == Navaid.DataComType.Datacom)
            {
                DataComOn.Checked = true;
            }
            else
            {
                DataComOff.Checked = true;
            }
        }
    }

    public class RpuMaintenance
    {
        private RadioButton MaintFlash, MaintOn, MaintOff;
        private Navaid _Navaid;

        public Navaid.MaintType GetValue()
        {
            if (MaintFlash.Checked)
            {
                _Navaid.Maint = Navaid.MaintType.Maintenanceflash;
            }
            else if (MaintOn.Checked)
            {
                _Navaid.Maint = Navaid.MaintType.Maintenance;
            }
            else
            {
                _Navaid.Maint = Navaid.MaintType.MainOff;
            }

            return _Navaid.Maint;
        }
        public RpuMaintenance(RadioButton maintflash, RadioButton mainton, RadioButton maintoff, Navaid navaid)
        {
            MaintFlash = maintflash;
            MaintOn = mainton;
            MaintOff = maintoff;
            _Navaid = navaid;

            if (_Navaid.DataCom == Navaid.DataComType.Datacomflash)
            {
                MaintFlash.Checked = true;
            }
            else if (_Navaid.DataCom == Navaid.DataComType.Datacom)
            {
                MaintOn.Checked = true;
            }
            else
            {
                MaintOff.Checked = true;
            }
        }
    }
}
