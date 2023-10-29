using LumosLIB.Kernel;
using LumosLIB.Tools;
using LumosProtobuf;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class ShortModbusOutputSink : AbstractModbusOutputSink
    {
        private static ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "Short");
        public ShortModbusOutputSink(ushort address) : base(getID(address), address, getName(address), CATEGORY)
        {
        }

        private static string getID(ushort address)
        {
            return string.Format("shortModbusRegisterSink-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("Short: {0}", address);
        }

        protected override bool update(object newValue)
        {
            long value;
            LumosTools.TryConvertToInt64(newValue, out value);
            ModbusManager.SetHoldingRegister(this.Address, (short)value.Limit(short.MinValue, short.MaxValue));
            return true;
        }

        protected override object min
        {
            get { return short.MinValue; }
        }

        protected override object max
        {
            get { return short.MaxValue; }
        }
    }
}