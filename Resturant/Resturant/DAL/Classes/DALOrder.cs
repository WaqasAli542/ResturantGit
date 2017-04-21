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
    public int addOrder(Order Order)
    {
        database.Orders.Add(Order);
         database.SaveChanges();
        return Order.Id;
    }

    public bool updateOrder(Order Order)
    {
        database.Entry(Order).State = System.Data.EntityState.Modified;
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool deleteOrder(int _id)
    {
        Order order = getOrderById(_id);
        if(order != null)
        database.Orders.Remove(order);
        return database.SaveChanges() != -1 ? true : false;
    }

    public Order getOrderById(int id)
    {
        return database.Orders.FirstOrDefault(Order => Order.Id == id);
    }

    public List<Order> getListOfOrder()
    {
        return database.Orders.ToList();
    }
    #endregion

    #region Order_Discount
    public bool addOrder_Discount(Order_Discount Order_Discount)
    {
        database.Order_Discount.Add(Order_Discount);
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool updateOrder_Discount(Order_Discount Order_Discount)
    {
        database.Entry(Order_Discount).State = System.Data.EntityState.Modified;
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool deleteOrder_Discount(int _id)
    {
        Order_Discount Order_Discount = getOrder_DiscountById(_id);
        if (Order_Discount != null)
            database.Order_Discount.Remove(Order_Discount);
        return database.SaveChanges() != -1 ? true : false;
    }

    public Order_Discount getOrder_DiscountById(int id)
    {
        return database.Order_Discount.FirstOrDefault(Order_Discount => Order_Discount.Id == id);
    }

    public List<Order_Discount> getListOfOrder_Discount()
    {
        return database.Order_Discount.ToList();
    }
    #endregion

    #region Order_ExtraCharges
    public bool addOrder_ExtraCharges(Order_ExtraCharges Order_ExtraCharges)
    {
        database.Order_ExtraCharges.Add(Order_ExtraCharges);
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool updateOrder_ExtraCharges(Order_ExtraCharges Order_ExtraCharges)
    {
        database.Entry(Order_ExtraCharges).State = System.Data.EntityState.Modified;
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool deleteOrder_ExtraCharges(int _id)
    {
        Order_ExtraCharges Order_ExtraCharges = getOrder_ExtraChargesById(_id);
        if (Order_ExtraCharges != null)
            database.Order_ExtraCharges.Remove(Order_ExtraCharges);
        return database.SaveChanges() != -1 ? true : false;
    }

    public Order_ExtraCharges getOrder_ExtraChargesById(int id)
    {
        return database.Order_ExtraCharges.FirstOrDefault(Order_ExtraCharges => Order_ExtraCharges.Id == id);
    }

    public List<Order_ExtraCharges> getListOfOrder_ExtraCharges()
    {
        return database.Order_ExtraCharges.ToList();
    }
    #endregion

    #region Order_Item
    public int addOrder_Item(Order_Item Order_Item)
    {
        database.Order_Item.Add(Order_Item);
        database.SaveChanges();
        return Order_Item.Id;
    }

    public bool updateOrder_Item(Order_Item Order_Item)
    {
        database.Entry(Order_Item).State = System.Data.EntityState.Modified;
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool deleteOrder_Item(int _id)
    {
        Order_Item Order_Item = getOrder_ItemById(_id);
        if (Order_Item != null)
            database.Order_Item.Remove(Order_Item);
        return database.SaveChanges() != -1 ? true : false;
    }

    public Order_Item getOrder_ItemById(int id)
    {
        return database.Order_Item.FirstOrDefault(Order_Item => Order_Item.Id == id);
    }

    public List<Order_Item> getListOfOrder_Item()
    {
        return database.Order_Item.ToList();
    }
    #endregion

    #region Order_SpecialOffer_AddOn
    public bool addOrder_SpecialOffer_AddOn(Order_SpecialOffer_AddOn Order_SpecialOffer_AddOn)
    {
        database.Order_SpecialOffer_AddOn.Add(Order_SpecialOffer_AddOn);
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool updateOrder_SpecialOffer_AddOn(Order_SpecialOffer_AddOn Order_SpecialOffer_AddOn)
    {
        database.Entry(Order_SpecialOffer_AddOn).State = System.Data.EntityState.Modified;
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool deleteOrder_SpecialOffer_AddOn(int _id)
    {
        Order_SpecialOffer_AddOn Order_SpecialOffer_AddOn = getOrder_SpecialOffer_AddOnById(_id);
        if (Order_SpecialOffer_AddOn != null)
            database.Order_SpecialOffer_AddOn.Remove(Order_SpecialOffer_AddOn);
        return database.SaveChanges() != -1 ? true : false;
    }
    public Order_SpecialOffer_AddOn getOrder_SpecialOffer_AddOnById(int id)
    {
        return database.Order_SpecialOffer_AddOn.FirstOrDefault(Order_SpecialOffer_AddOn => Order_SpecialOffer_AddOn.Id == id);
    }

    public List<Order_SpecialOffer_AddOn> getListOfOrder_SpecialOffer_AddOn()
    {
        return database.Order_SpecialOffer_AddOn.ToList();
    }
    #endregion

    #region Order_SpecialOffer_FoodItem
    public bool addOrder_SpecialOffer_FoodItem(Order_SpecialOffer_FoodItem Order_SpecialOffer_FoodItem)
    {
        database.Order_SpecialOffer_FoodItem.Add(Order_SpecialOffer_FoodItem);
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool updateOrder_SpecialOffer_FoodItem(Order_SpecialOffer_FoodItem Order_SpecialOffer_FoodItem)
    {
        database.Entry(Order_SpecialOffer_FoodItem).State = System.Data.EntityState.Modified;
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool deleteOrder_SpecialOffer_FoodItem(int _id)
    {
        Order_SpecialOffer_FoodItem Order_SpecialOffe_FoodItem = getOrder_SpecialOffer_FoodItemById(_id);
        if (Order_SpecialOffe_FoodItem != null)
            database.Order_SpecialOffer_FoodItem.Remove(Order_SpecialOffe_FoodItem);
        return database.SaveChanges() != -1 ? true : false;
    }

    public Order_SpecialOffer_FoodItem getOrder_SpecialOffer_FoodItemById(int id)
    {
        return database.Order_SpecialOffer_FoodItem.FirstOrDefault(Order_SpecialOffer_FoodItem => Order_SpecialOffer_FoodItem.Id == id);
    }

    public List<Order_SpecialOffer_FoodItem> getListOfOrder_SpecialOffer_FoodItem()
    {
        return database.Order_SpecialOffer_FoodItem.ToList();
    }
    #endregion

    #region Order_Taxes
    public bool addOrder_Taxes(Order_Taxes Order_Taxes)
    {
        database.Order_Taxes.Add(Order_Taxes);
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool updateOrder_Taxes(Order_Taxes Order_Taxes)
    {
        database.Entry(Order_Taxes).State = System.Data.EntityState.Modified;
        return database.SaveChanges() != -1 ? true : false;
    }

    public bool deleteOrder_Taxes(int _id)
    {
        Order_Taxes Order_Taxes = getOrder_TaxesById(_id);
        if (Order_Taxes != null)
            database.Order_Taxes.Remove(Order_Taxes);
        return database.SaveChanges() != -1 ? true : false;
    }

    public Order_Taxes getOrder_TaxesById(int id)
    {
        return database.Order_Taxes.FirstOrDefault(Order_Taxes => Order_Taxes.Id == id);
    }

    public List<Order_Taxes> getListOfOrder_Taxes()
    {
        return database.Order_Taxes.ToList();
    }
    #endregion

    #region OrderItem_AddOn
    public int addOrderItem_AddOn(OrderItem_AddOn OrderItem_AddOn)
    {
        database.OrderItem_AddOn.Add(OrderItem_AddOn);
        database.SaveChanges();
       return  OrderItem_AddOn.Id;
    }

    public bool updateOrderItem_AddOn(OrderItem_AddOn OrderItem_AddOn)
    {
        database.Entry(OrderItem_AddOn).State = System.Data.EntityState.Modified;
        return database.SaveChanges() != -1 ? true : false;
    }
    public bool deleteOrderItem_AddOn(int _id)
    {
        OrderItem_AddOn OrderItem_AddOn = getOrderItem_AddOnById(_id);
        if (OrderItem_AddOn != null)
            database.OrderItem_AddOn.Remove(OrderItem_AddOn);
        return database.SaveChanges() != -1 ? true : false;
    }

    public OrderItem_AddOn getOrderItem_AddOnById(int id)
    {
        return database.OrderItem_AddOn.FirstOrDefault(OrderItem_AddOn => OrderItem_AddOn.Id == id);
    }

    public List<OrderItem_AddOn> getListOfOrderItem_AddOn()
    {
        return database.OrderItem_AddOn.ToList();
    }
    #endregion



}
    
}