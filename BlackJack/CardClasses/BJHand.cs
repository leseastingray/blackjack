using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    /// <summary>
    /// BJHand inherits from Hand class.
    /// </summary>
    public class BJHand : Hand
    {
        // no instance variables!

        /// <summary>
        /// Default constructor
        /// </summary>
        public BJHand(): base() { }
        /// <summary>
        /// Overloaded constructor, inherits overloaded
        /// constructor from base Hand class.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="numCards"></param>
        public BJHand(Deck d, int numCards) : base(d, 2)
        { 

        }
        /// <summary>
        /// Property that returns the score for the
        /// BJHand as an int.
        /// </summary>
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
        /// <summary>
        /// Property returning bool representing whether
        /// the BJHand contains an Ace.
        /// </summary>
        public bool HasAce
        {
            get
            {
                // refers to this class
                return HasCard(1);
            }
        }
        /// <summary>
        /// Property returning bool representing whether
        /// the BJHand has a busted score.
        /// </summary>
        public bool IsBusted
        {
            get 
            {
                return Score > 21;
            }
        }
    }
}
