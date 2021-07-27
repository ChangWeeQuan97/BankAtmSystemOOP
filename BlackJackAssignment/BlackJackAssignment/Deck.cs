using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackAssignment
{
    class Deck
    {
        public List<Card> deck;

        public Deck()
        {
            deck = new List<Card>();
        }

        public void CreateDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    deck.Add(new Card((Suit)i, (Face)j));
                }
            }
        }
        public void Shuffle()
        {
            Random r = new Random();
            int n = deck.Count;

            while (n >= 1)
            {
                n--;
                int k = r.Next(n + 1);//0-51
                Card tempCard = deck[k];
                deck[k] = deck[n];
                deck[n] = tempCard;
            }
        }
        public Card DealCard()
        {
            Card tempCard = deck[0];
            deck.Remove(tempCard);
            return tempCard;
        }
        //public int GetDeckCount()
        //{
        //    return deck.Count;
        //}
    }
}
