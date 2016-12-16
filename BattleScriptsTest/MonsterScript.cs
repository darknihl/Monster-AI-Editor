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

        public bool LoadScriptFromOffset(RomFileIO Rom, int Offset)
        {
            OpcodeTranslator ot = OpcodeTranslator.Instance;

            byte OpcodeHex = Rom.Read8(Offset);
            Opcode op = ot.LookupOpcodeByHex(OpcodeHex);

            OpcodeName = op.Name;

            foreach (string ParameterName in op.Parameters)
            {
                uint ParameterHex = 0;
                ParameterHex = Rom.Read8();

                foreach (Parameter p in ot.LookupParameterType(ParameterName).ParameterList)
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
