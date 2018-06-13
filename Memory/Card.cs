using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class Card
        // This class stores info about every card: the shape and color (and in the future, the image as well), and the flip state.
    {
        public enum Shape { square, triangle, circle};
        ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green };
        Shape shape = new Shape();
        ConsoleColor color = new ConsoleColor();
        public enum State { show, hide};
        State state = State.hide;
        

        public Card() //Normal creation method to random shape and color
        {
            Array values = Enum.GetValues(typeof(Shape));
            Array colours = Enum.GetValues(typeof(Shape));
            Random random = new Random();
            shape = (Shape)values.GetValue(random.Next(values.Length));

            color = (ConsoleColor)colours.GetValue(random.Next(colours.Length));

/* I remove all this because I want Deck to take care of creating cards.
           Card otherCard = new Card(shape, color);
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
*/
        }

        //Three actions to change the state of the card
        public void ShowCard()
        {
            state = State.show ;
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

        //Getters of shape and state and booleans for them
        public State GetState()
        {
            return state;
        }

        public Shape GetShape()
        {
            return shape;
        }

        public bool IsHide()
        {
            if (state == State.hide) return true;
            else return false;
        }

        public bool IsShow()
        {
            if (state == State.hide) return false;
            else return true;
        }
    }
}
