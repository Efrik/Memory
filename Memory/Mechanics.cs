using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Memory
{
    static class Mechanics
    {
        public enum Difficulty { Baby=0, Easy, Normal, Hard } ;
        private static Difficulty difficulty = Difficulty.Easy;

        public static CardButton button1=null; //These two hold the cards that will be checked as couple
        public static CardButton button2=null;

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
        public static void AddToCheckCouple(CardButton btn) //Adds the card as the first or second to check to.
        {
            if (button1 == null)
            {
                button1 = btn;
                //MessageBox.Show("Button1: " + button1.GetCard().GetShape().ToString() + button1.GetCard().GetColor().ToString());
            }
            else if (button2 == null)
            {
                button2 = btn;
                //MessageBox.Show("Button1: " + button1.GetCard().GetShape().ToString() + button1.GetCard().GetColor().ToString() + "/nButton2: " + button2.GetCard().GetShape().ToString() + button2.GetCard().GetColor().ToString());
                //else button1.Content = "None is null";
            }
        }

        public static bool TwoCardsIn() //bool that checks if there are already two cards to be checked
        {
            if (button2 != null && button1 != null) return true;
            else return false;
        }

        private static bool IsCouple(CardButton crd1, CardButton crd2) //Checks if the two cards have the same colour and shape, given two cards.
        {
            string crd1Shape = crd1.GetCard().GetShape();
            string crd2Shape = crd2.GetCard().GetShape();
            ConsoleColor crd1Col = crd1.GetCard().GetColor();
            ConsoleColor crd2Col = crd2.GetCard().GetColor();
            if (crd1Shape == crd2Shape && crd1Col == crd2Col) return true;
            else return false;
        }

        private static bool IsCouple() //Check if the two cards in the couple (there should be two) have the saem colour and shape
        {
            bool rslt = IsCouple(button1, button2);
            return rslt;
        }

        public static void CheckCouple() //Checks if the two cards are equal and acts accordingly
        {
            if (TwoCardsIn())
            {
                Card cardNum1 = button1.GetCard();
                Card cardNum2 = button2.GetCard();
                if (IsCouple())
                {
                    MessageBox.Show("It loks like it is a couple");
                    button1.ShowCard();
                    button2.ShowCard();
                    button1.BlockCard();
                    button2.BlockCard();
                    ResetCouple();
                }
                else
                {
                    MessageBox.Show("It loks like it is NOT a couple");
                    button1.UnblockCard();
                    button2.UnblockCard();
                    button1.HideCard();
                    button2.HideCard();
                    ResetCouple();
                }
            }
        }

        public static void ResetCouple()
        {

            button1.ResetButton();
            button2.ResetButton();
            MessageBox.Show("Button1: " + button1.GetCard().GetState().ToString() + "/nButton2: " + button2.GetCard().GetState().ToString());
            button1 = null;
            button2 = null;
        }
    }
}
