using Resturant.DAL.Classes;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.BAL
{
    public class BLExtraCharges
    {
        #region ExtraCharges
        public List<ExtraCharge> getListOfExtraCharges()
        {
            return new DALExtraCharge().getListOfExtraCharges();
        }
        //Error
        public bool addExtraCharges(ExtraCharge _ExtraCharges)
        {
            return new DALExtraCharge().addExtraCharges(_ExtraCharges);
        }

        public bool deleteExtraCharges(int _Id)
        {
            return new DALExtraCharge().deleteExtraCharges(_Id);
        }

        public ExtraCharge getExtraChargesById(int _id)
        {
            return new DALExtraCharge().getExtraChargesById(_id);
        }

        public bool UpdateExtraCharges(ExtraCharge _ExtraCharges)
        {
            return new DALExtraCharge().updateExtraCharges(_ExtraCharges);
        }
        #endregion
    }
}