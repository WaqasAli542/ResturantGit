using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Resturant.DAL.Classes
{
    public class DALOrder
    {
          ResturantDatabase database = null;

        public DALOrder()
        {
            database = new ResturantDatabase();
        }
        #region Order
        public bool addOrder(Order _Order)
        {
            database.Orders.Add(_Order);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateOrder(Order _Order)
        {
            database.Entry(_Order).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteOrder(int _id)
        {
            Order Order = getOrderById(_id);
            if (Order != null)
                database.Orders.Remove(Order);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Order getOrderById(int _id)
        {
            return database.Orders.FirstOrDefault(Order => Order.Id == _id);
        }

        public List<Order> getListOfOrder()
        {
            return database.Orders.ToList();
        }
      
        #endregion
    }
}