namespace org.dmxc.lumos.Kernel.Modbus
{
    public abstract partial class AbstractModbusMaster
    {
        public sealed class EnumModbusRegister: AbstractModbusRegister
        {
            private object value;
            public override object Value
            {
                get { return this.value; }
            }

            public EnumModbusRegister(ushort address, string name = null): base (address, 1, name)
            {
            }

            internal override void processNewValues(int[] values)
            {
                this.value = values;
                base.processNewValues(values);
            }
        }
    }
}