using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    static class Mechanics
    {
        public enum Difficulty { Easy=0, Normal=1, Hard=2 } ;
        public static Difficulty difficulty = Difficulty.Easy;

        public static void ChangeDifficulty()
        {
            if (difficulty == Difficulty.Easy) difficulty = Difficulty.Normal;
            else if (difficulty == Difficulty.Normal) difficulty = Difficulty.Hard;
            else if (difficulty == Difficulty.Hard) difficulty = Difficulty.Easy;
        }

        public static void CreateDeck()
        {
            int couples = 4+((int)difficulty *2);

        }
    }
}
