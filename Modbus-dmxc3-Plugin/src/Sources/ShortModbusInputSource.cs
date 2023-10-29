using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;
using LumosLIB.Kernel;
using LumosLIB.Tools;
using LumosProtobuf;
using org.dmxc.lumos.Kernel.Input.v2;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class ShortModbusInputSource: AbstractModbusInputSource
    {
        private static readonly ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "Short");

        public ShortModbusInputSource(ushort address) : base(getID(address), address, getName(address), CATEGORY, (short)0)
        {
            ModbusManager.HoldingRegistersChanged += ModbusManager_HoldingRegistersChanged;
        }

        private void ModbusManager_HoldingRegistersChanged(int register, int numberOfRegisters)
        {
            if (Address >= register && Address < register + numberOfRegisters)
                this.CurrentValue = ModbusManager.GetHoldingRegisterShort(Address);
        }

        private static string getID(ushort address)
        {
            return string.Format("shortModbusRegisterSource-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("Short: {0}", address);
        }
        
        protected override object min
        {
            get { return short.MinValue; } //This doesn't make sence.... There must be some range limit in the modbus
        }

        protected override object max
        {
            get { return short.MaxValue; } //This doesn't make sence.... There must be some range limit in the modbus
        }
    }
}