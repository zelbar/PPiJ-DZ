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
        protected System.Random rnd { get; set; }

        /// <summary>
        /// Places the ship with with random position in the given array.
        /// </summary>
        /// <param name="array">FiledButton array to place the ship in.</param>
        public Ship(FieldButton[,] array, int size)
        {
            if (rnd == null)
            {
                rnd = new System.Random();
            }
            Size = size;

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
                if (rnd.Next(0, 2) == 1)
                {
                    // Horizontal
                    position.A.X = rnd.Next(0, 10 - this.Size + 1);
                    position.B.X = position.A.X + this.Size - 1;

                    position.A.Y = position.B.Y = rnd.Next(0, 10);
                }
                else
                {
                    // Vertical
                    position.A.Y = rnd.Next(0, 10 - this.Size + 1);
                    position.B.Y = position.A.Y + this.Size - 1;

                    position.A.X = position.B.X = rnd.Next(0, 10);
                }

                // Check direction and if there is overlapping
                overlap = false;
                for (i = position.A.X; (overlap == false) && (i <= position.B.X); ++i)
                {
                    for (j = position.A.Y; j <= position.B.Y; ++j)
                    {
                        if (array[i, j].HasShip == true)
                        {
                            overlap = true;
                            break;
                        }
                    }
                }
            } while (overlap == true);

            // Mark the chosen position in the position matrix and field array
            PositionMatrix = new bool[10, 10];
            for (i = position.A.X; i <= position.B.X; ++i)
            {
                for (j = position.B.Y; j <= position.B.Y; ++j)
                {
                    array[i, j].HasShip = PositionMatrix[i, j] = true;
                }
            }
        }
    }
}
