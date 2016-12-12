using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Web;
using BattleScriptsTest;


namespace BattleScriptsTest
{
    public class RomData
    {
        public const int MONSTER_STATS_NORMAL_DATA = 0x333530; // 384 entries, 32 byte struct, 1000 byte buffer for expansion, 3 difficulties = 0xC000 byte block
        public const int MONSTER_STATS_NORMAL_SECONDARY_DATA = 0x0F0000; // 384 entries, 3 byte struct, 180 byte buffer for expansion, 3 difficulties = 0x1200 byte block
        public const int MONSTER_HP_NORMAL = 0x0F1200; // 384 entries, 3 byte struct, 180 byte buffer for expansion, 3 difficulties = 0x1200 byte block
        public const int MONSTER_SPECIAL_ANIMATIONS = 0x0F2400; // 384 entries, 1 byte each, 180 byte block, 80 byte buffer for expansion = 0x200 byte block
        public const int MONSTER_STEAL_DROP_TABLE = 0x0F2600; // 384 entries, 4 byte struct, 600 byte block, 200 byte buffer for expansion = 0x800 byte block
        public const int MONSTER_AI_NORMAL_POINTERS = 0x0F8400; // 384 entries, 2 byte struct, 300 byte block, 100 byte buffer for expansion = 0x400 byte block
        public const int MONSTER_AI_NORMAL_BANK = 0x3E0000; // 384 entries, variable length
        public const int MONSTER_AI_HARD_POINTERS = 0x0F8800; // 384 entries, two bytes each, 300 byte block, 100 byte buffer for expansion = 0x400 byte block
        public const int MONSTER_AI_HARD_BANK = 0x3F0000; // 384 entries, variable length
        public const int MONSTER_NAMES = 0x0F8C00; // 384 entries, 10 byte struct, 0xF00(3840d) byte block, 0x500(1280d) byte buffer for expansion = 0x1400 byte block
        public const int MONSTER_CONTROL = 0x33F530; // 384 entries, 4 byte struct, 0x600 byte block, 200 byte buffer for expansion = 0x800 byte block
        public const int MONSTER_SKETCH = 0x0F3D00; // 384 entries, 2 byte struct, 300 byte block, 100 byte buffer for expansion = 0x400 byte block
        public const int MONSTER_RAGE = 0x0F4600; // 256 entries, 2 byte struct        
        public const int SPELL_DATA = 0x046AC0; // 256 entries, 14 bytes each
        public const int SPELL_DELAY = 0x333100; // 1 byte per spell, 256 spells
        public const int SPELL_ESPER_NAMES = 0x3A0000; // 9 characters, 54 spells; 12 characters, 27 espers
        public const int OTHER_SPELL_NAMES = 0x3A0B90;
        public const int ENEMY_NAMES = 0x0F8C00; // 384 entries, ten characters each
    }
}
