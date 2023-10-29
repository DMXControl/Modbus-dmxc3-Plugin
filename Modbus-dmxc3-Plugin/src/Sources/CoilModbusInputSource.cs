using LumosLIB.Kernel;
using LumosProtobuf;
using LumosProtobuf.Input;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class CoilModbusInputSource : AbstractModbusInputSource
    {
        private static readonly ParameterCategory CATEGORY = ParameterCategoryTools.FromNameWithSub("Modbus", "Coil");

        public CoilModbusInputSource(ushort address) : base(getID(address), address, getName(address), CATEGORY, false)
        {
            ModbusManager.CoilsChanged += ModbusManager_CoilsChangedHandler;
        }

        private void ModbusManager_CoilsChangedHandler(int coil, int numberOfCoils)
        {
            if (Address >= coil && Address < coil + numberOfCoils)
                this.CurrentValue = ModbusManager.GetCoils(Address, 1)[0];
        }

        private static string getID(ushort address)
        {
            return string.Format("coilModbusRegisterSource-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("Coil: {0}", address);
        }


        public sealed override EWellKnownInputType AutoGraphIOType
        {
            get { return EWellKnownInputType.Bool; }
        }

        protected override object min
        {
            get { return false; }
        }

        protected override object max
        {
            get { return true; }
        }
    }
}