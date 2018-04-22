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
        //What panel is set to visable now 
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

        private void reStart()
        {
            game.reset();
            setPanel();
            getStory();
        }

        private void setEnd()
        {
            string[] img = { "source/Images/Died.png", "source/Images/you escaped.png"};

            if (Won())
                setImage(GameOver, img[1]);
            else
                setImage(GameOver, img[0]);
            GameOver.Visibility = Visibility.Visible;
            BlackOut.Visibility = Visibility.Visible;
        }

        private bool Won()
        {
            bool win = false;
            if (game.Alive)
                if (game.Flag == 0)
                    win = true;
            return win;
        }

        private void setImage(Image pnlimg, string path)
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(path, UriKind.Relative));
            pnlimg.Source = img.Source;

        }

        private void setPanel()
        {
            string[] img = { "source/Images/Left.png", "source/Images/LeftDoor.png", "source/Images/LeftCave.png",
                "source/Images/Center.png", "source/Images/CenterDoor.png", "source/Images/CenterCave.png",
                "source/Images/Right.png", "source/Images/RightDoor.png", "source/Images/RightCave.png"};

            setImage(LeftPanel, img[game.LeftImage]);
            setImage(CenterPanel, img[game.FrontImage + 3]);
            setImage(RightPanel, img[game.RightImage + 6]);
        }

        private void getStory()
        {
            StoryBlock.Text = game.Story;
            Console.WriteLine(game.Story);
            Button1.Content = game.Button2;
            Button2.Content = game.Button1;
            Button3.Content = game.Button3;
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
                        setImage(mMap[i, j], "source/Images/index.png");
                        mMap[i, j].Visibility = Visibility.Visible;
                    }
                    else if (tVis[i, j] == false)
                    {
                        mMap[i, j].Visibility = Visibility.Hidden;
                    }
                    else if (game.tiles[i, j] == 1)
                    {
                        setImage(mMap[i, j], "source/Images/RockMap120.png");
                        mMap[i, j].Visibility = Visibility.Visible;
                    }
                    else if (game.tiles[i, j] == 2)
                    {
                        setImage(mMap[i, j], "source/Images/Key@2x.png");
                        mMap[i, j].Visibility = Visibility.Visible;
                    }
                    else
                    {
                        setImage(mMap[i, j], "source/Images/Hint@2x.png");
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

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MenuShadow.Visibility = Visibility.Hidden;
            MenuGrid.Visibility = Visibility.Hidden;
            setEnd();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            StoryBlock.Text = "I have entered new text.";
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            
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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            game.action(1);
            setPanel();
            getStory();
        }
        private void Button2_Click_1(object sender, RoutedEventArgs e)
        {
            game.action(3);
            setPanel();
            getStory();
        }

        private void Button3_Click_1(object sender, RoutedEventArgs e)
        {
            game.action(2);
            setPanel();
            getStory();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            reStart();
        }

        //example button
        //will pass move to game.option(1)
        //get new images and story = game.newLocation()
    }
}
