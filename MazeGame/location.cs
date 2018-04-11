/***********************************************************
  * Bradley Massey
  * Daniel Reiter
  * Erika Goad
  * Galina Vitvitskaya
  * 4/10/2018
  * 
  * Program: MazeGame
  * 
  * Class: location
  * 
  * int [] loc
  *
  * Program location provides a three element array object that
  * can be passed  between objects and be refered to by X,Y,Z
  * coordinates
  ***********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    class location
    {
        // global variables
        private int[] loc;

        // constructor
        public location()
        {
            loc = new int[3];
        }

        // constructor
        public location(int x, int y, int z)
        {
            loc = new int[3];
            X = x;
            Y = y;
            Z = z;
        }


        // properities to give location X,Y,Z variables
        public int X
        {
            get
            {
                return loc[0];
            }
            set
            {
                loc[0] = value;
            }
        }

        public int Y
        {
            get
            {
                return loc[1];
            }
            set
            {
                loc[1] = value;
            }
        }

        public int Z
        {
            get
            {
                return loc[2];
            }
            set
            {
                loc[2] = value;
            }
        }

        // properites for the locations
        public int[] Loc
        {
            get
            {
                return loc;
            }
            set
            {
                loc = value;
            }
        }

    }
}
