using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace _2d_Yahtzee_v2
{
    /// <summary>
    /// Interaction logic for Gamewindow.xaml
    /// </summary>
    public partial class Gamewindow : Window
    {
        private int backgroundRepetitionCount = 0;
        private DispatcherTimer timer = new DispatcherTimer();
        private int rollCount;  
        private DispatcherTimer timer2 = new DispatcherTimer();
        private string PlayerName;
        
        public Gamewindow()
        {
            InitializeComponent();
            string playerName = ((App)Application.Current).SharedDataStore.playerName;
            PlayerNameLabel.Content = $"Hello, {playerName}!";
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer2.Tick += Timer2_Tick;
            timer2.Interval = TimeSpan.FromSeconds(5);
            

            
            
        }
        //timer2 laat 2e gif zien als 2dYahtzee is gegooid
        private void Timer2_Tick(object sender, EventArgs e)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,,/Images/jeej.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gifImage, image);
            ImageBehavior.SetRepeatBehavior(gifImage, new System.Windows.Media.Animation.RepeatBehavior(8));
        }
        private void ExitGamewindowButton_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide(); 
            
        }      
        private void RollDiceButton_Click(object sender, RoutedEventArgs e)
        {
            rollCount++;
            AttemptsTextblock.Text = $"Attempts:\n\n{rollCount}\n\nTimes!"; 
            ((App)Application.Current).SharedDataStore.diceButtonCount = rollCount;
            if (((App)Application.Current).SharedDataStore.playerName == null)
            {
                PlayerName = "?";
            }
            else 
            {
                PlayerName = ((App)Application.Current).SharedDataStore.playerName;
            }
            //PlayerName = ((App)Application.Current).SharedDataStore.playerName;
            FontFamily fontFamily = new FontFamily("Calibri");
            FontWeight fontWeight = FontWeights.Bold;
            double fontSize = 22;    
            Random random = new Random();           
            int[] randomNumbers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                randomNumbers[i] = random.Next(1, 3); 
            }
            if (randomNumbers.All(x => x == 1) || randomNumbers.All(x => x == 2))
            {
                RollDiceButton.Visibility = Visibility.Hidden;
                RollDiceLabel.Visibility = Visibility.Hidden;
                ((App)Application.Current).SharedDataStore.diceButtonCount = rollCount;
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("pack://application:,,,/Images/jim-carrey-bingo.gif");
                image.EndInit();
                ImageBehavior.SetAnimatedSource(gifImage, image);
                ImageBehavior.SetRepeatBehavior(gifImage, new System.Windows.Media.Animation.RepeatBehavior(5));
                timer.Start();
                timer2.Start();               
                if (((App)Application.Current).SharedDataStore.highScores.ContainsKey(PlayerName))
                {
                    int existingScore = ((App)Application.Current).SharedDataStore.highScores[PlayerName];
                    if (rollCount < existingScore)
                    {                       
                        ((App)Application.Current).SharedDataStore.highScores[PlayerName] = rollCount;
                    }
                   
                }
                else
                {           
                    ((App)Application.Current).SharedDataStore.highScores[PlayerName] = rollCount;                
                }
            }
            else
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("pack://application:,,,/Images/jim-carrey-sad.gif");
                image.EndInit();
                ImageBehavior.SetAnimatedSource(gifImage, image);
                ImageBehavior.SetRepeatBehavior(gifImage, new System.Windows.Media.Animation.RepeatBehavior(1));
            }           
            DiceStackPanel.Children.Clear();          
            for (int i = 1; i <= 5; i++)
            {
                TextBlock diceLabel = new TextBlock();
                diceLabel.Text = $"Dice {i}: {randomNumbers[i - 1]}";
                if (randomNumbers[i -1] == 1)
                {
                    diceLabel.Foreground = Brushes.White;
                }
                else if (randomNumbers[i - 1] == 2)
                {
                    diceLabel.Foreground = Brushes.Blue;
                }
                DiceStackPanel.Children.Add(diceLabel);
                diceLabel.FontFamily = fontFamily;
                diceLabel.FontWeight = fontWeight;
                diceLabel.FontSize = fontSize;               
            }
        }
        //timer laat achtergrond veranderen als 2DYahtzee is gegooid, vervolgens word de WinnerWindow getoont. 
        private void Timer_Tick(object sender, EventArgs e) 
        {
            if (backgroundRepetitionCount < 10)
            {
                var backgroundimage = new BitmapImage();
                backgroundimage.BeginInit();
                backgroundimage.UriSource = new Uri("pack://application:,,,/Images/fireworks.gif");
                backgroundimage.EndInit();
                ImageBehavior.SetAnimatedSource(BackgroundGameWindow, backgroundimage);
                ImageBehavior.SetRepeatBehavior(BackgroundGameWindow, new System.Windows.Media.Animation.RepeatBehavior(10));
                backgroundRepetitionCount++;
            }
            else
            {
                timer.Stop();
                WinnerWindow winnerWindow = new WinnerWindow();
                winnerWindow.Show();
                this.Hide();
            }
        }

        private void stopMusic_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void startMusic_Click(object sender, RoutedEventArgs e)
        {
        }  
    }  
}
