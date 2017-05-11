using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Resturant.Models;
using Resturant.BAL;

namespace Resturant.Controllers
{
    public class CustomerAPIController : ApiController
    {
        public CustomerAPIController()
        {
            // Add the following code
            // problem will be solved 
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
        public bool AddCustomer(string FName, string LName, string Email, string PNumber, string Address, string City, string Country, string PostCode, string Password)
        {
            Customer cus = new Customer();
            cus.FirstName = FName;
            cus.LastName = LName;
            cus.Email = Email;
            cus.PhoneNumber = PNumber;
            cus.Address = Address;
            cus.City = City;
            cus.Country = Country;
            cus.PostCode = PostCode;
            cus.Password = Password;
            return new BLCustomer().addCustomers(cus);
        }
        public Customer Login(string Email,string Password)
        {
            return new BLCustomer().Login(Email,Password);
        }
        public bool deleteCustomer(int _CustomerId)
        {
            return new BLCustomer().deleteCustomers(_CustomerId);
        }
        public bool updateCustomer(int Id , string FirstName , string LastName, string Email,string PhoneNumber,string Address,string City,string Country,string PostCode,string Password)
        {
            Customer cus = new Customer();
            cus.FirstName = FirstName;
            cus.LastName = LastName;
            cus.Email = Email;
            cus.PhoneNumber = PhoneNumber;
            cus.Address = Address;
            cus.City = City;
            cus.Country = Country;
            cus.PostCode = PostCode;
            cus.Password = Password;
            cus.Id = Id;
            return new BLCustomer().UpdateCustomers(cus);
        }

        public Customer CustomerById(int _Id)
        {
            return new BLCustomer().getCustomersById(_Id);
        }
        //api/<controller>
        public List<Customer> CustomerList()
        {
            return new BLCustomer().getListOfCustomers();
        }



       
    }
}