using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScriptsTest
{
    public class OpcodeTranslator
    {
        public static readonly OpcodeTranslator Instance = new OpcodeTranslator();

        private List<Opcode> OpcodeList = new List<Opcode>();
        private List<ParameterType> ParameterTypeList = new List<ParameterType>();

        // Loads the configuration file containing all of the opcode settings and parameters
        public bool LoadConfigurationFile(string filename)
        {
            return false;
        }

        public Opcode LookupOpcodeByHex(byte Hex)
        {
            foreach (Opcode opcode in OpcodeList)
            {
                if (opcode.Hex == Hex)
                    return opcode;
            }

            throw new KeyNotFoundException();
        }

        public ParameterType LookupParameterType(string type)
        {
            foreach (ParameterType pt in ParameterTypeList)
            {
                if (pt.TypeName == type)
                {
                    return pt;
                }
            }

            throw new KeyNotFoundException();
        }
    }

    public class Opcode
    {
        public string Name;
        public byte Hex;

        public List<ParameterType> ParameterTypeList = new List<ParameterType>();
    }

    public class ParameterType
    {
        public string TypeName;
        public int Size;

        public List<Parameter> ParameterList = new List<Parameter>();
    }

    public class Parameter
    {
        public string Name;
        public uint Hex;
    }
}
