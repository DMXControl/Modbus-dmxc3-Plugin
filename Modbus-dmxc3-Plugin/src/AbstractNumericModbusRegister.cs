namespace org.dmxc.lumos.Kernel.Modbus
{
    public abstract partial class AbstractModbusMaster
    {
        public abstract class AbstractNumericModbusRegister : AbstractModbusRegister
        {
            public readonly string Unit;

            public AbstractNumericModbusRegister(ushort address, ushort length, string name, string unit) : base(address, length, name)
            {
                this.Unit = unit;
            }


            public sealed override string ToString()
            {
                if (!string.IsNullOrWhiteSpace(Unit))
                    return string.Format("{0}: {1} {2}", this.Name, this.Value, this.Unit);
                else
                    return string.Format("{0}: {1}", this.Name, this.Value);
            }
        }
    }
}