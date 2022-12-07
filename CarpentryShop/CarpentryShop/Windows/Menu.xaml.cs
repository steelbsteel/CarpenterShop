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
using System.IO;
using Microsoft.Win32;
using CarpentryShop.CarpentryShopDB;
using CarpentryShop.Windows;

namespace CarpentryShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void EventEnterButton(object sender, RoutedEventArgs e)
        {
            MediaPlayer mp3player = new MediaPlayer();
            mp3player.Open(new Uri("C:/Users/user/source/repos/CarpentryShop/CarpentryShop/CarpentryShop/MP3/Resonance.mp3", UriKind.Relative));
            //mp3player.Play();
            var window = new CarpenterWindow();
            window.Show();
            this.Close();
        }
    }
}
