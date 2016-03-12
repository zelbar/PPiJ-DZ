using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class PlayerButton : FieldButton
    {
        public bool Clicked
        {
            get
            {
                return _clicked;
            }
            set
            {
                _clicked = value;
                this.Text = "X";
                this.BackColor = System.Drawing.Color.Blue;
                if (this._hasShip == true)
                {
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
