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
            InitializeAirport();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Program.airportBinding.AptSetData();
            Program.airportBinding.AptSetData();
        }
        private void InitializeAirport()
        {
            InitializeRunway1();
            InitializeRunway2();
            InitializeRpu1();
            InitializeRpu2();
            InitializeRpu3();
            InitializeRpu4();
            InitializeRpu5();
            InitializeRpu6();
            InitializeRpu7();
            InitializeRpu8();
        }
        private void InitializeRunway1()
        {
            RwyStatus rwystatus1 = new RwyStatus(runwayStatusOn1, runwayStatusOff1);
            RwyControl rwycontrol1 = new RwyControl(runwayControlOn1, runwayControlOff1);
            RwyCat rwycat1 = new RwyCat(runwayCategoryAlarm1, runwayCategoryIII1, runwayCategoryI1, runwayCategoryNo1);
            RwyPcControl rwypccontrol1 = new RwyPcControl(pccontrolStatusFlash1, pccontrolStatusOn1, pccontrolStatusOff1);
            RwyBuzzer rwybuzzer1 = new RwyBuzzer(runwayBuzzerEnable1, runwayBuzzerDisable1);
            RwyBinding rwybinding1 = new RwyBinding(rwybuzzer1, rwycat1, rwypccontrol1, rwycontrol1, rwystatus1, runway1, Program.airportConfig.Runway[0]);

            Program.airportBinding._RwyBinding.Add(rwybinding1);
        }
        private void InitializeRunway2()
        {
            RwyStatus rwystatus2 = new RwyStatus(runwayStatusOn2, runwayStatusOff2);
            RwyControl rwycontrol2 = new RwyControl(runwayControlOn2, runwayControlOff2);
            RwyCat rwycat2 = new RwyCat(runwayCategoryAlarm2, runwayCategoryIII2, runwayCategoryI2, runwayCategoryNo2);
            RwyPcControl rwypccontrol2 = new RwyPcControl(pccontrolStatusFlash2, pccontrolStatusOn2, pccontrolStatusOff2);
            RwyBuzzer rwybuzzer2 = new RwyBuzzer(runwayBuzzerEnable2, runwayBuzzerDisable2);
            RwyBinding rwybinding2 = new RwyBinding(rwybuzzer2, rwycat2, rwypccontrol2, rwycontrol2, rwystatus2, runway2, Program.airportConfig.Runway[1]);

            Program.airportBinding._RwyBinding.Add(rwybinding2);
        }
        private void InitializeRpu1()
        {
            RpuDataCom rpudatacom1 = new RpuDataCom(datacomFlash1, datacomOn1, datacomOff1);
            RpuMaintenance rpumaintenance1 = new RpuMaintenance(maintFlash1, maintOn1, maintOff1);
            RpuStatus rpustatus1 = new RpuStatus(statusAlarm1, statusWarning1, statusNormal1, statusOff1);
            RpuBuzzer rpubuzzer1 = new RpuBuzzer(buzzerEnable1, buzzerDisable1);
            RpuBinding rpubinding1 = new RpuBinding(rpubuzzer1, rpudatacom1, rpumaintenance1, rpustatus1, rpu1, Program.airportConfig.Navaid[0]);

            Program.airportBinding._RpuBinding.Add(rpubinding1);
        }
        private void InitializeRpu2()
        {
            RpuDataCom rpudatacom2 = new RpuDataCom(datacomFlash2, datacomOn2, datacomOff2);
            RpuMaintenance rpumaintenance2 = new RpuMaintenance(maintFlash2, maintOn2, maintOff2);
            RpuStatus rpustatus2 = new RpuStatus(statusAlarm2, statusWarning2, statusNormal2, statusOff2);
            RpuBuzzer rpubuzzer2 = new RpuBuzzer(buzzerEnable2, buzzerDisable2);
            RpuBinding rpubinding2 = new RpuBinding(rpubuzzer2, rpudatacom2, rpumaintenance2, rpustatus2, rpu2, Program.airportConfig.Navaid[1]);

            Program.airportBinding._RpuBinding.Add(rpubinding2);
        }
        private void InitializeRpu3()
        {
            RpuDataCom rpudatacom3 = new RpuDataCom(datacomFlash3, datacomOn3, datacomOff3);
            RpuMaintenance rpumaintenance3 = new RpuMaintenance(maintFlash3, maintOn3, maintOff3);
            RpuStatus rpustatus3 = new RpuStatus(statusAlarm3, statusWarning3, statusNormal3, statusOff3);
            RpuBuzzer rpubuzzer3 = new RpuBuzzer(buzzerEnable3, buzzerDisable3);
            RpuBinding rpubinding3 = new RpuBinding(rpubuzzer3, rpudatacom3, rpumaintenance3, rpustatus3, rpu3, Program.airportConfig.Navaid[2]);

            Program.airportBinding._RpuBinding.Add(rpubinding3);
        }
        private void InitializeRpu4()
        {
            RpuDataCom rpudatacom4 = new RpuDataCom(datacomFlash4, datacomOn4, datacomOff4);
            RpuMaintenance rpumaintenance4 = new RpuMaintenance(maintFlash4, maintOn4, maintOff4);
            RpuStatus rpustatus4 = new RpuStatus(statusAlarm4, statusWarning4, statusNormal4, statusOff4);
            RpuBuzzer rpubuzzer4 = new RpuBuzzer(buzzerEnable4, buzzerDisable4);
            RpuBinding rpubinding4 = new RpuBinding(rpubuzzer4, rpudatacom4, rpumaintenance4, rpustatus4, rpu4, Program.airportConfig.Navaid[3]);

            Program.airportBinding._RpuBinding.Add(rpubinding4);
        }
        private void InitializeRpu5()
        {
            RpuDataCom rpudatacom5 = new RpuDataCom(datacomFlash5, datacomOn5, datacomOff5);
            RpuMaintenance rpumaintenance5 = new RpuMaintenance(maintFlash5, maintOn5, maintOff5);
            RpuStatus rpustatus5 = new RpuStatus(statusAlarm5, statusWarning5, statusNormal5, statusOff5);
            RpuBuzzer rpubuzzer5 = new RpuBuzzer(buzzerEnable5, buzzerDisable5);
            RpuBinding rpubinding5 = new RpuBinding(rpubuzzer5, rpudatacom5, rpumaintenance5, rpustatus5, rpu5, Program.airportConfig.Navaid[4]);

            Program.airportBinding._RpuBinding.Add(rpubinding5);
        }
        private void InitializeRpu6()
        {
            RpuDataCom rpudatacom6 = new RpuDataCom(datacomFlash6, datacomOn6, datacomOff6);
            RpuMaintenance rpumaintenance6 = new RpuMaintenance(maintFlash6, maintOn6, maintOff6);
            RpuStatus rpustatus6 = new RpuStatus(statusAlarm6, statusWarning6, statusNormal6, statusOff6);
            RpuBuzzer rpubuzzer6 = new RpuBuzzer(buzzerEnable6, buzzerDisable6);
            RpuBinding rpubinding6 = new RpuBinding(rpubuzzer6, rpudatacom6, rpumaintenance6, rpustatus6, rpu6, Program.airportConfig.Navaid[5]);

            Program.airportBinding._RpuBinding.Add(rpubinding6);
        }
        private void InitializeRpu7()
        {
            RpuDataCom rpudatacom7 = new RpuDataCom(datacomFlash7, datacomOn7, datacomOff7);
            RpuMaintenance rpumaintenance7 = new RpuMaintenance(maintFlash7, maintOn7, maintOff7);
            RpuStatus rpustatus7 = new RpuStatus(statusAlarm7, statusWarning7, statusNormal7, statusOff7);
            RpuBuzzer rpubuzzer7 = new RpuBuzzer(buzzerEnable7, buzzerDisable7);
            RpuBinding rpubinding7 = new RpuBinding(rpubuzzer7, rpudatacom7, rpumaintenance7, rpustatus7, rpu7, Program.airportConfig.Navaid[6]);

            Program.airportBinding._RpuBinding.Add(rpubinding7);
        }
        private void InitializeRpu8()
        {
            RpuDataCom rpudatacom8 = new RpuDataCom(datacomFlash8, datacomOn8, datacomOff8);
            RpuMaintenance rpumaintenance8 = new RpuMaintenance(maintFlash8, maintOn8, maintOff8);
            RpuStatus rpustatus8 = new RpuStatus(statusAlarm8, statusWarning8, statusNormal8, statusOff8);
            RpuBuzzer rpubuzzer8 = new RpuBuzzer(buzzerEnable8, buzzerDisable8);
            RpuBinding rpubinding8 = new RpuBinding(rpubuzzer8, rpudatacom8, rpumaintenance8, rpustatus8, rpu8, Program.airportConfig.Navaid[7]);

            Program.airportBinding._RpuBinding.Add(rpubinding8);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Time is up!!!");
            Program.airportBinding.AptGetData();
            Program.airportBinding.AptGetData();
            debugRunway(1);
            debugRpu(0);
        }
        private void debugRunway (int num)
        {
            Console.WriteLine("Runway-" + num + " " + Program.airportConfig.Runway[num].Name);
            Console.WriteLine("Runway Control " + Program.airportConfig.Runway[num].RwyControl);
            Console.WriteLine("Runway Status " + Program.airportConfig.Runway[num].Status);
            Console.WriteLine("Runway Buzzer " + Program.airportConfig.Runway[num].Buzzer);
            Console.WriteLine("Runway Category " + Program.airportConfig.Runway[num].Category);
            Console.WriteLine("Runway Pc Control " + Program.airportConfig.Runway[num].PcControl);
        }
        private void debugRpu(int num)
        {
            Console.WriteLine("Rpu-" + num + " " + Program.airportConfig.Navaid[num].Name);
            Console.WriteLine("Rpu Buzzer " + Program.airportConfig.Navaid[num].Buzzer);
            Console.WriteLine("Rpu Data Com " + Program.airportConfig.Navaid[num].DataCom);
            Console.WriteLine("Rpu Maintenance " + Program.airportConfig.Navaid[num].Maint);
            Console.WriteLine("Rpu Status " + Program.airportConfig.Navaid[num].Status);
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (String.Equals(buttonStart.Text, "Start"))
            {
                buttonStart.Text = "Stop";

                numericUpDown1.Enabled = false;

                timer1.Interval = Decimal.ToInt32(numericUpDown1.Value) * 1000;
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                buttonStart.Text = "Start";

                numericUpDown1.Enabled = true;

                timer1.Stop();
            }
            
        }
    }
}
