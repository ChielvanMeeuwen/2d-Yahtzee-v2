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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenSettingsButton_Click(object sender, RoutedEventArgs e)
        {            
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
            Gamewindow gameWindow = new Gamewindow();
            gameWindow.Show();
            this.Hide();
        }
    }
}
