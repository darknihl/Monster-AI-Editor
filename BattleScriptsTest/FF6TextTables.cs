using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleAIParserTest
{
    public class FF6TextTables
    {
        public Dictionary<ulong, string> ReadTableIn()
        {
            StreamReader sr = new StreamReader("./ff6_snes_menu_a.tbl");
            Dictionary<ulong, string> tblDict = new Dictionary<ulong, string>();
            string MenuTable = sr.ReadLine();
            string line;
            char[] DelimiterChar = { '=' };
            while ((line = MenuTable) != null)
            {
                string[] tblParse = MenuTable.Split(DelimiterChar);
                MenuTable = sr.ReadLine();
                tblDict.Add(ulong.Parse(tblParse[0], System.Globalization.NumberStyles.HexNumber), tblParse[1]);
            }
            sr.Close();
            return tblDict;
        }

        public Dictionary<string, ulong> ReadTableOut()
        {
            StreamReader sr = new StreamReader("./ff6_snes_menu_a.tbl");
            Dictionary<string, ulong> tblDict = new Dictionary<string, ulong>();
            string MenuTable = sr.ReadLine();
            string line;
            char[] DelimiterChar = { '=' };
            while ((line = MenuTable) != null)
            {
                string[] tblParse = MenuTable.Split(DelimiterChar);
                MenuTable = sr.ReadLine();
                tblDict.Add(tblParse[1], ulong.Parse(tblParse[0], System.Globalization.NumberStyles.HexNumber));
            }
            sr.Close();
            return tblDict;
        }
    }
}
