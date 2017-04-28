using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.Models
{
    public class Items
    {
        public int Quantitity;
       public  string Name;
       public  string price;

        public Items(int Quan,string N,string pr)
        {
            this.Quantitity = Quan;
            this.Name = N;
            this.price = pr;
        }

        public Items()
        {
            // TODO: Complete member initialization
        }
    }
}