using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPCGenerator.Models
{
    public class Background
    {
        public String Name { set; get; }
        public String PersonalityTrait { set; get; }
        public String Ideal { set; get; }
        public String Bond { set; get; }
        public String Flaw { set; get; }
        public IList<String> Equipment { set; get; }
        public IList<String> SkillProficiencies { set; get; }
        public Dictionary<string, string> ExtraFeatures { set; get; }
    }
}
