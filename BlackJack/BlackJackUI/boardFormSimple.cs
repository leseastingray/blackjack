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
        private Deck cDeck;

        private Hand userHand;
        private List<PictureBox> userHandPicBoxes;
        private Hand computerHand;
        private List<PictureBox> compHandPicBoxes;

        private Card currentUserCard;

        private int turn = -1;
        private const int USER = 1;
        private const int COMPUTER = 0;
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
        #endregion

        private void frmBoard_Load(object sender, EventArgs e)
        {
            hitButton.Enabled = true;
            standButton.Enabled = true;
            playerWinLabel.Visible = false;
            dealerWinLabel.Visible = false;
            playAgainButton.Enabled = false;
        }

        private void hitButton_Click(object sender, EventArgs e)
        {

        }

        private void standButton_Click(object sender, EventArgs e)
        {
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
        }
    }
}
