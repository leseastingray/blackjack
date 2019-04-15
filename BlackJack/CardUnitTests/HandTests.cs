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
            // declare and initialize Card deck
            Deck deck1 = new Deck();
            Deck deck2 = new Deck();
            // declare and initialize Hands w/overloaded constructor
            Hand hand1 = new Hand(deck1, 5);
            Hand hand2 = new Hand(deck2, 5);
            Hand hand3 = new Hand(deck2, 5);
            // number of cards in hand1 should be equal to 5
            Assert.AreEqual(hand1.NumCards, 5);
            // card at index 0 should be the same in hand2 and hand3
            Assert.AreEqual(hand1[0], hand2[0]);
            // card at index 4 should be the same in hand2 and hand3
            Assert.AreEqual(hand1[4], hand2[4]);
            // card at index 0 of hand2 should not be the same as card at index 0 of hand3
            Assert.AreNotEqual(hand2[0], hand3[0]);
        }

        [Test]
        public void TestNumCards()
        {
            // declare and initialize Card deck
            Deck deck1 = new Deck();
            // declare and initialize Hands w/overloaded constructor
            Hand hand1 = new Hand(deck1, 5);
            Hand hand2 = new Hand(deck1, 2);
            // number of cards in hand1 should be 5
            Assert.AreEqual(5, hand1.NumCards);
            // number of cards in hand2 should be 2
            Assert.AreEqual(2, hand2.NumCards);
        }

        [Test]
        public void TestAddCard()
        {
            Deck deck1 = new Deck();
            Hand hand1 = new Hand(deck1, 5);
            Card card1 = new Card();

            hand1.AddCard(card1);
            Assert.AreEqual(6, hand1.NumCards);
        }
        [Test]
        public void TestIndexer()
        {
            Deck deck1 = new Deck();
            Deck deck2 = new Deck();
            Hand hand1 = new Hand(deck1, 5);
            Hand hand2 = new Hand(deck2, 3);
            Hand hand3 = new Hand(deck2, 3);

            // card at index 0 should be Ace of Clubs
            Assert.AreEqual("Ace of Clubs", hand1[0].ToString());
            // card at index 0 of hand1 should be equal to card at index 0 of hand2
            Assert.AreEqual(hand1[0], hand2[0]);
        }

        [Test]
        public void TestIndexOf()
        {
            Deck deck1 = new Deck();
            Deck deck2 = new Deck();
            Hand hand1 = new Hand(deck1, 5);
            Hand hand2 = new Hand(deck2, 3);

            // create Seven of Spades card
            Card card3 = new Card(7, 4);
            // add card4 to hand2
            hand2.AddCard(card3);

            // Index of card 3 in hand2 should be equal to 3
            Assert.AreEqual(hand2.IndexOf(card3), 3);
            // Index of value 7 in hand2 should be equal to 3
            Assert.AreEqual(hand2.IndexOf(7), 3);
            // Index of Ace of Clubs in hand1 should be equal to 0
            Assert.AreEqual(hand1.IndexOf(1, 1), 0);
        }
        [Test]
        public void TestHasCard()
        {
            Deck deck1 = new Deck();
            Hand hand1 = new Hand(deck1, 5);

            // create Seven of Spades card
            Card card3 = new Card(7, 4);
            // add card4 to hand2
            hand1.AddCard(card3);

            // hand1 should contain an Ace
            Assert.True(hand1.HasCard(1));
            // hand1 should contain a Two of Clubs
            Assert.True(hand1.HasCard(2, 1));
            // hand1 should not contain an Eight of Hearts
            Assert.False(hand1.HasCard(8, 3));
            // hand1 should contain card3
            Assert.True(hand1.HasCard(card3));
        }

        [Test]
        public void TestDiscard()
        {
            Deck deck1 = new Deck();
            Hand hand1 = new Hand(deck1, 5);

            // discard card at index 3
            Card discard = hand1.Discard(3);
            // discarded card at index 3 should be Ace of Spades
            Assert.AreEqual(discard.ToString(), "Ace of Spades");
            // number of cards in hand1 should now be 4
            Assert.AreEqual(hand1.NumCards, 4);
        }

        [Test]
        public void TestBJHandConstructor()
        {
            Deck deck1 = new Deck();
            Deck deck2 = new Deck();

            // shuffle deck2
            deck2.Shuffle();

            BJHand bjhand1 = new BJHand(deck1, 2);
            BJHand bjhand2 = new BJHand(deck2, 2);

            // The number of cards in bjhand1 should be equal to 2
            Assert.AreEqual(bjhand1.NumCards, 2);
            // The card at index 0 of bjhand1 should not be equal to the card
            // at index 0 of bjhand2
            Assert.AreNotEqual(bjhand1[0], bjhand2[0]);

            // discard index 1 card from bjhand1
            Card discard = bjhand1.Discard(1);
            // The number of cards in bjhand1 should be equal to 1
            Assert.AreEqual(bjhand1.NumCards, 1);
            // discard card should be equal to "Ace of Diamonds"
            Assert.AreEqual(discard.ToString(), "Ace of Diamonds");
        }
        [Test]
        public void TestBJHandHasAce()
        {
            Deck deck1 = new Deck();
            BJHand bjhand1 = new BJHand(deck1, 2);

            // create Seven of Spades card
            Card card1 = new Card(7, 4);
            // create Five of Diamonds card
            Card card2 = new Card(5, 2);

            // HasAce should return true for bjhand1
            Assert.True(bjhand1.HasAce);
            // discard card in bjhand1 at index 1
            bjhand1.Discard(1);
            // discard card in bjhand1 at index 0
            bjhand1.Discard(0);
            // add card1 and card2 to bjhand1
            bjhand1.AddCard(card1);
            bjhand1.AddCard(card2);
            // HasAce should now return false for bjhand1
            Assert.False(bjhand1.HasAce);
            
        }
        [Test]
        public void TestBJHandScore()
        {
            Deck deck1 = new Deck();
            BJHand bjhand1 = new BJHand(deck1, 2);

            // create Seven of Spades card
            Card card1 = new Card(7, 4);

            // score of bjhand1 should be equal to 12
            Assert.AreEqual(bjhand1.Score, 11);

            // add card1 to bjhand1
            bjhand1.AddCard(card1);
            // score of bjhand1 should be equal to 19
            Assert.AreEqual(bjhand1.Score, 19);
        }
        [Test]
        public void TestBJHandIsBusted()
        {
            Deck deck1 = new Deck();
            BJHand bjhand1 = new BJHand(deck1, 2);

            // create Seven of Spades card
            Card card1 = new Card(7, 4);
            // create Five of Diamonds card
            Card card2 = new Card(5, 2);
            // create Ten of Diamonds card
            Card card3 = new Card(9, 2);

            // add card1 to bjhand1
            bjhand1.AddCard(card1);
            // IsBusted should return false for bjhand1.
            Assert.False(bjhand1.IsBusted);

            // discard card in bjhand1 at index 1
            bjhand1.Discard(1);
            // discard card in bjhand1 at index 0
            bjhand1.Discard(0);
            // add card2 and card3 to bjhand1
            bjhand1.AddCard(card2);
            bjhand1.AddCard(card3);
            // IsBusted should now return true for bjhand1.
            Assert.True(bjhand1.IsBusted);

        }
    }
}
