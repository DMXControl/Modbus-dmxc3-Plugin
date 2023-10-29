using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using LumosLIB.Kernel;
using LumosLIB.Kernel.Log;
using LumosLIB.Tools;
using LumosProtobuf;
using org.dmxc.lumos.Kernel.Modbus;
using T = LumosLIB.Tools.I18n.DummyT;

namespace org.dmxc.lumos.Kernel.Input.v2.Worker
{
    public abstract class AbstractModbusMasterNode : AbstractNode
    {
        protected static readonly ILumosLog log = LumosLogger.getInstance(typeof(AbstractModbusMasterNode));

        private const string P_IPADDRESS = "IPAddress";
        private const string P_PORT = "Port";

        private IGraphNodeInputPort inputPing;
        private IGraphNodeOutputPort outputPing;

        private List<Pair<IGraphNodeOutputPort, AbstractModbusMaster.AbstractModbusRegister>> outputRegisters =
            new List<Pair<IGraphNodeOutputPort, AbstractModbusMaster.AbstractModbusRegister>>();

        protected IReadOnlyList<Pair<IGraphNodeOutputPort, AbstractModbusMaster.AbstractModbusRegister>> OutputRegisters
        {
            get { return this.outputRegisters.AsReadOnly(); }
        }

        protected abstract AbstractModbusMaster ModbusMaster { get; }

        public AbstractModbusMasterNode(GraphNodeID id, string name, string type, ParameterCategory cat)
            : base(id, type, cat)
        {
            this.Name = name;

            if (ModbusMaster == null)
                throw new InvalidOperationException("Abstract ModbusMaster has to be != null");
        }

        protected override void OnAddedToGraph()
        {
            base.OnAddedToGraph();
            AssignEvents(true);
        }

        protected override void OnRemovedFromGraph()
        {
            base.OnRemovedFromGraph();
            AssignEvents(false);
        }

        public override void AddDefaultPorts()
        {
            outputPing = Outputs.SingleOrDefault(c => c.Name == "PING") ??
                         AddOutputPort(name: "PING");
            outputPing.ShortName = T._("PING");

            inputPing = Inputs.SingleOrDefault(c => c.Name == "PING") ??
                               AddInputPort(name: "PING");
            inputPing.ShortName = T._("PING");
            inputPing.ShowAsParameter = false;
            inputPing.InputValueChanged += (sender, value) =>
            {
                if (true.Equals(value))
                {
                    var t = Task.Run(() => {
                        Ping ping = new Ping();
                        PingReply pingresult = ping.Send(ModbusMaster.IPAddress,200);
                        if (!pingresult.Status.Equals(outputPing.Value))
                        {
                            outputPing.Value = pingresult.Status;
                            this.OnProcessRequested();
                        }
                    });
                    t.Start();
                }
            };

            foreach (var abstractModbusRegister in ModbusMaster.Registers)
            {
                var output = Outputs.SingleOrDefault(c => c.Name == abstractModbusRegister.Name) ??
                             AddOutputPort(name: abstractModbusRegister.Name);
                output.ShortName = T._(abstractModbusRegister.Name);
                outputRegisters.Add(
                    new Pair<IGraphNodeOutputPort, AbstractModbusMaster.AbstractModbusRegister>(output,
                        abstractModbusRegister));
            }
        }

        protected override void DisposeHook()
        {
            base.DisposeHook();
            AssignEvents(false);
        }

        private void AssignEvents(bool register)
        {
            if (register)
                ModbusManager.getInstance().AddMasterRemoteDevice(ModbusMaster);
            else
                ModbusManager.getInstance().RemoveMasterRemoteDevice(ModbusMaster);

            lock (outputRegisters)
                foreach (var val in outputRegisters)
                {
                    var abstractModbusRegister = val.Right;
                    abstractModbusRegister.ValueChanged += (o, e) =>
                    {
                        var output = val.Left;
                        if ((output.Value==null&& abstractModbusRegister.Value!=null)||!(output?.Value?.Equals(abstractModbusRegister.Value)??false))
                        {
                            output.Value = abstractModbusRegister.Value;
                            this.OnProcessRequested();
                        }
                    };
                }
        }
        #region Parameters

        protected override IEnumerable<GenericParameter> ParametersInternal
        {
            get
            {
                yield return new GenericParameter(P_IPADDRESS, GraphNodeParameters.GraphNodeParameterType, typeof(string));
                yield return new GenericParameter(P_PORT, GraphNodeParameters.GraphNodeParameterType, typeof(ushort));
            }
        }
        protected override object getParameterInternal(GenericParameter parameter)
        {
            switch (parameter.Name)
            {
                case P_IPADDRESS: return this.ModbusMaster.IPAddress;
                case P_PORT: return this.ModbusMaster.Port;
            }
            return base.getParameterInternal(parameter);
        }

        protected override bool setParameterInternal(GenericParameter parameter, object value)
        {
            switch (parameter.Name)
            {
                case P_IPADDRESS:
                    if (!this.ModbusMaster.IPAddress.Equals((string) value))
                        this.ModbusMaster.SetIPAddress((string) value, this.ModbusMaster.Port);
                    return true;
                case P_PORT:
                    if (!this.ModbusMaster.Port.Equals((ushort)value))
                        this.ModbusMaster.SetIPAddress(this.ModbusMaster.IPAddress, (ushort) value);
                    return true;
            }
            return base.setParameterInternal(parameter, value);
        }

        protected override bool testParameterInternal(GenericParameter parameter, object value)
        {
            switch (parameter.Name)
            {
                case P_IPADDRESS:
                    IPAddress address;
                    if (value is string)
                        if (IPAddress.TryParse((string) value, out address))
                        {
                            return true;
                        }

                    return false;
                case P_PORT:
                    return value is ushort;
            }

            return base.testParameterInternal(parameter, value);
        }
        #endregion
    }
}
