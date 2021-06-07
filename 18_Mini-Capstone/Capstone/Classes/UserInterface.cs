using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere

        // ALL instances of Console.ReadLine and Console.WriteLine should 
        // be in this class.
        // NO instances of Console.ReadLine or Console.WriteLIne should be
        // in any other class.

        private Catering catering = new Catering();


        public void RunInterface()
        {
            bool done = false;
            while (!done)

            {
                Console.WriteLine();
                MainMenu();
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CateringItems();               // will come back to complete method
                        break;
                    case "2":
                        OrderMenu();
                        break;
                    case "3":
                        done = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;

                }

            }

        }
        private void MainMenu()

        {
           
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
            Console.WriteLine();
        }

        private void CateringItems()
        {
            
            Console.WriteLine("Here are all the available catering items: ");   // how do we implement catering here?
            CateringItem[] item = catering.GetItems();
            Console.WriteLine();

            foreach (CateringItem menuItems in item)               // goes through list CateringItem...GetItems is name of Method we used to read the file
            {
                Console.WriteLine(menuItems.ToString());           // this returns everything in our properties in a string

            }
        }

        private void OrderMenu()
        {

            bool done = false;
            while (!done)
            {
                DisplayOrderMenu();                                            // method cant call itself ..need make Display Order Menu
                string input = Console.ReadLine();

                switch (input)

                {
                    case "1":
                        AddMoney();               // will come back to complete method
                        break;
                    case "2":
                        ProductSelection();
                        break;
                    case "3":
                        TransactionComplete();
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }
        public void DisplayOrderMenu()

        {
            Console.WriteLine("(1) Add Money ");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine("Current Account Balance: " + catering.CurrentBalance);

        }
        public void AddMoney()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter whole dollar amount up to $5000");
            double userInput = int.Parse(Console.ReadLine());

            if (catering.AddMoney(userInput))
            {
                Console.WriteLine();
                Console.WriteLine("Money successfully added!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Amount exceeded 5000, Please enter different amount.");
            }

        }
        private void ProductSelection()
        {
            {

                CateringItem[] item = catering.GetItems();
                foreach (CateringItem menuItems in item)
                    Console.WriteLine(menuItems.ToString());

                Console.WriteLine();
                Console.WriteLine("Please enter valid product code of product desired.");
                string productSelected = Console.ReadLine();


                if (productSelected == "")
                {

                }

                string amountWanted = "";
                while (amountWanted.Length <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter Quantity amount above 1.");

                    amountWanted = Console.ReadLine();
                }
                int amountSelected = int.Parse(amountWanted);

                string result = "";

                result = catering.ProductSelection(productSelected, amountSelected);

                Console.WriteLine();
                Console.WriteLine(result);
                Console.ReadLine();

            }
        }
        private void TransactionComplete()
        {
            Console.WriteLine();
            Console.WriteLine("This is your changeback: " + catering.CurrentBalance);

            string orderOutput = catering.TransactionComplete();

            Console.WriteLine(orderOutput);

 
        }
        
    }
}
    

