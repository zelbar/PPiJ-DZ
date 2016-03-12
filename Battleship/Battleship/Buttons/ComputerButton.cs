using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class ComputerButton : FieldButton
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
                this.Enabled = false;
                this.Text = "X";
                if (this._hasShip == true)
                {
                    this.ForeColor = System.Drawing.Color.White;
                    this.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    this.Text = "";
                    this.BackColor = System.Drawing.Color.White;
                }
            }
        }

        public ComputerButton(Action<object, EventArgs> button_Click) : base(button_Click)
        {

        }
    }
}
