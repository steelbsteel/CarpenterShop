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
    /// Логика взаимодействия для WoodDetailsReceipts.xaml
    /// </summary>
    public partial class DetailsReceiptsWIndow : Window
    {
        public DetailsReceiptsWIndow()
        {
            InitializeComponent();

            List<Receipt> receipts = new List<Receipt>();

            List<DetailReceipts> detailReceipts = App.Connection.DetailReceipts.ToList();

            List<WoodDetails> woodDetails = App.Connection.WoodDetails.ToList();
            List<MetalDetails> metalDetails = App.Connection.MetalDetails.ToList();
            /*
            foreach (DetailReceipts detialReceipt in detailReceipts)
            {
                Receipt receipt = new Receipt();

                receipt.ImageMachine = App.Connection.Machines.FirstOrDefault(x => x.idMachine == detialReceipt.idMachine).ImageMachine;
                receipt.NameMachine = App.Connection.Machines.FirstOrDefault(x => x.idMachine == detialReceipt.idMachine).NameMachine;
                receipt.ImageMaterial = App.Connection.Materials.FirstOrDefault(x => x.idMaterial == detialReceipt.idMaterial).ImageMaterial;
                receipt.NameMaterial = App.Connection.Materials.FirstOrDefault(x => x.idMaterial == detialReceipt.idMaterial).NameMaterial;
                bool isWoodDetail = false;

                foreach (WoodDetails detail in woodDetails)
                {
                    if (detail.idDetailReceipt == detialReceipt.idDetailReceipt)
                    {
                        isWoodDetail = true;
                    }
                }

                if (isWoodDetail)
                {
                    receipt.ImageDetail = App.Connection.WoodDetails.FirstOrDefault(x => x.idDetailReceipt == detialReceipt.idDetailReceipt).ImageWoodDetail;
                    receipt.NameDetail = App.Connection.WoodDetails.FirstOrDefault(x => x.idDetailReceipt == detialReceipt.idDetailReceipt).NameWoodDetail;
                }

                else
                {
                    receipt.ImageDetail = App.Connection.MetalDetails.FirstOrDefault(x => x.idDetailReceipt == detialReceipt.idDetailReceipt).ImageMetalDetail;
                    receipt.NameDetail= App.Connection.MetalDetails.FirstOrDefault(x => x.idDetailReceipt == detialReceipt.idDetailReceipt).NameMetalDetail;
                }

                receiptsImages.Add(receipt);
            }
            */

            foreach (MetalDetails detail in metalDetails)
            {
                Receipt receipt = new Receipt();

                receipt.ImageDetail = detail.ImageMetalDetail;
                receipt.NameDetail = detail.NameMetalDetail;

                var idMachine = App.Connection.DetailReceipts.FirstOrDefault(x => x.idDetailReceipt == detail.idDetailReceipt).idMachine;
                var idMaterial = App.Connection.DetailReceipts.FirstOrDefault(x => x.idDetailReceipt == detail.idDetailReceipt).idMaterial;

                receipt.ImageMachine = App.Connection.Machines.FirstOrDefault(x => x.idMachine == idMachine).ImageMachine;
                receipt.NameMachine = App.Connection.Machines.FirstOrDefault(x => x.idMachine == idMachine).NameMachine;

                receipt.ImageMaterial = App.Connection.Materials.FirstOrDefault(x => x.idMaterial == idMaterial).ImageMaterial;
                receipt.NameMaterial = App.Connection.Materials.FirstOrDefault(x => x.idMaterial == idMaterial).NameMaterial;

                receipts.Add(receipt);
            }

            foreach (WoodDetails detail in woodDetails)
            {
                Receipt receipt = new Receipt();

                receipt.ImageDetail = detail.ImageWoodDetail;
                receipt.NameDetail = detail.NameWoodDetail;

                var idMachine = App.Connection.DetailReceipts.FirstOrDefault(x => x.idDetailReceipt == detail.idDetailReceipt).idMachine;
                var idMaterial = App.Connection.DetailReceipts.FirstOrDefault(x => x.idDetailReceipt == detail.idDetailReceipt).idMaterial;

                receipt.ImageMachine = App.Connection.Machines.FirstOrDefault(x => x.idMachine == idMachine).ImageMachine;
                receipt.NameMachine = App.Connection.Machines.FirstOrDefault(x => x.idMachine == idMachine).NameMachine;

                receipt.ImageMaterial = App.Connection.Materials.FirstOrDefault(x => x.idMaterial == idMaterial).ImageMaterial;
                receipt.NameMaterial = App.Connection.Materials.FirstOrDefault(x => x.idMaterial == idMaterial).NameMaterial;

                receipts.Add(receipt);
            }

            DetailsReceiptsList.ItemsSource = receipts;
        }
    }
}
