using LumosLIB.Kernel;
using LumosLIB.Tools;
using LumosProtobuf;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class UShortModbusOutputSink: AbstractModbusOutputSink
    {
        private static ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "UShort");
        public UShortModbusOutputSink(ushort address) : base(getID(address), address, getName(address), CATEGORY)
        {
        }

        private static string getID(ushort address)
        {
            return string.Format("ushortModbusRegisterSink-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("UShort: {0}", address);
        }

        protected override bool update(object newValue)
        {
            ulong value;
            LumosTools.TryConvertToUInt64(newValue, out value);
            ModbusManager.SetHoldingRegister(this.Address, (ushort)(value.Limit(ushort.MinValue, ushort.MaxValue)));
            return true;
        }

        protected override object min
        {
            get { return ushort.MinValue; }
        }

        protected override object max
        {
            get { return ushort.MaxValue; }
        }
    }
}