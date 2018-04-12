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

        int[] panelValue = { 0, 0, 0 };
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
            LeftPanel1.Visibility = Visibility.Hidden;
            LeftPanel2.Visibility = Visibility.Visible;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            StoryBlock.Text = "I have entered new text.";
        }

        //example button
        //will pass move to game.option(1)
        //get new images and story = game.newLocation()
    }
}
