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

namespace _2d_Yahtzee_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            mediaPlayer.Open(new Uri(string.Format("{0}\\menu music.wav", AppDomain.CurrentDomain.BaseDirectory)));
            if (((App)Application.Current).SharedDataStore.musicplay == true)
            {
                mediaPlayer.Play();
                mediaPlayer.Volume = 0.1;
            }
        }
        private void OpenSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            Settings settingsWindow = new Settings();
            settingsWindow.Show();
            this.Hide();   
            
        }
        private void ExitProgramButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();

        }
        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            Gamewindow gameWindow = new Gamewindow();
            gameWindow.Show();
            this.Hide();
             
        }
    }
}
