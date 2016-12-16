using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScriptsTest
{
    public class MonsterCommand
    {
        public string OpcodeName = "";
        public List<string> ParameterList = new List<string>();
    }

    public class MonsterScript
    {
        public string MonsterName = "";
        public int MonsterIndex;
        public int PointerLoc;

        public List<MonsterCommand> CommandList = new List<MonsterCommand>();
        private bool ActiveScriptEnded = false;

        public MonsterScript(int Index)
        {
            MonsterIndex = Index;
        }

        public bool LoadScriptFromOffset(RomFileIO Rom, int Offset)
        {
            OpcodeTranslator ot = OpcodeTranslator.Instance;
            PointerLoc = Offset;
            Rom.Seek(PointerLoc);

            while (true)
            {
                MonsterCommand mc = new MonsterCommand();
                byte OpcodeHex = Rom.Read8();

                Opcode op = ot.LookupOpcodeByHex(OpcodeHex);
                mc.OpcodeName = op.Name;

                foreach (string ParameterName in op.Parameters)
                {
                    uint ParameterHex = 0;
                    ParameterHex = Rom.Read8();

                    if (ot.LookupParameterType(ParameterName) == null)
                        // Remove this later when all types are in the config file
                        mc.ParameterList.Add(String.Format("${0:X}", ParameterHex));
                    else
                    {
                        foreach (Parameter p in ot.LookupParameterType(ParameterName).ParameterList)
                        {
                            if (p.Hex == ParameterHex)
                                mc.ParameterList.Add(p.Name);
                        }
                    }
                }

                CommandList.Add(mc);

                if (op.Name == "End" && ActiveScriptEnded)
                    break;
                else if (op.Name == "End")
                    ActiveScriptEnded = true;
            }

            return true;
        }

        public bool SaveScriptToOffset(RomFileIO ROM, int Offset)
        {
            return false;
        }

    }
}
