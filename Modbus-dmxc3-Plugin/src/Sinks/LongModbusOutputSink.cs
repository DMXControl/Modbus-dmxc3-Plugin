using LumosLIB.Kernel;
using LumosLIB.Tools;
using LumosProtobuf;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class LongModbusOutputSink: AbstractModbusOutputSink
    {
        private static ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "Long");
        public LongModbusOutputSink(ushort address) : base(getID(address), address, getName(address), CATEGORY)
        {
        }

        private static string getID(ushort address)
        {
            return string.Format("longModbusRegisterSink-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("Long: {0}", address);
        }

        protected override bool update(object newValue)
        {
            long value;
            LumosTools.TryConvertToInt64(newValue, out value);
            ModbusManager.SetHoldingRegister(this.Address, (long)value.Limit(long.MinValue, long.MaxValue));
            return true;
        }

        protected override object min
        {
            get { return long.MinValue; }
        }

        protected override object max
        {
            get { return long.MaxValue; }
        }
    }
}