using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class Card
    {
        public enum Shape { square, triangle, circle};
        Array colors = [ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green];
        Shape shape = new Shape();
        ConsoleColor color = new ConsoleColor();
        public enum State { show, hide};
        State state = State.hide;
        

        public Card() //Normal creation method to random shape and color
        {
            Array values = Enum.GetValues(typeof(Shape));
            Random random = new Random();
            shape = (Shape)values.GetValue(random.Next(values.Length));

            Array colors = [ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green];
            color = (ConsoleColor)colors.GetValue(random.Next(colors.Length));

            Card otherCard = new Card(shape, color);

            AddToDeck();
        }

        public Card(Shape shp, ConsoleColor clr) //In case the card is created as a clone of another (like when you create a card).
        {
            shape = shp;
            color = clr;
            AddToDeck();
        }

        private void AddToDeck()
        {
            Deck.AddCard(this);
        }

        //Three actions to change the state of the card
        public void ShowCard()
        {
            state= State.show
        }

        public void HideCard()
        {
            state = State.hide;
        }

        public void FlipCard()
        {
            if (state == State.hide) state = State.show;
            else if (state == State.show) state = State.hide;
        }
}
}
