using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering
        public double CurrentBalance { get; private set; }

        private List<CateringItem> items = new List<CateringItem>();

        public Catering()
        {
            items.AddRange(data.GetItems());
        }

        private FileAccess data = new FileAccess();
        public CateringItem[] GetItems()
        {
            CateringItem[] item = items.ToArray();
            return item;

        }
        public bool AddMoney(double moneyAdded)
        {
            if (CurrentBalance + moneyAdded > 5000)
            {
                return false;
            }
            else
            {
                CurrentBalance += moneyAdded;

            }

            return true;
        }
        public string ProductSelection(string productSelected, int amountSelected)
        {


            foreach (CateringItem item in items)
            {

                if (productSelected == item.ProductCode)
                {
                    //Do something
                    if (amountSelected > item.Quantity)
                    {
                        return "Insufficient Stock!";
                    }
                    else if (item.Quantity == 0)
                    {
                        return "Item Out Of Stock";
                    }
                    else if (CurrentBalance < item.PurchasePrice)
                    {
                        return "Account Balance Low!";
                    }
                    else
                    {
                        item.Quantity -= amountSelected;
                        return "Item Purchased!";
                    }
                }
                
               item.PurchasePrice -= CurrentBalance;
            }

            return "Product not found";

        }
    }
}













