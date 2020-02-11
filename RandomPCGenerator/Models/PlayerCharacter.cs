using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPCGenerator.Models
{
    public class PlayerCharacter
    {
        public Background Background { set; get; }
        public IList<string> FeatureNames { set; get; } = new List<String>();

        public int[] AttributeScores { set; get; } = new int[6] { 10, 10, 10, 10, 10, 10 };

        public PlayerCharacter() { }

    }
}
