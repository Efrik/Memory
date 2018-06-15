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

        private static CardButton card1=null; //These two are the cards that will be checked if they are a couple
        private static CardButton card2=null;

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

        //Some methods to work with couples of cards
        public static void AddToCheckCouple(CardButton crd)
        {
            if (card1 == null) card1 = crd;
            else card2 = crd; 
        }

        public static bool TwoCardsIn()
        {
            if (card2 != null) return true;
            else return false;
        }

        public static bool IsCouple(CardButton crd1, CardButton crd2)
        {
            string crd1Shape = crd1.GetCard().GetShape();
            string crd2Shape = crd2.GetCard().GetShape();
            ConsoleColor crd1Col = crd1.GetCard().GetColor();
            ConsoleColor crd2Col = crd2.GetCard().GetColor();
            if (crd1Shape == crd2Shape && crd1Col == crd2Col) return true;
            else return false;
        }

        public static bool IsCouple()
        {
            bool rslt = IsCouple(card1, card2);
            return rslt;
        }

        public static void CheckCouple()
        {
            if (TwoCardsIn())
            {
                if (IsCouple())
                {
                    Card cardNum1 = card1.GetCard();
                    Card cardNum2 = card2.GetCard();
                    cardNum1.ShowCard();
                    cardNum2.ShowCard();
                    cardNum1.BlockUnblock();
                    cardNum2.BlockUnblock();
                    ResetCouple();
                }
            }
        }

        public static void ResetCouple()
        {
            if (!card1.GetCard().IsBlocked()) card1.GetCard().HideCard();
            if (!card2.GetCard().IsBlocked()) card2.GetCard().HideCard();
            card1 = null;
            card2 = null;
        }
    }
}
