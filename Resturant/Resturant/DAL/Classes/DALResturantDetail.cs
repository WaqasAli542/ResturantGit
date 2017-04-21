using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.DAL.Classes
{
    public class DALResturantDetail
    {
        ResturantDatabase database = null;

        public DALResturantDetail()
        {
            database = new ResturantDatabase();
        }

        #region Resturant
        public bool addResturantDetail(ResturantDetail _ResturantDetail)
        {
            database.ResturantDetails.Add(_ResturantDetail);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool UpdateResturantDetail(ResturantDetail _ResturantDetail)
        {
            database.Entry(_ResturantDetail).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteResturantDetail(int _Id)
        {
            ResturantDetail _ResturantDetail = database.ResturantDetails.FirstOrDefault(Res=>Res.Id==_Id);
            database.ResturantDetails.Remove(_ResturantDetail);
            return database.SaveChanges() != -1 ? true : false;
        }

        public ResturantDetail getResturantDetailById(int _id)
        {
            return database.ResturantDetails.FirstOrDefault(ResturantDetail => ResturantDetail.Id == _id);
        }

        public List<ResturantDetail> getListOfResturantDetail()
        {
            return database.ResturantDetails.ToList();
        }


        #endregion

        #region Branch
        public bool addBranch(Branch _Branch)
        {
            database.Branches.Add(_Branch);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool UpdateBranch(Branch _Branch)
        {
            database.Entry(_Branch).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteBranch(int _Id)
        {
            Branch _Branch = database.Branches.FirstOrDefault(Res => Res.Id == _Id);
            database.Branches.Remove(_Branch);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Branch getBranchById(int _id)
        {
            return database.Branches.FirstOrDefault(Branch => Branch.Id == _id);
        }

        public List<Branch> getListOfBranch()
        {
            return database.Branches.ToList();
        }


        #endregion

    }
}