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
        //global instance of game
        //game bigB = new game();
        public MainWindow()
        {
            //System.Windows.Media.ImageSource lImage = new BitmapImage(new Uri("pack://application:,,,/MazeGame;src\\Images\\index.png"));
            //LeftPanel.Source = lImage;
            InitializeComponent();
            //RightImage = "src\\Images\\index.png";
            //System.Windows.Media.ImageSource lImage = "src\\Images\\index.png";
            
            //Game.menu();
            //while(game.playing()){};
        }

        private void MENUButton_Click(object sender, RoutedEventArgs e)
        {
            //MenuShadow.Visibility = Visibility.Visible;
            //MenuGrid.Visibility = Visibility.Visible;
            


        }

        //example button
        //will pass move to game.option(1)
        //get new images and story = game.newLocation()

        //public static readonly DependencyProperty ImageRightProperty =
        //DependencyProperty.Register("LeftPanel", typeof(string), typeof(MainWindow));

        //public string leftImage
        //{
        //    get { return (string)GetValue(ImageRightProperty); }
        //    set { SetValue(ImageRightProperty, value); }
        //}
    }
}
