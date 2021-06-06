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

        public List<CateringItem> purchasedItems = new List<CateringItem>();

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
                    else if (productSelected == "")
                    {
                        return "You Must Choose A Product Code.";
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
                        CurrentBalance -= (item.PurchasePrice * amountSelected);
                        CateringItem purchasedItem = new CateringItem(productSelected, item.Name, item.PurchasePrice, amountSelected);
                        purchasedItems.Add(purchasedItem);
                        return "Item Purchased!";

                    }
                }
            }
            return "Product not found";

        }
        public string TransactionComplete()
        {
            string orderOutput = "";
            double totalPerItem = 0;
            double orderTotal = 0;

            foreach (CateringItem item in purchasedItems)
            {

                totalPerItem = item.Quantity * item.PurchasePrice;
                orderTotal = orderTotal + totalPerItem;

                orderOutput += item.Quantity + " | " + item.Name + " | " + item.PurchasePrice.ToString("c") + " | " + totalPerItem.ToString("c") + "\n";
            }
            orderOutput += "Shopping cart total. " + orderTotal;
            CurrentBalance = 0;
            return orderOutput;
        }
    }
    
}













