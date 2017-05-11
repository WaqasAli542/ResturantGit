using Resturant.DAL.Classes;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.BAL
{
    public class BLCustomer
    {
        #region Customers
        public List<Customer> getListOfCustomers()
        {
            return new DALCustomer().getListOfCustomers();
        }
        //Error
        public bool addCustomers(Customer _Customers)
        {
            return new DALCustomer().addCustomers(_Customers);
        }

        public bool deleteCustomers(int _Id)
        {
            return new DALCustomer().deleteCustomers(_Id);
        }

        public Customer getCustomersById(int _id)
        {
            return new DALCustomer().getCustomersById(_id);
        }

        public bool UpdateCustomers(Customer _Customers)
        {
            return new DALCustomer().updateCustomers(_Customers);
        }
       
        #endregion

        #region Login

        public Customer Login(string Email, string Password)
        {
            return new DALCustomer().login(Email, Password); ;
        }
        #endregion
    }
}