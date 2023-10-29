using LumosProtobuf;
using LumosProtobuf.Input;
using org.dmxc.lumos.Kernel.Input.v2;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public abstract class AbstractModbusInputSource : AbstractInputSource
    {
        public readonly ushort Address;
        public AbstractModbusInputSource(string id, ushort address, string name, ParameterCategory category, object initialValue) : base(id, name, category, initialValue)
        {
            this.Address = address;
        }

        public override EWellKnownInputType AutoGraphIOType
        {
            get { return EWellKnownInputType.Numeric; }
        }

        protected abstract object min { get; }
        public sealed override object Min
        {
            get { return this.min; }
        }

        protected abstract object max { get; }
        public sealed override object Max
        {
            get { return this.max; }
        }
    }
}