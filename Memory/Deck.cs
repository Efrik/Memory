using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Memory
{
    static class Deck
        //The deck stores and refers to every created card that shall be shown in the board.
    {
        static List<Card> deck = new List<Card>();
        public static BitmapImage backCard = new BitmapImage(new Uri(@"D:\Efrik\Documents\Visual Studio 2017\Projects\Memory\Memory\Resources\Images\Frame.png"));

        public static void CreateCoupleCard() //Creates a Card and adds two copies of it to the deck
        {
            Card crd = null;
            do { crd = new Card(); } while (IsCardInDeck(crd));
            deck.Add(crd);
            deck.Add(crd);
        }

        private static bool IsCardInDeck(Card crd)
        {
            foreach (Card aspirant in deck)
            {
                if (crd.GetColor() == aspirant.GetColor() & crd.GetShape()==aspirant.GetShape()) return true;
            }
            return false;
        }

        public static void AddCard(Card crd)
        {
            deck.Add(crd);
        }

        public static Card RetrieveCard() //Selects a random card, returns it and removes it from the deck
        {
            Random rnd = new Random();
            int rndNum = rnd.Next(deck.Count);
            Card card = deck.ElementAt (rndNum);
            deck.RemoveAt(rndNum);
            return card;
        }

        public static void Deal() //This method is taken from a discussion from Stack Overflow about a Shuffle function in c#. Thanks to grenade and Uwe Keim.
        {
            Random rng = new Random();

            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }


    }
}
