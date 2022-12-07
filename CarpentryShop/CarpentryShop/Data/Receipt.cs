using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CarpentryShop.Data
{
    internal class Receipt
    {
        public byte[] ImageMaterial { get; set; }
        public string NameMaterial { get; set; }

        public byte[] ImageMachine { get; set; }
        public string NameMachine { get; set; }

        public byte[] ImageDetail { get; set; }
        public string NameDetail { get; set; }

        public byte[] ImageTool { get; set; }
        public string NameTool { get; set; }
        
        public byte[] ImageWoodDetail { get; set; }
        public string NameWoodDetail { get; set; }

        public byte[] ImageMetalDetail { get; set; }
        public string NameMetalDetail { get; set;}

        public byte[] ImageComponent { get; set; }
        public string NameComponent { get; set; }

        public byte[] ImageProduct { get; set; }
        public string NameProduct { get; set; }
        
    }
}
