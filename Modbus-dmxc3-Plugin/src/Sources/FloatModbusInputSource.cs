using LumosLIB.Kernel;
using LumosProtobuf;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class FloatModbusInputSource : AbstractModbusInputSource
    {
        private static readonly ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "Float");
        public FloatModbusInputSource(ushort address) : base(getID(address), address, getName(address), CATEGORY, 0f)
        {
            ModbusManager.HoldingRegistersChanged += ModbusManager_HoldingRegistersChanged;
        }

        private void ModbusManager_HoldingRegistersChanged(int register, int numberOfRegisters)
        {
            if (Address >= register && Address < register + numberOfRegisters)
                this.CurrentValue = ModbusManager.GetHoldingRegisterFloat(Address);
        }

        private static string getID(ushort address)
        {
            return string.Format("floatModbusRegisterSource-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("Float: {0}", address);
        }

        protected override object min
        {
            get { return float.MinValue; } //This doesn't make sence.... There must be some range limit in the modbus
        }

        protected override object max
        {
            get { return float.MaxValue; } //This doesn't make sence.... There must be some range limit in the modbus
        }
    }
}