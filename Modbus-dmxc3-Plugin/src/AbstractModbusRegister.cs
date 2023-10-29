using LumosToolsLIB.Tools;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public abstract partial class AbstractModbusMaster
    {
        public abstract class AbstractModbusRegister
        {
            public readonly ushort Address;
            public readonly ushort Length;
            public readonly string Name;

            public abstract object Value { get; }

            public event EventHandler ValueChanged;

            public AbstractModbusRegister(ushort address, ushort length, string name = null)
            {
                this.Address = address;
                this.Length = length;
                this.Name = name;
            }

            internal virtual void processNewValues(int[] values)
            {
                this.ValueChanged?.InvokeFailSafe(this, EventArgs.Empty);
            }

            public override string ToString()
            {
                return string.Format("{0}: {1}", this.Name, this.Value);
            }
        }
    }
}