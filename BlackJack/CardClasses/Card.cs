using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CardClasses
{
    /// <summary>
    /// Card class, with IComparable interface
    /// </summary>
    public class Card : IComparable<Card>
    {
        private static string[] values = { "", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };
        private static string[] suits = { "", "Clubs", "Diamonds", "Hearts", "Spades" };
        private static Random generator = new Random();

        private int value;
        private int suit;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Card()
        {
            value = generator.Next(1, 14);
            suit = generator.Next(1, 5); 
        }
        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="v"></param>
        /// <param name="s"></param>
        public Card(int v, int s)
        {
            value = v;
            suit = s;
        }

        /// <summary>
        /// Value property
        /// </summary>
        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        /// <summary>
        /// Suit property
        /// </summary>
        public int Suit
        {
            get
            {
                return this.suit;
            }
            set
            {
                this.suit = value;
            }
        }

        /// <summary>
        /// Returns a bool representing if the card is red
        /// </summary>
        /// <returns>bool</returns>
        public bool IsRed()
        {
            return !IsBlack();
        }
        /// <summary>
        /// Returns a bool representing if the card is black
        /// </summary>
        /// <returns>bool</returns>
        public bool IsBlack()
        {
            if (IsSpade() || IsClub())
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns a bool representing if the card is a face card
        /// </summary>
        /// <returns></returns>
        public bool IsFaceCard()
        {
            switch (value)
            {
                case 11: case 12: case 13:
                    return true;
                default:
                    return false;
            }
        }
        /// <summary>
        /// Returns a bool representing if the card is an ace
        /// </summary>
        /// <returns>bool</returns>
        public bool IsAce()
        {
            if (value == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns a bool representing if the card is a club
        /// </summary>
        /// <returns>bool</returns>
        public bool IsClub()
        {
            if (suit == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns a bool representing if the card is a diamond
        /// </summary>
        /// <returns>bool</returns>
        public bool IsDiamond()
        {
            if (suit == 2)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns a bool representing if the card is a heart
        /// </summary>
        /// <returns>bool</returns>
        public bool IsHeart()
        {
            if (suit == 3)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns a bool representing if the card is a spade
        /// </summary>
        /// <returns>bool</returns>
        public bool IsSpade()
        {
            if (suit == 4)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns a bool representing if the card matches the given card parameter
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool HasMatchingValue(Card other)
        {
            if (other.Value == value)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Gets a card picture file name
        /// </summary>
        public string FileName
        {
            get
            {
                return "card" + values[value].Substring(0, 1) + 
                       suits[suit].Substring(0, 1) + ".jpg";
            }
        }
        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return values[value] + " of " + suits[suit];
        }

        /// <summary>
        /// Equals method override, returns a bool representing
        /// if the card is equal to the given card
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Card c = (Card)obj;
            if (c.value == this.value && c.suit == this.suit)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returns an int representing the hash code of the card
        /// </summary>
        /// <returns>int</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        /// <summary>
        /// CompareTo Interface Method
        /// </summary>
        /// <param name="otherC"></param>
        /// <returns>int</returns>
        public int CompareTo(Card otherC)
        {
            return this.Value.CompareTo(otherC.Value);
        }
    }
}
