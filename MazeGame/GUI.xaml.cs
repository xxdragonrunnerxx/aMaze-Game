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

namespace MazeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //What panel is set to visable now 
        int[] panelValue = { 1, 1, 1 };//Bradley
        //global instance of game
        //game bigB = new game();
        public MainWindow()
        {
            InitializeComponent();
            //Game.menu();
            //while(game.playing()){};
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
            for (int i = 0; i < 3; i++)
            {
                panelValue[i] = 2;
            }
            LeftPanel1.Visibility = Visibility.Hidden;
            LeftPanel2.Visibility = Visibility.Visible;
            CenterPanel1.Visibility = Visibility.Hidden;
            CenterPanel2.Visibility = Visibility.Visible;
            RightPanel1.Visibility = Visibility.Hidden;
            RightPanel2.Visibility = Visibility.Visible;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            StoryBlock.Text = "I have entered new text.";
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                panelValue[i] = 1;
            }
            LeftPanel1.Visibility = Visibility.Visible;
            LeftPanel2.Visibility = Visibility.Hidden;
            CenterPanel1.Visibility = Visibility.Visible;
            CenterPanel2.Visibility = Visibility.Hidden;
            RightPanel1.Visibility = Visibility.Visible;
            RightPanel2.Visibility = Visibility.Hidden;
        }

        //example button
        //will pass move to game.option(1)
        //get new images and story = game.newLocation()
    }
}
