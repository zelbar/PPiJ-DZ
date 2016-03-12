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
        private ComputerButton[,] computerButtons = new ComputerButton[10, 10];
        private PlayerButton[,] playerButtons = new PlayerButton[10, 10];
        private List<Ships.Ship> PlayerShips { get; set; }
        private List<Ships.Ship> ComputerShips { get; set; }
        System.Random rnd = new System.Random();

        /// <summary>
        /// Generates the board of two 10x10 button fields.
        /// </summary>
        private void GenerateBoard()
        {
            GenerateButtons(playerButtons, player: true);
            GenerateButtons(computerButtons, player: false);
        }

        /// <summary>
        /// Generates a 10x10 button field.
        /// </summary>
        /// <param name="buttonArray">FieldButton 10x10 array.</param>
        /// <param name="player">Determines whether to generates the computer or player button field</param>
        private void GenerateButtons(FieldButton[,] buttonArray, bool player)
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    FieldButton btn = null;
                    if (player)
                    {
                        btn = new PlayerButton(button_Click);
                    }
                    else
                    {
                        btn = new ComputerButton(button_Click);
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

        /// <summary>
        /// Generates ships on both computer and player fields.
        /// </summary>
        void GenerateShips()
        {
            PlaceShips(false, computerButtons);
            PlaceShips(true, playerButtons);
        }

        /// <summary>
        /// Places the ships within the given array.
        /// </summary>
        /// <param name="buttonsArray">Computer or player FieldButton array.</param>
        void PlaceShips(bool player, FieldButton[,] buttonsArray)
        {
            var list = new List<Ships.Ship>();
            
            list.Add(new Ships.Ship(buttonsArray, 4));

            for (int i = 0; i < 2; ++i)
            {
                list.Add(new Ships.Ship(buttonsArray, 3));
            }

            for (int i = 0; i < 3; ++i)
            {
                list.Add(new Ships.Ship(buttonsArray, 2));
            }

            for (int i = 0; i < 4; ++i)
            {
                list.Add(new Ships.Ship(buttonsArray, 1));
            }

            foreach (Ships.Ship ship in list)
            {
                for (int i = 0; i < 10; ++i)
                {
                    for (int j = 0; j < 10; ++j)
                    {
                        if (ship.PositionMatrix[i, j] == true)
                        {
                            if (player == true)
                            {
                                playerButtons[i, j].HasShip = true;
                            }
                            else if (player == false)
                            {
                                computerButtons[i, j].HasShip = true;
                            }
                        }
                    }
                }
            }

        }

        public MainForm()
        {
            InitializeComponent();
            GenerateBoard();
            GenerateShips();
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

            check_Loser();
        }

        private void check_Loser()
        {
            if (PlayerButton.PlayerFields == 0)
            {
                MessageBox.Show("You, sir, are a loser!");
                if (MessageBox.Show(null, "Do you want to lose again?", "Play again?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Restart();
                }
                Application.Exit();
            }
            if (ComputerButton.ComputerFields == 0)
            {
                MessageBox.Show("The computer lost, is sad, and doesn\'t want to play with you anymore.");
                Application.Exit();
            }
        }
    }
}
