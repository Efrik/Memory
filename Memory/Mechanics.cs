using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    static class Mechanics
    {
        public enum Difficulty { Baby=0, Easy, Normal, Hard } ;
        private static Difficulty difficulty = Difficulty.Easy;

        public static void ChangeDifficulty()
        {
            if (difficulty == Difficulty.Baby) difficulty = Difficulty.Easy;
            else if (difficulty == Difficulty.Easy) difficulty = Difficulty.Normal;
            else if (difficulty == Difficulty.Normal) difficulty = Difficulty.Hard;
            else if (difficulty == Difficulty.Hard) difficulty = Difficulty.Baby;
        }

        public static int GetDifficultyint()
        {
            return (int)difficulty;
        }

        public static string GetDifficultyString()
        {
            return difficulty.ToString();
        }

        public static void CreateDeck()
            //This creates two copies of each needed card. The amount of cards depends on the difficulty.
        {
            int couples = 2+((int)difficulty *2);
            for (int i = 0; i < couples; i++)
            {
                Deck.CreateCoupleCard();
            }
        }


    }
}
