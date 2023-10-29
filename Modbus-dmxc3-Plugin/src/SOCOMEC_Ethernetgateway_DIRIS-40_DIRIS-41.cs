using EasyModbus;

namespace org.dmxc.lumos.Kernel.Modbus
{
    public class SOCOMEC_Ethernetgateway_DIRIS_40_DIRIS_41 : AbstractModbusMaster
    {
        public override string Description
        {
            get
            {
                return "TODO";
            }
        }

        public override int Timeout
        {
            get { return 3000; }
        }

        private AbstractModbusRegister[] registers = new AbstractModbusRegister[]
        {
            //Table C550 Hex
            new Int32DivideBy100ModbusRegister(0xC550, "Betriebsstundenzähler", "h"),
            new Int32DivideBy100ModbusRegister(0xC552, "Spannung L1 - L2", "V"),
            new Int32DivideBy100ModbusRegister(0xC554, "Spannung L2 - L3", "V"),
            new Int32DivideBy100ModbusRegister(0xC556, "Spannung L3 - L1", "V"),
            new Int32DivideBy100ModbusRegister(0xC558, "Spannung L1", "V"),
            new Int32DivideBy100ModbusRegister(0xC55A, "Spannung L2", "V"),
            new Int32DivideBy100ModbusRegister(0xC55C, "Spannung L3", "V"),
            new Int32DivideBy100ModbusRegister(0xC55E, "Frequenz", "Hz"),
            new Int32DivideBy1000ModbusRegister(0xC560, "Strom L1", "A"),
            new Int32DivideBy1000ModbusRegister(0xC562, "Strom L2", "A"),
            new Int32DivideBy1000ModbusRegister(0xC564, "Strom L3", "A"),
            new Int32DivideBy1000ModbusRegister(0xC566, "Strom N", "A"),
            new Int32DivideBy100ModbusRegister(0xC568, "∑ Wirkleistung +/-", "kW"),
            new Int32DivideBy100ModbusRegister(0xC56A, "∑ Blindleistung +/-", "kvar"),
            new Int32DivideBy100ModbusRegister(0xC56C, "∑ Scheinleistung +/-", "kVA"),
            new Int32DivideBy100ModbusRegister(0xC56E, "∑ Leistungsfaktor +(ind.)/-(kap.)"),
            new Int32DivideBy100ModbusRegister(0xC570, "Wirkleistung L1 +/-", "kW"),
            new Int32DivideBy100ModbusRegister(0xC572, "Wirkleistung L2 +/-", "kW"),
            new Int32DivideBy100ModbusRegister(0xC574, "Wirkleistung L3 +/-", "kW"),
            new Int32DivideBy100ModbusRegister(0xC576, "Blindleistung L1 +/-", "kvar"),
            new Int32DivideBy100ModbusRegister(0xC578, "Blindleistung L2 +/-", "kvar"),
            new Int32DivideBy100ModbusRegister(0xC57A, "Blindleistung L3 +/-", "kvar"),
            new Int32DivideBy100ModbusRegister(0xC57C, "Scheinleistung L1 +/-", "kVA"),
            new Int32DivideBy100ModbusRegister(0xC57E, "Scheinleistung L2 +/-", "kVA"),
            new Int32DivideBy100ModbusRegister(0xC580, "Scheinleistung L3 +/-", "kVA"),
            new Int32DivideBy100ModbusRegister(0xC582, "Leistungsfaktor L1 +(ind.)/-(kap.)"),
            new Int32DivideBy100ModbusRegister(0xC584, "Leistungsfaktor L2 +(ind.)/-(kap.)"),
            new Int32DivideBy100ModbusRegister(0xC586, "Leistungsfaktor L3 +(ind.)/-(kap.)"),
            //RESERVED
            //RESERVED
            //RESERVED

            //Table C650 Hex
            new Int32DivideBy100ModbusRegister(0xC650, "Betriebsstundenzähler", "h"),
            new Int32ModbusRegister(0xC652, "Wirkleistung +", "kwh"),
            new Int32ModbusRegister(0xC654, "Blindleistung +", "kvarh"),
            new Int32ModbusRegister(0xC656, "Scheinleistung", "kVAh"),
            new Int32ModbusRegister(0xC658, "Wirkleistung -", "kWh"),
            new Int32ModbusRegister(0xC65A, "Blindleistung -", "kvarh"),
            new Int32ModbusRegister(0xC65C, "Anz. Impulszähler"),
            new Int32ModbusRegister(0xC65E, "Impulszähler 1"),
            new Int32ModbusRegister(0xC660, "Impulszähler 2"),
            new Int32ModbusRegister(0xC662, "Impulszähler 3"),
            new Int32ModbusRegister(0xC664, "Impulszähler 4"),
            new Int32ModbusRegister(0xC666, "Impulszähler 5"),
            new Int32ModbusRegister(0xC668, "Impulszähler 6"),
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            new Int32DivideBy100ModbusRegister(0xC672, "S Prädiktive Wirkleistung", "kW"),
            new Int32DivideBy100ModbusRegister(0xC674, "S Prädiktive Blindleistung", "kvar"),
            new Int32DivideBy100ModbusRegister(0xC676, "S Prädiktive  Scheinleistung", "kVA"),
            new Int32DivideBy100ModbusRegister(0xC678, "Ea+ zwischen 2 Tops", "0.1 Ws"),
            new Int32DivideBy100ModbusRegister(0xC67A, "Ea- zwischen 2 Tops", "0.1 Ws"),
            new Int32DivideBy100ModbusRegister(0xC67C, "Er+ zwischen 2 Tops", "0.1 vars"),
            new Int32DivideBy100ModbusRegister(0xC67E, "Er- zwischen 2 Tops", "0.1 vars"),
            new Int32ModbusRegister(0xC680, "Datum/Stunde letzte durchschnitlichen Leistungen P/Q"),
            //RESERVED
            //RESERVED


            //Table C750 Hex
            new Int32DivideBy100ModbusRegister(0xC750, "avg Spannung L1 - L2", "V"),
            new Int32DivideBy100ModbusRegister(0xC752, "avg Spannung L2 - L3", "V"),
            new Int32DivideBy100ModbusRegister(0xC754, "avg Spannung L3 - L1", "V"),
            new Int32DivideBy100ModbusRegister(0xC756, "avg Spannung L1", "V"),
            new Int32DivideBy100ModbusRegister(0xC758, "avg Spannung L2", "V"),
            new Int32DivideBy100ModbusRegister(0xC75A, "avg Spannung L3", "V"),
            new Int32DivideBy100ModbusRegister(0xC75C, "avg Frequenz", "Hz"),
            new Int32DivideBy1000ModbusRegister(0xC75E, "avg Strom L1", "A"),
            new Int32DivideBy1000ModbusRegister(0xC760, "avg Strom L2", "A"),
            new Int32DivideBy1000ModbusRegister(0xC762, "avg Strom L3", "A"),
            new Int32DivideBy1000ModbusRegister(0xC764, "avg Strom N", "A"),
            new Int32DivideBy100ModbusRegister(0xC766, "avg ∑ Wirkleistung +", "kW"),
            new Int32DivideBy100ModbusRegister(0xC768, "avg ∑ Wirkleistung -", "kW"),
            new Int32DivideBy100ModbusRegister(0xC76A, "avg ∑ Blindleistung +", "kvar"),
            new Int32DivideBy100ModbusRegister(0xC76C, "avg ∑ Blindleistung -", "kvar"),
            new Int32DivideBy100ModbusRegister(0xC76E, "avg ∑ Scheinleistun", "kVA"),
            new Int32DivideBy100ModbusRegister(0xC770,"max/avg Spannung L1 - L2", "V"),
            new Int32DivideBy100ModbusRegister(0xC772, "max/avg Spannung L2 - L3", "V"),
            new Int32DivideBy100ModbusRegister(0xC774, "max/avg Spannung L3 - L1", "V"),
            new Int32DivideBy100ModbusRegister(0xC776, "max/avg Spannung L1", "V"),
            new Int32DivideBy100ModbusRegister(0xC778, "max/avg Spannung L2", "V"),
            new Int32DivideBy100ModbusRegister(0xC77A, "max/avg Spannung L3", "V"),
            new Int32DivideBy100ModbusRegister(0xC77C, "max/avg Frequenz", "Hz"),
            new Int32DivideBy1000ModbusRegister(0xC77E, "max/avg Strom L1", "A"),
            new Int32DivideBy1000ModbusRegister(0xC780, "max/avg Strom L2", "A"),
            new Int32DivideBy1000ModbusRegister(0xC782, "max/avg Strom L3", "A"),
            new Int32DivideBy1000ModbusRegister(0xC784, "max/avg Strom N", "A"),
            new Int32DivideBy100ModbusRegister(0xC786, "max/avg ∑ Wirkleistung +", "kW"),
            new Int32DivideBy100ModbusRegister(0xC788, "max/avg ∑ Wirkleistung -", "kW"),
            new Int32DivideBy100ModbusRegister(0xC78A, "max/avg ∑ Blindleistung +", "kvar"),
            new Int32DivideBy100ModbusRegister(0xC78C, "max/avg ∑ Blindleistung -", "kvar"),
            new Int32DivideBy100ModbusRegister(0xC78E, "max/avg ∑ Scheinleistung", "kVA"),
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED
            //RESERVED

            //Table C900 Hex
            new EnumModbusRegister(0xC900, "Interne Temperatursonde vorhanden"),
            new Int16ModbusRegister(0xC901, "Temperaturmodul", "°C"),
            new Int16ModbusRegister(0xC902, "Externe Temperatursonden"),
            new Int16ModbusRegister(0xC903, "Temperatur extern 1", "°C"),
            new Int16ModbusRegister(0xC904, "Temperatur extern 2", "°C"),
            new Int16ModbusRegister(0xC905, "Temperatur extern 3", "°C"),
            //RESERVED
            //RESERVED
            
            //Table C950 Hex THD
            new Int16DivideBy100ModbusRegister(0xC950, "thd Spannung L1 - L2"),
            new Int16DivideBy100ModbusRegister(0xC951, "thd Spannung  L2 - L3"),
            new Int16DivideBy100ModbusRegister(0xC952, "thd Spannung  L3 - L1"),
            new Int16DivideBy100ModbusRegister(0xC953, "thd Spannung  L1"),
            new Int16DivideBy100ModbusRegister(0xC954, "thd Spannung  L2"),
            new Int16DivideBy100ModbusRegister(0xC955, "thd Spannung  L3"),
            new Int16DivideBy100ModbusRegister(0xC956, "thd Strom  L1"),
            new Int16DivideBy100ModbusRegister(0xC957, "thd Strom L2"),
            new Int16DivideBy100ModbusRegister(0xC958, "thd Strom L3"),
            new Int16DivideBy100ModbusRegister(0xC959, "thd Strom N"),
            //Table C950 Hex Strom
            new Int16ModbusRegister(0xC95A, "Rang"),
            new Int16DivideBy100ModbusRegister(0xC95B, "Harmonische Oberschwingungen Strom L1 Reihe 3"),
            new Int16DivideBy100ModbusRegister(0xC95C, "Harmonische Oberschwingungen Strom L2 Reihe 3"),
            new Int16DivideBy100ModbusRegister(0xC95D, "Harmonische Oberschwingungen Strom L3 Reihe 3"),
            new Int16DivideBy100ModbusRegister(0xC95E, "Harmonische Oberschwingungen Strom N Reihe 3"),
            new Int16DivideBy100ModbusRegister(0xC95F, "Harmonische Oberschwingungen Strom L1 Reihe 5"),
            new Int16DivideBy100ModbusRegister(0xC960, "Harmonische Oberschwingungen Strom L2 Reihe 5"),
            new Int16DivideBy100ModbusRegister(0xC961, "Harmonische Oberschwingungen Strom L3 Reihe 5"),
            new Int16DivideBy100ModbusRegister(0xC962, "Harmonische Oberschwingungen Strom N Reihe 5"),
            new Int16DivideBy100ModbusRegister(0xC963, "Harmonische Oberschwingungen Strom L1 Reihe 7"),
            new Int16DivideBy100ModbusRegister(0xC964, "Harmonische Oberschwingungen Strom L2 Reihe 7"),
            new Int16DivideBy100ModbusRegister(0xC965, "Harmonische Oberschwingungen Strom L3 Reihe 7"),
            new Int16DivideBy100ModbusRegister(0xC966, "Harmonische Oberschwingungen Strom N Reihe 7"),
            new Int16DivideBy100ModbusRegister(0xC967, "Harmonische Oberschwingungen Strom L1 Reihe 9"),
            new Int16DivideBy100ModbusRegister(0xC968, "Harmonische Oberschwingungen Strom L2 Reihe 9"),
            new Int16DivideBy100ModbusRegister(0xC969, "Harmonische Oberschwingungen Strom L3 Reihe 9"),
            new Int16DivideBy100ModbusRegister(0xC96A, "Harmonische Oberschwingungen Strom N Reihe 9"),
            new Int16DivideBy100ModbusRegister(0xC96B, "Harmonische Oberschwingungen Strom L1 Reihe 11"),
            new Int16DivideBy100ModbusRegister(0xC96C, "Harmonische Oberschwingungen Strom L2 Reihe 11"),
            new Int16DivideBy100ModbusRegister(0xC96D, "Harmonische Oberschwingungen Strom L3 Reihe 11"),
            new Int16DivideBy100ModbusRegister(0xC96E, "Harmonische Oberschwingungen Strom N Reihe 11"),
            new Int16DivideBy100ModbusRegister(0xC96F, "Harmonische Oberschwingungen Strom L1 Reihe 13"),
            new Int16DivideBy100ModbusRegister(0xC970, "Harmonische Oberschwingungen Strom L2 Reihe 13"),
            new Int16DivideBy100ModbusRegister(0xC971, "Harmonische Oberschwingungen Strom L3 Reihe 13"),
            new Int16DivideBy100ModbusRegister(0xC972, "Harmonische Oberschwingungen Strom N Reihe 13"),
            new Int16DivideBy100ModbusRegister(0xC973, "Harmonische Oberschwingungen Strom L1 Reihe 15"),
            new Int16DivideBy100ModbusRegister(0xC974, "Harmonische Oberschwingungen Strom L2 Reihe 15"),
            new Int16DivideBy100ModbusRegister(0xC975, "Harmonische Oberschwingungen Strom L3 Reihe 15"),
            new Int16DivideBy100ModbusRegister(0xC976, "Harmonische Oberschwingungen Strom N Reihe 15"),
            new Int16DivideBy100ModbusRegister(0xC977, "Harmonische Oberschwingungen Strom L1 Reihe 17"),
            new Int16DivideBy100ModbusRegister(0xC978, "Harmonische Oberschwingungen Strom L2 Reihe 17"),
            new Int16DivideBy100ModbusRegister(0xC979, "Harmonische Oberschwingungen Strom L3 Reihe 17"),
            new Int16DivideBy100ModbusRegister(0xC97A, "Harmonische Oberschwingungen Strom N Reihe 17"),
            new Int16DivideBy100ModbusRegister(0xC97B, "Harmonische Oberschwingungen Strom L1 Reihe 19"),
            new Int16DivideBy100ModbusRegister(0xC97C, "Harmonische Oberschwingungen Strom L2 Reihe 19"),
            new Int16DivideBy100ModbusRegister(0xC97D, "Harmonische Oberschwingungen Strom L3 Reihe 19"),
            new Int16DivideBy100ModbusRegister(0xC97E, "Harmonische Oberschwingungen Strom N Reihe 19"),
            new Int16DivideBy100ModbusRegister(0xC97F, "Harmonische Oberschwingungen Strom L1 Reihe 21"),
            new Int16DivideBy100ModbusRegister(0xC980, "Harmonische Oberschwingungen Strom L2 Reihe 21"),
            new Int16DivideBy100ModbusRegister(0xC981, "Harmonische Oberschwingungen Strom L3 Reihe 21"),
            new Int16DivideBy100ModbusRegister(0xC982, "Harmonische Oberschwingungen Strom N Reihe 21"),
            new Int16DivideBy100ModbusRegister(0xC983, "Harmonische Oberschwingungen Strom L1 Reihe 23"),
            new Int16DivideBy100ModbusRegister(0xC984, "Harmonische Oberschwingungen Strom L2 Reihe 23"),
            new Int16DivideBy100ModbusRegister(0xC985, "Harmonische Oberschwingungen Strom L3 Reihe 23"),
            new Int16DivideBy100ModbusRegister(0xC986, "Harmonische Oberschwingungen Strom N Reihe 23"),
            new Int16DivideBy100ModbusRegister(0xC987, "Harmonische Oberschwingungen Strom L1 Reihe 25"),
            new Int16DivideBy100ModbusRegister(0xC988, "Harmonische Oberschwingungen Strom L2 Reihe 25"),
            new Int16DivideBy100ModbusRegister(0xC989, "Harmonische Oberschwingungen Strom L3 Reihe 25"),
            new Int16DivideBy100ModbusRegister(0xC98A, "Harmonische Oberschwingungen Strom N Reihe 25"),
            new Int16DivideBy100ModbusRegister(0xC98B, "Harmonische Oberschwingungen Strom L1 Reihe 27"),
            new Int16DivideBy100ModbusRegister(0xC98C, "Harmonische Oberschwingungen Strom L2 Reihe 27"),
            new Int16DivideBy100ModbusRegister(0xC98D, "Harmonische Oberschwingungen Strom L3 Reihe 27"),
            new Int16DivideBy100ModbusRegister(0xC98E, "Harmonische Oberschwingungen Strom N Reihe 27"),
            new Int16DivideBy100ModbusRegister(0xC98F, "Harmonische Oberschwingungen Strom L1 Reihe 29"),
            new Int16DivideBy100ModbusRegister(0xC990, "Harmonische Oberschwingungen Strom L2 Reihe 29"),
            new Int16DivideBy100ModbusRegister(0xC991, "Harmonische Oberschwingungen Strom L3 Reihe 29"),
            new Int16DivideBy100ModbusRegister(0xC992, "Harmonische Oberschwingungen Strom N Reihe 29"),
            new Int16DivideBy100ModbusRegister(0xC993, "Harmonische Oberschwingungen Strom L1 Reihe 31"),
            new Int16DivideBy100ModbusRegister(0xC994, "Harmonische Oberschwingungen Strom L2 Reihe 31"),
            new Int16DivideBy100ModbusRegister(0xC995, "Harmonische Oberschwingungen Strom L3 Reihe 31"),
            new Int16DivideBy100ModbusRegister(0xC996, "Harmonische Oberschwingungen Strom N Reihe 31"),
            new Int16DivideBy100ModbusRegister(0xC997, "Harmonische Oberschwingungen Strom L1 Reihe 33"),
            new Int16DivideBy100ModbusRegister(0xC998, "Harmonische Oberschwingungen Strom L2 Reihe 33"),
            new Int16DivideBy100ModbusRegister(0xC999, "Harmonische Oberschwingungen Strom L3 Reihe 33"),
            new Int16DivideBy100ModbusRegister(0xC99A, "Harmonische Oberschwingungen Strom N Reihe 33"),
            new Int16DivideBy100ModbusRegister(0xC99B, "Harmonische Oberschwingungen Strom L1 Reihe 35"),
            new Int16DivideBy100ModbusRegister(0xC99C, "Harmonische Oberschwingungen Strom L2 Reihe 35"),
            new Int16DivideBy100ModbusRegister(0xC99D, "Harmonische Oberschwingungen Strom L3 Reihe 35"),
            new Int16DivideBy100ModbusRegister(0xC99E, "Harmonische Oberschwingungen Strom N Reihe 35"),
            new Int16DivideBy100ModbusRegister(0xC99F, "Harmonische Oberschwingungen Strom L1 Reihe 37"),
            new Int16DivideBy100ModbusRegister(0xC9A0, "Harmonische Oberschwingungen Strom L2 Reihe 37"),
            new Int16DivideBy100ModbusRegister(0xC9A1, "Harmonische Oberschwingungen Strom L3 Reihe 37"),
            new Int16DivideBy100ModbusRegister(0xC9A2, "Harmonische Oberschwingungen Strom N Reihe 37"),
            new Int16DivideBy100ModbusRegister(0xC9A3, "Harmonische Oberschwingungen Strom L1 Reihe 39"),
            new Int16DivideBy100ModbusRegister(0xC9A4, "Harmonische Oberschwingungen Strom L2 Reihe 39"),
            new Int16DivideBy100ModbusRegister(0xC9A5, "Harmonische Oberschwingungen Strom L3 Reihe 39"),
            new Int16DivideBy100ModbusRegister(0xC9A6, "Harmonische Oberschwingungen Strom N Reihe 39"),
            new Int16DivideBy100ModbusRegister(0xC9A7, "Harmonische Oberschwingungen Strom L1 Reihe 41"),
            new Int16DivideBy100ModbusRegister(0xC9A8, "Harmonische Oberschwingungen Strom L2 Reihe 41"),
            new Int16DivideBy100ModbusRegister(0xC9A9, "Harmonische Oberschwingungen Strom L3 Reihe 41"),
            new Int16DivideBy100ModbusRegister(0xC9AA, "Harmonische Oberschwingungen Strom N Reihe 41"),
            new Int16DivideBy100ModbusRegister(0xC9AB, "Harmonische Oberschwingungen Strom L1 Reihe 43"),
            new Int16DivideBy100ModbusRegister(0xC9AC, "Harmonische Oberschwingungen Strom L2 Reihe 43"),
            new Int16DivideBy100ModbusRegister(0xC9AD, "Harmonische Oberschwingungen Strom L3 Reihe 43"),
            new Int16DivideBy100ModbusRegister(0xC9AE, "Harmonische Oberschwingungen Strom N Reihe 43"),
            new Int16DivideBy100ModbusRegister(0xC9AF, "Harmonische Oberschwingungen Strom L1 Reihe 45"),
            new Int16DivideBy100ModbusRegister(0xC9B0, "Harmonische Oberschwingungen Strom L2 Reihe 45"),
            new Int16DivideBy100ModbusRegister(0xC9B1, "Harmonische Oberschwingungen Strom L3 Reihe 45"),
            new Int16DivideBy100ModbusRegister(0xC9B2, "Harmonische Oberschwingungen Strom N Reihe 45"),
            new Int16DivideBy100ModbusRegister(0xC9B3, "Harmonische Oberschwingungen Strom L1 Reihe 47"),
            new Int16DivideBy100ModbusRegister(0xC9B4, "Harmonische Oberschwingungen Strom L2 Reihe 47"),
            new Int16DivideBy100ModbusRegister(0xC9B5, "Harmonische Oberschwingungen Strom L3 Reihe 47"),
            new Int16DivideBy100ModbusRegister(0xC9B6, "Harmonische Oberschwingungen Strom N Reihe 47"),
            new Int16DivideBy100ModbusRegister(0xC9B7, "Harmonische Oberschwingungen Strom L1 Reihe 49"),
            new Int16DivideBy100ModbusRegister(0xC9B8, "Harmonische Oberschwingungen Strom L2 Reihe 49"),
            new Int16DivideBy100ModbusRegister(0xC9B9, "Harmonische Oberschwingungen Strom L3 Reihe 49"),
            new Int16DivideBy100ModbusRegister(0xC9BA, "Harmonische Oberschwingungen Strom N Reihe 49"),
            new Int16DivideBy100ModbusRegister(0xC9BB, "Harmonische Oberschwingungen Strom L1 Reihe 51"),
            new Int16DivideBy100ModbusRegister(0xC9BC, "Harmonische Oberschwingungen Strom L2 Reihe 51"),
            new Int16DivideBy100ModbusRegister(0xC9BD, "Harmonische Oberschwingungen Strom L3 Reihe 51"),
            new Int16DivideBy100ModbusRegister(0xC9BE, "Harmonische Oberschwingungen Strom N Reihe 51"),
            new Int16DivideBy100ModbusRegister(0xC9BF, "Harmonische Oberschwingungen Strom L1 Reihe 53"),
            new Int16DivideBy100ModbusRegister(0xC9C0, "Harmonische Oberschwingungen Strom L2 Reihe 53"),
            new Int16DivideBy100ModbusRegister(0xC9C1, "Harmonische Oberschwingungen Strom L3 Reihe 53"),
            new Int16DivideBy100ModbusRegister(0xC9C2, "Harmonische Oberschwingungen Strom N Reihe 53"),
            new Int16DivideBy100ModbusRegister(0xC9C3, "Harmonische Oberschwingungen Strom L1 Reihe 55"),
            new Int16DivideBy100ModbusRegister(0xC9C4, "Harmonische Oberschwingungen Strom L2 Reihe 55"),
            new Int16DivideBy100ModbusRegister(0xC9C5, "Harmonische Oberschwingungen Strom L3 Reihe 55"),
            new Int16DivideBy100ModbusRegister(0xC9C6, "Harmonische Oberschwingungen Strom N Reihe 55"),
            new Int16DivideBy100ModbusRegister(0xC9C7, "Harmonische Oberschwingungen Strom L1 Reihe 57"),
            new Int16DivideBy100ModbusRegister(0xC9C8, "Harmonische Oberschwingungen Strom L2 Reihe 57"),
            new Int16DivideBy100ModbusRegister(0xC9C9, "Harmonische Oberschwingungen Strom L3 Reihe 57"),
            new Int16DivideBy100ModbusRegister(0xC9CA, "Harmonische Oberschwingungen Strom N Reihe 57"),
            new Int16DivideBy100ModbusRegister(0xC9CB, "Harmonische Oberschwingungen Strom L1 Reihe 59"),
            new Int16DivideBy100ModbusRegister(0xC9CC, "Harmonische Oberschwingungen Strom L2 Reihe 59"),
            new Int16DivideBy100ModbusRegister(0xC9CD, "Harmonische Oberschwingungen Strom L3 Reihe 59"),
            new Int16DivideBy100ModbusRegister(0xC9CE, "Harmonische Oberschwingungen Strom N Reihe 59"),
            new Int16DivideBy100ModbusRegister(0xC9CF, "Harmonische Oberschwingungen Strom L1 Reihe 61"),
            new Int16DivideBy100ModbusRegister(0xC9D0, "Harmonische Oberschwingungen Strom L2 Reihe 61"),
            new Int16DivideBy100ModbusRegister(0xC9D1, "Harmonische Oberschwingungen Strom L3 Reihe 61"),
            new Int16DivideBy100ModbusRegister(0xC9D2, "Harmonische Oberschwingungen Strom N Reihe 61"),
            new Int16DivideBy100ModbusRegister(0xC9D3, "Harmonische Oberschwingungen Strom L1 Reihe 63"),
            new Int16DivideBy100ModbusRegister(0xC9D4, "Harmonische Oberschwingungen Strom L2 Reihe 63"),
            new Int16DivideBy100ModbusRegister(0xC9D5, "Harmonische Oberschwingungen Strom L3 Reihe 63"),
            new Int16DivideBy100ModbusRegister(0xC9D6, "Harmonische Oberschwingungen Strom N Reihe 63"),
            //Table C950 Hex Verkettete Spannung
            new Int16ModbusRegister(0xC9D7, "Rang"),
            new Int16DivideBy100ModbusRegister(0xC9D8, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 3"),
            new Int16DivideBy100ModbusRegister(0xC9D9, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 3"),
            new Int16DivideBy100ModbusRegister(0xC9DA, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 3"),
            new Int16DivideBy100ModbusRegister(0xC9DB, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 5"),
            new Int16DivideBy100ModbusRegister(0xC9DC, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 5"),
            new Int16DivideBy100ModbusRegister(0xC9DD, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 5"),
            new Int16DivideBy100ModbusRegister(0xC9DE, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 7"),
            new Int16DivideBy100ModbusRegister(0xC9DF, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 7"),
            new Int16DivideBy100ModbusRegister(0xC9E0, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 7"),
            new Int16DivideBy100ModbusRegister(0xC9E1, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 9"),
            new Int16DivideBy100ModbusRegister(0xC9E2, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 9"),
            new Int16DivideBy100ModbusRegister(0xC9E3, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 9"),
            new Int16DivideBy100ModbusRegister(0xC9E4, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 11"),
            new Int16DivideBy100ModbusRegister(0xC9E5, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 11"),
            new Int16DivideBy100ModbusRegister(0xC9E6, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 11"),
            new Int16DivideBy100ModbusRegister(0xC9E7, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 13"),
            new Int16DivideBy100ModbusRegister(0xC9E8, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 13"),
            new Int16DivideBy100ModbusRegister(0xC9E9, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 13"),
            new Int16DivideBy100ModbusRegister(0xC9EA, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 15"),
            new Int16DivideBy100ModbusRegister(0xC9EB, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 15"),
            new Int16DivideBy100ModbusRegister(0xC9EC, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 15"),
            new Int16DivideBy100ModbusRegister(0xC9ED, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 17"),
            new Int16DivideBy100ModbusRegister(0xC9EE, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 17"),
            new Int16DivideBy100ModbusRegister(0xC9EF, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 17"),
            new Int16DivideBy100ModbusRegister(0xC9F0, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 19"),
            new Int16DivideBy100ModbusRegister(0xC9F1, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 19"),
            new Int16DivideBy100ModbusRegister(0xC9F2, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 19"),
            new Int16DivideBy100ModbusRegister(0xC9F3, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 21"),
            new Int16DivideBy100ModbusRegister(0xC9F4, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 21"),
            new Int16DivideBy100ModbusRegister(0xC9F5, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 21"),
            new Int16DivideBy100ModbusRegister(0xC9F6, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 23"),
            new Int16DivideBy100ModbusRegister(0xC9F7, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 23"),
            new Int16DivideBy100ModbusRegister(0xC9F8, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 23"),
            new Int16DivideBy100ModbusRegister(0xC9F9, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 25"),
            new Int16DivideBy100ModbusRegister(0xC9FA, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 25"),
            new Int16DivideBy100ModbusRegister(0xC9FB, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 25"),
            new Int16DivideBy100ModbusRegister(0xC9FC, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 27"),
            new Int16DivideBy100ModbusRegister(0xC9FD, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 27"),
            new Int16DivideBy100ModbusRegister(0xC9FE, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 27"),
            new Int16DivideBy100ModbusRegister(0xC9FF, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 29"),
            new Int16DivideBy100ModbusRegister(0xCA00, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 29"),
            new Int16DivideBy100ModbusRegister(0xCA01, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 29"),
            new Int16DivideBy100ModbusRegister(0xCA02, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 31"),
            new Int16DivideBy100ModbusRegister(0xCA03, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 31"),
            new Int16DivideBy100ModbusRegister(0xCA04, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 31"),
            new Int16DivideBy100ModbusRegister(0xCA05, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 33"),
            new Int16DivideBy100ModbusRegister(0xCA06, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 33"),
            new Int16DivideBy100ModbusRegister(0xCA07, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 33"),
            new Int16DivideBy100ModbusRegister(0xCA08, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 35"),
            new Int16DivideBy100ModbusRegister(0xCA09, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 35"),
            new Int16DivideBy100ModbusRegister(0xCA0A, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 35"),
            new Int16DivideBy100ModbusRegister(0xCA0B, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 37"),
            new Int16DivideBy100ModbusRegister(0xCA0C, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 37"),
            new Int16DivideBy100ModbusRegister(0xCA0D, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 37"),
            new Int16DivideBy100ModbusRegister(0xCA0E, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 39"),
            new Int16DivideBy100ModbusRegister(0xCA0F, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 39"),
            new Int16DivideBy100ModbusRegister(0xCA10, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 39"),
            new Int16DivideBy100ModbusRegister(0xCA11, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 41"),
            new Int16DivideBy100ModbusRegister(0xCA12, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 41"),
            new Int16DivideBy100ModbusRegister(0xCA13, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 41"),
            new Int16DivideBy100ModbusRegister(0xCA14, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 43"),
            new Int16DivideBy100ModbusRegister(0xCA15, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 43"),
            new Int16DivideBy100ModbusRegister(0xCA16, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 43"),
            new Int16DivideBy100ModbusRegister(0xCA17, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 45"),
            new Int16DivideBy100ModbusRegister(0xCA18, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 45"),
            new Int16DivideBy100ModbusRegister(0xCA19, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 45"),
            new Int16DivideBy100ModbusRegister(0xCA1A, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 47"),
            new Int16DivideBy100ModbusRegister(0xCA1B, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 47"),
            new Int16DivideBy100ModbusRegister(0xCA1C, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 47"),
            new Int16DivideBy100ModbusRegister(0xCA1D, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 49"),
            new Int16DivideBy100ModbusRegister(0xCA1E, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 49"),
            new Int16DivideBy100ModbusRegister(0xCA1F, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 49"),
            new Int16DivideBy100ModbusRegister(0xCA20, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 51"),
            new Int16DivideBy100ModbusRegister(0xCA21, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 51"),
            new Int16DivideBy100ModbusRegister(0xCA22, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 51"),
            new Int16DivideBy100ModbusRegister(0xCA23, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 53"),
            new Int16DivideBy100ModbusRegister(0xCA24, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 53"),
            new Int16DivideBy100ModbusRegister(0xCA25, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 53"),
            new Int16DivideBy100ModbusRegister(0xCA26, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 55"),
            new Int16DivideBy100ModbusRegister(0xCA27, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 55"),
            new Int16DivideBy100ModbusRegister(0xCA28, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 55"),
            new Int16DivideBy100ModbusRegister(0xCA29, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 57"),
            new Int16DivideBy100ModbusRegister(0xCA2A, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 57"),
            new Int16DivideBy100ModbusRegister(0xCA2B, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 57"),
            new Int16DivideBy100ModbusRegister(0xCA2C, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 59"),
            new Int16DivideBy100ModbusRegister(0xCA2D, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 59"),
            new Int16DivideBy100ModbusRegister(0xCA2E, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 59"),
            new Int16DivideBy100ModbusRegister(0xCA2F, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 61"),
            new Int16DivideBy100ModbusRegister(0xCA30, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 61"),
            new Int16DivideBy100ModbusRegister(0xCA31, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 61"),
            new Int16DivideBy100ModbusRegister(0xCA32, "Harmonische Oberschwingungen Spannung L1 - L2 Reihe 63"),
            new Int16DivideBy100ModbusRegister(0xCA33, "Harmonische Oberschwingungen Spannung L2 - L3 Reihe 63"),
            new Int16DivideBy100ModbusRegister(0xCA34, "Harmonische Oberschwingungen Spannung L3 - L1 Reihe 63"),
            //Table C950 Hex Spannung
            new Int16ModbusRegister(0xCA35, "Rang"),
            new Int16DivideBy100ModbusRegister(0xCA36, "Harmonische Oberschwingungen Spannung L1 Reihe 3"),
            new Int16DivideBy100ModbusRegister(0xCA37, "Harmonische Oberschwingungen Spannung L2 Reihe 3"),
            new Int16DivideBy100ModbusRegister(0xCA38, "Harmonische Oberschwingungen Spannung L3 Reihe 3"),
            new Int16DivideBy100ModbusRegister(0xCA39, "Harmonische Oberschwingungen Spannung L1 Reihe 5"),
            new Int16DivideBy100ModbusRegister(0xCA3A, "Harmonische Oberschwingungen Spannung L2 Reihe 5"),
            new Int16DivideBy100ModbusRegister(0xCA3B, "Harmonische Oberschwingungen Spannung L3 Reihe 5"),
            new Int16DivideBy100ModbusRegister(0xCA3C, "Harmonische Oberschwingungen Spannung L1 Reihe 7"),
            new Int16DivideBy100ModbusRegister(0xCA3D, "Harmonische Oberschwingungen Spannung L2 Reihe 7"),
            new Int16DivideBy100ModbusRegister(0xCA3E, "Harmonische Oberschwingungen Spannung L3 Reihe 7"),
            new Int16DivideBy100ModbusRegister(0xCA3F, "Harmonische Oberschwingungen Spannung L1 Reihe 9"),
            new Int16DivideBy100ModbusRegister(0xCA40, "Harmonische Oberschwingungen Spannung L2 Reihe 9"),
            new Int16DivideBy100ModbusRegister(0xCA41, "Harmonische Oberschwingungen Spannung L3 Reihe 9"),
            new Int16DivideBy100ModbusRegister(0xCA42, "Harmonische Oberschwingungen Spannung L1 Reihe 11"),
            new Int16DivideBy100ModbusRegister(0xCA43, "Harmonische Oberschwingungen Spannung L2 Reihe 11"),
            new Int16DivideBy100ModbusRegister(0xCA44, "Harmonische Oberschwingungen Spannung L3 Reihe 11"),
            new Int16DivideBy100ModbusRegister(0xCA45, "Harmonische Oberschwingungen Spannung L1 Reihe 13"),
            new Int16DivideBy100ModbusRegister(0xCA46, "Harmonische Oberschwingungen Spannung L2 Reihe 13"),
            new Int16DivideBy100ModbusRegister(0xCA47, "Harmonische Oberschwingungen Spannung L3 Reihe 13"),
            new Int16DivideBy100ModbusRegister(0xCA48, "Harmonische Oberschwingungen Spannung L1 Reihe 15"),
            new Int16DivideBy100ModbusRegister(0xCA49, "Harmonische Oberschwingungen Spannung L2 Reihe 15"),
            new Int16DivideBy100ModbusRegister(0xCA4A, "Harmonische Oberschwingungen Spannung L3 Reihe 15"),
            new Int16DivideBy100ModbusRegister(0xCA4B, "Harmonische Oberschwingungen Spannung L1 Reihe 17"),
            new Int16DivideBy100ModbusRegister(0xCA4C, "Harmonische Oberschwingungen Spannung L2 Reihe 17"),
            new Int16DivideBy100ModbusRegister(0xCA4D, "Harmonische Oberschwingungen Spannung L3 Reihe 17"),
            new Int16DivideBy100ModbusRegister(0xCA4E, "Harmonische Oberschwingungen Spannung L1 Reihe 19"),
            new Int16DivideBy100ModbusRegister(0xCA4F, "Harmonische Oberschwingungen Spannung L2 Reihe 19"),
            new Int16DivideBy100ModbusRegister(0xCA50, "Harmonische Oberschwingungen Spannung L3 Reihe 19"),
            new Int16DivideBy100ModbusRegister(0xCA51, "Harmonische Oberschwingungen Spannung L1 Reihe 21"),
            new Int16DivideBy100ModbusRegister(0xCA52, "Harmonische Oberschwingungen Spannung L2 Reihe 21"),
            new Int16DivideBy100ModbusRegister(0xCA53, "Harmonische Oberschwingungen Spannung L3 Reihe 21"),
            new Int16DivideBy100ModbusRegister(0xCA54, "Harmonische Oberschwingungen Spannung L1 Reihe 23"),
            new Int16DivideBy100ModbusRegister(0xCA55, "Harmonische Oberschwingungen Spannung L2 Reihe 23"),
            new Int16DivideBy100ModbusRegister(0xCA56, "Harmonische Oberschwingungen Spannung L3 Reihe 23"),
            new Int16DivideBy100ModbusRegister(0xCA57, "Harmonische Oberschwingungen Spannung L1 Reihe 25"),
            new Int16DivideBy100ModbusRegister(0xCA58, "Harmonische Oberschwingungen Spannung L2 Reihe 25"),
            new Int16DivideBy100ModbusRegister(0xCA59, "Harmonische Oberschwingungen Spannung L3 Reihe 25"),
            new Int16DivideBy100ModbusRegister(0xCA5A, "Harmonische Oberschwingungen Spannung L1 Reihe 27"),
            new Int16DivideBy100ModbusRegister(0xCA5B, "Harmonische Oberschwingungen Spannung L2 Reihe 27"),
            new Int16DivideBy100ModbusRegister(0xCA5C, "Harmonische Oberschwingungen Spannung L3 Reihe 27"),
            new Int16DivideBy100ModbusRegister(0xCA5D, "Harmonische Oberschwingungen Spannung L1 Reihe 29"),
            new Int16DivideBy100ModbusRegister(0xCA5E, "Harmonische Oberschwingungen Spannung L2 Reihe 29"),
            new Int16DivideBy100ModbusRegister(0xCA5F, "Harmonische Oberschwingungen Spannung L3 Reihe 29"),
            new Int16DivideBy100ModbusRegister(0xCA60, "Harmonische Oberschwingungen Spannung L1 Reihe 31"),
            new Int16DivideBy100ModbusRegister(0xCA61, "Harmonische Oberschwingungen Spannung L2 Reihe 31"),
            new Int16DivideBy100ModbusRegister(0xCA62, "Harmonische Oberschwingungen Spannung L3 Reihe 31"),
            new Int16DivideBy100ModbusRegister(0xCA63, "Harmonische Oberschwingungen Spannung L1 Reihe 33"),
            new Int16DivideBy100ModbusRegister(0xCA64, "Harmonische Oberschwingungen Spannung L2 Reihe 33"),
            new Int16DivideBy100ModbusRegister(0xCA65, "Harmonische Oberschwingungen Spannung L3 Reihe 33"),
            new Int16DivideBy100ModbusRegister(0xCA66, "Harmonische Oberschwingungen Spannung L1 Reihe 35"),
            new Int16DivideBy100ModbusRegister(0xCA67, "Harmonische Oberschwingungen Spannung L2 Reihe 35"),
            new Int16DivideBy100ModbusRegister(0xCA68, "Harmonische Oberschwingungen Spannung L3 Reihe 35"),
            new Int16DivideBy100ModbusRegister(0xCA69, "Harmonische Oberschwingungen Spannung L1 Reihe 37"),
            new Int16DivideBy100ModbusRegister(0xCA6A, "Harmonische Oberschwingungen Spannung L2 Reihe 37"),
            new Int16DivideBy100ModbusRegister(0xCA6B, "Harmonische Oberschwingungen Spannung L3 Reihe 37"),
            new Int16DivideBy100ModbusRegister(0xCA6C, "Harmonische Oberschwingungen Spannung L1 Reihe 39"),
            new Int16DivideBy100ModbusRegister(0xCA6D, "Harmonische Oberschwingungen Spannung L2 Reihe 39"),
            new Int16DivideBy100ModbusRegister(0xCA6E, "Harmonische Oberschwingungen Spannung L3 Reihe 39"),
            new Int16DivideBy100ModbusRegister(0xCA6F, "Harmonische Oberschwingungen Spannung L1 Reihe 41"),
            new Int16DivideBy100ModbusRegister(0xCA70, "Harmonische Oberschwingungen Spannung L2 Reihe 41"),
            new Int16DivideBy100ModbusRegister(0xCA71, "Harmonische Oberschwingungen Spannung L3 Reihe 41"),
            new Int16DivideBy100ModbusRegister(0xCA72, "Harmonische Oberschwingungen Spannung L1 Reihe 43"),
            new Int16DivideBy100ModbusRegister(0xCA73, "Harmonische Oberschwingungen Spannung L2 Reihe 43"),
            new Int16DivideBy100ModbusRegister(0xCA74, "Harmonische Oberschwingungen Spannung L3 Reihe 43"),
            new Int16DivideBy100ModbusRegister(0xCA75, "Harmonische Oberschwingungen Spannung L1 Reihe 45"),
            new Int16DivideBy100ModbusRegister(0xCA76, "Harmonische Oberschwingungen Spannung L2 Reihe 45"),
            new Int16DivideBy100ModbusRegister(0xCA77, "Harmonische Oberschwingungen Spannung L3 Reihe 45"),
            new Int16DivideBy100ModbusRegister(0xCA78, "Harmonische Oberschwingungen Spannung L1 Reihe 47"),
            new Int16DivideBy100ModbusRegister(0xCA79, "Harmonische Oberschwingungen Spannung L2 Reihe 47"),
            new Int16DivideBy100ModbusRegister(0xCA7A, "Harmonische Oberschwingungen Spannung L3 Reihe 47"),
            new Int16DivideBy100ModbusRegister(0xCA7B, "Harmonische Oberschwingungen Spannung L1 Reihe 49"),
            new Int16DivideBy100ModbusRegister(0xCA7C, "Harmonische Oberschwingungen Spannung L2 Reihe 49"),
            new Int16DivideBy100ModbusRegister(0xCA7D, "Harmonische Oberschwingungen Spannung L3 Reihe 49"),
            new Int16DivideBy100ModbusRegister(0xCA7E, "Harmonische Oberschwingungen Spannung L1 Reihe 51"),
            new Int16DivideBy100ModbusRegister(0xCA7F, "Harmonische Oberschwingungen Spannung L2 Reihe 51"),
            new Int16DivideBy100ModbusRegister(0xCA80, "Harmonische Oberschwingungen Spannung L3 Reihe 51"),
            new Int16DivideBy100ModbusRegister(0xCA81, "Harmonische Oberschwingungen Spannung L1 Reihe 53"),
            new Int16DivideBy100ModbusRegister(0xCA82, "Harmonische Oberschwingungen Spannung L2 Reihe 53"),
            new Int16DivideBy100ModbusRegister(0xCA83, "Harmonische Oberschwingungen Spannung L3 Reihe 53"),
            new Int16DivideBy100ModbusRegister(0xCA84, "Harmonische Oberschwingungen Spannung L1 Reihe 55"),
            new Int16DivideBy100ModbusRegister(0xCA85, "Harmonische Oberschwingungen Spannung L2 Reihe 55"),
            new Int16DivideBy100ModbusRegister(0xCA86, "Harmonische Oberschwingungen Spannung L3 Reihe 55"),
            new Int16DivideBy100ModbusRegister(0xCA87, "Harmonische Oberschwingungen Spannung L1 Reihe 57"),
            new Int16DivideBy100ModbusRegister(0xCA88, "Harmonische Oberschwingungen Spannung L2 Reihe 57"),
            new Int16DivideBy100ModbusRegister(0xCA89, "Harmonische Oberschwingungen Spannung L3 Reihe 57"),
            new Int16DivideBy100ModbusRegister(0xCA8A, "Harmonische Oberschwingungen Spannung L1 Reihe 59"),
            new Int16DivideBy100ModbusRegister(0xCA8B, "Harmonische Oberschwingungen Spannung L2 Reihe 59"),
            new Int16DivideBy100ModbusRegister(0xCA8C, "Harmonische Oberschwingungen Spannung L3 Reihe 59"),
            new Int16DivideBy100ModbusRegister(0xCA8D, "Harmonische Oberschwingungen Spannung L1 Reihe 61"),
            new Int16DivideBy100ModbusRegister(0xCA8E, "Harmonische Oberschwingungen Spannung L2 Reihe 61"),
            new Int16DivideBy100ModbusRegister(0xCA8F, "Harmonische Oberschwingungen Spannung L3 Reihe 61"),
            new Int16DivideBy100ModbusRegister(0xCA90, "Harmonische Oberschwingungen Spannung L1 Reihe 63"),
            new Int16DivideBy100ModbusRegister(0xCA91, "Harmonische Oberschwingungen Spannung L2 Reihe 63"),
            new Int16DivideBy100ModbusRegister(0xCA92, "Harmonische Oberschwingungen Spannung L3 Reihe 63"),
        };
        public override AbstractModbusRegister[] Registers
        {
            get { return registers; }
        }

        public SOCOMEC_Ethernetgateway_DIRIS_40_DIRIS_41(string ipAddress, ushort port = 502) : base(ipAddress, port)
        {

        }
        public sealed class Int32ModbusRegister : AbstractNumericModbusRegister
        {
            public int Int32Value { get; private set; }

            public override object Value
            {
                get { return this.Int32Value; }
            }

            public Int32ModbusRegister(ushort address, string name = null, string unit = null) : base(address, 2, name,
                unit)
            {
            }

            internal override void processNewValues(int[] values)
            {
                this.Int32Value = ModbusClient.ConvertRegistersToInt(values, ModbusClient.RegisterOrder.HighLow);
                base.processNewValues(values);
            }
        }
        public sealed class Int32DivideBy100ModbusRegister : AbstractNumericModbusRegister
        {
            public double DoubleValue { get; private set; }

            public override object Value
            {
                get { return this.DoubleValue; }
            }

            public Int32DivideBy100ModbusRegister(ushort address, string name = null, string unit = null) : base(address, 2, name,
                unit)
            {
            }

            internal override void processNewValues(int[] values)
            {
                this.DoubleValue = ModbusClient.ConvertRegistersToInt(values, ModbusClient.RegisterOrder.HighLow) / 100.0;
                base.processNewValues(values);
            }
        }
        public sealed class Int32DivideBy1000ModbusRegister : AbstractNumericModbusRegister
        {
            public double DoubleValue { get; private set; }

            public override object Value
            {
                get { return this.DoubleValue; }
            }

            public Int32DivideBy1000ModbusRegister(ushort address, string name = null, string unit = null) : base(address, 2, name,
                unit)
            {
            }

            internal override void processNewValues(int[] values)
            {
                this.DoubleValue = ModbusClient.ConvertRegistersToInt(values, ModbusClient.RegisterOrder.HighLow) / 1000.0;
                base.processNewValues(values);
            }
        }
        public sealed class Int16DivideBy100ModbusRegister : AbstractNumericModbusRegister
        {
            public double DoubleValue { get; private set; }

            public override object Value
            {
                get { return this.DoubleValue; }
            }

            public Int16DivideBy100ModbusRegister(ushort address, string name = null, string unit = null) : base(address, 1, name,
                unit)
            {
            }

            internal override void processNewValues(int[] values)
            {
                this.DoubleValue = ((short)values[0]) / 100.0;
                base.processNewValues(values);
            }
        }
    }
}
