﻿using System;

namespace Battleship
{
    class PlayerButton : FieldButton
    {
        public static int PlayerFields { get; set; }
        public static int Moves { get; set; }
        public bool Clicked
        {
            get
            {
                return _clicked;
            }
            set
            {
                _clicked = value;
                ++Moves;
                this.Text = "X";
                this.BackColor = System.Drawing.Color.Blue;
                if (this._hasShip == true)
                {
                    --PlayerFields;
                    System.Threading.Thread.Sleep(250);
                    this.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    this.Text = "";
                    this.BackColor = System.Drawing.Color.White;
                }
            }
        }
        public bool HasShip
        {
            get
            {
                return _hasShip;
            }
            set
            {
                ++PlayerFields;
                this._hasShip = value;
                if (value == true)
                {
                    this.BackColor = System.Drawing.Color.DarkGray;
                }
            }
        }
        public PlayerButton(Action<object, EventArgs> button_Click) : base(button_Click)
        {
            this.Enabled = false;
        }
    }
}
