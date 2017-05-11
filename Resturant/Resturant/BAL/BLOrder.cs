using Resturant.DAL.Classes;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.BAL
{
    public class BLOrder
    {
        #region Order
        public bool addOrder(Order _Order)
        {
            return new DALOrder().addOrder(_Order);
        }
        public bool updateOrder(Order _Order)
        {
            return new DALOrder().updateOrder(_Order);
        }

        public bool deleteOrder(int _id)
        {
            return new DALOrder().deleteOrder(_id);
        }

        public Order getOrderById(int _id)
        {
            return new DALOrder().getOrderById(_id);
        }
        public List<Order> getListOfOrder()
        {
            return new DALOrder().getListOfOrder();
        }
        #endregion
    }
}