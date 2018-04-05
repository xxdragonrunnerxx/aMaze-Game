/***********************************************************
  * Bradley Massey
  * Daniel Reiter
  * Erika Goad
  * Galina Vitvitskaya
  * 4/10/2018
  * 
  * Program: MazeGame
  * 
  * Class: Items
  * 
  * int life, index;
  * int[] keys;
  *
  * Program Items is an object that keeps track of the players
  * life and keys and can be passed between challenges and the 
  * charecter
  ***********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    class Items
    {
        // global variables  
        private int life, index;
        private int[] keys;

        // constructor 
        public Items(int l, int k)
        {
            Life = l;
            keys = new int[k];
            index = 0;
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = -1;
            }
        }

        // properties for life
        public int Life
        {
            get
            {
                return life;
            }
            set
            {
                life = value;
            }
        }

        // properity for keys
        public int[] Keys
        {
            get
            {
                return keys;
            }
            set
            {
                keys = value;
            }
        }

        // function to remove a key
        public bool removeKey(int k)
        {
            for (int i = 0; i < index; i++)
            {
                if (keys[i] == k)
                {
                    if (i < index)
                    {
                        keys[i] = keys[index];
                        keys[index--] = -1;
                    }
                    else
                    {
                        keys[index--] = -1;
                    }
                    return true;
                }
            }
            return false;
        }

        // function to add a key
        public void addKey(int k)
        {
            if (index <= keys.Length - 1)
            {
                keys[index++] = k;

            }
            else
            {
                int[] tempArr = new int[(keys.Length * 2)];
                for (int i = 0; i < tempArr.Length; i++)
                {
                    if (i < keys.Length - 1)
                    {
                        tempArr[i] = keys[i];
                    }
                    else
                    {
                        tempArr[i] = -1;
                    }
                }
                tempArr[index++] = k;
                keys = tempArr;
            }
        }

    }
}
