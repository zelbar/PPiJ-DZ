using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class AI
    {
        private bool [,] computerMap;
        private bool [,] playerMap;

        public AI ()
        {
            computerMap = new bool [10, 10];
            playerMap = new bool [10, 10];
            GenerateObjects();
        }

        public void GenerateObjects ()
        {
            //var x = System.Random;
        }
    }
}
