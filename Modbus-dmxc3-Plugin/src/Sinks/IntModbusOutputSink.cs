using LumosLIB.Kernel;
using LumosLIB.Tools;
using LumosProtobuf;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class IntModbusOutputSink : AbstractModbusOutputSink
    {
        private static ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "Int");
        public IntModbusOutputSink(ushort address) : base(getID(address), address, getName(address), CATEGORY)
        {
        }

        private static string getID(ushort address)
        {
            return string.Format("intModbusRegisterSink-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("Int: {0}", address);
        }

        protected override bool update(object newValue)
        {
            long value;
            LumosTools.TryConvertToInt64(newValue, out value);
            ModbusManager.SetHoldingRegister(this.Address, (int)value.Limit(int.MinValue, int.MaxValue));
            return true;
        }

        protected override object min
        {
            get { return int.MinValue; }
        }

        protected override object max
        {
            get { return int.MaxValue; }
        }
    }
}