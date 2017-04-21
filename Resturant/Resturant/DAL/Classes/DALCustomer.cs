using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Resturant.DAL.Classes
{
    public class DALCustomer
    {
         ResturantDatabase database = null;

         public DALCustomer()
        {
            database = new ResturantDatabase();
        }
        public List<Models.Customer> getListOfCustomers()
        {
            return database.Customers.ToList();
        }

        public bool addCustomers(Models.Customer _Customers)
        {
            database.Customers.Add(_Customers);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteCustomers(int _Id)
        {
            database.Customers.Remove(getCustomersById(_Id));
            return database.SaveChanges() != -1 ? true : false;
        }

        public Models.Customer getCustomersById(int _id)
        {
            return database.Customers.FirstOrDefault(cus => cus.Id == _id);
        }

        public bool updateCustomers(Models.Customer _Customers)
        {
            database.Entry(_Customers).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }
        public bool login(string Email, string Password)
        {
            if(database.Customers.FirstOrDefault(customer=>customer.Email.Equals(Email) && customer.Password.Equals(Password))!=null)
            {
                return true;
            }return false;

        }
    }
}