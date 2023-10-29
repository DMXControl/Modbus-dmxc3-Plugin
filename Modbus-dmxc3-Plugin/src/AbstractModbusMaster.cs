using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EasyModbus;
using LumosLIB.Kernel.Log;
using LumosLIB.Tools;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public abstract partial class AbstractModbusMaster
    {
        protected ILumosLog log { get; }
        public string IPAddress { get; private set; }
        public ushort Port { get; private set; }

        protected ModbusClient client { get; private set; }
        public abstract string Description { get; }
        public abstract int Timeout { get; }
        public abstract AbstractModbusRegister[] Registers { get; }
        private List<Pair<ushort,ushort>> registerMapBlocks = new List<Pair<ushort, ushort>>();

        public AbstractModbusMaster(string ipAddress, ushort port = 502)
        {
            this.log = LumosLogger.getInstance(this.GetType());

            if (string.IsNullOrWhiteSpace(ipAddress))
                throw new ArgumentNullException(nameof(ipAddress));

            this.SetIPAddress(ipAddress,port);

            ushort blockStartAddress = 0;
            ushort nextBlockHasToBeAddress = 0;
            bool firstBlock = true;
            var groub = this.Registers.GroupBy(r => r.Address).OrderBy(g => g.Key);
            foreach (var register in groub)
            {
                if (firstBlock)
                {
                    blockStartAddress = register.Key;
                    firstBlock = false;
                }
                else if(nextBlockHasToBeAddress != register.Key)
                {
                    registerMapBlocks.Add(new Pair<ushort, ushort>(blockStartAddress,
                        (ushort) (nextBlockHasToBeAddress - blockStartAddress)));
                    nextBlockHasToBeAddress = 0;
                    blockStartAddress = register.Key;
                }

                nextBlockHasToBeAddress = register.Key;
                nextBlockHasToBeAddress += register.Max(r=>r.Length);
            }

            registerMapBlocks.Add(new Pair<ushort, ushort>(blockStartAddress,
                (ushort) (nextBlockHasToBeAddress - blockStartAddress)));
        }

        public void Refresh(AbstractModbusMaster[] clones=null)
        {
            try
            {
                var registers = this.Registers;
                if (!this.client.Connected)
                    this.client.Connect();
                foreach (var block in this.registerMapBlocks)
                {
                    int[] blockValues = client.ReadHoldingRegisters(block.Left, block.Right);
                    var _reg = registers.Where(r =>
                        block.Left <= r.Address && (block.Left + block.Right) >= r.Address).ToList();
                    foreach (var register in _reg)
                    {
                        int[] values = new int[register.Length];
                        for (ushort i = 0; i < values.Length; i++)
                        {
                            int blockIndex = register.Address - block.Left + i;
                            if (blockValues.Length <= blockIndex)
                                break;

                            values[i] = blockValues[blockIndex];
                        }

                        register.processNewValues(values);
                        if (clones.NullToEmpty().Any())
                            clones.ForEach(c => c.Registers.Single(r=>r.Name.Equals(register.Name)&&r.Address==register.Address).processNewValues(values));
                    }
                }
                client.Disconnect();
            }
            catch (Exception e)
            {
                log.ErrorOrDebug(e);
                client.Disconnect();
            }
        }

        public void SetIPAddress(string ipAddress, ushort port = 502)
        {
            this.IPAddress = ipAddress;
            this.Port = port;

            var backup = Console.Out;
            Console.SetOut(TextWriter.Null); // Disable Copyright Printout!!!
            client = new ModbusClient(this.IPAddress, port);
            Console.SetOut(backup);
            client.ConnectionTimeout = this.Timeout;
        }
    }
}
