/***********************************************************
  * Bradley Massey
  * Daniel Reiter
  * Erika Goad
  * Galina Vitvitskaya
  * 4/10/2018
  * 
  * Program: MazeGame
  * 
  * Class: coords
  * 
  * bool vis;
  * int image, story, tile;
  *
  * Program coords stores the flags for each location on the map 
  * flags include a boolean if the location is visible on the mini map
  * and integers to represent the locations image, story and tile value
  ***********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    class coord
    {
        // global varibles
        private bool vis;
        private int image, story, tile;

        // constructor
        public coord()
        {
            vis = false;
            image = 0;
            story = 0;
            tile = 0;
        }

        // constructor
        public coord(bool v, int i, int s, int t)
        {
            Vis = v;
            Image = i;
            Story = s;
            Tile = t;
        }

        public bool Vis
        {
            get
            {
                return vis;
            }
            set
            {
                vis = value;
            }
        }

        public int Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        public int Story
        {
            get
            {
                return story;
            }
            set
            {
                story = value;
            }
        }

        public int Tile
        {
            get
            {
                return tile;
            }
            set
            {
                tile = value;
            }
        }


    }
}
