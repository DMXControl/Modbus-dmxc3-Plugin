using LumosLIB.Kernel;
using LumosLIB.Tools;
using LumosProtobuf;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class FloatModbusOutputSink : AbstractModbusOutputSink
    {
        private static ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "Float");
        public FloatModbusOutputSink(ushort address) : base(getID(address), address, getName(address), CATEGORY)
        {
        }

        private static string getID(ushort address)
        {
            return string.Format("floatModbusRegisterSink-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("Float: {0}", address);
        }

        protected override bool update(object newValue)
        {
            double value;
            LumosTools.TryConvertToDouble(newValue, out value);
            ModbusManager.SetHoldingRegister(this.Address, (float)value.Limit(float.MinValue, float.MaxValue));
            return true;
        }

        protected override object min
        {
            get { return float.MinValue; }
        }

        protected override object max
        {
            get { return float.MaxValue; }
        }
    }
}