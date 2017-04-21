using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.DAL.Classes
{
    public class DALSpecialOffer
    {
        ResturantDatabase database = null;
        public DALSpecialOffer()
        {
            database = new ResturantDatabase();
        }   
        public List<SpecialOffer> getListOfSpecialOffer()
        {
            return database.SpecialOffers.ToList();
        }
        public bool UpdateSpecialOffer(SpecialOffer _SpecialOffer)
        {
            database.Entry(_SpecialOffer).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public SpecialOffer getSpecialOfferById(int _id)
        {
            return database.SpecialOffers.FirstOrDefault(add => add.Id == _id);
        }

        public bool deleteSpecialOffer(int _taxId)
        {
            SpecialOffer _tax = getSpecialOfferById(_taxId);
            database.SpecialOffers.Remove(_tax);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool addSpecialOffer(SpecialOffer _specialOffer)
        {
            database.SpecialOffers.Add(_specialOffer);
            return database.SaveChanges() != -1 ? true : false;
        }



    }
}