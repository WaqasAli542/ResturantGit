using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.DAL.Classes
{
    public class DALAddOn
    {
        ResturantDatabase database = null;

        public DALAddOn()
        {
            database = new ResturantDatabase();
        }
        public bool addAddOn(AddOn _addOn)
        {
            database.AddOns.Add(_addOn);
            return database.SaveChanges() != -1? true : false;
        }

        public bool updateAddOn(AddOn _addOn)
        {
            database.Entry(_addOn).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteAddOn(AddOn _addOn)
        {
            database.AddOns.Remove(_addOn);
            return database.SaveChanges() != -1 ? true : false;
        }

        public AddOn getAddOnById(int _id)
        {
            return database.AddOns.FirstOrDefault(AddOn => AddOn.Id == _id);
        }

        public List<AddOn> getListOfAddOn()
        {
            return database.AddOns.ToList();
        }
 
    }
}