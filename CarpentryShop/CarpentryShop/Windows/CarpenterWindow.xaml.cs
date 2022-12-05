using CarpentryShop.CarpentryShopDB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CarpentryShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для CarpenterWindow.xaml
    /// </summary>
    public partial class CarpenterWindow : Window
    {
        List<Carpenter> carpenterInfo = App.Connection.Carpenter.Where(x => x.idCarpenter == 1).ToList();
        Carpenter carpenter = App.Connection.Carpenter.First();
        public byte[] Image { get; set; }
        public CarpenterWindow()
        {
            InitializeComponent();

            CarpenterPhoto.Source = ByteToImage(carpenter.ImageCarpenter);
            NameTextBlock.Text = carpenter.NameCarpenter;
            SurnameTextBlock.Text = carpenter.SurnameCarpenter;
            StaminaTextBlock.Text = carpenter.StaminaCarpenter.ToString();
            BalanceTextBlock.Text = carpenter.BalanceCarpenter.ToString();

        }

        private void EventChangePhoto(object sender, RoutedEventArgs e)
        {
            var thisCarpenter = App.Connection.Carpenter.FirstOrDefault(x => x.idCarpenter == 1);

            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() != null)
            {
                if (dialog.FileName != null)
                {
                    Image = File.ReadAllBytes(dialog.FileName);
                    thisCarpenter.ImageCarpenter = Image;
                    App.Connection.SaveChanges();

                    MessageBox.Show("Фотография обновлена");
                }

                else
                {
                    MessageBox.Show("Выберите файл!");
                }
            }
        }

        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }
        
    }
}
