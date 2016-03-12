using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class FieldButton : System.Windows.Forms.Button
    {
        protected bool _hasShip = false;
        protected bool _clicked;
        
        public bool HasShip
        {
            get
            {
                return _hasShip;
            }
            set
            {
                _hasShip = value;
            }
        }

        public FieldButton(Action<object, EventArgs> button_Click)
        {
            this.Text = "";
            this.Size = new System.Drawing.Size(25, 25);
            this.Click += new System.EventHandler(button_Click);
        }
    }
}
