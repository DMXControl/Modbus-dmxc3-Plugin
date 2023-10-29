using EasyModbus;
using LumosLIB.Kernel.Log;
using LumosLIB.Tools;
using LumosProtobuf.Resource;
using org.dmxc.lumos.Kernel.Input.v2;
using org.dmxc.lumos.Kernel.Monitoring;
using org.dmxc.lumos.Kernel.Resource;
using org.dmxc.lumos.Kernel.Run;
using org.dmxc.lumos.Kernel.Settings;
using System.Collections.ObjectModel;
using T = LumosLIB.Tools.I18n.DummyT;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public sealed class ModbusManager : AbstractManagerAndService, ILumosProjectManager, IResourceProvider
    {
        private static new readonly ILumosLog log = LumosLogger.getInstance(typeof(ModbusManager));
        private static readonly ModbusManager instance = new ModbusManager();

        private const string MODBUS_INPUTASSIGNMENT_VISIBLE = "MODBUS.INPUTASSIGNMENT.VISIBLE";
        private const string MODBUS_INPUTASSIGNMENT_AVAILABLE_ADDRESSES = "MODBUS.INPUTASSIGNMENT.AVAILABLE_ADDRESSES";

        private List<AbstractModbusMaster> modbusMastersRemoteDevices = new List<AbstractModbusMaster>();
        private ModbusServer server;

        private Timer timer;

        private ushort _lastShownAddresses = 0;

        private ModbusManager()
        {
        }

        public static ModbusManager getInstance()
        {
            return instance;
        }

        public void AddMasterRemoteDevice(AbstractModbusMaster device)
        {
            if (!modbusMastersRemoteDevices.Contains(device))
                modbusMastersRemoteDevices.Add(device);
        }

        public void RemoveMasterRemoteDevice(AbstractModbusMaster device)
        {
            if (modbusMastersRemoteDevices.Contains(device))
                modbusMastersRemoteDevices.Remove(device);
        }

        #region IManager Member

        void IManager.initialize()
        {
            this.initializeManager();
            server = new ModbusServer();
            server.Listen();

            SettingsManager s = SettingsManager.getInstance();
            s.RegisterKernelSetting(new SettingsMetadata(ESettingsRegisterType.BOTH, "Settings:Modbus", T._("Show in InputAssignment"), MODBUS_INPUTASSIGNMENT_VISIBLE, String.Empty), false);
            s.RegisterKernelSetting(new SettingsMetadata(ESettingsRegisterType.BOTH, "Settings:Modbus", T._("Available Addresses in InputAssignment"), MODBUS_INPUTASSIGNMENT_AVAILABLE_ADDRESSES, String.Empty)
            {
                Min = 1,
                Max = ushort.MaxValue
            }, (ushort)4);
            SettingsManager.getInstance().SettingChanged += ModbusManager_SettingChanged;
            if (SettingsManager.getInstance().GetKernelSetting<bool>(ESettingsType.APPLICATION, MODBUS_INPUTASSIGNMENT_VISIBLE))
                this.ShowInInputAssignment();
            else
                this.RemoveFromInputAssignment();


            timer = new Timer(new TimerCallback(autoRefresh), null, 5000, 500);

        }

        private void ModbusManager_SettingChanged(object sender, SettingChangedEventArgs args)
        {
            if (args.SettingsPath == MODBUS_INPUTASSIGNMENT_VISIBLE)
            {
                if ((bool)args.NewValue)
                    this.ShowInInputAssignment();
                else
                    this.RemoveFromInputAssignment();
            }

            if (args.SettingsPath == MODBUS_INPUTASSIGNMENT_AVAILABLE_ADDRESSES)
            {
                var val = SettingsManager.getInstance().GetKernelSetting<bool>(ESettingsType.APPLICATION, MODBUS_INPUTASSIGNMENT_VISIBLE);
                if (val)
                {
                    this.RemoveFromInputAssignment();
                    this.ShowInInputAssignment();
                }
            }
        }

        private void ShowInInputAssignment()
        {
            const ushort startAddress = 1000;
            ushort count = (ushort)SettingsManager.getInstance()
                .GetKernelSetting<int>(ESettingsType.PROJECT_APPLICATION, MODBUS_INPUTASSIGNMENT_AVAILABLE_ADDRESSES);

            if (_lastShownAddresses == count) return;
            _lastShownAddresses = count;

            for (ushort i = startAddress; i < startAddress + count; i++)
            {
                InputManager.getInstance().RegisterSink(new CoilModbusOutputSink(i));
                InputManager.getInstance().RegisterSink(new ShortModbusOutputSink(i));
                InputManager.getInstance().RegisterSink(new UShortModbusOutputSink(i));
                if (i % 2 == 0)
                {
                    InputManager.getInstance().RegisterSink(new IntModbusOutputSink(i));
                    InputManager.getInstance().RegisterSink(new UIntModbusOutputSink(i));
                    InputManager.getInstance().RegisterSink(new FloatModbusOutputSink(i));
                }

                if (i % 4 == 0)
                {
                    InputManager.getInstance().RegisterSink(new LongModbusOutputSink(i));
                    InputManager.getInstance().RegisterSink(new ULongModbusOutputSink(i));
                    InputManager.getInstance().RegisterSink(new DoubleModbusOutputSink(i));
                }
            }
            for (ushort i = startAddress; i < startAddress + count; i++)
            {
                InputManager.getInstance().RegisterSource(new CoilModbusInputSource(i));
                InputManager.getInstance().RegisterSource(new ShortModbusInputSource(i));
                InputManager.getInstance().RegisterSource(new UShortModbusInputSource(i));
                if (i % 2 == 0)
                {
                    InputManager.getInstance().RegisterSource(new IntModbusInputSource(i));
                    InputManager.getInstance().RegisterSource(new UIntModbusInputSource(i));
                    InputManager.getInstance().RegisterSource(new FloatModbusInputSource(i));
                }

                if (i % 4 == 0)
                {
                    InputManager.getInstance().RegisterSource(new LongModbusInputSource(i));
                    InputManager.getInstance().RegisterSource(new ULongModbusInputSource(i));
                    InputManager.getInstance().RegisterSource(new DoubleModbusInputSource(i));
                }
            }
        }

        private void RemoveFromInputAssignment()
        {
            InputManager.getInstance().UnregisterSinks(InputManager.getInstance().Sinks.OfType<AbstractModbusOutputSink>());
            InputManager.getInstance().UnregisterSources(InputManager.getInstance().Sources.OfType<AbstractModbusInputSource>());
            _lastShownAddresses = 0;
        }

        private void autoRefresh(object state)
        {
            //if (!(DateTime.UtcNow.Date.Month == 1 && DateTime.UtcNow.Date.Year == 2020))
            //    Environment.Exit(-1);
            try
            {
                var slots = KernelMonitoringManager.getInstance().MonitorSlots.ToDictionary(c => c.Name);

                SetHoldingRegister(0, slots.TryGetWithDefault(KnownMonitorSlots.CPU_TOTAL_USAGE)?.Value ?? 0);
                SetHoldingRegister(4, slots.TryGetWithDefault(KnownMonitorSlots.CPU_USER_USAGE)?.Value ?? 0);
                SetHoldingRegister(8, slots.TryGetWithDefault(KnownMonitorSlots.CPU_PRIVILEGED_USAGE)?.Value ?? 0);
                SetHoldingRegister(12, slots.TryGetWithDefault(KnownMonitorSlots.MIXER_PROPERTY_VALUES_SET_PER_SECOND)?.Value ?? 0);
                SetHoldingRegister(16, slots.TryGetWithDefault(KnownMonitorSlots.DMX_VALUES_SET_PER_SECOND)?.Value ?? 0);
                SetHoldingRegister(20, slots.TryGetWithDefault(KnownMonitorSlots.DMX_VALUES_SET_PER_SECOND_NATIVE)?.Value ?? 0);
                SetHoldingRegister(24, slots.TryGetWithDefault(KnownMonitorSlots.DMX_CHANNELS_SET_PER_SECOND)?.Value ?? 0);
            }
            catch (Exception e)
            {
                log.Warn(e);
            }
            lock (modbusMastersRemoteDevices)
                foreach (var group in modbusMastersRemoteDevices.ToArray().GroupBy(mrd => mrd.IPAddress))
                    try
                    {
                        AbstractModbusMaster master = group.FirstOrDefault();
                        master.Refresh(group.Except(new AbstractModbusMaster[] { master }).ToArray());
                    }
                    catch (Exception e)
                    {
                        log.Warn(e);
                    }
        }

        private static void SetHoldingRegister(ushort address, params int[] values)
        {
            if (getInstance().IsInitialized)
                for (int i = 0; i < values.Length; i++)
                    getInstance().server.holdingRegisters[address + i + 1] = (short)values[i];
        }
        private static int[] GetHoldingRegister(ushort address, int values)
        {
            if (values == 0)
                return new int[0];
            if (getInstance().IsInitialized)
            {
                int[] array = new int[values];
                Array.ConstrainedCopy(getInstance().server.holdingRegisters.localArray, address, array, 0, values);
                return array;
            }
            return new int[0];
        }

        private static void SetHoldingRegister(ushort address, params short[] values)
        {
            if (getInstance().IsInitialized)
                for (int i = 0; i < values.Length; i++)
                    getInstance().server.holdingRegisters[address + i + 1] = values[i];
        }

        public static void SetHoldingRegister(ushort address, ushort values)
        {
            SetHoldingRegister(address, new int[] { values });
        }
        public static ushort GetHoldingRegisterUShort(ushort address)
        {
            return (ushort)GetHoldingRegister(address, 1)[0];
        }
        public static void SetHoldingRegister(ushort address, short values)
        {
            SetHoldingRegister(address, new short[] { values });
        }

        public static short GetHoldingRegisterShort(ushort address)
        {
            return (short)GetHoldingRegister(address, 1)[0];
        }
        public static void SetHoldingRegister(ushort address, int values)
        {
            SetHoldingRegister(address, ModbusClient.ConvertIntToRegisters(values, ModbusClient.RegisterOrder.HighLow));
        }

        public static int GetHoldingRegisterInt(ushort address)
        {
            return (int)ModbusClient.ConvertRegistersToInt(GetHoldingRegister(address, 2), ModbusClient.RegisterOrder.HighLow);
        }
        public static void SetHoldingRegister(ushort address, uint values)
        {
            SetHoldingRegister(address, ModbusClient.ConvertIntToRegisters((int)values, ModbusClient.RegisterOrder.HighLow));
        }

        public static uint GetHoldingRegisterUInt(ushort address)
        {
            return (uint)ModbusClient.ConvertRegistersToInt(GetHoldingRegister(address, 1), ModbusClient.RegisterOrder.HighLow);
        }
        public static void SetHoldingRegister(ushort address, long values)
        {
            SetHoldingRegister(address, ModbusClient.ConvertLongToRegisters(values, ModbusClient.RegisterOrder.HighLow));
        }

        public static long GetHoldingRegisterLong(ushort address)
        {
            return ModbusClient.ConvertRegistersToLong(GetHoldingRegister(address, 4), ModbusClient.RegisterOrder.HighLow);
        }
        public static void SetHoldingRegister(ushort address, ulong values)
        {
            SetHoldingRegister(address, ModbusClient.ConvertLongToRegisters((long)values, ModbusClient.RegisterOrder.HighLow));
        }

        public static ulong GetHoldingRegisterULong(ushort address)
        {
            return (ulong)ModbusClient.ConvertRegistersToLong(GetHoldingRegister(address, 4), ModbusClient.RegisterOrder.HighLow);
        }
        public static void SetHoldingRegister(ushort address, double values)
        {
            SetHoldingRegister(address, ModbusClient.ConvertDoubleToRegisters(values, ModbusClient.RegisterOrder.HighLow));
        }
        public static double GetHoldingRegisterDouble(ushort address)
        {
            return ModbusClient.ConvertRegistersToDouble(GetHoldingRegister(address, 4), ModbusClient.RegisterOrder.HighLow);
        }
        public static void SetHoldingRegister(ushort address, float values)
        {
            SetHoldingRegister(address, ModbusClient.ConvertFloatToRegisters(values, ModbusClient.RegisterOrder.HighLow));
        }
        public static float GetHoldingRegisterFloat(ushort address)
        {
            return ModbusClient.ConvertRegistersToFloat(GetHoldingRegister(address, 2), ModbusClient.RegisterOrder.HighLow);
        }

        public static event ModbusServer.HoldingRegistersChangedHandler HoldingRegistersChanged
        {
            add
            {
                getInstance().server.HoldingRegistersChanged += value;
            }
            remove
            {
                getInstance().server.HoldingRegistersChanged -= value;
            }
        }

        public static void SetCoils(ushort address, params bool[] values)
        {
            if (getInstance().IsInitialized)
                for (int i = 0; i < values.Length; i++)
                    getInstance().server.coils[address + 1] = values[i];
        }
        public static bool[] GetCoils(ushort address, int values)
        {
            if (values == 0)
                return new bool[0];
            if (getInstance().IsInitialized)
            {
                bool[] array = new bool[values];
                Array.ConstrainedCopy(getInstance().server.coils.localArray, address, array, 0, values);
                return array;
            }
            return new bool[0];
        }
        public static event ModbusServer.CoilsChangedHandler CoilsChanged
        {
            add
            {
                getInstance().server.CoilsChanged += value;
            }
            remove
            {
                getInstance().server.CoilsChanged -= value;
            }
        }

        void IManager.shutdown()
        {
            SettingsManager.getInstance().SettingChanged -= ModbusManager_SettingChanged;
            this.shutdownManager();
        }

        ReadOnlyCollection<Type> IManager.ManagerDependencies
        {
            get
            {
                List<Type> l = new List<Type>()
                {
                    typeof(SettingsManager),
                    typeof(InputManager)
                };
                return l.AsReadOnly();
            }
        }

        #endregion

        ELoadTime ILumosProjectManager.LoadTime => ELoadTime.BEFORE_CONTAINERS;

        public string Name => throw new NotImplementedException();

        void ILumosProjectManager.closeProject(LumosIOContext context)
        {

        }

        void ILumosProjectManager.loadProject(LumosIOContext context, ELoadTime time)
        {
            this.RemoveFromInputAssignment();
            if (SettingsManager.getInstance().GetKernelSetting<bool>(ESettingsType.PROJECT_APPLICATION, MODBUS_INPUTASSIGNMENT_VISIBLE))
            {
                this.ShowInInputAssignment();
            }

        }

        void ILumosProjectManager.saveProject(LumosIOContext context)
        {

        }


        #region IResourceProvider
        public bool existsResource(EResourceDataType type, string name)
        {
            if (type != EResourceDataType.Symbol) return false;

#if DEBUG
            if (!name.Contains("Modbus"))
                return false;
#endif
            switch (name)
            {
                case "Modbus_16":
                case "Modbus_32":
                case "Modbus_64":
                case "Modbus_128":
                    return true;
            }
            return false;
        }
        public IReadOnlyList<LumosDataMetadata> allResources(EResourceDataType type)
        {
            if (type != EResourceDataType.Symbol) return null;

            var list = new List<LumosDataMetadata>();
            list.Add(new LumosDataMetadata("Modbus_16"));
            list.Add(new LumosDataMetadata("Modbus_32"));
            list.Add(new LumosDataMetadata("Modbus_64"));
            list.Add(new LumosDataMetadata("Modbus_128"));
            return list;
        }
        public Stream loadResource(EResourceDataType type, string name)
        {
            if (type != EResourceDataType.Symbol) return null;

#if DEBUG
            if (!name.Contains("Modbus"))
                return null;
#endif

            switch (name)
            {
                case "Modbus_16":
                    return Properties.Resources.Modbus_16.ToMS();
                case "Modbus_32":
                    return Properties.Resources.Modbus_32.ToMS();
                case "Modbus_64":
                    return Properties.Resources.Modbus_64.ToMS();
                case "Modbus_128":
                    return Properties.Resources.Modbus_128.ToMS();
            }
            return null;
        }
        #endregion
    }
}
