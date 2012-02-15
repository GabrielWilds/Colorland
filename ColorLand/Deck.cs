using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorLand
{
    public class Deck
    {
        protected Stack<Card> Cards
        {
            get;
            set;
        }

        public Stack<Card> ShuffleDeck(List<Card> cards)
        {
            Stack<Card> deck = new Stack<Card>();
            int listIndex = 0;
            while (cards.Count > 0)
            {
                listIndex = Randomizer.GetRandomNumber(cards.Count - 1);
                deck.Push(cards[listIndex]);
                cards.RemoveAt(listIndex);
            }
            return deck;
        }

        public void GenerateCards()
        {
            List<Card> cards = new List<Card>();
            GameColors[] colors = (GameColors[])Enum.GetValues(typeof(GameColors));
            for(int i = 0; i < 10; i++)
                foreach(GameColors color in colors)
                {
                    cards.Add(new Card(color));
                }
            Cards = ShuffleDeck(cards);
        }

        public Deck()
        {
            GenerateCards();
        }

        public Card DrawCard()
        {
            if (Cards.Count == 0)
                GenerateCards();
            return Cards.Pop();
        }
    }
}
