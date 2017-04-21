using Resturant.DAL.Classes;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.BAL
{
    public class BLBranch
    {
        public bool addPostcodes(Postcode _Postcodes)
        {
            return new DALPostcode().addPostcodes(_Postcodes);
        }
        public bool updatePostcodes(Postcode _Postcodes)
        {
            return new DALPostcode().updatePostcodes(_Postcodes);
        }
        public bool deletePostcodes(int _id)
        {
            return new DALPostcode().deletePostcodes(_id);
        }
        public Postcode getPostcodesById(int _id)
        {
            return new DALPostcode().getPostcodesById(_id);
        }
        public List<Postcode> getListOfPostcodes()
        {
            return new DALPostcode().getListOfPostcodes();
        }
        public int isValidPostcode(string _value)
        {
            Branch branch=new DALPostcode().getListOfPostcodes().FirstOrDefault(postcode => postcode.PostCodeValue.Equals(_value)).Branch;
            return branch != null ? branch.Id : -1;
        }
    }
}