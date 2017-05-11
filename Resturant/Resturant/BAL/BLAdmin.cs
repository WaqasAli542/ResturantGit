using Resturant.DAL.Classes;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.BAL
{
    public class BLAdmin
    {
              public bool addAdmins(Admin _admins)
                 {
                return new DALAdmin().addAdmins(_admins);
                 }
              public bool updateAdmins(Admin _admins)
               {
                    return new DALAdmin().updateAdmins(_admins);
               }
              public bool deleteAdmins(int _id)
              {
                  return new DALAdmin().deleteAdmins(_id);
              }
              public Admin getAdminsById(int _id)
              {
                  return new DALAdmin().getAdminsById(_id);
              }
               public List<Admin> getListOfAdmins()
              {
                  return new DALAdmin().getListOfAdmins();
              }
             public Admin authenticateAdmin(string _email,string _password)
               {
                   return new DALAdmin().authenticateAdmin(_email, _password);
               }

    }
}