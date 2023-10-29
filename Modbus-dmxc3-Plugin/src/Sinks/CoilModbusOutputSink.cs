using LumosLIB.Kernel;
using LumosLIB.Tools;
using LumosProtobuf;
using LumosProtobuf.Input;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class CoilModbusOutputSink : AbstractModbusOutputSink
    {
        private static ParameterCategory CATEGORY = ParameterCategoryTools.FromNames("Modbus", "Coil");
        public CoilModbusOutputSink(ushort address) : base(getID(address), address, getName(address), CATEGORY)
        {
        }

        private static string getID(ushort address)
        {
            return string.Format("coilModbusRegisterSink-{0}", address);
        }

        private static string getName(ushort address)
        {
            return string.Format("Coil: {0}", address);
        }


        public sealed override EWellKnownInputType AutoGraphIOType
        {
            get { return EWellKnownInputType.Bool; }
        }
        protected override bool update(object newValue)
        {
            bool value;
            LumosTools.TryConvertToBool(newValue, out value);
            ModbusManager.SetCoils(this.Address, value);
            return true;
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