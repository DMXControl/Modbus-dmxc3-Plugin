using LumosLIB.Kernel;
using LumosLIB.Tools;
using LumosProtobuf;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class ULongModbusOutputSink: AbstractModbusOutputSink
    {
        private static ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "ULong");
        public ULongModbusOutputSink(ushort address) : base(getID(address), address, getName(address), CATEGORY)
        {
        }

        private static string getID(ushort address)
        {
            return string.Format("ulongModbusRegisterSink-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("ULong: {0}", address);
        }

        protected override bool update(object newValue)
        {
            ulong value;
            LumosTools.TryConvertToUInt64(newValue, out value);
            ModbusManager.SetHoldingRegister(this.Address, (ulong)((ulong)value).Limit(ulong.MinValue, ulong.MaxValue));
            return true;
        }

        protected override object min
        {
            get { return ulong.MinValue; }
        }

        protected override object max
        {
            get { return ulong.MaxValue; }
        }
    }
}