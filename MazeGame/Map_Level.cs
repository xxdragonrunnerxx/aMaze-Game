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
            setVisible();
            view = new coord[3];
        }

        // function to load a level from a file
        private Map<coord> loadMap(int l)
        {
            String tempString = getPath() + "/src/level" + l + ".txt";
            reader = new StreamReader(tempString); //sets a stream reader to the selected file
            tempString = reader.ReadLine();
            String[] tempArr = tempString.Split(',');
            String[] tempCord = tempArr[2].Split('/');
            currentLocation = new location(Convert.ToInt32(tempCord[0]), Convert.ToInt32(tempCord[1]), Convert.ToInt32(tempCord[2]));
            int x = int.Parse(tempArr[0]) + 2;
            int y = int.Parse(tempArr[1]) + 2;
            Map<coord> lMap = new Map<coord>(x, y);
            for (int i = 0; i < y; i++)
            {
                if (i == 0 || i == (y - 1))
                {
                    for (int j = 0; j < x; j++)
                    {

                        lMap[i, j].Vis = true;
                        lMap[i, j].Image = -1;
                        lMap[i, j].Story = -1;
                        lMap[i, j].Tile = -1;
                    }
                }
                else
                {
                    tempString = reader.ReadLine();
                    tempArr = tempString.Split(',');
                    for (int j = 0; j < x; j++)
                    {
                        tempCord = tempArr[j].Split('/');
                        if (j == 0 || j == x - 1)
                        {
                            lMap[i, j].Vis = true;
                            lMap[i, j].Image = -1;
                            lMap[i, j].Story = -1;
                            lMap[i, j].Tile = -1;
                        }
                        else
                        {
                            if (int.Parse(tempCord[0]) == 1)
                            {
                                lMap[i, j].Vis = true;
                            }
                            else
                            {
                                lMap[i, j].Vis = false;
                            }
                            lMap[i, j].Image = int.Parse(tempCord[1]);
                            lMap[i, j].Story = int.Parse(tempCord[2]);
                            lMap[i, j].Tile = int.Parse(tempCord[3]);
                        }
                    }
                }
            }
            return lMap;
        }

        // function returns the coords in front and to the sides of a location 
        public void setView(location loc)
        {
            Loc = loc;
            setVisible();
            int i = 1;
            if (loc.Z % 2 > 0)
            {
                i = -1;
            }
            if (loc.Z < 3)
            {
                view[0] = map[Loc.X + i, Loc.Y];
                view[1] = map[Loc.X, Loc.Y + i];
                view[2] = map[Loc.X - i, Loc.Y];
            }
            else
            {
                view[0] = map[Loc.X, Loc.Y + i];
                view[1] = map[Loc.X + i, Loc.Y];
                view[2] = map[Loc.X, Loc.Y - i];
            }
        }

        // fuction set all square surounding currentloction to visble
        public void setVisible()
        {
            int x = currentLocation.X;
            int y = currentLocation.Y;
            map[x, y].Vis = true;
            map[x + 1, y].Vis = true;
            map[x - 1, y].Vis = true;
            map[x, y + 1].Vis = true;
            map[x, y - 1].Vis = true;
        }



        //method returns the path at the .snl level
        private string getPath()
        {
            string s = Directory.GetCurrentDirectory();
            //int i = s.IndexOf(Application.ProductName);
            //string path = Path.GetDirectoryName(Application.ExecutablePath);
            //s = s.Substring(0, i + Application.ProductName.Length + 1);

            return s;
        }

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

    }
}