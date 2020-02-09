using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public IList<int> NumSpellSlots { set; get; } = new List<int>();
        public IList<string> Spells { set; get; } = new List<string>();
        public string SpellModifier { set; get; }
        public string Source { set; get; } = "PHB";
        public int ClassLevel {set; get;} = 1;
        public IList<string> ClassFeatures { set; get; } = new List<string>();

        public CharacterClass() { }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("Class: Level ").Append(ClassLevel).Append(" ").Append(ClassName);
            if(SubclassName !is null)
            {
                text.AppendLine("Subclass: ").Append(SubclassName);
            }
            text.AppendLine("Hit Die: d").Append(HitDie);
            text.AppendLine("Features: ");
            foreach(String feature in ClassFeatures)
            {
                text.AppendLine(feature);
            }
            if(Spells.Count > 0)
            {
                text.AppendLine("Spells: ");
                foreach(String spellName in Spells)
                {
                    text.AppendLine(spellName);
                }
            }


            return text.ToString();
        }
    }
}
