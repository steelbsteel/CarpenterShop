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

            List<Tools> tools = new List<Tools>();
            List<Materials> materials = new List<Materials>();
            List<MetalDetails> metalDetails = new List<MetalDetails>();
            List<WoodDetails> woodDetails = new List<WoodDetails>();
            List<Components> components = new List<Components>();

            foreach (var tool in App.Connection.InventoryTools)
            {
                int id = tool.idTool;
                Tools currentTool = App.Connection.Tools.FirstOrDefault(x => x.idTool == id);
                tools.Add(currentTool);
            }

            foreach (var material in App.Connection.InventoryMaterials)
            {
                int id = material.idMaterial;
                Materials currentMaterial = App.Connection.Materials.FirstOrDefault(x => x.idMaterial == id);
                materials.Add(currentMaterial);
            }

            foreach (var woodDetail in App.Connection.InventoryWoodDetails)
            {
                int id = woodDetail.idWoodDetail;
                WoodDetails currentWoodDetail = App.Connection.WoodDetails.FirstOrDefault(x => x.idWoodDetail == id);
                woodDetails.Add(currentWoodDetail);
            }


            foreach (var metalDetail in App.Connection.InventoryMetalDetails)
            {
                int id = metalDetail.idMetalDetail;
                MetalDetails currentMetalDetail = App.Connection.MetalDetails.FirstOrDefault(x => x.idMetalDetail == id);
                metalDetails.Add(currentMetalDetail);
            }

            foreach (var component in App.Connection.InventoryComponents)
            {
                int id = component.idComponent;
                Components currentComponent = App.Connection.Components.FirstOrDefault(x => x.idComponent == id);
                components.Add(currentComponent);
            }

            ToolsList.ItemsSource = tools;
            MaterialsList.ItemsSource = materials;
            WoodDetailsList.ItemsSource = woodDetails;
            MetalDetailsList.ItemsSource = metalDetails;
            ComponentsList.ItemsSource = components;
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
