using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.Model
{
    public class Product
    {
         public string  Barcode { get; set; }
        public string Name   { get; set; }

        public int Quantity { get; set; }

        public int Total { get; set; }

        public int UnitPrice { get; set; }

        public DateTime EntryDate { get; set; }

    }
}