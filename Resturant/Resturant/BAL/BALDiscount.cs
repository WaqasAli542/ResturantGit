using Resturant.DAL.Classes;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.BAL
{
    public class BLDiscount
    {
        #region Discount
        public List<Discount> getListOfDiscount()
        {
            return new DALDiscount().getListOfDiscount();
        }
        //Error
        public bool addDiscount(Discount _Discount)
        {
            return new DALDiscount().addDiscount(_Discount);
        }

        public bool deleteDiscount(int _Id)
        {
            return new DALDiscount().deleteDiscount(_Id);
        }

        public Discount getDiscountById(int _id)
        {
            return new DALDiscount().getDiscountById(_id);
        }

        public bool UpdateDiscount(Discount _Discount)
        {
            return new DALDiscount().UpdateDiscount(_Discount);
        }
        public Discount getDiscountByCategoryId(int _Id)
        {
            return new DALDiscount().getDiscountByCategoryId(_Id);
        }
        #endregion

       
    }
}