using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxField
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //used to draw boxes on screen
        SolidBrush boxBrush = new SolidBrush(Color.White);

        List<Box> boxes = new List<Box>();
        List<Box> boxesRight = new List<Box>();

        int waitTime = 8;

        //TODO - create a list of Boxes

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //TODO - create initial box object and add it to list of Boxes
            Box b = new Box(300, 0);
            boxes.Add(b);

            b = new Box(500, 0);
            boxesRight.Add(b);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.B:
                    bDown = true;
                    break;
                case Keys.N:
                    nDown = true;
                    break;
                case Keys.M:
                    mDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.B:
                    bDown = false;
                    break;
                case Keys.N:
                    nDown = false;
                    break;
                case Keys.M:
                    mDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            waitTime--;
            //TODO - update position of each box
            if (waitTime == 0)
            {
                //add new boxes
                Box b = new Box(300, 0);
                boxes.Add(b);

                b = new Box(500, 0);
                boxesRight.Add(b);

                waitTime = 8;

            }
            //TODO - remove box from list if it is off screen
            for (int i = 0; i < boxes.Count; i++)
            {
                boxes[i].y += 6;
                boxesRight[i].y += 6;
            }

            //remove box from list if it is off screen
            if (boxes[0].y > this.Height)
            {
                boxes.RemoveAt(0);
                boxesRight.RemoveAt(0);
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //TODO - draw each box to the screen
            //draw boxes ti screeb
            //for (int i = 0; < boxes.Count; i++)
            // {
            //  e.Graphics.FillRectagle(boxBrush, boxees[i].x, boxes[i].y, 30, 30);
            // }

            foreach(Box b in boxes)
            {
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, 30, 30);
            }

            foreach(Box b in boxesRight)
            {
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, 30, 30);

            }


        }


    }
}
