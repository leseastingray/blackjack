using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    /// <summary>
    /// Hand class representing a hand of cards.
    /// </summary>
    public class Hand
    {
        /// <summary>
        /// Field: List of cards declared and instantiated.
        /// </summary>
        protected List<Card> handCards = new List<Card>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Hand() { }
        /// <summary>
        /// Overloaded constructor, creates hand given
        /// Deck and number of Cards parameters.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="numCards"></param>
        public Hand(Deck d, int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                Card newcard = d.Deal();
                handCards.Add(newcard);
            }
        }
        /// <summary>
        /// Returns int representing the number of Cards in the Hand.
        /// </summary>
        public int NumCards
        {
            get
            {
                return handCards.Count;
            }
        }
        /// <summary>
        /// Adds a Card to the end of the Hand.
        /// </summary>
        /// <param name="c"></param>
        public void AddCard(Card c)
        {
            handCards.Add(c);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Card this[int i]
        {
            get
            {
                return handCards[i];
            }
        }
        /// <summary>
        /// IndexOf method taking a Card as parameter,
        /// returning an int representing the index of that card.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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
        /// <summary>
        /// IndexOf method taking int value as parameter,
        /// returning int representing the index of the
        /// first Card that matches.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        /// <summary>
        /// IndexOf method taking int value and int suit
        /// as parameters, returning int representing the
        /// index of the Card that matches.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="suit"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method returning a bool representing
        /// whether the deck contains a given Card.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Method returning a bool representing whether
        /// the deck contains a Card with given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool HasCard(int value)
        {
            if (IndexOf(value) != -1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method returning a bool representing whether
        /// the deck contains a Card with given value and suit.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="suit"></param>
        /// <returns></returns>
        public bool HasCard(int value, int suit)
        {
            if (IndexOf(value, suit) != -1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method that removes a Card at the given index
        /// from the Hand, and returns the Card.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";
            return output;
        }
    }
}
