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
        private coord leftView, rightView, frontView;
        private location currentLocation;

        // constructor
        public Map_Level(int level)
        {
            map = loadMap(level);
            //setVisible();
            leftView = new coord();
            rightView = new coord();
            frontView = new coord();
            setView();
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
                            lMap[i, j] = new coord(true, int.Parse(tempCord[1]), int.Parse(tempCord[2]), int.Parse(tempCord[3]));
                        }
                        else
                        {
                            lMap[i, j] = new coord(false, int.Parse(tempCord[1]), int.Parse(tempCord[2]), int.Parse(tempCord[3]));
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
            Console.WriteLine();
            for (int l = 0; l < 5; l++)
            {
                for (int k = 0; k < 5; k++)
                {
                    Console.Write(map[l, k].Vis + " ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
            //setVisible();
            map[Loc.X, Loc.Y].Vis = true;
            bool[,] tVis = Vis;
            int[,] tTile = Tiles;
            int[,] tStory = Story;
            int[,] tImage = Image;
            Console.WriteLine("enter set view.");
            Console.WriteLine("Loc.X: " + Loc.X + " Loc.Y: " + Loc.Y);
            Console.WriteLine("Image[Loc.X - 1, Loc.Y]: " + Image[Loc.X - 1, Loc.Y] + " Image[Loc.X, Loc.Y + 1]: " + Image[Loc.X, Loc.Y + 1] + " Image[Loc.X + 1, Loc.Y]: " + Image[Loc.X + 1, Loc.Y]);
            Console.WriteLine("Image[Loc.X - 1, Loc.Y]: " + Image[Loc.X - 1, Loc.Y] + " Image[Loc.X, Loc.Y - 1]: " + Image[Loc.X, Loc.Y - 1] + " Image[Loc.X + 1, Loc.Y]: " + Image[Loc.X + 1, Loc.Y]);

            Console.WriteLine("Image[Loc.X, Loc.Y - 1]: " + Image[Loc.X, Loc.Y - 1] + " Image[Loc.X + 1, Loc.Y]: " + Image[Loc.X + 1, Loc.Y] + " Image[Loc.X + 1, Loc.Y]: " + Image[Loc.X + 1, Loc.Y]);
            Console.WriteLine("Image[Loc.X, Loc.Y - 1]: " + Image[Loc.X, Loc.Y - 1] + " Image[Loc.X - 1, Loc.Y]: " + Image[Loc.X - 1, Loc.Y] + " Image[Loc.X + 1, Loc.Y]: " + Image[Loc.X + 1, Loc.Y]);
            int i = 1;
            if (Loc.Z % 2 > 0)
            {
                i = -1;
            }
            try
            {

                Console.WriteLine("Loc.X: " + Loc.X + " Loc.Y: " + Loc.Y);
                Console.WriteLine("Loc.Z: " + Loc.Z + " i: " + i);
                if (Loc.Z > 2)
                {


                    map[Loc.X + i, Loc.Y].Vis = true;
                    map[Loc.X, Loc.Y + i].Vis = true;
                    map[Loc.X - i, Loc.Y].Vis = true;
                    RightView = new coord(tVis[Loc.X, Loc.Y + i], tImage[Loc.X, Loc.Y + i], tStory[Loc.X, Loc.Y + i], tTile[Loc.X, Loc.Y + i]);
                    FrontView = new coord(tVis[Loc.X + 1, Loc.Y], tImage[Loc.X + 1, Loc.Y], tStory[Loc.X + 1, Loc.Y], tTile[Loc.X + 1, Loc.Y]);
                    LeftView = new coord(tVis[Loc.X, Loc.Y - i], tImage[Loc.X, Loc.Y - i], tStory[Loc.X, Loc.Y - i], tTile[Loc.X, Loc.Y - i]);



                    Console.WriteLine("right view: x: " + (Loc.X + i) + " y: " + (Loc.Y));
                    Console.WriteLine("Front view: x: " + (Loc.X) + " y: " + (Loc.Y + i));
                    Console.WriteLine("left view: x: " + (Loc.X - i) + " y: " + (Loc.Y));
                    Console.WriteLine("left view map[Loc.X - i, Loc.Y].Image: " + map[Loc.X - i, Loc.Y].Image);
                    Console.WriteLine("LeftView.image: " + LeftView.Image);



                    //Console.WriteLine("right view map[Loc.X + i, Loc.Y].Image: " + map[Loc.X + i, Loc.Y].Image);
                    //Console.WriteLine("RightView.image: " + RightView.Image);
                    //Console.WriteLine("LeftView.image: " + LeftView.Image);
                    //RightView.Image = map[Loc.X + 1, Loc.Y].Image;
                    //Console.WriteLine("RightView.image: " + RightView.Image);
                    //Console.WriteLine("LeftView.image: " + LeftView.Image);
                    //FrontView.Image = map[Loc.X, Loc.Y + i].Image;
                    //LeftView.Image = map[Loc.X - i, Loc.Y].Image;
                    //Console.WriteLine("RightView.image: " + RightView.Image);
                    //Console.WriteLine("LeftView.image: " + LeftView.Image);
                    //LeftView.Story = map[Loc.X - i, Loc.Y].Story;
                    //RightView.Story = map[Loc.X + 1, Loc.Y].Story;
                    //FrontView.Story = map[Loc.X, Loc.Y + i].Story;
                    //Console.WriteLine("RightView.image: " + RightView.Image);
                    //Console.WriteLine("LeftView.image: " + LeftView.Image);
                }
                else
                {
                    RightView = new coord(tVis[Loc.X - i, Loc.Y], tImage[Loc.X - i, Loc.Y], tStory[Loc.X - i, Loc.Y], tTile[Loc.X - i, Loc.Y]);
                    FrontView = new coord(tVis[Loc.X, Loc.Y + i], tImage[Loc.X, Loc.Y + i], tStory[Loc.X, Loc.Y + i], tTile[Loc.X, Loc.Y + i]);
                    LeftView = new coord(tVis[Loc.X + i, Loc.Y], tImage[Loc.X + i, Loc.Y], tStory[Loc.X + i, Loc.Y], tTile[Loc.X + i, Loc.Y]);
                    Console.WriteLine("right view: x: " + (Loc.X) + " y: " + (Loc.Y - i));
                    Console.WriteLine("Front view: x: " + (Loc.X + i) + " y: " + (Loc.Y));
                    Console.WriteLine("left view: x: " + (Loc.X) + " y: " + (Loc.Y + i));
                    map[Loc.X, Loc.Y - i].Vis = true;
                    map[Loc.X + i, Loc.Y].Vis = true;
                    map[Loc.X, Loc.Y + i].Vis = true;

                }

                Console.WriteLine();
                for (int l = 0; l < 5; l++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        Console.Write(map[l, k].Vis + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

            }
            catch (Exception e)
            {
                Console.WriteLine("SetView Error: " + e);

            }
        }

        // function to move location by one map unit
        // 1 = left, 2 = foward, 3 = right
        public void move(int direction)
        {
            Console.WriteLine("enter move");
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
            Console.WriteLine("After move Loc.X: " + Loc.X + " Loc.Y: " + Loc.Y);

        }

        //function rotate currentloction z access
        // 1 = north, 2 = south, 3 = east, 4 = west
        //input: dir = 2 rotate left dir = 3 rotate right
        public void rotate(int dir)
        {
            Console.WriteLine("enter Rotate");
            switch (Loc.Z)
            {
                case 1:
                    if (dir == 2)
                    {
                        Console.WriteLine("Z = 1 rotate to 3");
                        Loc.Z = 3;
                    }
                    else
                    {
                        Console.WriteLine("Z = 1 rotate to 4");
                        Loc.Z = 4;
                    }
                    break;
                case 2:
                    if (dir == 2)
                    {
                        Console.WriteLine("Z = 2 rotate to 4");
                        Loc.Z = 4;
                    }
                    else
                    {
                        Console.WriteLine("Z = 2 rotate to 3");
                        Loc.Z = 3;
                    }
                    break;
                case 3:
                    if (dir == 2)
                    {
                        Console.WriteLine("Z = 3 rotate to 2");
                        Loc.Z = 2;
                    }
                    else
                    {
                        Console.WriteLine("Z = 3 rotate to 1");
                        Loc.Z = 1;
                    }
                    break;
                case 4:
                    if (dir == 2)
                    {
                        Console.WriteLine("Z = 4 rotate to 1");
                        Loc.Z = 1;
                    }
                    else
                    {
                        Console.WriteLine("Z = 4 rotate to 2");
                        Loc.Z = 2;
                    }
                    break;

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

        public coord RightView
        {
            get
            {
                return rightView;
            }
            set
            {
                rightView = value;
            }
        }

        public coord FrontView
        {
            get
            {
                return frontView;
            }
            set
            {
                frontView = value;
            }
        }
        public coord LeftView
        {
            get
            {
                return leftView;
            }
            set
            {
                leftView = value;
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

        public int[,] Image
        {
            get
            {
                int[,] I = new int[map.Length, map.Height];
                int temp;
                for (int i = 0; i < map.Length; i++)
                {
                    for (int j = 0; j < map.Height; j++)
                    {
                        temp = map[i, j].Image;
                        I[j, i] = temp;
                    }
                }

                return I;
            }

        }
    }
}