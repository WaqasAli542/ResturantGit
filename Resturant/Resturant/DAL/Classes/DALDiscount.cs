using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.DAL.Classes
{
    public class DALDiscount
    {
        ResturantDatabase database = null;

        public DALDiscount()
        {
            database = new ResturantDatabase();
        }
        public bool addDiscount(Discount _Discount)
        {
            database.Discounts.Add(_Discount);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool UpdateDiscount(Discount _Discount)
        {
            database.Entry(_Discount).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteDiscount(int _id)
        {
            Discount _discount = getDiscountById(_id);
            if (_discount != null)
                database.Discounts.Remove(_discount);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Discount getDiscountById(int _id)
        {
            return database.Discounts.FirstOrDefault(Discount => Discount.Id == _id);
        }

        public List<Discount> getListOfDiscount()
        {
            return database.Discounts.ToList();
        }

        public Discount getDiscountByCategoryId(int _Id)
        {
            return database.Discounts.FirstOrDefault(dis => dis.CategoryId == _Id);
        }
    }

       
}