using LumosLIB.Kernel;
using LumosProtobuf;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class LongModbusInputSource : AbstractModbusInputSource
    {
        private static readonly ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "Long");

        public LongModbusInputSource(ushort address) : base(getID(address), address, getName(address), CATEGORY, (long)0)
        {
            ModbusManager.HoldingRegistersChanged += ModbusManager_HoldingRegistersChanged;
        }

        private void ModbusManager_HoldingRegistersChanged(int register, int numberOfRegisters)
        {
            if (Address >= register && Address < register + numberOfRegisters)
                this.CurrentValue = ModbusManager.GetHoldingRegisterLong(Address);
        }

        private static string getID(ushort address)
        {
            return string.Format("longModbusRegisterSource-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("Long: {0}", address);
        }

        protected override object min
        {
            get { return long.MinValue; } //This doesn't make sence.... There must be some range limit in the modbus
        }

        protected override object max
        {
            get { return long.MaxValue; } //This doesn't make sence.... There must be some range limit in the modbus
        }
    }
}