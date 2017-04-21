
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.DAL.Classes
{
    public class DALAdmin 
    {
            ResturantDatabase database = null;
      public  DALAdmin ()
            {
                database = new ResturantDatabase();
            }


        public bool addAdmins(Admin _admins)
        {
            database.Admins.Add(_admins);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateAdmins(Admin _admins)
        {
            database.Entry(_admins).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteAdmins(int _id)
        {
            database.Admins.Remove(getAdminsById(_id));
            return database.SaveChanges() != -1 ? true : false;
        }

        public Admin getAdminsById(int _id)
        {
            return database.Admins.FirstOrDefault(Admin => Admin.Id == _id);
        }

        public List<Admin> getListOfAdmins()
        {
            return database.Admins.ToList();
        }

        public Admin authenticateAdmin(string _email,string _password)
        {
            return database.Admins.FirstOrDefault(admin => admin.Email.Equals(_email) && admin.Password.Equals(_password));
        }
    }
}