using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    // BJHand class inherits from Hand class
    public class BJHand : Hand
    {
        // no instance variables!

        // default constructor, inherited from Hand class
        public BJHand(): base() { }

        public BJHand(Deck d, int numCards) : base(d, 2)
        { 

        }

        public int Score
        {
            get 
            {
                int score = 0;
                foreach (Card c in handCards)
                {
                    if (c.IsFaceCard())
                    {
                        score += 10;
                    }
                    else
                    {
                        score += c.Value;
                    }
                }
                if (HasAce && score <= 11)
                {
                    score += 10;
                }
                return score;
            }
        }

        public bool HasAce
        {
            get
            {
                // refers to this class
                return HasCard(1);
            }
        }

        public bool IsBusted
        {
            get 
            {
                return Score > 21;
            }
        }
    }
}
