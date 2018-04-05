/***********************************************************
  * Bradley Massey
  * Daniel Reiter
  * Erika Goad
  * Galina Vitvitskaya
  * 4/10/2018
  * 
  * Program: MazeGame
  * 
  * Class: map
  * 
  * T[,] myMap;
  * int length, height;
  *
  * Program map object supplies a two dimenional array of a 
  * generic type to store levels of a mapp while in play
  ***********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    class Map<T>
    {
        // global variables
        private T[,] myMap;
        private int length, height;

        // constructor to instaniate a map
        public Map(int x, int y)
        {
            myMap = new T[x, y];
            Length = x;
            Height = y;
        }

        //constructor set a map equal to another map
        public Map(Map<T> x)
        {
            myMap = x.myMap;
            Height = x.Height;
            Length = x.Length;

        }

        // properties for map variables
        public T this[int x, int y]
        {
            get
            {
                return myMap[x, y];
            }

            set
            {
                myMap[x, y] = value;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

    }
}
