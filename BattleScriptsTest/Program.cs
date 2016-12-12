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

        static void Main(string[] args)
        {
            RomFileIO Rom = new RomFileIO();
            Rom.Open("./ff6mtest.sfc");
            //ReadPointerNormal(Rom, BattleAIConstants.MONSTER_SCRIPT_POINTERS_NORMAL);
            //ReadPointerHard(Rom, BattleAIConstants.MONSTER_SCRIPT_POINTERS_HARD);
            Rom.Close();
        }

        static void ReadPointerNormal(RomFileIO Rom, int Offset)
        {
            int PointerLoop = 0;
            List<int> EnemyPointerNormal = new List<int>();
            while (PointerLoop < 384*2)
            {
                int Pointer = Rom.Read16(Offset + PointerLoop);
                EnemyPointerNormal.Add(Pointer);
                PointerLoop++;
                PointerLoop++;
            }
            /*using (StreamWriter file = new StreamWriter("./pointertest.txt", false))
            {
                int WriteLoop = 0;
                while (WriteLoop < 384)
                {
                    file.WriteLine("{0:X}", EnemyPointerNormal[WriteLoop]);
                    WriteLoop++;
                }
            }*/
        }

        static void ReadPointerHard(RomFileIO Rom, int Offset)
        {
            int PointerLoop = 0;
            List<int> EnemyPointerHard = new List<int>();
            while (PointerLoop < 384 * 2)
            {
                int Pointer = Rom.Read16(Offset + PointerLoop);
                EnemyPointerHard.Add(Pointer);
                PointerLoop++;
                PointerLoop++;
            }
            /*using (StreamWriter file = new StreamWriter("./pointertest.txt", true))
            {
                int WriteLoop = 0;
                while (WriteLoop < 384)
                {
                    file.WriteLine("{0:X}", EnemyPointerHard[WriteLoop]);
                    WriteLoop++;
                }
            }*/
        }

        static void ReadScriptNormal(RomFileIO Rom, int Offset)
        {
            //Extract script and convert to readable format
        }
    }
}
