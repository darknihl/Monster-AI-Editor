using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScripts
{
    public class Program
    {
        public const string RomFileName = @"./ff6test/FF6MTEST.sfc";
        public const string ConfigFileName = @"./ff6test/OpcodeConfig.txt";
        public const string NormalScriptOutputFileName = @"./ff6test/normalscripts.txt";
        public const string HardScriptOutputFilename = @"./ff6test/hardscripts.txt";
        public const int NumMonsters = 384;
        public int ScriptOffset;

        static void Main(string[] args)
        {
            RomFileIO Rom = new RomFileIO();
            Rom.Open(RomFileName);
            OpcodeTranslator ot = OpcodeTranslator.Instance;
            ot.LoadConfigurationFile(ConfigFileName);

            ExportScriptsNormal(Rom, NormalScriptOutputFileName);
            ExportScriptsHard(Rom, HardScriptOutputFilename);
            Rom.Close();
        }

        static List<int> ReadPointerNormal(RomFileIO Rom, int Offset)
        {
            if (!Directory.Exists("./Normal/"))
            {
                Directory.CreateDirectory("./Normal/"); 
            }
            int PointerIndex = 0;
            List<int> EnemyPointerNormal = new List<int>();
            while (PointerIndex < NumMonsters)
            {
                int Pointer = Rom.Read16(Offset + PointerIndex * 2);
                EnemyPointerNormal.Add(Pointer + RomData.MONSTER_AI_NORMAL_BANK);
                PointerIndex++;
            }
            using (StreamWriter file = new StreamWriter("./Normal/normal_pointers.txt", false))
            {
                int WriteLoop = 0;
                while (WriteLoop < NumMonsters)
                {
                    file.WriteLine("{0:X}", EnemyPointerNormal[WriteLoop]);
                    WriteLoop++;
                }
            }

            return EnemyPointerNormal;
        }

        static List<int> ReadPointerHard(RomFileIO Rom, int Offset)
        {
            if (!Directory.Exists("./Hard/"))
            {
                Directory.CreateDirectory("./Hard/");
            }
            int PointerIndex = 0;
            List<int> EnemyPointerHard = new List<int>();
            while (PointerIndex < NumMonsters)
            {
                int Pointer = Rom.Read16(Offset + PointerIndex * 2);
                EnemyPointerHard.Add(Pointer + RomData.MONSTER_AI_HARD_BANK);
                PointerIndex++;
            }
            using (StreamWriter file = new StreamWriter("./Normal/hard_pointers.txt", false))
            {
                int WriteLoop = 0;
                while (WriteLoop < NumMonsters)
                {
                    file.WriteLine("{0:X}", EnemyPointerHard[WriteLoop]);
                    WriteLoop++;
                }
            }

            return EnemyPointerHard;
        }

        //*********************************************************************************************//

        //This reads a single script and renders it as readable text
        static void ReadSingleScriptNormal(RomFileIO Rom, int Offset)
        {
            if (!File.Exists("./FF6MTest.sfc"))
            {
                throw new FileNotFoundException("FF6MTest.sfc not found.");
            }

        }

        //This reads a single script and renders it as bytecode
        static void WriteSingleScriptNormal(RomFileIO Rom, int Offset)
        {
            //TODO: read and import a single script to a txt file in \Normal
        }

        //This reads a single script and renders it as readable text
        static void ReadSingleScriptHard(RomFileIO Rom, int Offset)
        {
            //TODO: read and export a single script to a txt file in \Hard
        }

        //This reads a single script and renders it as bytecode
        static void WriteSingleScriptHard(RomFileIO Rom, int Offset)
        {
            //TODO: read and import a single script to a txt file in \Hard
        }

        //*********************************************************************************************//

        static List<MonsterScript> ReadScriptsNormal(RomFileIO Rom, List<int> PointerList)
        {
            List<MonsterScript> MonsterList = new List<MonsterScript>();

            //TODO: loop single script read 512 times
            for (int i = 0; i < NumMonsters; i++)
            {
                MonsterScript ms = new MonsterScript(i);
                ms.LoadScriptFromOffset(Rom, PointerList[i]);
                MonsterList.Add(ms);
            }

            return MonsterList;
        }

        static void WriteScriptsNormal(RomFileIO Rom, int Offset)
        {
            //TODO: loop single script read 512 times
        }

        static List<MonsterScript> ReadScriptsHard(RomFileIO Rom, List<int> PointerList)
        {
            List<MonsterScript> MonsterList = new List<MonsterScript>();

            //TODO: loop single script read 512 times
            for (int i = 0; i < NumMonsters; i++)
            {
                MonsterScript ms = new MonsterScript(i);
                ms.LoadScriptFromOffset(Rom, PointerList[i]);
                MonsterList.Add(ms);
            }

            return MonsterList;
        }

        static void WriteScriptsHard(RomFileIO Rom, int Offset)
        {
            //TODO: loop single script read 512 times
        }

        //*********************************************************************************************//

        static void ExportScriptsNormal(RomFileIO Rom, string OutputFileName)
        {
            //Extract script and convert to readable format
            List<int> PointerList = ReadPointerNormal(Rom, RomData.MONSTER_AI_NORMAL_POINTERS);
            List<MonsterScript> MonsterList = ReadScriptsNormal(Rom, PointerList);

            using (StreamWriter file = new StreamWriter(OutputFileName, false))
            {
                foreach (MonsterScript ms in MonsterList)
                {
                    file.Write("Monster idx [{0}] Pointer offset [{1:X}]\n", ms.MonsterIndex, ms.PointerLoc);
                    foreach (MonsterCommand mc in ms.CommandList)
                    {
                        file.Write("{0}", mc.OpcodeName);
                        foreach (string s in mc.ParameterList)
                            file.Write(" {0}", s);
                        file.Write("\n");
                    }
                    file.Write("\n");
                }
            }
        }

        static void ImportScriptsNormal(RomFileIO Rom)
        {
            //Insert script and convert to byte format
        }

        static void ExportScriptsHard(RomFileIO Rom, string OutputFileName)
        {
            //Extract script and convert to readable format
            List<int> PointerList = ReadPointerHard(Rom, RomData.MONSTER_AI_HARD_POINTERS);
            List<MonsterScript> MonsterList = ReadScriptsHard(Rom, PointerList);

            using (StreamWriter file = new StreamWriter(OutputFileName, false))
            {
                foreach (MonsterScript ms in MonsterList)
                {
                    file.Write("Monster idx [{0}] Pointer offset [{1:X}]\n", ms.MonsterIndex, ms.PointerLoc);
                    foreach (MonsterCommand mc in ms.CommandList)
                    {
                        file.Write("{0}", mc.OpcodeName);
                        foreach (string s in mc.ParameterList)
                            file.Write(" {0}", s);
                        file.Write("\n");
                    }
                    file.Write("\n");
                }
            }
        }

        static void ImportScriptsHard(RomFileIO Rom)
        {
            //Insert script and convert to byte format
        }
    }
}
