using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScriptsTest
{
    public class MonsterScript
    {
        public string MonsterName = "";
        public int PointerLoc = -1;

        public string OpcodeName = "";

        public List<string> ParameterList = new List<string>();

        public bool LoadScriptFromOffset(RomFileIO ROM, int Offset)
        {
            OpcodeTranslator ot = OpcodeTranslator.Instance;

            byte OpcodeHex = ROM.Read8(Offset);
            Opcode op = ot.LookupOpcodeByHex(OpcodeHex);

            OpcodeName = op.Name;

            foreach (ParameterType pt in op.ParameterTypeList)
            {
                uint ParameterHex = 0;

                if (pt.Size == 1)
                    ParameterHex = ROM.Read8();
                else if(pt.Size == 2)
                    ParameterHex = ROM.Read16();
                else if(pt.Size == 4)
                    ParameterHex = ROM.Read32();

                foreach (Parameter p in pt.ParameterList)
                {
                    if(p.Hex == ParameterHex)
                        ParameterList.Add(p.Name);
                }
            }

            return false;
        }

        public bool SaveScriptToOffset(RomFileIO ROM, int Offset)
        {
            return false;
        }

    }
}
