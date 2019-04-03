using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class BJHand
    {
        public BJHand() { }

        public BJHand(Deck d, int numCards) 
        { 
        }

        public int Score
        {
            get 
            {
                return 0;
            }
        }

        public bool HasAce
        {
            get 
            {
                return false;
            }
        }

        public bool IsBusted
        {
            get 
            {
                return false;
            }
        }
    }
}
