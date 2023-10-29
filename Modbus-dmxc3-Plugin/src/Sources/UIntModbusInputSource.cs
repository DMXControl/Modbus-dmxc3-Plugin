using LumosLIB.Kernel;
using LumosProtobuf;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class UIntModbusInputSource : AbstractModbusInputSource
    {
        private static readonly ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "UInt");

        public UIntModbusInputSource(ushort address) : base(getID(address), address, getName(address), CATEGORY, (uint)0)
        {
            ModbusManager.HoldingRegistersChanged += ModbusManager_HoldingRegistersChanged;
        }

        private void ModbusManager_HoldingRegistersChanged(int register, int numberOfRegisters)
        {
            if (Address >= register && Address < register + numberOfRegisters)
                this.CurrentValue = ModbusManager.GetHoldingRegisterUInt(Address);
        }

        private static string getID(ushort address)
        {
            return string.Format("uintModbusRegisterSource-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("UInt: {0}", address);
        }

        protected override object min
        {
            get { return uint.MinValue; }
        }

        protected override object max
        {
            get { return uint.MaxValue; } //This doesn't make sence.... There must be some range limit in the modbus
        }
    }
}