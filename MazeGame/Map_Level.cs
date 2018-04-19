/***********************************************************
  * Bradley Massey
  * Daniel Reiter
  * Erika Goad
  * Galina Vitvitskaya
  * 4/10/2018
  * 
  * Program: MazeGame
  * 
  * Class: Map_Level
  * 
  * Map<coord> map;
  * coord[] view;
  * location currentLocation;
  *
  * Program loads map from a text file to a map object stores a 
  * current loction object, update visiblity to the map, retrieves 
  * and return front and side views as coordinate objects
  ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.ComponentModel;

namespace MazeGame
{

    class Map_Level
    {
        //class level variables
        private StreamReader reader;
        private Map<coord> map;
        private coord[] view;
        private location currentLocation;

        // constructor
        public Map_Level(int level)
        {
            map = loadMap(level);
            //setVisible();
            view = new coord[3];
        }

        // function to load a level from a file
        private Map<coord> loadMap(int l)
        {
            String tempString = "level" + l + ".txt";
            try
            {
                reader = new StreamReader(tempString); //sets a stream reader to the selected file
                Console.WriteLine("opened:" + tempString);
                tempString = reader.ReadLine();
                Console.WriteLine("tempString line one:" + tempString);
                String[] tempArr = tempString.Split(',');
                String[] tempCord = tempArr[2].Split('/');
                currentLocation = new location(int.Parse(tempCord[0]) - 1, int.Parse(tempCord[1]) - 1, int.Parse(tempCord[2]));
                int x = int.Parse(tempArr[0]);
                int y = int.Parse(tempArr[1]);
                Map<coord> lMap = new Map<coord>(x, y);
                string[] tArr = new string[x];

                Console.WriteLine("Made lMap Height: " + lMap.Height + " Length: " + lMap.Length);


                for (int i = 0; i < y; i++)
                {
                    tempString = reader.ReadLine();
                    tArr = tempString.Split(',');
                    for (int j = 0; j < x; j++)
                    {

                        //tempCord = tArr[j - 1].Split('/');
                        tempCord = tArr[j].Split('/');
                        if (int.Parse(tempCord[0]) == 1)
                        {
                            lMap[j, i] = new coord(true, int.Parse(tempCord[1]), int.Parse(tempCord[2]), int.Parse(tempCord[3]));
                        }
                        else
                        {
                            lMap[j, i] = new coord(false, int.Parse(tempCord[1]), int.Parse(tempCord[2]), int.Parse(tempCord[3]));
                        }
                    }
                    Console.WriteLine();
                }
                reader.Close();
                return lMap;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR ERROR ERROR ERROR ERROR");
                Console.WriteLine(e);
                return null;
            }
        }

        // function returns the coords in front and to the sides of a location 
        public void setView()
        {
            //setVisible();
            map[Loc.X, Loc.Y].Vis = true;
            int i = 1;
            if (Loc.Z % 2 > 0)
            {
                i = -1;
            }
            try
            {
                Console.WriteLine("Loc.Z: " + Loc.Z + " i: " + i);
                if (Loc.Z < 3)
                {
                    view[0] = map[Loc.X + i, Loc.Y];
                    view[1] = map[Loc.X, Loc.Y + i];
                    view[2] = map[Loc.X - i, Loc.Y];
                    //map[Loc.X + i, Loc.Y].Vis = true;
                    //map[Loc.X, Loc.Y + i].Vis = true;
                    //map[Loc.X - i, Loc.Y].Vis = true; ;
                    Console.WriteLine("Loc.X: " + Loc.X + " Loc.Y: " + Loc.Y);
                }
                else
                {
                    view[0] = map[Loc.X, Loc.Y + i];
                    view[1] = map[Loc.X + i, Loc.Y];
                    view[2] = map[Loc.X, Loc.Y - i];
                    //map[Loc.X, Loc.Y + i].Vis = true;
                    //map[Loc.X + i, Loc.Y].Vis = true;
                    //map[Loc.X, Loc.Y - i].Vis = true;

                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        // function to move location by one map unit
        // 1 = left, 2 = foward, 3 = right
        public void move(int direction)
        {
            Console.WriteLine("before move Loc.X: " + Loc.X + " Loc.Y: " + Loc.Y);

            int i = 1;
            if (Loc.Z % 2 > 0)
            {
                i = -1;
            }
            if (Loc.Z < 3)
            {
                Console.Write("i: " + i);
                Console.Write("Loc.Y: " + Loc.Y + " Loc.Y + i: " + Loc.Y + i);
                Loc.Y = Loc.Y + i;
            }
            else
            {
                Loc.X = Loc.X + i;
            }
            setView();
            Console.WriteLine("After move Loc.X: " + Loc.X + " Loc.Y: " + Loc.Y);
        }

        //function rotate currentloction z access
        // 1 = north, 2 = south, 3 = east, 4 = west
        //input: dir = 2 rotate left dir = 3 rotate right
        public void rotate(int dir)
        {

            switch (Loc.Z)
            {
                case 1:
                    if (dir == 2)
                        Loc.Z = 3;
                    else
                        Loc.Z = 4;
                    break;
                case 2:
                    if (dir == 3)
                        Loc.Z = 4;
                    else
                        Loc.Z = 3;
                    break;
                case 3:
                    if (dir == 2)
                        Loc.Z = 2;
                    else
                        Loc.Z = 1;
                    break;
                case 4:
                    if (dir == 3)
                        Loc.Z = 2;
                    else
                        Loc.Z = 1;
                    break;
                    //setView();

            }
        }


        // fuction set all square surounding currentloction to visble
        //public void setVisible()
        //{
        //    int x = currentLocation.X;
        //    int y = currentLocation.Y;
        //    map[x, y].Vis = true;
        //    map[x + 1, y].Vis = true;
        //    map[x - 1, y].Vis = true;
        //    map[x, y + 1].Vis = true;
        //    map[x, y - 1].Vis = true;
        //}

        // set properties for variables
        public location Loc
        {
            get
            {
                return currentLocation;
            }
            set
            {
                currentLocation = value;
            }

        }

        public coord rightView
        {
            get
            {
                return view[0];
            }
        }

        public coord frontView
        {
            get
            {
                return view[1];
            }
        }
        public coord leftView
        {
            get
            {
                return view[2];
            }
        }

        public int[,] Tiles
        {
            get
            {
                int[,] t = new int[map.Length, map.Height];
                for (int i = 0; i < map.Length; i++)
                {
                    for (int j = 0; j < map.Height; j++)
                    {
                        t[j, i] = map[i, j].Tile;
                    }
                }

                return t;
            }
        }

        public bool[,] Vis
        {
            get
            {
                bool[,] v = new bool[map.Length, map.Height];
                for (int i = 0; i < map.Length; i++)
                {
                    for (int j = 0; j < map.Height; j++)
                    {
                        v[j, i] = map[i, j].Vis;
                    }
                }

                return v;
            }
        }

        public int[,] Story
        {
            get
            {
                int[,] s = new int[map.Length, map.Height];
                for (int i = 0; i < map.Length; i++)
                {
                    for (int j = 0; j < map.Height; j++)
                    {
                        s[j, i] = map[i, j].Story;
                    }
                }

                return s;
            }
        }

    }
}