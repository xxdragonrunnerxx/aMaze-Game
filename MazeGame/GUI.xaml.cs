/***********************************************************
  * Bradley Massey
  * Daniel Reiter
  * Erika Goad
  * Galina Vitvitskaya
  * 4/1/2018
  * 
  * Program: MazeGame
  * 
  * Class: Game
  * 
  * Variables:
  * 
  * Methods:
  * Main()
  ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using System.Drawing;

namespace MazeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        //What panel is set to visible now 
        int[] panelValue = { 1, 1, 1 };//Bradley
        bool[,] mapView = new bool[5, 5];
        Game game;
        //global instance of game
        //game bigB = new game();
        public MainWindow()
        {

            DataContext = this;


            game = new Game(1);

            InitializeComponent();

            setPanel();
            getStory();
        }

        private void restart()
        {
            RETURN.Visibility = Visibility.Hidden;
            EndTest.Visibility = Visibility.Hidden;
            Text.Visibility = Visibility.Hidden;
            restartButton.Visibility = Visibility.Hidden;
            startButton.Visibility = Visibility.Visible;
            Title.Visibility = Visibility.Visible;
            rules.Visibility = Visibility.Visible;
            again.Visibility = Visibility.Hidden;
            MenuShadow.Visibility = Visibility.Visible;
            MenuGrid.Visibility = Visibility.Visible;
            GameOver.Visibility = Visibility.Hidden;
            BlackOut.Visibility = Visibility.Hidden;
            game.reset();
            setPanel();
            getStory();
        }

        private void isEnd()
        {
            Console.WriteLine("game.win: " + game.win);
            string[] img = { "source/Images/Died.png", "source/Images/you escaped.png"};
            bool show = false;
            if (game.win)
            {
                show = true;
                setImage(GameOver, img[1]);
            }
            if (!game.Alive)
            {
                show = true;
                setImage(GameOver, img[0]);
            }
            if (show)
            {
                again.Visibility = Visibility.Visible;
                ReturnMini.Visibility = Visibility.Visible;
                GameOver.Visibility = Visibility.Visible;
                BlackOut.Visibility = Visibility.Visible;
            }

        }
        

        private void setImage(Image pnlimg, string path)
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(path, UriKind.Relative));
            pnlimg.Source = img.Source;

        }

        private void setPanel()
        {
            string[] img = { "source/Images/Left.png", "source/Images/LeftCave.png", "source/Images/LeftCave.png", "source/Images/LeftDoor.png",
                "source/Images/Center.png", "source/Images/CenterCave.png", "source/Images/CenterCave.png", "source/Images/CenterDoor.png",
                "source/Images/Right.png", "source/Images/RightCave.png", "source/Images/RightCave.png", "source/Images/RightDoor.png"};

            setImage(LeftPanel, img[game.LeftImage]);
            setImage(CenterPanel, img[game.FrontImage + 4]);
            setImage(RightPanel, img[game.RightImage + 8]);
        }

        private void getStory()
        {
            StoryBlock.Text = game.Story;
            Console.WriteLine(game.Story);
            LeftButton.Content = game.Button2;
            CenterButton.Content = game.Button1;
            RightButton.Content = game.Button3;
        }


        private void setMini()
        {
            Image[,] mMap =
            { { Map0_0, Map0_1, Map0_2, Map0_3, Map0_4 },
             { Map1_0, Map1_1, Map1_2, Map1_3, Map1_4 },
             { Map2_0, Map2_1, Map2_2, Map2_3, Map2_4 },
             { Map3_0, Map3_1, Map3_2, Map3_3, Map3_4 },
             { Map4_0, Map4_1, Map4_2, Map4_3, Map4_4 } };
            bool[,] tVis = game.Vis;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {

                    if (game.currentLoc.X == i && game.currentLoc.Y == j)
                    {
                        Console.WriteLine("game.currentLoc.X: " + game.currentLoc.X + " game.currentLoc.Y: " + game.currentLoc.Y + " i: " + i + " j: " + j);
                        setImage(mMap[i, j], "source/Images/person.png");
                        mMap[i, j].Visibility = Visibility.Visible;
                    }
                    else if (tVis[i, j] == false)
                    {
                        mMap[i, j].Visibility = Visibility.Hidden;
                    }
                    else if (game.tiles[i, j] == 1)
                    {
                        setImage(mMap[i, j], "source/Images/ground.png");
                        mMap[i, j].Visibility = Visibility.Visible;
                    }
                    else if (game.tiles[i, j] == 2)
                    {
                        setImage(mMap[i, j], "source/Images/Key@2x.png");
                        mMap[i, j].Visibility = Visibility.Visible;
                    }
                    else if (game.tiles[i, j] == 3)
                    {
                        setImage(mMap[i, j], "source/Images/Hint@2x.png");
                        mMap[i, j].Visibility = Visibility.Visible;
                    }
                    else
                    {
                        setImage(mMap[i, j], "source/Images/RockMap120.png");
                        mMap[i, j].Visibility = Visibility.Visible;
                    }
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void miniMapVisable(int x, int y)
        {
            mapView[x, y] = true;
        }

        private bool isVisableMap(int x, int y)
        {
            return true;
        }

        private void MENUButton_Click(object sender, RoutedEventArgs e)
        {
            MenuShadow.Visibility = Visibility.Visible;
            MenuGrid.Visibility = Visibility.Visible;
        }

        private void RETURN_Click(object sender, RoutedEventArgs e)
        {
            MenuShadow.Visibility = Visibility.Hidden;
            MenuGrid.Visibility = Visibility.Hidden;
        }

        private void EndTest_Click(object sender, RoutedEventArgs e)
        {
            MenuShadow.Visibility = Visibility.Hidden;
            MenuGrid.Visibility = Visibility.Hidden;
            isEnd();
        }

        private void text_Click(object sender, RoutedEventArgs e)
        {
            StoryBlock.Text = "I have entered new text.";
        }
        
        private void Map_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < mapView.GetLength(0); i++)
            {
                for (int j = 0; j < mapView.GetLength(1); j++)
                {
                    setMini();
                    setMapVisability(i, j);
                }

            }
            MenuShadow.Visibility = Visibility.Visible;
            MiniMap.Visibility = Visibility.Visible;
        }

        private void setMapVisability(int i, int j)
        {
            switch (i)
            {
                case 0:
                    switch (j)
                    {
                        case 0:
                            if (isVisableMap(i, j))
                                Map0_0.Visibility = Visibility.Visible;
                            else
                                Map0_0.Visibility = Visibility.Hidden;
                            break;
                        case 1:
                            if (isVisableMap(i, j))
                                Map0_1.Visibility = Visibility.Visible;
                            else
                                Map0_1.Visibility = Visibility.Hidden;
                            break;
                        case 2:
                            if (isVisableMap(i, j))
                                Map0_2.Visibility = Visibility.Visible;
                            else
                                Map0_2.Visibility = Visibility.Hidden;
                            break;
                        case 3:
                            if (isVisableMap(i, j))
                                Map0_3.Visibility = Visibility.Visible;
                            else
                                Map0_3.Visibility = Visibility.Hidden;
                            break;
                        default:
                            if (isVisableMap(i, j))
                                Map0_4.Visibility = Visibility.Visible;
                            else
                                Map0_4.Visibility = Visibility.Hidden;
                            break;
                    }
                    break;
                case 1:
                    switch (j)
                    {
                        case 0:
                            if (isVisableMap(i, j))
                                Map1_0.Visibility = Visibility.Visible;
                            else
                                Map1_0.Visibility = Visibility.Hidden;
                            break;
                        case 1:
                            if (isVisableMap(i, j))
                                Map1_1.Visibility = Visibility.Visible;
                            else
                                Map1_1.Visibility = Visibility.Hidden;
                            break;
                        case 2:
                            if (isVisableMap(i, j))
                                Map1_2.Visibility = Visibility.Visible;
                            else
                                Map1_2.Visibility = Visibility.Hidden;
                            break;
                        case 3:
                            if (isVisableMap(i, j))
                                Map1_3.Visibility = Visibility.Visible;
                            else
                                Map1_3.Visibility = Visibility.Hidden;
                            break;
                        default:
                            if (isVisableMap(i, j))
                                Map1_4.Visibility = Visibility.Visible;
                            else
                                Map1_4.Visibility = Visibility.Hidden;
                            break;
                    }
                    break;
                case 2:
                    switch (j)
                    {
                        case 0:
                            if (isVisableMap(i, j))
                                Map2_0.Visibility = Visibility.Visible;
                            else
                                Map2_0.Visibility = Visibility.Hidden;
                            break;
                        case 1:
                            if (isVisableMap(i, j))
                                Map2_1.Visibility = Visibility.Visible;
                            else
                                Map2_1.Visibility = Visibility.Hidden;
                            break;
                        case 2:
                            if (isVisableMap(i, j))
                                Map2_2.Visibility = Visibility.Visible;
                            else
                                Map2_2.Visibility = Visibility.Hidden;
                            break;
                        case 3:
                            if (isVisableMap(i, j))
                                Map2_3.Visibility = Visibility.Visible;
                            else
                                Map2_3.Visibility = Visibility.Hidden;
                            break;
                        default:
                            if (isVisableMap(i, j))
                                Map2_4.Visibility = Visibility.Visible;
                            else
                                Map2_4.Visibility = Visibility.Hidden;
                            break;
                    }
                    break;
                case 3:
                    switch (j)
                    {
                        case 0:
                            if (isVisableMap(i, j))
                                Map3_0.Visibility = Visibility.Visible;
                            else
                                Map3_0.Visibility = Visibility.Hidden;
                            break;
                        case 1:
                            if (isVisableMap(i, j))
                                Map3_1.Visibility = Visibility.Visible;
                            else
                                Map3_1.Visibility = Visibility.Hidden;
                            break;
                        case 2:
                            if (isVisableMap(i, j))
                                Map3_2.Visibility = Visibility.Visible;
                            else
                                Map3_2.Visibility = Visibility.Hidden;
                            break;
                        case 3:
                            if (isVisableMap(i, j))
                                Map3_3.Visibility = Visibility.Visible;
                            else
                                Map3_3.Visibility = Visibility.Hidden;
                            break;
                        default:
                            if (isVisableMap(i, j))
                                Map3_4.Visibility = Visibility.Visible;
                            else
                                Map3_4.Visibility = Visibility.Hidden;
                            break;
                    }
                    break;
                default:
                    switch (j)
                    {
                        case 0:
                            if (isVisableMap(i, j))
                                Map4_0.Visibility = Visibility.Visible;
                            else
                                Map4_0.Visibility = Visibility.Hidden;
                            break;
                        case 1:
                            if (isVisableMap(i, j))
                                Map4_1.Visibility = Visibility.Visible;
                            else
                                Map4_1.Visibility = Visibility.Hidden;
                            break;
                        case 2:
                            if (isVisableMap(i, j))
                                Map4_2.Visibility = Visibility.Visible;
                            else
                                Map4_2.Visibility = Visibility.Hidden;
                            break;
                        case 3:
                            if (isVisableMap(i, j))
                                Map4_3.Visibility = Visibility.Visible;
                            else
                                Map4_3.Visibility = Visibility.Hidden;
                            break;
                        default:
                            if (isVisableMap(i, j))
                                Map4_4.Visibility = Visibility.Visible;
                            else
                                Map4_4.Visibility = Visibility.Hidden;
                            break;
                    }
                    break;
            }
        }

        private void ReturnMini_Click(object sender, RoutedEventArgs e)
        {
            MenuShadow.Visibility = Visibility.Hidden;
            MiniMap.Visibility = Visibility.Hidden;
        }

        private void CenterButton_Click(object sender, RoutedEventArgs e)
        {
            game.action(1);
            isEnd();
            key();
            setPanel();
            getStory();
        }
        
        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            game.action(3);
            setPanel();
            getStory();
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            game.action(2);
            setPanel();
            getStory();
        }

        private void key()
        {
            if (game.haveKey(0))
            {
                Key1.Visibility = Visibility.Visible;
            }

        }

        private void Button_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            // ... Set ToolTip on Button before it is shown.
            Button b = sender as Button;
            b.ToolTip = "MiniMap";
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            restart();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            MenuShadow.Visibility = Visibility.Hidden;
            MenuGrid.Visibility = Visibility.Hidden;
            RETURN.Visibility = Visibility.Visible;
            EndTest.Visibility = Visibility.Visible;
            Text.Visibility = Visibility.Visible;
            restartButton.Visibility = Visibility.Visible;
            startButton.Visibility = Visibility.Hidden;
            Title.Visibility = Visibility.Hidden;
            rules.Visibility = Visibility.Hidden;
        }


        //example button
        //will pass move to game.option(1)
        //get new images and story = game.newLocation()
    }
}
