using Resturant.DAL.Classes;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.BAL
{
    public class BLResturantDetails
    {
        #region ResturantDetail
        public List<ResturantDetail> getListOfResturantDetail()
        {
            return new DALResturantDetail().getListOfResturantDetail();
        }
        //Error
        public bool addResturantDetail(ResturantDetail _ResturantDetail)
        {
            return new DALResturantDetail().addResturantDetail(_ResturantDetail);
        }

        public bool deleteResturantDetail(int _Id)
        {
            return new DALResturantDetail().deleteResturantDetail(_Id);
        }

        public ResturantDetail getResturantDetailById(int _id)
        {
            return new DALResturantDetail().getResturantDetailById(_id);
        }

        public bool UpdateResturantDetail(ResturantDetail _ResturantDetail)
        {
            return new DALResturantDetail().UpdateResturantDetail(_ResturantDetail);
        }
        #endregion

        #region Branch
        public List<Branch> getListOfBranch()
        {
            return new DALResturantDetail().getListOfBranch();
        }
        //Error
        public bool addBranch(Branch _Branch)
        {
            return new DALResturantDetail().addBranch(_Branch);
        }

        public bool deleteBranch(int _Id)
        {
            return new DALResturantDetail().deleteBranch(_Id);
        }

        public Branch getBranchById(int _id)
        {
            return new DALResturantDetail().getBranchById(_id);
        }

        public bool UpdateBranch(Branch _Branch)
        {
            return new DALResturantDetail().UpdateBranch(_Branch);
        }
        #endregion
    }
}