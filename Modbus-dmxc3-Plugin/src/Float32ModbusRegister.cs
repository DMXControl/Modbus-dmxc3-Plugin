using EasyModbus;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public abstract partial class AbstractModbusMaster
    {
        public sealed class Float32ModbusRegister: AbstractNumericModbusRegister
        {
            public float Float32Value { get; private set; }

            public override object Value
            {
                get { return this.Float32Value; }
            }

            public Float32ModbusRegister(ushort address, string name = null, string unit = null) : base(address, 2, name,
                unit)
            {
            }

            internal override void processNewValues(int[] values)
            {
                this.Float32Value = ModbusClient.ConvertRegistersToFloat(values, ModbusClient.RegisterOrder.HighLow);
                base.processNewValues(values);
            }
        }
    }
}