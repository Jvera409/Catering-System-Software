using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering
        private FileAccess data = new FileAccess();
        public CateringItem[] GetItems()
        {
            CateringItem[] item = data.GetItems();
            return item;

        }




    }



}













