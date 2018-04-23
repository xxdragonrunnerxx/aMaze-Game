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
        Character player;
        Map_Level level;
        int flag;
        public int[,] tiles, story;
        public bool[,] vis;
        public bool win;
        int resetLevel;
        int option1, option2, option3;
        string responce = "";
        string tale = "";
        string op1 = "";
        string op2 = "";
        string op3 = "";


        //constructor
        public Game(int lev)
        {
            resetLevel = lev;
            level = new Map_Level(lev);
            player = new Character("Bob", 10, 4);
            tiles = level.Tiles;
            story = level.Story;
            flag = 0;
            win = false;
        }

        // Method to reset th game
        public void reset()
        {
            level = new Map_Level(resetLevel);
            player = new Character("Bob", 10, 1);
            tiles = level.Tiles;
            story = level.Story;
            flag = 0;
            win = false;

        }

        // Method for updating after action is taken
        public void action(int button)
        {
            setStory();
            int option = 0;
            string dir = "";
            Console.WriteLine("enter action");
            Console.WriteLine("Button: " + button);
            Console.WriteLine("Option1: " + option1);
            Console.WriteLine("Option2: " + option2);
            Console.WriteLine("Option3: " + option3);
            switch (button)
            {
                case 2:
                    Console.WriteLine("Case button 2: rotate left");
                    dir = "left";
                    level.rotate(button);
                    break;
                case 3:
                    Console.WriteLine("Case button 3: rotate right");
                    dir = "right";
                    level.rotate(button);
                    break;
                default:
                    option = option1;
                    Console.WriteLine("Enter");
                    dir = "foward";
                    switch (option)
                    {
                        case 0:
                            Console.WriteLine("default case 0: wall");
                            responce = "You move " + dir + " and run into a wall. That hurt. ";
                            player.Life -= 1;
                            break;
                        case 1:
                            Console.WriteLine("default case 1: move");
                            responce = "You move " + dir + ". ";
                            level.move(button);
                            break;
                        case 2:
                            Console.WriteLine("default case 2: keys");
                            responce = "You move " + dir + " and find a KEY in the room. Where does this got to? ";
                            player.keys[0] = 1;
                            Console.WriteLine("player keys " + player.keys[0] + " avaliable");
                            level.move(button);
                            break;
                        case 3:
                            Console.WriteLine("Option Case 3: door");
                            if (player.keys[0]==1)
                            {
                                win = true;
                            }else
                            {
                                responce = "The door is locked! You need a KEY to get through this door! ";
                            }
                            break;
                    }
                    break;
            }
            //vis = level.Vis;
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
            StreamReader reader, reader1, reader2;
            Console.WriteLine("enter set story");
            level.setView();
            int tempStor = level.FrontView.Story;
            String tempString = "story" + tempStor + ".txt";
            string[] tempArr, tempArr1, tempArr2;
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
                op1 = "Move foward toward " + tempArr[1];
                option1 = int.Parse(tempArr[2]);
                reader.Close();
                Console.WriteLine("Tale: " + tale);
                if (tempStor > 9)
                {
                    op1 = tempArr[1];
                    option1 = int.Parse(tempArr[2]);
                    op2 = tempArr[3];
                    option2 = int.Parse(tempArr[4]);
                    op3 = tempArr[5];
                    option3 = int.Parse(tempArr[6]);
                }
                else
                {
                    Console.WriteLine("enter setStory/op2");
                    tempStor = level.LeftView.Story;
                    Console.WriteLine("level.LeftView.Story: " + tempStor);
                    tempString = "story" + tempStor + ".txt";
                    Console.WriteLine("tempString: " + tempString);
                    reader1 = new StreamReader(tempString);
                    tempStr = reader1.ReadLine();
                    while (!reader1.EndOfStream)
                    {
                        tempStr += reader1.ReadLine();

                    }
                    Console.WriteLine("tempStr: " + tempStr);
                    tempArr1 = tempStr.Split(';');
                    Console.WriteLine("tempArr1[1]: " + tempArr1[1]);
                    op2 = "To left " + tempArr1[1];
                    option2 = int.Parse(tempArr1[2]);
                    reader1.Close();

                    tempStor = level.RightView.Story;
                    tempString = "story" + tempStor + ".txt";
                    reader2 = new StreamReader(tempString);
                    tempStr = reader2.ReadLine();
                    while (!reader2.EndOfStream)
                    {
                        tempStr += reader2.ReadLine();

                    }
                    tempArr2 = tempStr.Split(';');
                    op3 = "To right " + tempArr2[1];
                    option3 = int.Parse(tempArr2[2]);
                    reader2.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error setStory" + e);
            }
        }

        //// string for for button option and a number assigned for for the string
        //public void setOption(int opt)
        //{
        //    Console.WriteLine("Enter setOption");
        //    level.setView();
        //    int tempStor = 0;
        //    string tempString = "";
        //    string[] tempArr;
        //    if(opt == 1 || level.FrontView.Story > 9)
        //    {
        //        // read file for the left view and set options
        //        tempStor = level.FrontView.Story;
        //    }
        //    else if(opt == 2)
        //    {
        //        // read file for the left view and set options
        //        tempStor = level.LeftView.Story;
        //    }
        //    else if (opt == 3)
        //    {
        //        // read file for the left view and set options
        //        tempStor = level.RightView.Story;
        //    }

        //    Console.WriteLine("level story: " + tempStor);

        //    tempString = "story" + tempStor + ".txt";

        //    try
        //    {
        //        reader = new StreamReader(tempString); //sets a stream reader to the selected file
        //        tempString = reader.ReadLine();
        //        while (!reader.EndOfStream)
        //        {
        //            tempString += reader.ReadLine();

        //        }
        //        tempArr = tempString.Split(';');
        //        reader.Close();
        //        if (tempStor > 9)
        //        {
        //            op1 = tempArr[1];
        //            option1 = int.Parse(tempArr[2]);
        //            op2 = tempArr[3];
        //            option2 = int.Parse(tempArr[4]);
        //            op3 = tempArr[5];
        //            option3 = int.Parse(tempArr[6]);
        //        }
        //        else if (tempStor == 1)
        //        {
        //            op1 = "Move foward toward " + tempArr[1];
        //            option1 = int.Parse(tempArr[2]);
        //        }
        //        else if (tempStor == 2)
        //        {
        //            op2 = "To the left: " + tempArr[1];
        //            option2 = int.Parse(tempArr[2]);
        //        }
        //        else if (tempStor == 3)
        //        {
        //            op3 = "To the right: " + tempArr[1];
        //            option3 = int.Parse(tempArr[2]);
        //        }
        //    }catch (Exception) { }
        //}

        // Properties
        public bool[,] Vis
        {
            get
            {
                return level.Vis;
            }
        }

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
                //setOption(1);
                Console.WriteLine("Button1 op1: " + op1 + " option1: " + option1);
                return op1;
            }
        }

        public string Button2
        {
            get
            {
                //setOption(2);
                Console.WriteLine("Button2 op2: " + op2 + " option2: " + option2);
                return op2;
            }
        }

        public string Button3
        {
            get
            {
                //setOption(3);
                Console.WriteLine("Button3 op3: " + op3 + " option3: " + option3);
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
                return level.FrontView.Image;
            }
        }

        public int LeftImage
        {
            get
            {
                level.setView();
                return level.LeftView.Image;
            }
        }

        public int RightImage
        {
            get
            {
                level.setView();
                return level.RightView.Image;
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

        internal bool haveKey(int v)
        {
            if (player.keys[v] == 1)
            {
                return true;
            }
            return false;
        }
    }
}