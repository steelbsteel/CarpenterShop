using CarpentryShop.CarpentryShopDB;
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
using System.Windows.Shapes;

namespace CarpentryShop.Windows.MachinesWindow
{
    /// <summary>
    /// Логика взаимодействия для PossibleDetailsChoose.xaml
    /// </summary>
    public partial class PossibleDetailsChoose : Window
    {
        public PossibleDetailsChoose(List<MetalDetails> metalDetails)
        {
            InitializeComponent();
            PossibleDetails.ItemsSource = metalDetails;
        }

        private void EventCreateDetail(object sender, RoutedEventArgs e)
        {
            if (PossibleDetails.SelectedItem != null)
            {
                MetalDetails detail = PossibleDetails.SelectedItem as MetalDetails;
                MetalDetails neededDetail = App.Connection.MetalDetails.FirstOrDefault(x => x.NameMetalDetail == detail.NameMetalDetail);
                DetailReceipts receipt = App.Connection.DetailReceipts.FirstOrDefault(x => x.idDetailReceipt == neededDetail.idDetailReceipt);
                InventoryMaterials materialToDelete = App.Connection.InventoryMaterials.FirstOrDefault(x => x.idMaterial == receipt.idMaterial);

                InventoryMetalDetails inventoryDetail = new InventoryMetalDetails();
                inventoryDetail.idMetalDetail = neededDetail.idMetalDetail;
                inventoryDetail.idInventory = 1;

                App.Connection.InventoryMaterials.Remove(materialToDelete);
                App.Connection.InventoryMetalDetails.Add(inventoryDetail);
                App.Connection.SaveChanges();
                MessageBox.Show("Деталь успешно создана!");
                var window = new CarpenterWindow();
                window.Show();
                this.Close();
            }
        }
    }
}
