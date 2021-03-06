﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BattleScripts
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
                int OpcodeHex = Rom.Read8();

                if (OpcodeHex == 0xFB || OpcodeHex == 0xFC)
                {
                    Rom.Seek(-1, SeekOrigin.Current);
                    OpcodeHex = Rom.Read16();
                    OpcodeHex = ((OpcodeHex & 0x00FF) << 8) | ((OpcodeHex & 0xFF00) >> 8);
                }

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

                if (op.Name == "EndPhase" && ActiveScriptEnded)
                    break;
                else if (op.Name == "EndPhase")
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
