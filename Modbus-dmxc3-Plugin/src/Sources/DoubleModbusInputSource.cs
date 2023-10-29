﻿using System;
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
    public class DoubleModbusInputSource: AbstractModbusInputSource
    {
        private static readonly ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "HoldingRegister", "Double");
        public DoubleModbusInputSource(ushort address) : base(getID(address), address, getName(address), CATEGORY, 0.0)
        {
            ModbusManager.HoldingRegistersChanged += ModbusManager_HoldingRegistersChanged;
        }

        private void ModbusManager_HoldingRegistersChanged(int register, int numberOfRegisters)
        {
            if (Address >= register && Address < register + numberOfRegisters)
                this.CurrentValue = ModbusManager.GetHoldingRegisterDouble(Address);
        }

        private static string getID(ushort address)
        {
            return string.Format("doubleModbusRegisterSource-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("Double: {0}", address);
        }
        
        protected override object min
        {
            get { return double.MinValue; } //This doesn't make sence.... There must be some range limit in the modbus
        }

        protected override object max
        {
            get { return double.MaxValue; } //This doesn't make sence.... There must be some range limit in the modbus
        }
    }
}