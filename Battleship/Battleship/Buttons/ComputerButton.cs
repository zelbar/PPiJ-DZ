using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class ComputerButton : FieldButton
    {
        public static int ComputerFields { get; set; }
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
                //System.Threading.Thread.Sleep(250);
                this.BackColor = System.Drawing.Color.Blue;

                this.Text = "X";
                if (this._hasShip == true)
                {
                    --ComputerFields;
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
        public bool HasShip
        {
            get
            {
                return _hasShip;
            }
            set
            {
                ++ComputerFields;
                _hasShip = true;
            }
        }

        public ComputerButton(Action<object, EventArgs> button_Click) : base(button_Click)
        {
        }
    }
}
