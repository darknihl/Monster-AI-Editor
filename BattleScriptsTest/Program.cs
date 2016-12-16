using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleScriptsTest
{
    public class Program
    {
        public const int NumPointers = 512;
        public int ScriptOffset;

        static void Main(string[] args)
        {
            RomFileIO Rom = new RomFileIO();
            Rom.Open("./FF6MTEST.sfc");
            ExportScriptsNormal(Rom);
            ExportScriptsHard(Rom);
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
            while (PointerIndex < NumPointers)
            {
                int Pointer = Rom.Read16(Offset + PointerIndex * 2);
                EnemyPointerNormal.Add(Pointer);
                PointerIndex++;
            }
            using (StreamWriter file = new StreamWriter("./Normal/normal_pointers.txt", false))
            {
                int WriteLoop = 0;
                while (WriteLoop < 512)
                {
                    file.WriteLine("{0:X}", EnemyPointerNormal[WriteLoop]);
                    WriteLoop++;
                }
            }

            return EnemyPointerNormal;
        }

        static void ReadPointerHard(RomFileIO Rom, int Offset)
        {
            if (!Directory.Exists("./Hard/"))
            {
                Directory.CreateDirectory("./Hard/");
            }
            int PointerIndex = 0;
            List<int> EnemyPointerHard = new List<int>();
            while (PointerIndex < NumPointers)
            {
                int Pointer = Rom.Read16(Offset + PointerIndex * 2);
                EnemyPointerHard.Add(Pointer);
                PointerIndex++;
            }
            using (StreamWriter file = new StreamWriter("./Hard/hard_pointers.txt", false))
            {
                int WriteLoop = 0;
                while (WriteLoop < NumPointers)
                {
                    file.WriteLine("{0:X}", EnemyPointerHard[WriteLoop]);
                    WriteLoop++;
                }
            }
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

        static void ReadScriptsNormal(RomFileIO Rom, int Offset, List<int> PointerList)
        {
            //TODO: loop single script read 512 times
            for (int i = 0; i < NumPointers; i++)
            {
                
            }
        }

        static void WriteScriptsNormal(RomFileIO Rom, int Offset)
        {
            //TODO: loop single script read 512 times
        }

        //*********************************************************************************************//

        static void ExportScriptsNormal(RomFileIO Rom)
        {
            //Extract script and convert to readable format
            List<int> PointerList = ReadPointerNormal(Rom, BattleAIConstants.MONSTER_SCRIPT_POINTERS_NORMAL);
            ReadScriptsNormal(Rom, BattleAIConstants.MONSTER_SCRIPTS_NORMAL, PointerList);

        }

        static void ImportScriptsNormal(RomFileIO Rom)
        {
            //Insert script and convert to byte format
        }

        static void ExportScriptsHard(RomFileIO Rom)
        {
            ReadPointerHard(Rom, BattleAIConstants.MONSTER_SCRIPT_POINTERS_HARD);
            //Extract script and convert to readable format
        }

        static void ImportScriptsHard(RomFileIO Rom)
        {
            //Insert script and convert to byte format
        }
    }
}
