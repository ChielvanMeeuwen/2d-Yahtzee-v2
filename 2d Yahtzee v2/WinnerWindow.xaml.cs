using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace _2d_Yahtzee_v2
{
    /// <summary>
    /// Interaction logic for WinnerWindow.xaml
    /// </summary>
    public partial class WinnerWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private int diceButtonCount;
        private bool greatJob;
        private bool awsomeJob;
        private bool badJob;
        public WinnerWindow()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Start();
            WinnerStackPanel.Visibility = Visibility.Hidden;
            diceButtonCount = ((App)Application.Current).SharedDataStore.diceButtonCount;
            NumberOfAttemptsLabel.Visibility = Visibility.Hidden;
            MenuSettingsStackpanel.Visibility = Visibility.Hidden;
            if (diceButtonCount == 1) 
            {
                awsomeJob = true;
            }          
            if (diceButtonCount > 1 && diceButtonCount <= 15) 
            {
                greatJob = true;  
            }
            if (diceButtonCount > 15)
            {
                badJob = true;  
            }
            if (((App)Application.Current).SharedDataStore.highscore == true)
            {
                var highscoreimage = new BitmapImage();
                highscoreimage.BeginInit();
                highscoreimage.UriSource = new Uri("pack://application:,,,/Images/highscore.jpg");
                highscoreimage.EndInit();
                ImageBehavior.SetAnimatedSource(WinnerWindowBackground, highscoreimage);
            }
        }        
        private void Timer_Tick(object sender, EventArgs e)
        {            
            var winnerimage = new BitmapImage();
            winnerimage.BeginInit();
            winnerimage.UriSource = new Uri("pack://application:,,,/Images/Winner 2.jpg");
            winnerimage.EndInit();
            ImageBehavior.SetAnimatedSource(WinnerWindowBackground, winnerimage);
            NumberOfAttemptsLabel.Visibility= Visibility.Visible;
            if (awsomeJob == true)
            {
                NumberOfAttemptsLabel.Content = $"Insane!! 2DYahtzee in one roll!";
            }
            
            if (greatJob == true) 
            {
                NumberOfAttemptsLabel.Content = $"Great Job!! You needed {diceButtonCount} times to get 2DYahtzee!";
            }
            if (badJob == true)
            {
                NumberOfAttemptsLabel.Content = $"You can do Better!! {diceButtonCount} times is a wee bit much!!";
            }
            WinnerStackPanel.Visibility= Visibility.Visible;
            MenuSettingsStackpanel.Visibility= Visibility.Visible;
        }
        private void PlayAgainYes_Click(object sender, RoutedEventArgs e)
        {
            Gamewindow gameWindow = new Gamewindow();
            gameWindow.Show();
            this.Hide();
        }
        private void PlayAgainNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings settingsWindow = new Settings();
            settingsWindow.Show();
            this.Hide();
        }
    }
}
