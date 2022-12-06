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
    /// Логика взаимодействия для ToolsWindow.xaml
    /// </summary>
    public partial class ToolsWindow : Window
    {
        public ToolsWindow()
        {
            InitializeComponent();
            ToolsList.ItemsSource = App.Connection.Tools.ToList();
        }

        private void EventAddTool(object sender, RoutedEventArgs e)
        {
            List<int> idTools = new List<int>();
            InventoryTools tools = new InventoryTools();
            Tools selectedTool = ToolsList.SelectedItem as Tools;
            var carpenterWindow = new CarpenterWindow();

            foreach (InventoryTools inventoryTool in App.Connection.InventoryTools.ToList())
            {
                idTools.Add(inventoryTool.idTool);
            }

            if (ToolsList.SelectedItem != null)
            {
                bool isEquiped = false;
                tools.idTool = selectedTool.idTool;
                tools.idInventory = 1;
                foreach (int id in idTools)
                {
                    if (tools.idTool == id)
                    {
                        MessageBox.Show("Предмет уже находится в инвентаре!");
                        isEquiped = true;
                        carpenterWindow.Show();
                        this.Close();
                    }
                }
                if (!isEquiped)
                {
                    App.Connection.InventoryTools.Add(tools);
                    App.Connection.SaveChanges();
                    carpenterWindow.Show();
                    this.Close();
                }
            }

            else
            {
                MessageBox.Show("Выберите предмет");
            }
        }
    }
}
