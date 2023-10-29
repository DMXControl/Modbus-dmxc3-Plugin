namespace org.dmxc.lumos.Kernel.Modbus
{
    public abstract partial class AbstractModbusMaster
    {
        public sealed class UInt16ModbusRegister : AbstractNumericModbusRegister
        {
            public ushort UInt16Value { get; private set; }

            public override object Value
            {
                get { return this.UInt16Value; }
            }

            public UInt16ModbusRegister(ushort address, string name = null, string unit = null) : base(address, 1, name,
                unit)
            {
            }

            internal override void processNewValues(int[] values)
            {
                this.UInt16Value = (ushort)values[0];
                base.processNewValues(values);
            }
        }
    }
}