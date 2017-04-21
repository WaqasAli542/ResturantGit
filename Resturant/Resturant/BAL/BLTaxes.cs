using Resturant.DAL.Classes;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.BAL
{
    public class BLTax
    {
        #region Tax
        public List<Tax> getListOfTax()
        {
            return new DALTax().getListOfTax();
        }
        //Error
        public bool addTax(Tax _Tax)
        {
            return new DALTax().addTax(_Tax);
        }

        public bool deleteTax(int _Id)
        {
            return new DALTax().deleteTax(_Id);
        }

        public Tax getTaxById(int _id)
        {
            return new DALTax().getTaxById(_id);
        }

        public bool UpdateTax(Tax _Tax)
        {
            return new DALTax().UpdateTax(_Tax);
        }
        #endregion
    }
}