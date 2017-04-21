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
        public List<Order> getListOfOrder()
        {
            return new DALOrder().getListOfOrder();
        }
        //Error
        public int addOrder(Order _Order)
        {
            return new DALOrder().addOrder(_Order);
        }

        public bool deleteOrder(int _Id)
        {
            return new DALOrder().deleteOrder(_Id);
        }

        public Order getOrderById(int _id)
        {
            return new DALOrder().getOrderById(_id);
        }

        public bool UpdateOrder(Order _Order)
        {
            return new DALOrder().updateOrder(_Order);
        }
        #endregion

        #region Order_Discount
        public List<Order_Discount> getListOfOrder_Discount()
        {
            return new DALOrder().getListOfOrder_Discount();
        }

        public bool addOrder_Discount(Order_Discount _Order_Discount)
        {
            return new DALOrder().addOrder_Discount(_Order_Discount);
        }

        public bool deleteOrder_Discount(int _Order_DiscountId)
        {
            return new DALOrder().deleteOrder_Discount(_Order_DiscountId);
        }

        public Order_Discount getOrder_DiscountById(int _id)
        {
            return new DALOrder().getOrder_DiscountById(_id);
        }
        public bool UpdateOrder_Discount(Order_Discount _Order_Discount)
        {
            return new DALOrder().updateOrder_Discount(_Order_Discount);
        }
        #endregion

        #region Order_ExtraCharges
        public List<Order_ExtraCharges> getListOfOrder_ExtraCharges()
        {
            return new DALOrder().getListOfOrder_ExtraCharges();
        }

        public bool addOrder_ExtraCharges(Order_ExtraCharges _Order_ExtraCharges)
        {
            return new DALOrder().addOrder_ExtraCharges(_Order_ExtraCharges);
        }

        public bool deleteOrder_ExtraCharges(int _Order_ExtraChargesId)
        {
            return new DALOrder().deleteOrder_ExtraCharges(_Order_ExtraChargesId);
        }

        public Order_ExtraCharges getOrder_ExtraChargesById(int _id)
        {
            return new DALOrder().getOrder_ExtraChargesById(_id);
        }
        public bool UpdateOrder_ExtraCharges(Order_ExtraCharges _Order_ExtraCharges)
        {
            return new DALOrder().updateOrder_ExtraCharges(_Order_ExtraCharges);
        }
        #endregion


        #region Order_Item
        public List<Order_Item> getListOfOrder_Item()
        {
            return new DALOrder().getListOfOrder_Item();
        }

        public int addOrder_Item(Order_Item _Order_Item)
        {
            return new DALOrder().addOrder_Item(_Order_Item);
        }

        public bool deleteOrder_Item(int _Order_ItemId)
        {
            return new DALOrder().deleteOrder_Item(_Order_ItemId);
        }

        public Order_Item getOrder_ItemById(int _id)
        {
            return new DALOrder().getOrder_ItemById(_id);
        }
        public bool UpdateOrder_Item(Order_Item _Order_Item)
        {
            return new DALOrder().updateOrder_Item(_Order_Item);
        }
        #endregion

        #region Order_SpecialOffer_AddOn
        public List<Order_SpecialOffer_AddOn> getListOfOrder_SpecialOffer_AddOn()
        {
            return new DALOrder().getListOfOrder_SpecialOffer_AddOn();
        }

        public bool addOrder_SpecialOffer_AddOn(Order_SpecialOffer_AddOn _Order_SpecialOffer_AddOn)
        {
            return new DALOrder().addOrder_SpecialOffer_AddOn(_Order_SpecialOffer_AddOn);
        }

        public bool deleteOrder_SpecialOffer_AddOn(int _Order_SpecialOffer_AddOnId)
        {
            return new DALOrder().deleteOrder_SpecialOffer_AddOn(_Order_SpecialOffer_AddOnId);
        }

        public Order_SpecialOffer_AddOn getOrder_SpecialOffer_AddOnById(int _id)
        {
            return new DALOrder().getOrder_SpecialOffer_AddOnById(_id);
        }
        public bool UpdateOrder_SpecialOffer_AddOn(Order_SpecialOffer_AddOn _Order_SpecialOffer_AddOn)
        {
            return new DALOrder().updateOrder_SpecialOffer_AddOn(_Order_SpecialOffer_AddOn);
        }
        #endregion

        #region Order_SpecialOffer_FoodItem
        public List<Order_SpecialOffer_FoodItem> getListOfOrder_SpecialOffer_FoodItem()
        {
            return new DALOrder().getListOfOrder_SpecialOffer_FoodItem();
        }

        public bool addOrder_SpecialOffer_FoodItem(Order_SpecialOffer_FoodItem _Order_SpecialOffer_FoodItem)
        {
            return new DALOrder().addOrder_SpecialOffer_FoodItem(_Order_SpecialOffer_FoodItem);
        }

        public bool deleteOrder_SpecialOffer_FoodItem(int _Order_SpecialOffer_FoodItemId)
        {
            return new DALOrder().deleteOrder_SpecialOffer_FoodItem(_Order_SpecialOffer_FoodItemId);
        }

        public Order_SpecialOffer_FoodItem getOrder_SpecialOffer_FoodItemById(int _id)
        {
            return new DALOrder().getOrder_SpecialOffer_FoodItemById(_id);
        }
        public bool UpdateOrder_SpecialOffer_FoodItem(Order_SpecialOffer_FoodItem _Order_SpecialOffer_FoodItem)
        {
            return new DALOrder().updateOrder_SpecialOffer_FoodItem(_Order_SpecialOffer_FoodItem);
        }
        #endregion

        #region Order_Taxes
        public List<Order_Taxes> getListOfOrder_Taxes()
        {
            return new DALOrder().getListOfOrder_Taxes();
        }

        public bool addOrder_Taxes(Order_Taxes _Order_Taxes)
        {
            return new DALOrder().addOrder_Taxes(_Order_Taxes);
        }

        public bool deleteOrder_Taxes(int _Order_TaxesId)
        {
            return new DALOrder().deleteOrder_Taxes(_Order_TaxesId);
        }

        public Order_Taxes getOrder_TaxesById(int _id)
        {
            return new DALOrder().getOrder_TaxesById(_id);
        }
        public bool UpdateOrder_Taxes(Order_Taxes _Order_Taxes)
        {
            return new DALOrder().updateOrder_Taxes(_Order_Taxes);
        }
        #endregion

        #region OrderItem_AddOn
        public List<OrderItem_AddOn> getListOfOrderItem_AddOn()
        {
            return new DALOrder().getListOfOrderItem_AddOn();
        }

        public int addOrderItem_AddOn(OrderItem_AddOn _OrderItem_AddOn)
        {
            return new DALOrder().addOrderItem_AddOn(_OrderItem_AddOn);
        }

        public bool deleteOrderItem_AddOn(int _OrderItem_AddOnId)
        {
            return new DALOrder().deleteOrderItem_AddOn(_OrderItem_AddOnId);
        }

        public OrderItem_AddOn getOrderItem_AddOnById(int _id)
        {
            return new DALOrder().getOrderItem_AddOnById(_id);
        }
        public bool UpdateOrderItem_AddOn(OrderItem_AddOn _OrderItem_AddOn)
        {
            return new DALOrder().updateOrderItem_AddOn(_OrderItem_AddOn);
        }
        #endregion
    }
}