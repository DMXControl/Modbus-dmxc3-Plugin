using Lumos.GUI.Resource;
using Lumos.GUI.Run;
using Lumos.GUI.Settings;
using Lumos.GUI.Windows.ProjectExplorer;
using LumosLIB.Kernel.Log;
using LumosProtobuf.Resource;
using org.dmxc.lumos.Kernel.Resource;
using org.dmxc.lumos.Kernel.Run;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using T = LumosLIB.Tools.I18n.DummyT;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public sealed class ModbusManager : AbstractManagerAndService, IResourceProvider, IGuiManager
    {
        private static new readonly ILumosLog log = LumosLogger.getInstance(typeof(ModbusManager));
        private static readonly ModbusManager instance = new ModbusManager();

        public string Name => nameof(ModbusManager);

        private ModbusManager()
        {
        }

        public static ModbusManager getInstance()
        {
            return instance;
        }


        #region IManager Member

        void IManager.initialize()
        {
            this.initializeManager();
            ResourceManager.getInstance().registerResourceProvider(this);
            SettingsManager.getInstance().AddSettingsNode("Settings:Modbus", T._("Modbus"), "Modbus", EDisplayCategory.NEW_PROJECT_DEFAULTS | EDisplayCategory.CURRENT_PROJECT_SETTINGS);

        }

        void IManager.shutdown()
        {
            ResourceManager.getInstance().deregisterResourceProvider(this);
            SettingsManager.getInstance().RemoveSettingsNode("Settings:Modbus");
            this.shutdownManager();
        }

        ReadOnlyCollection<Type> IManager.ManagerDependencies
        {
            get
            {
                List<Type> l = new List<Type>()
                {
                    typeof(SettingsManager),
                    typeof(ResourceManager)
                };
                return l.AsReadOnly();
            }
        }

        #endregion

        #region IResourceProvider
        public bool existsResource(EResourceDataType type, string name)
        {
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
            var list = new List<LumosDataMetadata>();
            list.Add(new LumosDataMetadata("Modbus_16"));
            list.Add(new LumosDataMetadata("Modbus_32"));
            list.Add(new LumosDataMetadata("Modbus_64"));
            list.Add(new LumosDataMetadata("Modbus_128"));
            return list;
        }
        public Stream loadResource(EResourceDataType type, string name)
        {
#if DEBUG
            if (!name.Contains("Modbus"))
                return null;
#endif

            switch (name)
            {
                case "Modbus_16":
                    return toByteArray(Properties.Resources.Modbus_16);
                case "Modbus_32":
                    return toByteArray(Properties.Resources.Modbus_32);
                case "Modbus_64":
                    return toByteArray(Properties.Resources.Modbus_64);
                case "Modbus_128":
                    return toByteArray(Properties.Resources.Modbus_128);
            }
            return null;
        }
        private Stream toByteArray(Bitmap i)
        {
            var m = new MemoryStream();
            if (i != null)
            {

                i.Save(m, ImageFormat.Png);
                m.Position = 0;
                return m;
            }
            return null;
        }
        #endregion
    }
}
