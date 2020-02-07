using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPCGenerator.Models
{
    public class PlayerCharacter
    {
        public Background background { set; get; }
        public Dictionary<string, string> Features { set; get; }
        public int Str { set; get; }
        public int Dex { set; get; }
        public int Con { set; get; }
        public int Int { set; get; }
        public int Wis { set; get; }
        public int Cha { set; get; }

        public int StrMod { set; get; }
        public int DexMod { set; get; }
        public int ConMod { set; get; }
        public int IntMod { set; get; }
        public int WisMod { set; get; }
        public int ChaMod { set; get; }

        private void updateMods()
        {
            StrMod = (Str - 10) / 2;
            DexMod = (Dex - 10) / 2;
            ConMod = (Con - 10) / 2;
            IntMod = (Int - 10) / 2;
            WisMod = (Wis - 10) / 2;
            ChaMod = (Cha - 10) / 2;
        }

        public PlayerCharacter() { }

        public void SetStatsWithIntArray(int[] statBlock)
        {
            Str = statBlock[0];
            Dex = statBlock[1];
            Con = statBlock[3];
            Int = statBlock[4];
            Wis = statBlock[5];
            Cha = statBlock[6];
            updateMods();

        }
    }
}
