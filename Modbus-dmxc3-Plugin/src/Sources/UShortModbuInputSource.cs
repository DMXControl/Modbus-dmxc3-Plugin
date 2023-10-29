using LumosLIB.Kernel;
using LumosProtobuf;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class UShortModbusInputSource : AbstractModbusInputSource
    {
        private static readonly ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "UShort");

        public UShortModbusInputSource(ushort address) : base(getID(address), address, getName(address), CATEGORY, (ushort)0)
        {
            ModbusManager.HoldingRegistersChanged += ModbusManager_HoldingRegistersChanged;
        }

        private void ModbusManager_HoldingRegistersChanged(int register, int numberOfRegisters)
        {
            if (Address >= register && Address < register + numberOfRegisters)
                this.CurrentValue = ModbusManager.GetHoldingRegisterUShort(Address);
        }

        private static string getID(ushort address)
        {
            return string.Format("ushortModbusRegisterSource-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("UShort: {0}", address);
        }

        protected override object min
        {
            get { return ushort.MinValue; }
        }

        protected override object max
        {
            get { return ushort.MaxValue; } //This doesn't make sence.... There must be some range limit in the modbus
        }
    }
}