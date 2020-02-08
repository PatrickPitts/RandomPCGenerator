using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPCGenerator.Models
{
    public class CharacterClass
    {
        public int HitDie { set; get; }
        public string[] SavingThrows { set; get; } = new string[2];
        public string SubclassName { set; get; }
        public string ClassName { set; get; }
        public int NumSpellsKnown { set; get; }
        public IList<int> NumSpellSlots { set; get; }
        public IList<string> Spells { set; get; }
        public string SpellModifier { set; get; }
        public string Source { set; get; } = "PHB";

        public CharacterClass() { }
    }
}
