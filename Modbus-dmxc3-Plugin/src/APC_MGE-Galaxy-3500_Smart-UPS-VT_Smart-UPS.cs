using System;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class APC_MGEGalaxy3500_SmartUPSVT_SmartUPS:AbstractModbusMaster
    {
        public override string Description
        {
            get
            {
                return "Supported APS UPS:" + Environment.NewLine +
                       "MGE Galaxy 3500, Smart-UPS VT, and Smart-UPS" + Environment.NewLine +
                       "Excluding UPS models with prefix SMT, SMX, SURTD, and SRT";
            }
        }

        public override int Timeout
        {
            get { return 3000; }
        }

        private AbstractModbusRegister[] registers= new AbstractModbusRegister[]
        {
            new BoolModbusRegister(0,0,"UPS turning on"),
            new BoolModbusRegister(0,1,"UPS in bypass due to an internal fault"),
            new BoolModbusRegister(0,2,"UPS going to bypass due to command"),
            new BoolModbusRegister(0,3,"UPS in bypass due to command"),
            new BoolModbusRegister(0,4,"UPS returning from bypass"),
            new BoolModbusRegister(0,5,"UPS in bypass mode as a result of manual bypass control"),
            new BoolModbusRegister(0,6,"UPS ready to power load upon user command"),
            new BoolModbusRegister(0,7,"UPS ready to power load upon return of normal line or upon user command"),
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED

            new BoolModbusRegister(1,0,"UPS output not powered due to low battery shutdown"),
            new BoolModbusRegister(1,1,"UPS unable to transfer to on-battery operation due to overload"),
            new BoolModbusRegister(1,2,"UPS fault - main relay malfunction"),
            new BoolModbusRegister(1,3,"UPS in sleep mode"),
            new BoolModbusRegister(1,4,"UPS in shutdown mode"),
            new BoolModbusRegister(1,5,"UPS fault - battery charger failure"),
            new BoolModbusRegister(1,7,"UPS fault - internal temperature has exceeded nominal limits"),
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            new BoolModbusRegister(2,4,"UPS fault - UPS in bypass; or DC imbalance in inverter"),
            new BoolModbusRegister(2,5,"UPS commanded out of bypass with no batteries attached; or No batteries attached"),
            new BoolModbusRegister(2,6,"Boost or trim relay fault"),
            new BoolModbusRegister(2,7,"Inverter fault; or Output overvoltage"),
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED

            new BoolModbusRegister(3,0,"Performing battery calibration discharge"),
            new BoolModbusRegister(3,1,"Smart trim"),
            new BoolModbusRegister(3,2,"Smart boost"),
            new BoolModbusRegister(3,3,"On line"),
            new BoolModbusRegister(3,4,"On battery"),
            new BoolModbusRegister(3,5,"Overload"),
            new BoolModbusRegister(3,6,"Low battery (runtime remaining <= low battery duraton)"),
            new BoolModbusRegister(3,7,"Replace battery"),
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED

            new LineQualityModbusRegister(4,"Line Quality"),
            new UInt16ModbusRegister(5,"Battery State of Charge","%"),
            new UInt16ModbusRegister(6,"Runtime Remaining","m"),
            new UInt16ModbusRegister(7,"Battery Voltage","V"),
            new UInt16ModbusRegister(8,"UPS Internal Temperature", "°C"),
            new UInt16ModbusRegister(9,"Amps Drawn by Load","A"),
            new UInt16ModbusRegister(10,"Quantity of battery packs with bad batteries"),
            new UInt16ModbusRegister(11,"Quantity of battery packs"),
            new UInt16ModbusRegister(12,"Power drawn by load","%"),
            new UInt16ModbusRegister(13,"Nominal Output Voltage", "V"),
            new UInt16ModbusRegister(14,"Actual Output Voltage", "V"),
            new UInt16ModbusRegister(15,"Maximum Input Voltage Since Last Reading", "V"),
            new UInt16ModbusRegister(16,"Minimum Input Voltage Since Last Reading", "V"),
            new UInt16ModbusRegister(17,"Input Voltage", "V"),
            new UInt16ModbusRegister(18,"Input Frequency", "Hz"),
            new UInt16ModbusRegister(19,"Measure-UPS Temperature Reading (Probe 1)", "°C"),
            new UInt16ModbusRegister(20,"Measure-UPS Humidity Reading (Probe 1)","%"),
            new UInt16ModbusRegister(21,"Measure-UPS Temperature Reading (Probe 2)", "°C"),
            new UInt16ModbusRegister(22,"Measure-UPS Humidity Reading (Probe 2) ","%"),
            new UInt16ModbusRegister(23,"Measure-UPS Contact Position"),
            //RESERVED
            //RESERVED
            new UInt16ModbusRegister(26,"Minimum Return Battery Capacity","%"),
            new UInt16ModbusRegister(27,"Lower Transfer Point", "V"),
            new UInt16ModbusRegister(28,"Upper Transfer Point", "V"),
            new UInt16ModbusRegister(29,"Nominal Output Voltage", "V"),
            new UInt16ModbusRegister(30,"Shutdown Delay", "s"),
            new UInt16ModbusRegister(31,"Low Battery Duration","m"),
            new UInt16ModbusRegister(32,"Turn On Delay", "s"),
            new EnumModbusRegister(33,"Sensitivity"),//WIP
            new ASCIIModbusRegister(34,"UPS ID Character #1"),
            new ASCIIModbusRegister(35,"UPS ID Character #2"),
            new ASCIIModbusRegister(36,"UPS ID Character #3"),
            new ASCIIModbusRegister(37,"UPS ID Character #4"),
            new ASCIIModbusRegister(38,"UPS ID Character #5"),
            new ASCIIModbusRegister(39,"UPS ID Character #6"),
            new ASCIIModbusRegister(40,"UPS ID Character #7"),
            new ASCIIModbusRegister(41,"UPS ID Character #8"),

            //RESERVED
            //RESERVED
            //RESERVED
            new BoolModbusRegister(42,3,"Run time below alarm threshold"),
            new BoolModbusRegister(42,4,"XR frame fault"),
            new BoolModbusRegister(42,5,"Output voltage out of range"),
            new BoolModbusRegister(42,6,"System not synchronized"),
            new BoolModbusRegister(42,7,"No batteries"),
            new BoolModbusRegister(42,8,"Battery voltage high"),
            new BoolModbusRegister(42,9,"Fault"),
            new BoolModbusRegister(42,10,"Site wiring fault"),
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            
            new BoolModbusRegister(43,0,"An installed Power Module has failed"),
            //RESERVED
            //RESERVED
            new BoolModbusRegister(43,3,"An installed Battery has failed"),
            new BoolModbusRegister(43,4,"Load is above alarm threshold"),
            //RESERVED
            //RESERVED
            new BoolModbusRegister(43,7,"Bypass not in range (either freq or voltage unacceptable)"),
            //RESERVED
            //RESERVED
            new BoolModbusRegister(43,10,"UPS in bypass due to internal fault"),
            new BoolModbusRegister(43,11,"UPS in bypass due to overload"),
            new BoolModbusRegister(43,12,"System is in maintenance bypass"),
            //RESERVED
            new BoolModbusRegister(43,14,"System level fan failed"),
            //RESERVED

            new UInt16ModbusRegister(44,"Nominal Battery Voltage", "V"),
            new UInt16ModbusRegister(45,"Actual Battery Voltage", "V"),
            new UInt16ModbusRegister(46,"Utility Input Voltage Phase A", "V"),
            new UInt16ModbusRegister(47,"Utility Input Current Phase A", "A"),
            new UInt16ModbusRegister(48,"Bypass Input Voltage Phase A", "V"),
            new UInt16ModbusRegister(49,"Percent of Maximum Output VA’s Phase A @ n+0", "%"),
            new UInt16ModbusRegister(50,"Percent of Maximum Output VA’s Phase A @ n+x", "%"),
            new UInt16ModbusRegister(51,"Phase A Output kVA", "kVA"),
            new UInt16ModbusRegister(52,"Output Voltage Phase A", "V"),
            new UInt16ModbusRegister(53,"Output Current Phase A", "V"),
            new UInt16ModbusRegister(54,"Peak Output Current Phase A", "A"),
            new UInt16ModbusRegister(55,"Utility Input Voltage Phase B", "V"),
            new UInt16ModbusRegister(56,"Utility Input Current Phase B", "A"),
            new UInt16ModbusRegister(57,"Bypass Input Voltage Phase B", "V"),
            new UInt16ModbusRegister(58,"Percent of Maximum Output VA’s Phase B @ n+0", "%"),
            new UInt16ModbusRegister(59,"Percent of Maximum Output VA’s Phase B @ n+x", "%"),
            new UInt16ModbusRegister(60,"Phase B Output kVA", "kVA"),
            new UInt16ModbusRegister(61,"Output Voltage Phase B", "V"),
            new UInt16ModbusRegister(62,"Output Current Phase B", "A"),
            new UInt16ModbusRegister(63,"Peak Output Current Phase B", "A"),
            new UInt16ModbusRegister(64,"Utility Input Voltage Phase C", "V"),
            new UInt16ModbusRegister(65,"Utility Input Current Phase C", "A"),
            new UInt16ModbusRegister(66,"Bypass Input Voltage Phase C", "V"),
            new UInt16ModbusRegister(67,"Percent of Maximum Output VA’s Phase C @ n+0", "%"),
            new UInt16ModbusRegister(68,"Percent of Maximum Output VA’s Phase C @ n+x", "%"),
            new UInt16ModbusRegister(69,"Phase C Output kVA", "kVA"),
            new UInt16ModbusRegister(70,"Output Voltage Phase C", "V"),
            new UInt16ModbusRegister(71,"Output Current Phase C", "A"),
            new UInt16ModbusRegister(72,"Peak Output Current Phase C", "A"),
            //RESERVED
            //RESERVED
            
            new BoolModbusRegister(73,0,"Parallel config fault"),
            new BoolModbusRegister(73,1,"Dust filter must be changed soon"),
            new BoolModbusRegister(73,2,"Dust filter must be changed immediately"),
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            
            new BoolModbusRegister(74,0,"EPO active"),
            new BoolModbusRegister(74,1,"SBS fault"),
            new BoolModbusRegister(74,2,"System config fault"),
            new BoolModbusRegister(74,3,"Emergency PSU fault"),
            new BoolModbusRegister(74,4,"Weak battery"),
            new BoolModbusRegister(74,5,"Battery over temp"),
            new BoolModbusRegister(74,6,"Mechanical bypass active (not a fault)"),
            new BoolModbusRegister(74,7,"Parallel redundancy lost"),
            new BoolModbusRegister(74,8,"Parallel bus comm lost cable 1"),
            new BoolModbusRegister(74,9,"Parallel bus comm lost cable 2"),
            new BoolModbusRegister(74,10,"Auxiliary bus comm los"),
            new BoolModbusRegister(74,11,"Parallel bus termination fault cable 1"),
            new BoolModbusRegister(74,12,"Parallel bus termination fault cable 2"),
            new BoolModbusRegister(74,13,"Auxiliary bus termination fault"),
            new BoolModbusRegister(74,14,"No master in parallel system"),
            new BoolModbusRegister(74,15,"Overload on parallel unit"),

            new UInt16ModbusRegister(75,"Battery Current", "A"),
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
        };
        public override AbstractModbusRegister[] Registers
        {
            get { return registers; }
        }

        public APC_MGEGalaxy3500_SmartUPSVT_SmartUPS(string ipAddress, ushort port = 502) : base(ipAddress, port)
        {

        }

        private sealed class LineQualityModbusRegister : AbstractNumericModbusRegister
        {
            public double QualityValue { get; private set; }
            public override object Value
            {
                get { return this.QualityValue; }
            }
            
            public LineQualityModbusRegister(ushort address, string name = null) : base(address, 1, name,"%")
            {
            }

            internal override void processNewValues(int[] values)
            {
                this.QualityValue = values[0] / 2.55;
                base.processNewValues(values);
            }
        }
    }
}
