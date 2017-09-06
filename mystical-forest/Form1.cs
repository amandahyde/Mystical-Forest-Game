using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace mystical_forest
{
    public partial class Form1 : Form
    {

        // shroom class
        shroomDoom calcDoom = new shroomDoom();
        public Form1()
        {
            InitializeComponent();
            Image image = this.BackgroundImage;
            this.ClientSize = image.Size;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //methods to load game sounds and objects.
            LoadSound();
            LoadGameObjects();
        }

        #region LoadStuff
        private static void LoadSound()
        {
            SoundPlayer audio = new SoundPlayer(global::mystical_forest.Properties.Resources
                .Magic_Fantasy_Music___Tales_of_the_Night);
            audio.Play();
        }

        private void LoadGameObjects()
        {
            picMushBlue.Visible = false;
            picMushGreen.Visible = false;
            picMushPink.Visible = false;
            picMushPurple.Visible = false;
            picMushCyan.Visible = false;
            picMushRed.Visible = false;
            PicDeadShroom1.Visible = false;
            picDeadShroom2.Visible = false;
            picDeadShroom3.Visible = false;
            picDeadShroom4.Visible = false;
            picDeadShroom5.Visible = false;
            picMushDead6.Visible = false;
            picChoice.Visible = false;

            lblEat.Visible = false;
            lblDiscard.Visible = false;
            lblEatShroom.Visible = false;
            lblPoison.Visible = false;
            lblAttempts.Visible = false;
        }

        #endregion


        //green mushroom click - holds int value that compares with poison value - image hidden once clicked
        public void picMushGreen_Click(object sender, EventArgs e)
        {

            lblEatShroom.Text = calcDoom.EatShroom(calcDoom.ShroomNumber("MushGreen"), lblPoison.Text);
            popup();
            picMushGreen.Visible = false;
        }

        //purple mushroom click
        public void picMushPurple_Click(object sender, EventArgs e)
        {

            lblEatShroom.Text = calcDoom.EatShroom(calcDoom.ShroomNumber("MushPurple"), lblPoison.Text);


            popup();
            picMushPurple.Visible = false;

        }

        //cyan mushroom click
        public void picMushCyan_Click(object sender, EventArgs e)
        {
            lblEatShroom.Text = calcDoom.EatShroom(calcDoom.ShroomNumber("MushCyan"), lblPoison.Text);
            popup();
            picMushCyan.Visible = false;

        }

        //red mushroom click
        public void picMushRed_Click(object sender, EventArgs e)
        {
            lblEatShroom.Text = calcDoom.EatShroom(calcDoom.ShroomNumber("MushRed"), lblPoison.Text);
            popup();
            picMushRed.Visible = false;

        }

        //blue mushroom click
        public void picMushBlue_Click(object sender, EventArgs e)
        {
            lblEatShroom.Text = calcDoom.EatShroom(calcDoom.ShroomNumber("MushBlue"), lblPoison.Text);
            popup();
            picMushBlue.Visible = false;

        }

        //pink mushroom click
        public void picMushPink_Click_1(object sender, EventArgs e)
        {

            lblEatShroom.Text = calcDoom.EatShroom(calcDoom.ShroomNumber("MushPink"), lblPoison.Text);
            popup();
            picMushPink.Visible = false;
        }



        public void button1_Click(object sender, EventArgs e)
        {

        }

   



        

        #region popup






        //Pop up to display options when mushroom is clicked.
        public void popup()
        {
            picChoice.Visible = true;
            btnEAT.Visible = true;
            btnDISCARD.Visible = true;
            picOption.Visible = true;


        }

        #endregion



        //discard shroom click
        public void btnDISCARD_Click(object sender, EventArgs e)
        {

            
            calcDoom.EATSHROOM = Convert.ToInt16(lblEatShroom.Text);
            //set the discard value
            calcDoom.Discard = 0;
            calcDoom.Discard = Convert.ToInt16(lblDiscard.Text);
            //count for discard
            calcDoom.Discard++;
            lblDiscard.Text = calcDoom.Discard.ToString();


            //disable discard button when count equals 2
            if (calcDoom.Discard.Equals(2))
            {
                btnDISCARD.Enabled = false;

            }

            picOption.Visible = false;
            btnEAT.Visible = false;
            btnDISCARD.Visible = false;
            picChoice.Visible = false;



            //if poison mushroom is discarded then player wins
            if (calcDoom.Poison == (calcDoom.EATSHROOM))
            {
                //display "winning screen & sound effects"
                btnReplay.Visible = true;
                picCongrats.Visible = true;
                picOption.Visible = false;
                btnEAT.Visible = false;
                btnDISCARD.Visible = false;

                SoundPlayer audio = new SoundPlayer(global::mystical_forest.Properties.Resources.Crowd_cheer_sound_effect);
                audio.Play();
                //winning method - add count to win label
                winning();


            }

        }

        public void btnEAT_Click(object sender, EventArgs e)
        {

            //run eat shroom method
            calcDoom.Eat = calcDoom.EAT();
            lblEat.Text = calcDoom.Eat.ToString();

            //get shroom number
            calcDoom.EATSHROOM = Convert.ToInt16(lblEatShroom.Text);

            {

                // if poison mushroom is eaten then player losses
                if (calcDoom.Poison.Equals(calcDoom.EATSHROOM))
                {

                    //display "losing screen & sound effects"
                    btnReplay.Visible = true;
                    picShroomDoom.Visible = true;
                    SoundPlayer audio = new SoundPlayer(global::mystical_forest.Properties.Resources.Evil_Laugh_Sound_Effect2);
                    audio.Play();
                    picOption.Visible = false;
                    btnEAT.Visible = false;
                    btnDISCARD.Visible = false;
                    picChoice.Visible = false;
                    losing();

                }

                else
                {
                    //remove pop up display & continue play
                    picOption.Visible = false;
                    btnEAT.Visible = false;
                    btnDISCARD.Visible = false;
                    picChoice.Visible = false;

                }



            }


        }


        // REPLAY GAME - Button
        public void btnReplay_Click(object sender, EventArgs e)

        {

            RePlayGameObjects();
            playGame();

        }

        #region ReplayGameObjects

        private void RePlayGameObjects()
        {

            //reset default screen and sound effects for a new game
            picInfo.Visible = false;
            btnReplay.Visible = false;
            picShroomDoom.Visible = false;
            picCongrats.Visible = false;

            SoundPlayer audio2 = new SoundPlayer(global::mystical_forest.Properties.Resources.Magic_Fantasy_Music___Tales_of_the_Night);
            audio2.Play();


            picMushBlue.Visible = true;
            picMushGreen.Visible = true;
            picMushPink.Visible = true;
            picMushPurple.Visible = true;
            picMushCyan.Visible = true;
            picMushRed.Visible = true;     
            PicDeadShroom1.Visible = true;
            picDeadShroom2.Visible = true;
            picDeadShroom3.Visible = true;
            picDeadShroom4.Visible = true;
            picDeadShroom5.Visible = true;
            picMushDead6.Visible = true;
            btnDISCARD.Enabled = true;


        }
        #endregion


        //PLAY GAME - Button   drtdryudrdryu
        private void btnPlayNow_Click(object sender, EventArgs e)
        {
        
            picInfo.Visible = false;

            playGame();
  

            playGameObjects();


        }

        public void playGame()
        {
            //generate a random number for the poison shroom
            calcDoom.Poison = calcDoom.RandomNumber();
            lblPoison.Text = calcDoom.Poison.ToString();
            
            //reset eat and discard to zero
            calcDoom.Discard = 0;
            calcDoom.Eat = 0;


            lblDiscard.Text = calcDoom.Discard.ToString();
            lblEat.Text = calcDoom.Eat.ToString();
        }


        #region playGameObjects

        private void playGameObjects()
        {

            //display all mushrooms
            picMushBlue.Visible = true;
            picMushGreen.Visible = true;
            picMushPink.Visible = true;
            picMushPurple.Visible = true;
            picMushCyan.Visible = true;
            picMushRed.Visible = true;
            PicDeadShroom1.Visible = true;
            picDeadShroom2.Visible = true;
            picDeadShroom3.Visible = true;
            picDeadShroom4.Visible = true;
            picDeadShroom5.Visible = true;
            picMushDead6.Visible = true;
            btnPlayNow.Visible = false;
        }

        #endregion



        public void winning()
        {
            //calculate wins and display label
            calcDoom.wins = Convert.ToInt16(lblWin.Text);
            calcDoom.wins++;
            lblWin.Text = Convert.ToString(calcDoom.wins);



        }

        public void losing()
        {
                //calculate loses and display label
               calcDoom.losses = Convert.ToInt16(lblLosses.Text);
               calcDoom.losses++;
               lblLosses.Text = Convert.ToString(calcDoom.losses);
       }




        #region topMenu

        //Top Menu Bar
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game hand crafted by Amanda the Amazing Merino");
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There are six mushrooms in the Mystical Forest to be picked. One of the six mushrooms is poisonous. Click a mushroom to choose whether to eat or discard it. You have 2 chances to discard the poisonous mushroom. If you guess correctly you win the game.");
        }

    #endregion
    }
    }
