using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {

        public Hand() { }
        public Hand(Deck d, int numCards)
        {
        }

        public int NumCards
        {
            get
            {
                return 0;
            }
        }

        public void AddCard(Card c)
        {
        }

        public Card GetCard(int index)
        {
            return null;
        }

        public int IndexOf(Card c)
        {
            return -1;
        }

        public int IndexOf(int value)
        {
            return -1;
        }

        public int IndexOf(int value, int suit)
        {
            return -1;
        }

        public bool HasCard(Card c)
        {
            return false;
        }

        public bool HasCard(int value)
        {
            return false;
        }

        public bool HasCard(int value, int suit)
        {
            return false;
        }

        public Card Discard(int index)
        {
            return null;
        }

        public override string ToString()
        {
            string output = "";
            return output;
        }
    }
}
