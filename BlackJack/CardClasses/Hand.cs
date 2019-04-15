using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
        protected List<Card> handCards = new List<Card>();
        // default constructor
        public Hand() { }
        //overloaded constructor
        public Hand(Deck d, int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                Card newcard = d.Deal();
                handCards.Add(newcard);
            }
        }

        public int NumCards
        {
            get
            {
                return handCards.Count;
            }
        }

        public void AddCard(Card c)
        {
            handCards.Add(c);
        }
        // indexer
        public Card this[int i]
        {
            get
            {
                return handCards[i];
            }
        }
        // indexof methods
        public int IndexOf(Card c)
        {
            foreach (Card cardInHand in handCards)
            {
                if (cardInHand == c)
                {
                    return handCards.IndexOf(c);
                }
            }
            return -1;
        }

        public int IndexOf(int value)
        {
            foreach (Card c in handCards)
            {
                if (c.Value == value)
                {
                    return handCards.IndexOf(c);
                }
            }
            return -1;
        }

        public int IndexOf(int value, int suit)
        {
            foreach (Card c in handCards)
            {
                if (c.Value == value)
                {
                    if (c.Suit == suit)
                    {
                        return handCards.IndexOf(c);
                    }
                }
            }
            return -1;
        }

        //important
        public bool HasCard(Card c)
        {
            if (handCards.IndexOf(c) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasCard(int value)
        {
            if (IndexOf(value) != -1)
            {
                return true;
            }
            return false;
        }

        public bool HasCard(int value, int suit)
        {
            if (IndexOf(value, suit) != -1)
            {
                return true;
            }
            return false;
        }

        public Card Discard(int index)
        {
            if (handCards.Count != 0)
            {
                foreach (Card c in handCards)
                {
                    if (IndexOf(c) == index)
                    {
                        handCards.Remove(c);
                        return c;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            string output = "";
            return output;
        }
    }
}
