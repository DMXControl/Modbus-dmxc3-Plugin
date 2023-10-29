namespace org.dmxc.lumos.Kernel.Modbus
{
    public abstract partial class AbstractModbusMaster
    {
        public sealed class ASCIIModbusRegister : AbstractModbusRegister
        {
            public Char ASCIIValue { get; private set; }
            public override object Value
            {
                get { return this.ASCIIValue; }
            }

            public ASCIIModbusRegister(ushort address, string name = null) : base(address, 1, name)
            {
            }

            internal override void processNewValues(int[] values)
            {
                this.ASCIIValue = Char.ConvertFromUtf32(values[0]).ToCharArray()[0];
                base.processNewValues(values);
            }
        }
    }
}