using System.Linq;
using LumosLIB.Tools;
using org.dmxc.lumos.Kernel.Modbus;
using T = LumosLIB.Tools.I18n.DummyT;

namespace org.dmxc.lumos.Kernel.Input.v2.Worker
{
    
#if DEBUG
    public
#endif
        class APCUPSNode : AbstractModbusMasterNode
    {
        public static readonly string NAME = T._("APCUPS");
        public static readonly string TYPE = "__APCUPS";

        private ushort[] defaultVisibleAddresses = new ushort[] {4, 5, 6, 7, 8, 15, 16, 17, 18};
        public APCUPSNode(GraphNodeID id)
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
            new APC_MGEGalaxy3500_SmartUPSVT_SmartUPS("192.168.11.200");
    }
}
