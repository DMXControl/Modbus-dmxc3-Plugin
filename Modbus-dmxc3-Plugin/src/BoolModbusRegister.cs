namespace org.dmxc.lumos.Kernel.Modbus
{
    public abstract partial class AbstractModbusMaster
    {
        public sealed class BoolModbusRegister : AbstractModbusRegister
        {
            public readonly byte Bit;
            public bool BoolValue { get; private set; }
            public override object Value
            {
                get { return this.BoolValue; }
            }

            public BoolModbusRegister(ushort address, byte bit, string name = null) : base(address, 1, name)
            {
                this.Bit = bit;
            }

            internal override void processNewValues(int[] values)
            {
                this.BoolValue = (values[0] & (1 << this.Bit)) != 0;
                base.processNewValues(values);
            }
        }
    }
}