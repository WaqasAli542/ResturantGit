
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.DAL.Classes
{
    public class DALExtraCharge 
    {
            ResturantDatabase database = null;

        public DALExtraCharge()
            {
                database = new ResturantDatabase();
            }
            public ExtraCharge getExtraChargesById(int _id)
            {
                return database.ExtraCharges.FirstOrDefault(ExtraCharge => ExtraCharge.Id == _id);
            }

            public List<ExtraCharge> getListOfExtraCharges()
            {
                return database.ExtraCharges.ToList();
            }
        public bool addExtraCharges(ExtraCharge _extraCharges)
        {
            database.ExtraCharges.Add(_extraCharges);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateExtraCharges(ExtraCharge _extraCharges)
        {
            database.Entry(_extraCharges).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteExtraCharges(int _id)
        {
            ExtraCharge _extraCharges = getExtraChargesById(_id);
            database.ExtraCharges.Remove(_extraCharges);
            return database.SaveChanges() != -1 ? true : false;
        }

     
    }
}