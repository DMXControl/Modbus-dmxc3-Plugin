namespace org.dmxc.lumos.Kernel.Modbus
{
    public abstract partial class AbstractModbusMaster
    {
        public sealed class Int16ModbusRegister: AbstractNumericModbusRegister
        {
            public short Int16Value { get; private set; }

            public override object Value
            {
                get { return this.Int16Value; }
            }

            public Int16ModbusRegister(ushort address, string name = null, string unit = null) : base(address, 1, name,
                unit)
            {
            }

            internal override void processNewValues(int[] values)
            {
                this.Int16Value = (short)values[0];
                base.processNewValues(values);
            }
        }
    }
}