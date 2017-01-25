using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace FINAL_PROJECT
{
    public partial class Form1 : Form
    {
        // Goaly Values
        int P1GoalyX = 80;
        int P1GoalyY = 275;
        int P2GoalyX = 730;
        int P2GoalyY = 300;
        Boolean p1goalyMovingUp = true;
        Boolean p1goalyMovingLeft = false;
        Boolean p2goalyMovingUp = false;
        Boolean p2goalyMovingLeft = true;

        // Ball values
        int ballx = 408;
        int bally = 303;
        int ballspeed = 5;
        int ballwidth = 4;
        int ballheight = 4;
        Boolean movingLeft = true;
        Boolean movingUp = true;

        // Odd Player Values
        int P1x = 265;
        int P1y = 280;
        int P2x = 540;
        int P2y = 280;
        int P1score = 0;
        int P2score = 0;
        int playerSpeed = 3;
        int playerWidth = 10;
        int playerHeight = 40;

        // Feild Walls and Crease Lines
        int leftFieldWall = 65;
        int rightFieldWall = 755;
        int topFieldWall = 110;
        int bottomFieldWall = 500;
        int P1bottomCreaseLine = 382;
        int P1topCreaseLine = 228;
        int P1frontCreaseLine = 127;
        int P2bottomCreaseLine = 382;
        int P2topcreaseLine = 228;
        int P2frontCreaseLine = 693;

        Pen P2pen = new Pen(Color.Blue, 6);
        Pen P1pen = new Pen(Color.Red, 6);
        Pen ballPen = new Pen(Color.Black, 4);
        Pen goalyPen = new Pen(Color.Gray, 6);
        Pen whitePen = new Pen(Color.White, 6);
        Pen grayPen = new Pen(Color.Gray, 6);
        Pen blackPen = new Pen(Color.Black, 6);
        Font drawFont = new Font("Arial", 52, FontStyle.Bold);
        Font finalFont = new Font("Arial", 72);
        SolidBrush p1whiteBrush = new SolidBrush(Color.White);
        SolidBrush p2whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush grayBrush = new SolidBrush(Color.Gray);
        SolidBrush blackBrush = new SolidBrush(Color.Black);

        Boolean P1leftArrowDown, P1downArrowDown, P1rightArrowDown, P1upArrowDown, P2leftArrowDown, P2downArrowDown, P2rightArrowDown, P2upArrowDown;

        SoundPlayer bouncePlayer;
        SoundPlayer winPlayer;
        SoundPlayer scorePlayer;

        public Form1()
        {
            InitializeComponent();
            bouncePlayer = new SoundPlayer(Properties.Resources.Ball_Bounce_Popup_Pixels_172648817);
            winPlayer = new SoundPlayer(Properties.Resources.Short_triumphal_fanfare_John_Stracke_815794903);
            scorePlayer = new SoundPlayer(Properties.Resources.Air_Horn_SoundBible_com_964603082);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)

        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    P1leftArrowDown = true;
                    break;
                case Keys.Down:
                    P1downArrowDown = true;
                    break;
                case Keys.Right:
                    P1rightArrowDown = true;
                    break;
                case Keys.Up:
                    P1upArrowDown = true;
                    break;
                case Keys.A:
                    P2leftArrowDown = true;
                    break;
                case Keys.S:
                    P2downArrowDown = true;
                    break;
                case Keys.D:
                    P2rightArrowDown = true;
                    break;
                case Keys.W:
                    P2upArrowDown = true;
                    break;
                default:
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    P1leftArrowDown = false;
                    break;
                case Keys.Down:
                    P1downArrowDown = false;
                    break;
                case Keys.Right:
                    P1rightArrowDown = false;
                    break;
                case Keys.Up:
                    P1upArrowDown = false;
                    break;
                case Keys.A:
                    P2leftArrowDown = false;
                    break;
                case Keys.S:
                    P2downArrowDown = false;
                    break;
                case Keys.D:
                    P2rightArrowDown = false;
                    break;
                case Keys.W:
                    P2upArrowDown = false;
                    break;
                default:
                    break;
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            #region P1 Movement
            if (P1leftArrowDown == true)
            {
                if (P1x > leftFieldWall)
                {
                    P1x = P1x - playerSpeed;
                }
                else
                {
                    P1x = leftFieldWall;
                }
            }

            if (P1rightArrowDown == true)
            {
                if (P1x < rightFieldWall - playerWidth)
                {
                    P1x = P1x + playerSpeed;
                }
                else
                {
                    P1x = rightFieldWall - playerWidth;
                }
            }

            if (P1upArrowDown == true)
            {
                if (P1y > topFieldWall)
                {
                    P1y = P1y - playerSpeed;
                }
                else
                {
                    P1y = topFieldWall;
                }
            }

            if (P1downArrowDown == true)
            {
                if (P1y < bottomFieldWall - playerHeight)
                {
                    P1y = P1y + playerSpeed;
                }
                else
                {
                    P1y = bottomFieldWall - playerHeight;
                }
            }

            if (P1score == 2 && P2score == 2)
            {
                playerSpeed = 4;
            }
            #endregion

            #region P2 Movement

            if (P2leftArrowDown == true)
            {
                if (P2x > leftFieldWall)
                {
                    P2x = P2x - playerSpeed;
                }
                else
                {
                    P2x = leftFieldWall;
                }
            }

            if (P2rightArrowDown == true)
            {
                if (P2x < rightFieldWall - playerWidth)
                {
                    P2x = P2x + playerSpeed;
                }
                else
                {
                    P2x = rightFieldWall - playerWidth;
                }
            }

            if (P2upArrowDown == true)
            {
                if (P2y > topFieldWall)
                {
                    P2y = P2y - playerSpeed;
                }
                else
                {
                    P2y = topFieldWall;
                }
            }

            if (P2downArrowDown == true)
            {
                if (P2y < bottomFieldWall - playerHeight)
                {
                    P2y = P2y + playerSpeed;
                }
                else
                {
                    P2y = bottomFieldWall - playerHeight;
                }
            }

            #endregion

            #region Ball

            if (movingLeft)
            {
                ballx = ballx - ballspeed;
            }
            else
            {
                ballx = ballx + ballspeed;
            }

            if (movingUp)
            {
                bally = bally - ballspeed;
            }
            else
            {
                bally = bally + ballspeed;
            }

            if (bally < topFieldWall)
            {
                movingUp = false;
                bouncePlayer.Play();
            }

            if (bally > bottomFieldWall)
            {
                movingUp = true;
                bouncePlayer.Play();
            }

            if (ballx < leftFieldWall)
            {
                movingLeft = false;
                bouncePlayer.Play();
            }

            if (ballx > rightFieldWall)
            {
                movingLeft = true;
                bouncePlayer.Play();
            }

            #endregion

            #region P1 Goaly

            if (p1goalyMovingLeft)
            {
                P1GoalyX = P1GoalyX - playerSpeed;
            }
            else
            {
                P1GoalyX = P1GoalyX + playerSpeed;
            }

            if (p1goalyMovingUp)
            {
                P1GoalyY = P1GoalyY - playerSpeed;
            }
            else
            {
                P1GoalyY = P1GoalyY + playerSpeed;
            }

            if (P1GoalyX < leftFieldWall)
            {
                p1goalyMovingLeft = false;
            }

            if (P1GoalyX > P1frontCreaseLine - playerWidth)
            {
                p1goalyMovingLeft = true;
            }

            if (P1GoalyY < P1topCreaseLine)
            {
                p1goalyMovingUp = false;
            }

            if (P1GoalyY > P1bottomCreaseLine - playerHeight)
            {
                p1goalyMovingUp = true;
            }


            #endregion

            #region P2 Goaly

            if (p2goalyMovingLeft)
            {
                P2GoalyX = P2GoalyX - playerSpeed;
            }
            else
            {
                P2GoalyX = P2GoalyX + playerSpeed;
            }

            if (p2goalyMovingUp)
            {
                P2GoalyY = P2GoalyY - playerSpeed;
            }
            else
            {
                P2GoalyY = P2GoalyY + playerSpeed;
            }

            if (P2GoalyX < P2frontCreaseLine)
            {
                p2goalyMovingLeft = false;
            }

            if (P2GoalyX > rightFieldWall - playerWidth)
            {
                p2goalyMovingLeft = true;
            }

            if (P2GoalyY < P2topcreaseLine)
            {
                p2goalyMovingUp = false;
            }

            if (P2GoalyY > P2bottomCreaseLine - playerHeight)
            {
                p2goalyMovingUp = true;
            }

            #endregion

            #region Ball Collision

            Rectangle ballRec = new Rectangle(ballx, bally, ballwidth, ballheight);
            Rectangle p1Rec = new Rectangle(P1x, P1y, playerWidth, playerHeight);
            Rectangle p2Rec = new Rectangle(P2x, P2y, playerWidth, playerHeight);
            Rectangle g1Rec = new Rectangle(P1GoalyX, P1GoalyY, playerWidth, playerHeight);
            Rectangle g2Rec = new Rectangle(P2GoalyX, P2GoalyY, playerWidth, playerHeight);
            Rectangle goal1 = new Rectangle(leftFieldWall, 275, 3, 60);
            Rectangle goal2 = new Rectangle(rightFieldWall, 275, 3, 60);

            if (ballRec.IntersectsWith(p1Rec))
            {
                if (movingLeft == true)
                {
                    movingLeft = false;
                }
                else
                {
                    movingLeft = true;
                }
                bouncePlayer.Play();
            }

            if (ballRec.IntersectsWith(p2Rec))
            {
                if (movingLeft == false)
                {
                    movingLeft = true;
                }
                else
                {
                    movingLeft = false;
                }
                bouncePlayer.Play();
            }

            if (ballRec.IntersectsWith(g1Rec))
            {
                if (movingLeft == true)
                {
                    movingLeft = false;
                }
                else
                {
                    movingLeft = true;
                }
                bouncePlayer.Play();
            }

            if (ballRec.IntersectsWith(g2Rec))
            {
                if (movingLeft == false)
                {
                    movingLeft = true;
                }
                else
                {
                    movingLeft = false;
                }
                bouncePlayer.Play();
            }

            #endregion

            #region Score

            if (ballRec.IntersectsWith(goal1))
            {
                P2score = P2score + 1;
                ballx = 410;
                bally = 305;
                movingLeft = false;
                scorePlayer.Play();
            }

            if (ballRec.IntersectsWith(goal2))
            {
                P1score = P1score + 1;
                ballx = 410;
                bally = 305;
                movingLeft = true;
                scorePlayer.Play();
            }



            if (P1score == 3 || P2score == 3)
            {
                winPlayer.Play();
                timer.Stop();
            }

            #endregion

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            #region White Lines
            // Outside Walls
            e.Graphics.DrawLine(whitePen, 57, 105, 763, 105);
            e.Graphics.DrawLine(whitePen, 60, 105, 60, 505);
            e.Graphics.DrawLine(whitePen, 57, 505, 763, 505);
            e.Graphics.DrawLine(whitePen, 760, 105, 760, 505);

            // Center Line
            e.Graphics.DrawLine(whitePen, 410, 105, 410, 505);
            e.Graphics.DrawEllipse(whitePen, 350, 245, 120, 120);

            // P1 Large Line
            e.Graphics.DrawLine(whitePen, 60, 140, 205, 140);
            e.Graphics.DrawLine(whitePen, 60, 470, 205, 470);
            e.Graphics.DrawLine(whitePen, 205, 137, 205, 473);

            // P1 Net
            e.Graphics.DrawLine(whitePen, 60, 275, 32, 275);
            e.Graphics.DrawLine(whitePen, 32, 335, 60, 335);
            e.Graphics.DrawLine(whitePen, 35, 275, 35, 335);

            // P1 Goaly Crease
            e.Graphics.DrawLine(whitePen, 60, 225, 133, 225);
            e.Graphics.DrawLine(whitePen, 60, 385, 133, 385);
            e.Graphics.DrawLine(whitePen, 130, 227, 130, 385);

            // P2 Large Line
            e.Graphics.DrawLine(whitePen, 760, 140, 615, 140);
            e.Graphics.DrawLine(whitePen, 760, 470, 615, 470);
            e.Graphics.DrawLine(whitePen, 615, 137, 615, 473);

            // P2 Net
            e.Graphics.DrawLine(whitePen, 760, 275, 785, 275);
            e.Graphics.DrawLine(whitePen, 760, 335, 785, 335);
            e.Graphics.DrawLine(whitePen, 785, 272, 785, 338);

            // P2 Goal Crease
            e.Graphics.DrawLine(whitePen, 760, 225, 690, 225);
            e.Graphics.DrawLine(whitePen, 760, 385, 690, 385);
            e.Graphics.DrawLine(whitePen, 690, 222, 690, 388);

            // Score Board
            e.Graphics.FillRectangle(grayBrush, 330, 15, 160, 80);
            e.Graphics.DrawLine(blackPen, 410, 15, 410, 95);
            e.Graphics.DrawLine(blackPen, 327, 15, 493, 15);
            e.Graphics.DrawLine(blackPen, 327, 95, 493, 95);
            e.Graphics.DrawLine(blackPen, 330, 15, 330, 95);
            e.Graphics.DrawLine(blackPen, 490, 15, 490, 95);
            e.Graphics.DrawString("" + P1score, drawFont, p1whiteBrush, 340, 15);
            e.Graphics.DrawString("" + P2score, drawFont, p2whiteBrush, 420, 15);

            #endregion

            #region Items The Move

            //P1
            e.Graphics.DrawRectangle(P1pen, P1x, P1y, playerWidth, playerHeight);
            e.Graphics.FillRectangle(redBrush, P1x, P1y, playerWidth, playerHeight);

            //P2
            e.Graphics.DrawRectangle(P2pen, P2x, P2y, playerWidth, playerHeight);
            e.Graphics.FillRectangle(blueBrush, P2x, P2y, playerWidth, playerHeight);

            //P1 Goaly
            e.Graphics.DrawRectangle(goalyPen, P1GoalyX, P1GoalyY, playerWidth, playerHeight);
            e.Graphics.FillRectangle(grayBrush, P1GoalyX, P1GoalyY, playerWidth, playerHeight);

            //P2 Goaly
            e.Graphics.DrawRectangle(goalyPen, P2GoalyX, P2GoalyY, playerWidth, playerHeight);
            e.Graphics.FillRectangle(grayBrush, P2GoalyX, P2GoalyY, playerWidth, playerHeight);

            //Ball
            e.Graphics.DrawEllipse(ballPen, ballx, bally, ballwidth, ballheight);

            if (P1score == 5)
            {
                e.Graphics.DrawString("Player 1 Wins!!!", drawFont, blackBrush, 190, 250);
            }

            if (P2score == 5)
            {
                e.Graphics.DrawString("Player 2 Wins!!!", drawFont, blackBrush, 190, 250);
            }
            #endregion
        }
    }
}
