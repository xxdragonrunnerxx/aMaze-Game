/***********************************************************
  * Bradley Massey
  * Daniel Reiter
  * Erika Goad
  * Galina Vitvitskaya
  * 4/1/2018
  * 
  * Program: MazeGame
  * 
  * Class: Map_Level
  * 
  * Variables:
  * location[](int)
  * currentLocation[](int)
  * story[](int)
  * map[][](int)
  * 
  * Methods:
  * int[] getStory(location) Bradley
  * 
  ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    /*We need to create the map loader
     * 
     */
    class Map_Level
    {
        int[] location = new int[3];//(x,y) {1=N, 2=S, 3=E, 4=W}
        int[] currentLocation = new int[3];
        int[] story = new int[3];
        int[][] map;

        private int[] getStory(int[] loc) //Bradley
        {
            byte OOBx = 1;//Out of Bounds Flag: 0=low, 1=none, 2=high
            byte OOBy = 1;//Out of Bounds Flag: 0=low, 1=none, 2=high
            int x = loc[0], y = loc[1], z = loc[2];//split location (x,y) z={1=N, 2=S, 3=E, 4=W}
            sbyte sign = 1;

            if (z == 1 || z == 3)//if North or East swap sign
                sign = Convert.ToSByte(-sign);
            {//check for "Out of Bounds" issues with map boundries.
                if (x <= 0 || x >= map.GetLength(0))
                {
                    if (x <= 0)
                        OOBx = 0;
                    else
                        OOBx = 2;
                }
                else
                    OOBx = 1;
                if (y <= 0 || y >= map.GetLength(1))
                {
                    if (y <= 0)
                        OOBy = 0;
                    else
                        OOBy = 2;
                }
                else
                    OOBy = 1;
            }

            switch (z)
            {
                case 1://North
                case 2://South
                    if (OOBx == 1 || (OOBx > 1 && sign == -1) || (OOBx < 1 && sign == 1))
                        story[0] = map[x + sign][y];
                    else
                        story[0] = 0;
                    if (OOBy == 1 || (OOBy < 1 && sign == 1) || (OOBy > 1 && sign == -1))
                        story[1] = map[x][y + sign];
                    else
                        story[1] = 0;
                    if (OOBx == 1 || (OOBx < 1 && sign == -1) || (OOBx > 1 && sign == 1))
                        story[2] = map[x - sign][y];
                    else
                        story[2] = 0;
                    break;
                case 3://East
                case 4://West
                    if (OOBy == 1 || (OOBy < 1 && sign == 1) || (OOBy > 1 && sign == -1))
                        story[0] = map[x][y + sign];
                    else
                        story[0] = 0;
                    if (OOBx == 1 || (OOBx < 1 && sign == -1) || (OOBx > 1 && sign == 1))
                        story[1] = map[x - sign][y];
                    else
                        story[1] = 0;
                    if (OOBy == 1 || (OOBy < 1 && sign == -1) || (OOBy > 1 && sign == 1))
                        story[2] = map[x][y - sign];
                    else
                        story[2] = 0;
                    break;
                default:
                    story = null;
                    break;
            }//end switch(z) 
            return story;//return left, front, right of player or null if no location is found
        }//end getStory(loc[])
    }
}
