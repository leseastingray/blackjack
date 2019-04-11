using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CardClasses;

namespace CardUnitTests
{
    [TestFixture]
    public class HandTests
    {
        [Test]
        public void TestConstructor()
        {
            // declared and initialize Hand w/default constructor
            Hand hand1 = new Hand();
            // declared and initialize Card deck
            Deck deck1 = new Deck();
            Deck deck2 = new Deck();
            // declared and initialize Hands w/overloaded constructor
            Hand hand2 = new Hand(deck1, 5);
            Hand hand3 = new Hand(deck2, 5);
            // card at index 0 should be the same in hand2 and hand3
            Assert.AreEqual(hand2.IndexOf(0), hand3.IndexOf(0));
            // card at index 4 should be the same in hand2 and hand3
            Assert.AreEqual(hand2.IndexOf(4), hand3.IndexOf(4));
        }

        [Test]
        public void TestNumCards()
        {

        }
    }
}
