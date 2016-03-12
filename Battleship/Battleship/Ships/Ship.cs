using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Ships
{

    class Ship
    {
        /// <summary>
        /// Represents the field containing true where the ship is and false where it is not.
        /// </summary>
        public bool[,] PositionMatrix { get; set; }
        protected int Size { get; set; }
        protected System.Random Random { get; set; }

        /// <summary>
        /// Places the ship with with random position in the given array.
        /// </summary>
        /// <param name="array">FiledButton array to place the ship in.</param>
        public Ship(FieldButton[,] array)
        {
            var position = new StartEnd()
            {
                A = new Point() { X = 0, Y = 0 },
                B = new Point() { X = 0, Y = 0 }
            };

            bool overlap = false;
            int i = 0, j = 0;
            // Loop until random position has no overlapping on the field
            do
            {
                // Random generate orientation and starting position
                // within the field
                if (Random.Next(0, 2) == 1)
                {
                    // Horizontal
                    position.A.X = Random.Next(0, 11 - this.Size);
                    position.A.Y = Random.Next(0, 11);
                }
                else
                {
                    // Vertical
                    position.A.X = Random.Next(0, 11);
                    position.A.Y = Random.Next(0, 11 - this.Size);
                }

                // Check if there is overlapping
                overlap = false;
                for (i = position.A.X; (overlap == false) && (i < position.B.X); ++i)
                {
                    for (j = position.A.Y; j < position.B.Y; ++j)
                    {
                        if (array[i, j].HasShip == true)
                        {
                            overlap = true;
                            break;
                        }
                    }
                }
            } while (overlap == true);

            // Mark the chosen position in the position matrix
            PositionMatrix = new bool[10, 10];
            for (i = position.A.X; i < position.B.X; ++i)
            {
                for (j = position.B.X; j < position.B.Y; ++j)
                {
                    PositionMatrix[i, j] = true;
                    array[i, j].HasShip = true;
                }
            }
        }
    }
}
