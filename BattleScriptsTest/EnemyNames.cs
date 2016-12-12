using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleAIParserTest
{

    public class EnemyList
    {
        RomFileIO Rom = new RomFileIO();
        FF6TextTables TextTables = new FF6TextTables();

        public int Enemy = 0;
        public int ReadLetter;
        public byte EnemyByte;

        List<string> EnemyLettersList = new List<string>();
        string EnemyName;
        List<string> EnemyNamesList = new List<string>();

        public List<string> ReadEnemyNames(RomFileIO Rom)
        {
            if (!Rom.IsOpen())
            {
                throw new NullReferenceException();
            }
            else
            {
                ReadLetter = RomData.ENEMY_NAMES;
                int l = 0;
                StringBuilder sb = new StringBuilder();
                Dictionary<ulong, string> FF6TableIn = TextTables.ReadTableIn();
                Rom.Read8(ReadLetter - 1);
                while (Enemy < 384)
                {
                    while (l < 10)
                    {
                        EnemyByte = Rom.Read8();
                        EnemyLettersList.Add(FF6TableIn[EnemyByte]);
                        ReadLetter++;
                        l++;
                    }
                    EnemyName = EnemyLettersList[0];
                    for (int i = 0; i < 9; i++)
                    {
                        EnemyName += EnemyLettersList[i + 1];
                    }
                    EnemyNamesList.Add(Convert.ToString(EnemyName));
                    EnemyName = null;
                    Enemy++;
                    l = 0;
                    EnemyLettersList.Clear();
                }
                return EnemyNamesList;
            }
        }

        /*public List<string> WriteEnemyNames()
        {
            Dictionary<string, ulong> FF6TableOut = TextTables.ReadTableOut();
        }*/
    }
}
