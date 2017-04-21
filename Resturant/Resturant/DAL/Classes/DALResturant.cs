using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.DAL.Classes
{
    public class DALResturant
    {
        ResturantDatabase database = null;

          public DALResturant()
    {
        database = new ResturantDatabase();
    }
    #region ResturantDetail
          public bool addResturantDetail(ResturantDetail ResturantDetail)
    {
        database.ResturantDetails.Add(ResturantDetail);
        return database.SaveChanges() != -1? true : false;
    }

    public bool updateResturantDetail(ResturantDetail ResturantDetail)
    {
        database.Entry(ResturantDetail).State = System.Data.EntityState.Modified;
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool deleteResturantDetail(ResturantDetail ResturantDetail)
    {
        database.ResturantDetails.Remove(ResturantDetail);
        return database.SaveChanges() != -1 ? true : false;
    }

    public ResturantDetail getResturantDetailById(int id)
    {
        return database.ResturantDetails.FirstOrDefault(ResturantDetail => ResturantDetail.Id == id);
    }

    public List<ResturantDetail> getListOfResturantDetail()
    {
        return database.ResturantDetails.ToList();
    }
    #endregion

    #region Branch
    public bool addBranch(Branch Branch)
    {
        database.Branches.Add(Branch);
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool updateBranch(Branch Branch)
    {
        database.Entry(Branch).State = System.Data.EntityState.Modified;
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool deleteBranch(Branch Branch)
    {
        database.Branches.Remove(Branch);
        return database.SaveChanges() != -1 ? true : false;
    }

    public Branch getBranchById(int id)
    {
        return database.Branches.FirstOrDefault(Branch => Branch.Id == id);
    }

    public List<Branch> getListOfBranch()
    {
        return database.Branches.ToList();
    }
    #endregion

    #region Postcode
    public bool addPostcode(Postcode Postcode)
    {
        database.Postcodes.Add(Postcode);
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool updatePostcode(Postcode Postcode)
    {
        database.Entry(Postcode).State = System.Data.EntityState.Modified;
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool deletePostcode(Postcode Postcode)
    {
        database.Postcodes.Remove(Postcode);
        return database.SaveChanges() != -1 ? true : false;
    }

    public Postcode getPostcodeById(int id)
    {
        return database.Postcodes.FirstOrDefault(Postcode => Postcode.Id == id);
    }

    public List<Postcode> getListOfPostcode()
    {
        return database.Postcodes.ToList();
    }
    #endregion

    }
}