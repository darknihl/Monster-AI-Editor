using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BattleScriptsTest
{
    public enum ParamValueType { String = 0, Int8 };

    public class OpcodeTranslator
    {
        public static readonly OpcodeTranslator Instance = new OpcodeTranslator();

        private Dictionary<string, Opcode> NameOpcodeList = new Dictionary<string, Opcode>();
        private Dictionary<int, Opcode> HexOpcodeList = new Dictionary<int, Opcode>();
        private Dictionary<string, ParameterType> ParameterTypeList = new Dictionary<string, ParameterType>();

        // Loads the configuration file containing all of the opcode settings and parameters
        public bool LoadConfigurationFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (string s in lines)
            {
                if (s.Length == 0)
                    continue;
                if (s[0] == '#')
                    continue;

                string[] tokens = s.Split(' ');
                switch (tokens[0])
                {
                    // Opcode OpcodeName Hex NumberOfParameters [Types]
                    case "Opcode":
                        Opcode opcode = new Opcode();
                        opcode.Name = tokens[1];
                        opcode.Hex = Byte.Parse(tokens[2], System.Globalization.NumberStyles.HexNumber);
                        opcode.NumParameters = int.Parse(tokens[3]);
                        for(int i = 0; i < opcode.NumParameters; i++)
                            opcode.Parameters.Add(tokens[4+i]);
                        NameOpcodeList.Add(opcode.Name, opcode);
                        HexOpcodeList.Add(opcode.Hex, opcode);
                        break;
                    // Type TypeName ValueType
                    case "Type":
                        ParameterType type = new ParameterType();
                        type.Name = tokens[1];
                        Enum.TryParse(tokens[2], false, out type.ValueType);
                        ParameterTypeList.Add(type.Name, type);
                        break;
                    // Parameter TypeName ParameterName HexValue
                    case "Parameter":
                        Parameter p = new Parameter();
                        p.Name = tokens[2];
                        p.Hex = uint.Parse(tokens[3], System.Globalization.NumberStyles.HexNumber);
                        ParameterTypeList[tokens[1]].ParameterList.Add(p);
                        break;
                    default:
                        Console.WriteLine("Unknown identifier {0}\n", tokens[0]);
                        return false;
                }
            }

            return true;
        }

        public Opcode LookupOpcodeByName(string Name)
        {
            if (NameOpcodeList.ContainsKey(Name))
                return NameOpcodeList[Name];

            throw new KeyNotFoundException();
        }

        public Opcode LookupOpcodeByHex(byte Hex)
        {
            if (HexOpcodeList.ContainsKey(Hex))
                return HexOpcodeList[Hex];

            throw new KeyNotFoundException();
        }

        public ParameterType LookupParameterType(string type)
        {
            if (ParameterTypeList.ContainsKey(type))
                return ParameterTypeList[type];

            throw new KeyNotFoundException();
        }
    }

    public class Opcode
    {
        public string Name;
        public byte Hex;
        public int NumParameters;

        public List<string> Parameters = new List<string>();
    }

    public class ParameterType
    {
        public string Name;
        public ParamValueType ValueType;

        public List<Parameter> ParameterList = new List<Parameter>();
    }

    public class Parameter
    {
        public string Name;
        public uint Hex;
    }
}
