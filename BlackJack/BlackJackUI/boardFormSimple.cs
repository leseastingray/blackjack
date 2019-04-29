using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardClasses;

namespace BlackJack
{
    public partial class boardFormSimple : Form
    {
        #region Instance Variables
        private Deck cDeck = new Deck();

        private BJHand userHand = new BJHand();
        private BJHand compHand = new BJHand();

        private int startUPicBoxNumber = 18;
        private int startCPicBoxNumber = 3;

        #endregion

        public boardFormSimple()
        {
            InitializeComponent();
        }

        #region Methods
        public void Show(PictureBox p, Card c)
        {
            p.Image = Image.FromFile(System.Environment.CurrentDirectory
                + "\\Cards\\" + c.FileName);
        }

        public void ShowBack(PictureBox p, Card c)
        {
            p.Image = Image.FromFile(System.Environment.CurrentDirectory
                + "\\Cards\\black_back.jpg");
        }

        public void DealCards()
        {
            // shuffle deck
            cDeck.Shuffle();

            // deal 1st card to user, show in pic box
            Card userCard1 = cDeck.Deal();
            userHand.AddCard(userCard1);
            card16.Visible = true;
            Show(card16, userCard1);

            // deal 2nd card to user, show in pic box
            Card userCard2 = cDeck.Deal();
            userHand.AddCard(userCard2);
            card17.Visible = true;
            Show(card17, userCard2);

            // deal 1st card to computer, show in pic box
            Card compCard1 = cDeck.Deal();
            compHand.AddCard(compCard1);
            card1.Visible = true;
            ShowBack(card1, compCard1);

            // deal 2nd card to computer, show in pic box
            Card compCard2 = cDeck.Deal();
            compHand.AddCard(compCard2);
            card2.Visible = true;
            ShowBack(card2, compCard2);
        }
        
        public void Hit()
        {
            /* if picture box number >= 21
             *    show message box
             *    return to break out of method
             */
            if (startUPicBoxNumber >= 21)
            {
                MessageBox.Show("Hit limit reached.");
                return;
            }

            // deal 1 card and add it to userHand
            Card hitCard = cDeck.Deal();
            userHand.AddCard(hitCard);
            // show above card in appropriate pic box
            PictureBox hit = (PictureBox)this.Controls["card" + startUPicBoxNumber];
            hit.Visible = true;
            Show(hit, hitCard);

            // if user busts
            if (userHand.IsBusted == true)
            {
                // computer shows cards
                for (int i = 1; i < startCPicBoxNumber; i++)
                {
                    PictureBox iPic = (PictureBox)this.Controls["card" + i];
                    Card iCard = compHand[i - 1];
                    Show(iPic, iCard);
                }
                // computer wins!
                computerWinLabel.Visible = true;

                // disable all UI except play again
                hitButton.Enabled = false;
                standButton.Enabled = false;
                playAgainButton.Enabled = true;
            }
            // increment user pic box number
            startUPicBoxNumber++;
        }
        public void MakeComputerMove()
        {
            // deal a card from deck
            Card compCard = cDeck.Deal();
            // add card to computer hand
            compHand.AddCard(compCard);
            // set picture box compHit to computer pic box number
            PictureBox compHit = (PictureBox)this.Controls["card" + startCPicBoxNumber];
            // set compHit to visible
            compHit.Visible = true;
            // show back of card in compHit pic box
            Show(compHit, compCard);
        }

        public void Stand()
        {
            // while computer has pic box space and has score below 18
            while (startCPicBoxNumber < 6 && compHand.Score < 18)
            {
                MakeComputerMove();
            }
            // call check score method
            CheckScore();
        }
        public void CheckScore()
        {
            // if computer busts
            if (compHand.IsBusted == true)
            {
                // user wins!
                userWinLabel.Visible = true;
                // computer shows cards
                for (int i = 1; i < startCPicBoxNumber; i++)
                {
                    PictureBox iPic = (PictureBox)this.Controls["card" + i];
                    Card iCard = compHand[i - 1];
                    Show(iPic, iCard);
                }
                // disable all UI except play again
                hitButton.Enabled = false;
                standButton.Enabled = false;
                playAgainButton.Enabled = true;
            }
            // else if userHand score is greater than compHand score
            else if (userHand.Score > compHand.Score)
            {
                // user wins!
                userWinLabel.Visible = true;

                // computer shows cards
                for (int i = 1; i < startCPicBoxNumber; i++)
                {
                    PictureBox iPic = (PictureBox)this.Controls["card" + i];
                    Card iCard = compHand[i - 1];
                    Show(iPic, iCard);
                }
                // disable all UI except play again
                hitButton.Enabled = false;
                standButton.Enabled = false;
                playAgainButton.Enabled = true;
            }
            // else if compHand score is greater than userHand score
            else if (compHand.Score > userHand.Score)
            {
                // computer wins!
                computerWinLabel.Visible = true;
                // computer shows cards
                for (int i = 1; i < startCPicBoxNumber; i++)
                {
                    PictureBox iPic = (PictureBox)this.Controls["card" + i];
                    Card iCard = compHand[i - 1];
                    Show(iPic, iCard);
                }
                // disable all UI except play again
                hitButton.Enabled = false;
                standButton.Enabled = false;
                playAgainButton.Enabled = true;
            }
            // else if scores are equal
            else if (compHand.Score == userHand.Score)
            {
                // it's a tie!
                tieLabel.Visible = true;

                // computer shows cards
                for (int i = 1; i < startCPicBoxNumber; i++)
                {
                    PictureBox iPic = (PictureBox)this.Controls["card" + i];
                    Card iCard = compHand[i - 1];
                    Show(iPic, iCard);
                }
                // disable all UI except play again
                hitButton.Enabled = false;
                standButton.Enabled = false;
                playAgainButton.Enabled = true;
            }
        }
        // sets up new game
        public void NewGame()
        {
            // clear userHand of cards
            while (userHand.NumCards > 0)
            {
                userHand.Discard(0);
            }
            // clear compHand of cards
            while (compHand.NumCards > 0)
            {
                compHand.Discard(0);
            }

            // hide user hand picture boxes
            for (int i = 16; i < 21; i++)
            {
                this.Controls["card" + i].Visible = false;
            }

            // hide computer hand picture boxes
            for (int i = 1; i < 6; i++)
            {
                this.Controls["card" + i].Visible = false;
            }

            // counters set to default
            startUPicBoxNumber = 18;
            startCPicBoxNumber = 3;

            // UI set to default
            hitButton.Enabled = true;
            standButton.Enabled = true;
            computerWinLabel.Visible = false;
            userWinLabel.Visible = false;
            tieLabel.Visible = false;
            playAgainButton.Enabled = false;

            // deal cards
            DealCards();
        }
        #endregion

        private void frmBoard_Load(object sender, EventArgs e)
        {
            NewGame();
            // wiring for event handler
            cDeck.AlmostEmpty += new Deck.EmptyHandler(HandleEmpty);
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            Hit();
        }

        private void standButton_Click(object sender, EventArgs e)
        {
            Stand();
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        // event handler corresponding to HandleEmpty delegate
        public void HandleEmpty(Deck d)
        {
            if (d == cDeck)
            {
                cDeck = new Deck();
                cDeck.Shuffle();
            }
        }
    }
}
