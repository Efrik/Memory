using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    static class Deck
    {
        static List<Card> deck = new List<Card>();

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
    }
}
