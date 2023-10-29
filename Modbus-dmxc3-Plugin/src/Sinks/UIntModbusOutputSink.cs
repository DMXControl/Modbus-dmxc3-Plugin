using LumosLIB.Kernel;
using LumosLIB.Tools;
using LumosProtobuf;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class UIntModbusOutputSink: AbstractModbusOutputSink
    {
        private static ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "UInt");
        public UIntModbusOutputSink(ushort address) : base(getID(address), address, getName(address), CATEGORY)
        {
        }

        private static string getID(ushort address)
        {
            return string.Format("uintModbusRegisterSink-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("UInt: {0}", address);
        }

        protected override bool update(object newValue)
        {
            ulong value;
            LumosTools.TryConvertToUInt64(newValue, out value);
            ModbusManager.SetHoldingRegister(this.Address, (uint)((ulong)value).Limit(uint.MinValue, uint.MaxValue));
            return true;
        }

        protected override object min
        {
            get { return uint.MinValue; }
        }

        protected override object max
        {
            get { return uint.MaxValue; }
        }
    }
}