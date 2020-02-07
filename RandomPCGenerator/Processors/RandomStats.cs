using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPCGenerator.Processors
{
    public class RandomStats
    {
        public static Random random = new Random();

        public static int[] Random3d6()
        {
            int[] statBlock = new int[6];
            for(int i=0; i < 6; i++)
            {
                statBlock[i] = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            }
            return statBlock;
        }

        public static int[] Random4d6DropLowest()
        {
            int[] statBlock = new int[6];
            List<int> temp = new List<int> { 0, 0, 0, 0 };
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    temp[j] = random.Next(1, 7);
                }
                temp.Sort();
                statBlock[i] = temp[1] + temp[2] + temp[3];
            }
            return statBlock;
        }
    }
}
