using LumosLIB.Tools;
using org.dmxc.lumos.Kernel.Modbus;
using T = LumosLIB.Tools.I18n.DummyT;

namespace org.dmxc.lumos.Kernel.Input.v2.Worker
{
#if DEBUG
    public
#endif
        class SOCOMECPowerMeasurementNode : AbstractModbusMasterNode
    {
        public static readonly string NAME = T._("SOCOMECPowerMeasurement");
        public static readonly string TYPE = "__SOCOMECPowerMeasurement";

        private ushort[] defaultVisibleAddresses = new ushort[]
        {
            0xC550,
            0xC552,
            0xC554,
            0xC556,
            0xC558,
            0xC55A,
            0xC55C,
            0xC55E,
            0xC560,
            0xC562,
            0xC564,
            0xC566,
            0xC550,
            0xC550,
            0xC550
        };
        public SOCOMECPowerMeasurementNode(GraphNodeID id)
            : base(id, NAME, TYPE, KnownCategories.ELECTRICITY)
        {
        }

        public override void AddDefaultPorts()
        {
            base.AddDefaultPorts();

            this.OutputRegisters.ForEach(or =>
                ((AbstractGraphNodePort)or.Left).IsDefaultHidden = !defaultVisibleAddresses.Contains(or.Right.Address));
        }

        protected override AbstractModbusMaster ModbusMaster { get; } =
            new SOCOMEC_Ethernetgateway_DIRIS_40_DIRIS_41("192.168.1.19");
    }
}
