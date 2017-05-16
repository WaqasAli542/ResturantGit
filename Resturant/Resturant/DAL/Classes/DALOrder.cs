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
      
        public int getLastAddedOrder()
        {
            var list = getListOfOrder();
            return list.Count == 0 ? 0 : list.Last().Id;
        }

        #endregion


        #region Order_Item
        public bool addOrder_Item(Order_Item _Order_Item)
        {
            database.Order_Item.Add(_Order_Item);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateOrder_Item(Order_Item _Order_Item)
        {
            database.Entry(_Order_Item).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteOrder_Item(int _id)
        {
            Order_Item Order_Item = getOrder_ItemById(_id);
            if (Order_Item != null)
                database.Order_Item.Remove(Order_Item);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Order_Item getOrder_ItemById(int _id)
        {
            return database.Order_Item.FirstOrDefault(Order_Item => Order_Item.Id == _id);
        }

        public List<Order_Item> getListOfOrder_Item()
        {
            return database.Order_Item.ToList();
        }

        public int getLastOrderItemId()
        {
            var list = getListOfOrder_Item();
            return list.Count == 0 ? 0 : list.Last().Id;
        }

        #endregion



        #region Order_SpecialOffer
        public bool addOrder_SpecialOffer(Order_SpecialOffer _Order_SpecialOffer)
        {
            database.Order_SpecialOffer.Add(_Order_SpecialOffer);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateOrder_SpecialOffer(Order_SpecialOffer _Order_SpecialOffer)
        {
            database.Entry(_Order_SpecialOffer).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteOrder_SpecialOffer(int _id)
        {
            Order_SpecialOffer Order_SpecialOffer = getOrder_SpecialOfferById(_id);
            if (Order_SpecialOffer != null)
                database.Order_SpecialOffer.Remove(Order_SpecialOffer);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Order_SpecialOffer getOrder_SpecialOfferById(int _id)
        {
            return database.Order_SpecialOffer.FirstOrDefault(Order_SpecialOffer => Order_SpecialOffer.Id == _id);
        }

        public List<Order_SpecialOffer> getListOfOrder_SpecialOffer()
        {
            return database.Order_SpecialOffer.ToList();
        }
        public int getLastOrder_SpecialOfferId()
        {
            var list = getListOfOrder_SpecialOffer();
            return list.Count == 0 ? 0 : list.Last().Id;
        }
        #endregion

        #region Order_SpecialOffer_AddOn
        public bool addOrder_SpecialOffer_AddOn(Order_SpecialOffer_AddOn _Order_SpecialOffer_AddOn)
        {
            database.Order_SpecialOffer_AddOn.Add(_Order_SpecialOffer_AddOn);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateOrder_SpecialOffer_AddOn(Order_SpecialOffer_AddOn _Order_SpecialOffer_AddOn)
        {
            database.Entry(_Order_SpecialOffer_AddOn).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteOrder_SpecialOffer_AddOn(int _id)
        {
            Order_SpecialOffer_AddOn Order_SpecialOffer_AddOn = getOrder_SpecialOffer_AddOnById(_id);
            if (Order_SpecialOffer_AddOn != null)
                database.Order_SpecialOffer_AddOn.Remove(Order_SpecialOffer_AddOn);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Order_SpecialOffer_AddOn getOrder_SpecialOffer_AddOnById(int _id)
        {
            return database.Order_SpecialOffer_AddOn.FirstOrDefault(Order_SpecialOffer_AddOn => Order_SpecialOffer_AddOn.Id == _id);
        }

        public List<Order_SpecialOffer_AddOn> getListOfOrder_SpecialOffer_AddOn()
        {
            return database.Order_SpecialOffer_AddOn.ToList();
        }

        #endregion


        #region Order_SpecialOffer_Item
        public bool addOrder_SpecialOffer_Item(Order_SpecialOffer_Item _Order_SpecialOffer_Item)
        {
            database.Order_SpecialOffer_Item.Add(_Order_SpecialOffer_Item);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateOrder_SpecialOffer_Item(Order_SpecialOffer_Item _Order_SpecialOffer_Item)
        {
            database.Entry(_Order_SpecialOffer_Item).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteOrder_SpecialOffer_Item(int _id)
        {
            Order_SpecialOffer_Item Order_SpecialOffer_Item = getOrder_SpecialOffer_ItemById(_id);
            if (Order_SpecialOffer_Item != null)
                database.Order_SpecialOffer_Item.Remove(Order_SpecialOffer_Item);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Order_SpecialOffer_Item getOrder_SpecialOffer_ItemById(int _id)
        {
            return database.Order_SpecialOffer_Item.FirstOrDefault(Order_SpecialOffer_Item => Order_SpecialOffer_Item.Id == _id);
        }

        public List<Order_SpecialOffer_Item> getListOfOrder_SpecialOffer_Item()
        {
            return database.Order_SpecialOffer_Item.ToList();
        }

        #endregion

        #region OrderItem_AddOn
        public bool addOrderItem_AddOn(OrderItem_AddOn _OrderItem_AddOn)
        {
            database.OrderItem_AddOn.Add(_OrderItem_AddOn);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateOrderItem_AddOn(OrderItem_AddOn _OrderItem_AddOn)
        {
            database.Entry(_OrderItem_AddOn).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteOrderItem_AddOn(int _id)
        {
            OrderItem_AddOn OrderItem_AddOn = getOrderItem_AddOnById(_id);
            if (OrderItem_AddOn != null)
                database.OrderItem_AddOn.Remove(OrderItem_AddOn);
            return database.SaveChanges() != -1 ? true : false;
        }

        public OrderItem_AddOn getOrderItem_AddOnById(int _id)
        {
            return database.OrderItem_AddOn.FirstOrDefault(OrderItem_AddOn => OrderItem_AddOn.Id == _id);
        }

        public List<OrderItem_AddOn> getListOfOrderItem_AddOn()
        {
            return database.OrderItem_AddOn.ToList();
        }

        #endregion

        #region Order_ExtraCharges
        public bool addOrder_ExtraCharges(Order_ExtraCharges _Order_ExtraCharges)
        {
            database.Order_ExtraCharges.Add(_Order_ExtraCharges);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateOrder_ExtraCharges(Order_ExtraCharges _Order_ExtraCharges)
        {
            database.Entry(_Order_ExtraCharges).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteOrder_ExtraCharges(int _id)
        {
            Order_ExtraCharges Order_ExtraCharges = getOrder_ExtraChargesById(_id);
            if (Order_ExtraCharges != null)
                database.Order_ExtraCharges.Remove(Order_ExtraCharges);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Order_ExtraCharges getOrder_ExtraChargesById(int _id)
        {
            return database.Order_ExtraCharges.FirstOrDefault(Order_ExtraCharges => Order_ExtraCharges.Id == _id);
        }

        public List<Order_ExtraCharges> getListOfOrder_ExtraCharges()
        {
            return database.Order_ExtraCharges.ToList();
        }

        #endregion

        #region Order_Taxes
        public bool addOrder_Taxes(Order_Taxes _Order_Taxes)
        {
            database.Order_Taxes.Add(_Order_Taxes);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateOrder_Taxes(Order_Taxes _Order_Taxes)
        {
            database.Entry(_Order_Taxes).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteOrder_Taxes(int _id)
        {
            Order_Taxes Order_Taxes = getOrder_TaxesById(_id);
            if (Order_Taxes != null)
                database.Order_Taxes.Remove(Order_Taxes);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Order_Taxes getOrder_TaxesById(int _id)
        {
            return database.Order_Taxes.FirstOrDefault(Order_Taxes => Order_Taxes.Id == _id);
        }

        public List<Order_Taxes> getListOfOrder_Taxes()
        {
            return database.Order_Taxes.ToList();
        }

        #endregion








    }
}