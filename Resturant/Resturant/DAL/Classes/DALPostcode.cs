using Resturant.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.DAL.Classes
{
    public class DALPostcode
    {
        ResturantDatabase database = null;

        public DALPostcode()
        {
            database = new ResturantDatabase();
        }

        public bool addPostcodes(Postcode _postcodes)
        {
            database.Postcodes.Add(_postcodes);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updatePostcodes(Postcode _postcodes)
        {
            database.Entry(_postcodes).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }



        public bool deletePostcodes(int _id)
        {
            Postcode _postcode = getPostcodesById(_id);
            if(_postcode != null)
            database.Postcodes.Remove(_postcode);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Postcode getPostcodesById(int _id)
        {
            return database.Postcodes.FirstOrDefault(Postcode => Postcode.Id == _id);
        }

        public List<Postcode> getListOfPostcodes()
        {
            return database.Postcodes.ToList();
        }
    }
}