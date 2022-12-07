using CarpentryShop.CarpentryShopDB;
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

namespace CarpentryShop.Windows.MachinesWindow
{
    /// <summary>
    /// Логика взаимодействия для SamStalWindow.xaml
    /// </summary>
    public partial class SamStalWindow : Window
    {
        public SamStalWindow()
        {
            InitializeComponent();
            MachineImage.Source = ByteToImage(App.Connection.Machines.First(x => x.idMachine == 1).ImageMachine);

            List<Materials> materialsList = new List<Materials>();

            foreach (InventoryMaterials inventoryMaterial in App.Connection.InventoryMaterials.ToList())
            {
                Materials currentMaterial = App.Connection.Materials.FirstOrDefault(x => x.idMaterial == inventoryMaterial.idMaterial);
                materialsList.Add(currentMaterial);
            }

            MaterialsInventoryList.ItemsSource = materialsList;
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

        private void EventCreateDetail(object sender, RoutedEventArgs e)
        {
            if (MaterialsInventoryList.SelectedItem != null)
            {
                List<DetailReceipts> samStalReceipts = App.Connection.DetailReceipts.Where(x => x.idMachine == 1).ToList();
                List<DetailReceipts> possibleReceipts = new List<DetailReceipts>();
                List<MetalDetails> metalDetails = App.Connection.MetalDetails.ToList();
                List<MetalDetails> possibleMetalDetails = new List<MetalDetails>();

                Materials selectedMaterial = MaterialsInventoryList.SelectedItem as Materials;

                foreach(DetailReceipts currentReceipt in samStalReceipts) //возможные рецептов с выбранным материалом
                {
                    if (currentReceipt.idMaterial == selectedMaterial.idMaterial)
                    {
                        possibleReceipts.Add(currentReceipt);
                    }
                }

                foreach(MetalDetails currentMetalDetail in metalDetails) //возможные металлических деталей с возможными рецептами
                {
                    foreach(DetailReceipts currentReceipt in possibleReceipts)
                    {
                        if(currentMetalDetail.idDetailReceipt == currentReceipt.idDetailReceipt)
                        {
                            possibleMetalDetails.Add(currentMetalDetail);
                        }
                    }
                }
                
                if (possibleMetalDetails.Count != 0)
                {
                    var window = new PossibleDetailsChoose(possibleMetalDetails);
                    window.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("с таким материалом не получится создать деталь на этом станке");
                }

            }

            else
            {
                MessageBox.Show("Выберите материал");
            }
        }
    }
}
