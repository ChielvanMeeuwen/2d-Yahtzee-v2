using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace _2d_Yahtzee_v2
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
      
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private string lastClickedButton = null;
        
        public Settings()
        {
            InitializeComponent();
            mediaPlayer.Volume = 0.1;
            popUpLabel.Visibility = Visibility.Collapsed;
            highScoreLabel.Visibility = Visibility.Collapsed;
            TextBoxPlayerName.Text = ((App)Application.Current).SharedDataStore.playerName;
            if (((App)Application.Current).SharedDataStore.musicplay == true)
            {
                Audiobutton.Content = "Music is on";
            }
            if (((App)Application.Current).SharedDataStore.musicplay == false)
            {
                Audiobutton.Content = "Music is off"; 
            }
            mediaPlayer.Open(new Uri(string.Format("{0}\\bosstime.wav", AppDomain.CurrentDomain.BaseDirectory)));
            if (((App)Application.Current).SharedDataStore.musicplay == true)
            {
                mediaPlayer.Play();  
            }
            
        }      
        private void ConfirmPlayerName_Click(object sender, RoutedEventArgs e)
        {         
            ((App)Application.Current).SharedDataStore.playerName = TextBoxPlayerName.Text; 
        }
        private void ExitSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();  
            this.Hide();   
            mediaPlayer.Stop(); 
        }

        private void ContolsButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (lastClickedButton == "ControlsButton")
            {
                popUpLabel.Visibility = popUpLabel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
            else if (lastClickedButton == "HelpButton")
            {
                popUpLabel.Content = $"Controls:\n \nYou play this game \nwith the mouse\n \nWith the left \nmousebutton \nyou click on the\nbuttons";
                popUpLabel.Visibility = Visibility.Visible;
            }
            else
            {               
                popUpLabel.Content = $"Controls:\n \nYou play this game \nwith the mouse\n \nWith the left \nmousebutton \nyou click on the\nbuttons";
                popUpLabel.Visibility = Visibility.Visible;
            }
            lastClickedButton = "ControlsButton";
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {

            if (lastClickedButton == "HelpButton")
            {
                popUpLabel.Visibility = popUpLabel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
            else if (lastClickedButton == "ControlsButton")
            {
                popUpLabel.Content = $"Help:\n \nIf you need help?\n\nYou can contact us at:\n \nsupport@youdonttre\nallythinkweactuallygi\nvesupportonthisgam\ne.com";
                popUpLabel.Visibility = Visibility.Visible;
            }
            else
            {
                popUpLabel.Content = $"Help:\n \nIf you need help?\n\nYou can contact us at:\n \nsupport@youdonttre\nallythinkweactuallygi\nvesupportonthisgam\ne.com";
                popUpLabel.Visibility = Visibility.Visible;
            }
            lastClickedButton = "HelpButton";
        }

        private void HighScoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (highScoreLabel.Visibility == Visibility.Collapsed)
            {
                var highscores = ((App)Application.Current).SharedDataStore.highScores;
                highScoreLabel.Content = "Highrolls:\n";
                foreach (var entry in highscores)
                {
                    highScoreLabel.Content += $"{entry.Key}: {entry.Value} rolls\n";
                }
                highScoreLabel.Visibility = Visibility.Visible;
            }
            else
            {
                highScoreLabel.Visibility= Visibility.Collapsed;
            }
        }

        private void Audiobutton_Click(object sender, RoutedEventArgs e)
        {
           
            if (((App)Application.Current).SharedDataStore.musicplay == true)
            {
                ((App)Application.Current).SharedDataStore.musicplay = false;
                Audiobutton.Content = "Music is off";
                mediaPlayer.Pause(); 
            }     
            else
            {
                ((App)Application.Current).SharedDataStore.musicplay = true;
                Audiobutton.Content = "Music is on";
                mediaPlayer.Play();
            }
        }
    }
}
