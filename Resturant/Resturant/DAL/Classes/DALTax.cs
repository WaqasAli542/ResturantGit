using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.DAL.Classes
{
    public class DALTax
    {
         ResturantDatabase database = null;
         public DALTax()
        {
            database = new ResturantDatabase();
        }
         #region Tax
         public List<Tax> getListOfTax()
         {
             return database.Taxes.ToList();
         }
         public bool UpdateTax(Tax _Tax)
         {
             database.Entry(_Tax).State = System.Data.EntityState.Modified;
             return database.SaveChanges() != -1 ? true : false;
         }

         public Tax getTaxById(int _id)
         {
             return database.Taxes.FirstOrDefault(add => add.Id == _id);
         }

         public bool deleteTax(int _taxId)
         {
             Tax _tax = getTaxById(_taxId);
             database.Taxes.Remove(_tax);
             return database.SaveChanges() != -1 ? true : false;
         }

         public bool addTax(Tax _Tax)
         {
             database.Taxes.Add(_Tax);
             return database.SaveChanges() != -1 ? true : false;
         }
         #endregion


    }
}