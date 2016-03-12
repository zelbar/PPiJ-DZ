using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Button[,] computerButtons = new FieldButton[10, 10];
        private System.Windows.Forms.Button[,] playerButtons = new FieldButton[10, 10];
        System.Random rnd = new System.Random();

        /// <summary>
        /// Generates the board of two 10x10 button fields.
        /// </summary>
        private void GenerateBoard()
        {
            GenerateButtons(ref playerButtons, player: true);
            GenerateButtons(ref computerButtons, player: false);
        }

        /// <summary>
        /// Generates a 10x10 button field.
        /// </summary>
        /// <param name="buttonArray">FieldButton 10x10 array.</param>
        /// <param name="player">Determines whether to generates the computer or player button field</param>
        private void GenerateButtons(ref System.Windows.Forms.Button[,] buttonArray, bool player)
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    FieldButton btn = null;
                    if (player)
                    {
                        btn = new PlayerButton(button_Click);
                        (btn as PlayerButton).HasShip = (rnd.Next(0, 5) == 1) ? true : false;
                    }
                    else
                    {
                        btn = new ComputerButton(button_Click);
                        (btn as ComputerButton).HasShip = (rnd.Next(0, 5) == 1) ? true : false;
                    }

                    btn.Location = new System.Drawing.Point(25 * j, 25 * i);
                    btn.Name = i.ToString() + "," + j.ToString();
                    buttonArray[i, j] = btn;

                    if (player)
                    {
                        this.splitContainer1.Panel2.Controls.Add(btn);
                    }
                    else
                    {
                        this.splitContainer1.Panel1.Controls.Add(btn);
                    }
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            GenerateBoard();
        }

        private void button_Click(object sender, EventArgs e)
        {
            var s = (sender as ComputerButton);
            s.Clicked = true;
            
            computer_Play();
        }

        private void computer_Play()
        {
            // Choose a non-clicked player field button randomly
            PlayerButton btn = null;
            do
            {
                btn = (PlayerButton)playerButtons[rnd.Next(0, 10), rnd.Next(0, 10)];
            } while (btn.Clicked == true);
            (btn as PlayerButton).Clicked = true;
        }
    }
}
