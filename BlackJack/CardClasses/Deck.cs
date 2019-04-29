using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    /// <summary>
    /// Deck of cards Class, with IEnumerable interface
    /// </summary>
    public class Deck : IEnumerable<Card>
    {
        private List<Card> cards = new List<Card>();

        /// <summary>
        /// default constructor
        /// </summary>
        public Deck()
        {
            for (int value = 1; value <= 13; value++)
                for (int suit = 1; suit <= 4; suit++)
                    cards.Add(new Card(value, suit));
        }
        /// <summary>
        /// NumCards count property, returns int
        /// </summary>
        public int NumCards
        {
            get 
            {
                return cards.Count;
            }
        }
        /// <summary>
        /// IsEmpty property, returns bool
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return (cards.Count == 0);
            }
        }
        /// <summary>
        /// Method to deal a card, removes card at index 0
        /// of the deck and returns said card
        /// </summary>
        /// <returns></returns>
        public Card Deal()
        {
            if (!IsEmpty)
            {
                Card c = cards[0];
                cards.RemoveAt(0);
                return c;
            }
            return
                null;
        }
        /// <summary>
        /// Method to shuffle the deck
        /// </summary>
        public void Shuffle()
        {
            Random gen = new Random();
            for (int i = 0; i < NumCards; i++)
            {
                int rnd = gen.Next(i, NumCards);
                Card c = cards[rnd];
                cards[rnd] = cards[i];
                cards[i] = c;
            }
        }
        /// <summary>
        /// ToString method override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";
            foreach (Card c in cards)
                output += (c.ToString() + "\n");
            return output;
        }

        /// <summary>
        /// IEnumerable interface method allowing for foreach loop
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Card> GetEnumerator()
        {
            foreach (Card c in cards)
            {
                yield return c;
            }
        }

        IEnumerator<Card> IEnumerable<Card>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
