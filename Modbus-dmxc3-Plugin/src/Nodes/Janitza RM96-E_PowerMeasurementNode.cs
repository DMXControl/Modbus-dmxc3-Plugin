using System.Linq;
using LumosLIB.Tools;
using org.dmxc.lumos.Kernel.Modbus;
using T = LumosLIB.Tools.I18n.DummyT;

namespace org.dmxc.lumos.Kernel.Input.v2.Worker
{
#pragma warning disable CS0162 // Unerreichbarer Code wurde entdeckt.
#if DEBUG
    public
#endif
        class Janitza_RM96_E_PowerMeasurementNode : AbstractModbusMasterNode
    {
        public static readonly string NAME = T._("Janitza RM96-E PowerMeasurement");
        public static readonly string TYPE = "__Janitza_RM96_E_PowerMeasurement";
        
        private ushort[] defaultVisibleAddresses = new ushort[]
        {
        };
        public Janitza_RM96_E_PowerMeasurementNode(GraphNodeID id)
            : base(id, NAME, TYPE, KnownCategories.ELECTRICITY)
        {
        }

        public override void AddDefaultPorts()
        {
            base.AddDefaultPorts();
            return;
            this.OutputRegisters.ForEach(or =>
                ((AbstractGraphNodePort)or.Left).IsDefaultHidden = !defaultVisibleAddresses.Contains(or.Right.Address));
        }

        protected override AbstractModbusMaster ModbusMaster { get; } =
            new Janitza_RM96_E("192.168.200.9");
    }
#pragma warning restore CS0162 // Unerreichbarer Code wurde entdeckt.
}
