using LumosLIB.Kernel;
using LumosLIB.Tools;
using LumosProtobuf;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class DoubleModbusOutputSink: AbstractModbusOutputSink
    {
        private static ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "Double");
        public DoubleModbusOutputSink(ushort address) : base(getID(address), address, getName(address), CATEGORY)
        {
        }

        private static string getID(ushort address)
        {
            return string.Format("doubleModbusRegisterSink-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("Double: {0}", address);
        }

        protected override bool update(object newValue)
        {
            double value;
            LumosTools.TryConvertToDouble(newValue, out value);
            ModbusManager.SetHoldingRegister(this.Address, value.Limit(double.MinValue, double.MaxValue));
            return true;
        }

        protected override object min
        {
            get { return double.MinValue; }
        }

        protected override object max
        {
            get { return double.MaxValue; }
        }
    }
}