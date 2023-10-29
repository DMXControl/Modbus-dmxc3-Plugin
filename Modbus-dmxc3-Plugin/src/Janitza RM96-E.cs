namespace org.dmxc.lumos.Kernel.Modbus
{
    public class Janitza_RM96_E : AbstractModbusMaster
    {
        public override string Description
        {
            get
            {
                return "TODO";
            }
        }

        public override int Timeout
        {
            get { return 3000; }
        }

        private AbstractModbusRegister[] registers = new AbstractModbusRegister[]
        {
            new Float32ModbusRegister(19000,"Voltage L1-N","V"),
            new Float32ModbusRegister(19002,"Voltage L2-N","V"),
            new Float32ModbusRegister(19004,"Voltage L3-N","V"),
            new Float32ModbusRegister(19006,"Voltage L1-L2","V"),
            new Float32ModbusRegister(19008,"Voltage L2-L3","V"),
            new Float32ModbusRegister(19010,"Voltage L3-L1","V"),
            new Float32ModbusRegister(19012,"Current L1","A"),
            new Float32ModbusRegister(19014,"Current L2","A"),
            new Float32ModbusRegister(19016,"Current L3","A"),
            new Float32ModbusRegister(19018,"Vector sum; IN=I1+I2+I3","A"),
            new Float32ModbusRegister(19020,"Real power P1 L1-N","W"),
            new Float32ModbusRegister(19022,"Real power P2 L2-N","W"),
            new Float32ModbusRegister(19024,"Real power P3 L3-N","W"),
            new Float32ModbusRegister(19026,"Sum; Psum3=P1+P2+P3","W"),
            new Float32ModbusRegister(19028,"Apparent power S1 L1-N","VA"),
            new Float32ModbusRegister(19030,"Apparent power S2 L2-N","VA"),
            new Float32ModbusRegister(19032,"Apparent power S3 L3-N","VA"),
            new Float32ModbusRegister(19034,"Sum; Ssum3=S1+S2+S3","VA"),
            new Float32ModbusRegister(19036,"Fund. reactive power Q1 L1-N","var"),
            new Float32ModbusRegister(19038,"Fund. reactive power Q2 L2-N","var"),
            new Float32ModbusRegister(19040,"Fund. reactive power Q3 L3-N","var"),
            new Float32ModbusRegister(19042,"Sum; Qsum3=Q1+Q2+Q3","var"),
            new Float32ModbusRegister(19044,"CosPhi; UL1 IL1 (fundamental comp.)"),
            new Float32ModbusRegister(19046,"CosPhi; UL2 IL2 (fundamental comp.)"),
            new Float32ModbusRegister(19048,"CosPhi; UL3 IL3 (fundamental comp.)"),
            new Float32ModbusRegister(19050,"Measured frequency", "Hz"),
            new Float32ModbusRegister(19052,"Rotation field; 1=right, 0=none, -1=left"),
            new Float32ModbusRegister(19054,"Real energy L1","Wh"),
            new Float32ModbusRegister(19056,"Real energy L2","Wh"),
            new Float32ModbusRegister(19058,"Real energy L3","Wh"),
            new Float32ModbusRegister(19060,"Real energy L1,L2,L3","Wh"),
            new Float32ModbusRegister(19062,"Real energy L1(consumed)","Wh"),
            new Float32ModbusRegister(19064,"Real energy L2(consumed)","Wh"),
            new Float32ModbusRegister(19066,"Real energy L3(consumed)","Wh"),
            new Float32ModbusRegister(19068,"Real energy L1,L2,L3(consumed)","Wh"),
            new Float32ModbusRegister(19070,"Real energy L1(delivered)","Wh"),
            new Float32ModbusRegister(19072,"Real energy L2(delivered)","Wh"),
            new Float32ModbusRegister(19074,"Real energy L3(delivered)","Wh"),
            new Float32ModbusRegister(19076,"Real energy L1,L2,L3(delivered)","Wh"),
            new Float32ModbusRegister(19078,"Apparent energy L1","VAh"),
            new Float32ModbusRegister(19080,"Apparent energy L2","VAh"),
            new Float32ModbusRegister(19082,"Apparent energy L3","VAh"),
            new Float32ModbusRegister(19084,"Apparent energy L1,L2,L3","VAh"),
            new Float32ModbusRegister(19086,"Reactive energy L1","varh"),
            new Float32ModbusRegister(19088,"Reactive energy L2","varh"),
            new Float32ModbusRegister(19090,"Reactive energy L3","varh"),
            new Float32ModbusRegister(19092,"Reactive energy L1,L2,L3","varh"),
            new Float32ModbusRegister(19094,"Reactive energy ind. L1","varh"),
            new Float32ModbusRegister(19096,"Reactive energy ind. L2","varh"),
            new Float32ModbusRegister(19098,"Reactive energy ind. L3","varh"),
            new Float32ModbusRegister(19100,"Reactive energy ind. L1,L2,L3","varh"),
            new Float32ModbusRegister(19102,"Reactive energy cap. L1","varh"),
            new Float32ModbusRegister(19104,"Reactive energy cap. L2","varh"),
            new Float32ModbusRegister(19106,"Reactive energy cap. L3","varh"),
            new Float32ModbusRegister(19108,"Reactive energy cap. L1,L2,L3","varh"),
            new Float32ModbusRegister(19110,"Harmonic, THD U L1-N","%"),
            new Float32ModbusRegister(19112,"Harmonic, THD U L2-N","%"),
            new Float32ModbusRegister(19114,"Harmonic, THD U L3-N","%"),
            new Float32ModbusRegister(19116,"Harmonic, THD I L1","%"),
            new Float32ModbusRegister(19118,"Harmonic, THD I L2","%"),
            new Float32ModbusRegister(19120,"Harmonic, THD I L3","%"),
        };
        public override AbstractModbusRegister[] Registers
        {
            get { return registers; }
        }

        public Janitza_RM96_E(string ipAddress, ushort port = 502) : base(ipAddress, port)
        {

        }
    }
}
