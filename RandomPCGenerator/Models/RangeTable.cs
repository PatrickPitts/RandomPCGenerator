using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPCGenerator.Models
{
    public class RangeTable
    {

        private List<Tuple<Tuple<int, int>, string>> Entries = new List<Tuple<Tuple<int, int>, string>>();

        private void CleanupList()
        {
            Entries = Entries.OrderBy(i => i.Item1).ToList();
        }

        public void AddEntry(int lower, int upper, string text)
        {
            Tuple<int, int> Range = new Tuple<int, int>(lower, upper);
            Tuple<Tuple<int, int>, string> Entry = new Tuple<Tuple<int, int>, string>(Range, text);
            Entries.Add(Entry);
            CleanupList();
        }

        public void AddEntry(Tuple<Tuple<int, int>, string> entry)
        {
            Entries.Add(entry);
            CleanupList();
        }

        public string Roll()
        {
            /* Entries list should be sorted in ascending order by the first value in the Ranges for each value.
             * This method gets a random integer between the lowest value of the first Ranges tuple and the higher value of the last Ranges tuple
             */
            Random random = new Random();
            int rollResult = random.Next(Entries[0].Item1.Item1, Entries.Last().Item1.Item2+1);
            foreach(Tuple<Tuple<int,int>,string> entry in Entries)
            {
                Tuple<int, int> range = entry.Item1;
                if(rollResult >= range.Item1 && rollResult <= range.Item2)
                {
                    return entry.Item2;
                }

            }
            return Roll();
        }
    }
}
