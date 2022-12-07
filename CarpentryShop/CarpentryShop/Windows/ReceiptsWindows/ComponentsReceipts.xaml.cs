using CarpentryShop.CarpentryShopDB;
using CarpentryShop.Data;
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

namespace CarpentryShop.Windows.ReceiptsWindows
{
    /// <summary>
    /// Логика взаимодействия для ComponentsReceipts.xaml
    /// </summary>
    public partial class ComponentsReceipts : Window
    {
        public ComponentsReceipts()
        {
            InitializeComponent();

            List<Components> components = App.Connection.Components.ToList();
            List<Receipt> receipts = new List<Receipt>();

            foreach(Components component in components)
            {
                Receipt receipt= new Receipt();

                receipt.NameComponent = component.Name;
                receipt.ImageComponent= component.Image;

                var idMachine = App.Connection.ComponentReceipts.FirstOrDefault(x => x.idCompontentReceipt == component.idComponentReceipt).idMachine;
                var idMetalDetail = App.Connection.ComponentReceipts.FirstOrDefault(x => x.idCompontentReceipt == component.idComponentReceipt).idMetalDetail;
                var idWoodDetail = App.Connection.ComponentReceipts.FirstOrDefault(x => x.idCompontentReceipt == component.idComponentReceipt).idWoodDetail;
                var idTool = App.Connection.ComponentReceipts.FirstOrDefault(x => x.idCompontentReceipt == component.idComponentReceipt).idTool;

                if (idMachine != null)
                {
                    receipt.ImageMachine = App.Connection.Machines.FirstOrDefault(x => x.idMachine == idMachine).ImageMachine;
                    string name = $"{App.Connection.Machines.FirstOrDefault(x => x.idMachine == idMachine).NameMachine}   +   ";
                    receipt.NameMachine = name;
                }
                if (idWoodDetail != null)
                {
                    receipt.ImageWoodDetail = App.Connection.WoodDetails.FirstOrDefault(x => x.idWoodDetail == idWoodDetail).ImageWoodDetail;
                    string name = $"{App.Connection.WoodDetails.FirstOrDefault(x => x.idWoodDetail == idWoodDetail).NameWoodDetail}   +   ";
                    receipt.NameWoodDetail = name;
                }
                if (idMetalDetail != null)
                {
                    receipt.ImageMetalDetail = App.Connection.MetalDetails.FirstOrDefault(x => x.idMetalDetail == idMetalDetail).ImageMetalDetail;
                    string name = $"{App.Connection.MetalDetails.FirstOrDefault(x => x.idMetalDetail == idMetalDetail).NameMetalDetail}   +   ";
                    receipt.NameMetalDetail = name;
                }

                if (idTool != null)
                {
                    receipt.ImageTool = App.Connection.Tools.FirstOrDefault(x => x.idTool == idTool).ImageTool;
                    string name = $"{App.Connection.Tools.FirstOrDefault(x => x.idTool == idTool).NameTool}   +   ";
                    receipt.NameTool = name;
                }
                receipts.Add(receipt);
            }

            ComponentsReceiptsList.ItemsSource = receipts;
        }
    }
}
