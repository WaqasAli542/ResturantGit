using Resturant.DAL.Classes;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.BAL
{
    public class BLSpecialOffer
    {
        #region SpecialOffer
        public List<SpecialOffer> getListOfSpecialOffer()
        {
            return new DALSpecialOffer().getListOfSpecialOffer();
        }
        //Error
        public bool addSpecialOffer(SpecialOffer _SpecialOffer)
        {
            return new DALSpecialOffer().addSpecialOffer(_SpecialOffer);
        }

        public bool deleteSpecialOffer(int _Id)
        {
            return new DALSpecialOffer().deleteSpecialOffer(_Id);
        }

        public SpecialOffer getSpecialOfferById(int _id)
        {
            return new DALSpecialOffer().getSpecialOfferById(_id);
        }

        public bool UpdateSpecialOffer(SpecialOffer _SpecialOffer)
        {
            return new DALSpecialOffer().UpdateSpecialOffer(_SpecialOffer);
        }
        #endregion
    }
}