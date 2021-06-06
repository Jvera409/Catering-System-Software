﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class FileAccess
    {
        // all files for this application should in this directory
        // you will likley need to create it on your computer
        private string filePath = @"C:\Catering\cateringsystem.csv";

        // This class should contain any and all details of access to files
        public CateringItem[] GetItems()
        {
            List<CateringItem> items = new List<CateringItem>();


            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split('|');
                    CateringItem menuItems = new CateringItem();

                    menuItems.ProductCode = split[0];
                    menuItems.Name = split[1];
                    menuItems.PurchasePrice = double.Parse(split[2]);
                    

                    items.Add(menuItems);


                }


            }

            return items.ToArray();                         // had to add return .ToArray because we used string[]
        }
        public bool SetItems(CateringItem[] items)
        {
            return false;
        }

        public bool SetItems(List<CateringItem> items)
        {
            using(StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(DateTime.UtcNow);

                foreach(CateringItem item in items)
                {
                    string log = $"{item.ProductCode}, {item.Name}, {item.PurchasePrice}, {item.Quantity}";
                    sw.WriteLine(log);
                }
            }
            return true;
        }
    }
}