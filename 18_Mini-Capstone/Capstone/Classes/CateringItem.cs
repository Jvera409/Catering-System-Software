using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public double PurchasePrice { get; set; }
        public int Quantity { get; set; } = 50;             // all item start out at 50                                             // This class should contain the definition for one catering item



        public CateringItem(string productCode, string name, double purchasePrice, int quantity)        // constructor for our properties
        {
            ProductCode = productCode;
            Name = name;
            PurchasePrice = purchasePrice;
            Quantity = quantity;

        }

        public CateringItem()
        {
        }

        public override string ToString()                    // converts all to string to be presented as string 
        {

            return ProductCode + " | " + Name + " | " + PurchasePrice + " | " + Quantity;

        }


    }
}