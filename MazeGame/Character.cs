/***********************************************************
  * Bradley Massey
  * Daniel Reiter
  * Erika Goad
  * Galina Vitvitskaya
  * 4/10/2018
  * 
  * Program: MazeGame
  * 
  * Class: Character
  * 
  * Variables:
  *     String name;
  *     private Items status;
  *     private location loc;
  *     
  * program keeps track of a character's name, items, and location
  * includes methods to check if character is alive and to move the 
  * charcter's location
  ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    class Character
    {
        /* For the Character class we need to create the variables for the items, keys, usable items,notes, POV
         * we also need to make the methods to get/set
         * follow diagram 4A
         */
        // global variables
        private String name;
        private Items status;
        private location loc;

        // constructor
        public Character(String _name, int life, int keyNum, location _loc)
        {
            name = _name;
            status(life, keyNum);
            Loc = _loc;
        }

        // function to check if character is alive
        public bool isAlive()
        {
            return (Life > 0);
        }

        // properties
        public int Life
        {
            set
            {
                status.Life = value;
            }
            get
            {
               return statue.life;
            }
        }

        public int[] Keys
        {
            set
            {
                status.Keys = value;
            }
            get
            {
               return statue.Keys;
            }
        }

        // property to add a key as an int value
        public int newKey
        {
            set
            {
                status.addKey(value);
            }
        }
        
        // function to move location by one map unit
        // 1 = north, 2 = south, 3 = east, 4 = west
        public void move(int direction)
        {
            int i = 1;
            if(direction%2 > 0)
            {
                i = -1;
            }
            if(direction < 3)
            {
                loc.Y = loc.Y + i;
            }
            else
            {
                loc.X = loc.X + i;
            }
        }
    }
}
