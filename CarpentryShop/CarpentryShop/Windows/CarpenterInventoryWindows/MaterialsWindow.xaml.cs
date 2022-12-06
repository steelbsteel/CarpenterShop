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

namespace CarpentryShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для MaterialsWindow.xaml
    /// </summary>
    public partial class MaterialsWindow : Window
    {
        public MaterialsWindow()
        {
            InitializeComponent();
            MaterialsList.ItemsSource = App.Connection.Materials.ToList();
        }

        private void EventAddMaterial(object sender, RoutedEventArgs e)
        {
            InventoryMaterials materials = new InventoryMaterials();
            Materials selectedMaterial = MaterialsList.SelectedItem as Materials;
            var carpenterWindow = new CarpenterWindow();

            if (MaterialsList.SelectedItem != null)
            {
                materials.idMaterial = selectedMaterial.idMaterial;
                materials.idInventory = 1;
  
                App.Connection.InventoryMaterials.Add(materials);
                App.Connection.SaveChanges();
                carpenterWindow.Show();
                this.Close();
        }

            else
            {
                MessageBox.Show("Выберите предмет");
            }
        }
    }
}
