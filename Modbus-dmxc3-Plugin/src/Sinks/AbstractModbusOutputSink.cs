using LumosProtobuf;
using LumosProtobuf.Input;
using org.dmxc.lumos.Kernel.Input.v2;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public abstract class AbstractModbusOutputSink:AbstractInputSink
    {
        public readonly ushort Address;
        public AbstractModbusOutputSink(string id, ushort address, string name, ParameterCategory category) : base(id, name, category)
        {
            this.Address = address;
        }

        protected abstract bool update(object newValue);
        public sealed override bool UpdateValue(object newValue)
        {
            return this.update(newValue);
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