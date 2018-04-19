/***********************************************************
  * Bradley Massey
  * Daniel Reiter
  * Erika Goad
  * Galina Vitvitskaya
  * 4/17/2018
  * 
  * Program: MazeGame
  * 
  * Class: Game
  *
  * Variables:
  *     used out side of game class :
  *         asscess as property (i.e. text = Story) 
  *         
  *         Story: returns a string read from a file
  *         Button1: returns a string read from a file and updates corrisponding glass variables
  *         Button2: returns a string read from a file and updates corrisponding glass variables
  *         Button3: returns a string read from a file and updates corrisponding glass variables
  *         Flag: variable that is returned to the game class to preform an action
  *         FrontImage: returns an int for value of front image
  *         LeftImage: returns an int for value of left image
  *         RigtImage: returns an int for value of right image
  *          
  * 
  * Methods:
  * run() - returns 
  * Game(int) - constuctor for game class
  * action(int) - takes in a on int (user interface value) and updates the game
  * select() - is run in run method and runs a continues loop until the flag variable is changes or player dies or the game is won
  * setStory() - is called buy the story property to update the story from a file and return a string
  * setOption(int) - is called by all three of the button properties to update the button text and button option numbers
  * 
  * 
  ***********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MazeGame
{
    class Game
    {
        // global variables
        StreamReader reader;
        Character player;
        Map_Level level;
        int flag;
        public int[,] tiles, story;
        public bool[,] vis;
        bool win;
        int option1, option2, option3;
        string responce = "";
        string tale = "";
        string op1 = "";
        string op2 = "";
        string op3 = ""; 


        //constructor
        public Game(int lev)
        {
            level = new Map_Level(lev);
            player = new Character("Bob", 10, 0);
            tiles = level.Tiles;
            story = level.Story;
            vis = level.Vis;
            flag = 0;
            win = false;
        }

        // Method for updating after action is taken
        public void action(int button)
        {
            int option = 0;
            string dir = "";
            switch (button)
            {
             case 2:
                dir = "left";
                level.rotate(button);
                break;
            case 3:
                dir = "right";
                level.rotate(button);
                break;
            default:
                option = option1;
                dir = "foward";
                switch (option)
                {
                    case 0:
                            Console.WriteLine("default case 0");
                        responce = "You move " + dir + " and run into a wall. That hurt. ";
                        player.Life -= 1;
                        break;
                    case 1:
                        Console.WriteLine("default case 2");
                        responce = "You move " + dir + ". ";
                        level.move(button);
                        break;
                    case 2:
                        Console.WriteLine("default case 2");
                        responce = "You move " + dir + " and find a key in a chest. ";
                        level.move(button);
                        player.newKey = 1;
                        break;
                }
                break;
            }
            vis = level.Vis;
        }

        // method waits while flag is not changed
        public void select()
        {
            flag = 0;
            while (flag == 0) { }
            action(flag);
            vis = level.Vis;
        }

        // set the current story line with the current view
        public void setStory()
        {
            level.setView();
            int tempStor = level.frontView.Story;
            String tempString = "story" + tempStor + ".txt";
            string[] tempArr;
            string tempStr = "";
            try
            {
                // read main story from a file and set tale and option2
                reader = new StreamReader(tempString); //sets a stream reader to the selected file
                tempStr = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    tempStr += reader.ReadLine();

                }
                tempArr = tempStr.Split(';');
                tale = responce + tempArr[0];
                reader.Close();
            }
            catch (Exception e) {
            }
        }

        // returns string for for button option and a number assigned for for the string
        public void setOption(int opt)
        {
            level.setView();
            int tempStor = 0;
            string tempString = "";
            string[] tempArr;
            if(opt == 1 || level.frontView.Story > 9)
            {
                // read file for the left view and set options
                tempStor = level.frontView.Story;
            }
            else if(opt == 2)
            {
                // read file for the left view and set options
                tempStor = level.leftView.Story;
            }
            else if (opt == 3)
            {
                // read file for the left view and set options
                tempStor = level.rightView.Story;
            }

            tempString = "story" + tempStor + ".txt";

            try
            {
                reader = new StreamReader(tempString); //sets a stream reader to the selected file
                tempString = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    tempString += reader.ReadLine();

                }
                tempArr = tempString.Split(';');
                reader.Close();
                if (tempStor > 9)
                {
                    op1 = tempArr[1];
                    option1 = int.Parse(tempArr[2]);
                    op2 = tempArr[3];
                    option2 = int.Parse(tempArr[4]);
                    op3 = tempArr[5];
                    option3 = int.Parse(tempArr[6]);
                }
                else if (tempStor == 1)
                {
                    op1 = "Move foward toward " + tempArr[1];
                    option1 = int.Parse(tempArr[2]);
                }
                else if (tempStor == 2)
                {
                    op2 = "Move left toward " + tempArr[1];
                    option2 = int.Parse(tempArr[2]);
                }
                else if (tempStor == 3)
                {
                    op3 = "Move right toward " + tempArr[1];
                    option3 = int.Parse(tempArr[2]);
                }
            }catch (Exception) { }
        }

        // Properties
        public string Story
        {
            get
            {
                setStory();
                return tale;
            }
        }

        public string Button1
        {
            get
            {
                setOption(1);
                return op1;
            }
        }

        public string Button2
        {
            get
            {
                setOption(2);
                return op2;
            }
        }

        public string Button3
        {
            get
            {
                setOption(3);
                return op3;
            }
        }

        public location currentLoc
        {
            get
            {
                return level.Loc;
            }
        }

        public int FrontImage
        {
            get
            {
                level.setView();
                return level.frontView.Image;
            }
        }

        public int LeftImage
        {
            get
            {
                level.setView();
                return level.leftView.Image;
            }
        }

        public int RightImage
        {
            get
            {
                level.setView();
                return level.rightView.Image;
            }
        }

        public int Flag
        {
            get
            {
                return flag;
            }

            set
            {
                flag = value;
            }
        }

        public bool Alive
        {
            get
            {
                return player.isAlive();
            }
        }

        public bool Win
        {
            get
            {
                return win;
            }
        }
    }
}