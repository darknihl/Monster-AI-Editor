using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleAIParserTest
{
    class AIConstants
    {
        public const int MONSTER_AI_NORMAL_POINTERS = 0x0F8400; // 384 entries, 2 byte struct, 300 byte block, 100 byte buffer for expansion = 0x400 byte block
        public const int MONSTER_AI_NORMAL_BANK = 0x3E0000; // 384 entries, variable length
        public const int MONSTER_AI_HARD_POINTERS = 0x0F8800; // 384 entries, two bytes each, 300 byte block, 100 byte buffer for expansion = 0x400 byte block
        public const int MONSTER_AI_HARD_BANK = 0x3F0000; // 384 entries, variable length
        public const int ENEMY_NAMES = 0x0F8C00; // 384 entries, ten characters each
    }
}
