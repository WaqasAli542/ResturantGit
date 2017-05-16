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

            public int getLastAddedOrder()
        {
           return new DALOrder().getLastAddedOrder();
        }
        #endregion



        #region Order_SpecialOffer_Item
        public bool addOrder_SpecialOffer_Item(Order_SpecialOffer_Item _Order_SpecialOffer_Item)
        {
            return new DALOrder().addOrder_SpecialOffer_Item(_Order_SpecialOffer_Item);
        }
        public bool updateOrder_SpecialOffer_Item(Order_SpecialOffer_Item _Order_SpecialOffer_Item)
        {
            return new DALOrder().updateOrder_SpecialOffer_Item(_Order_SpecialOffer_Item);
        }

        public bool deleteOrder_SpecialOffer_Item(int _id)
        {
            return new DALOrder().deleteOrder_SpecialOffer_Item(_id);
        }

        public Order_SpecialOffer_Item getOrder_SpecialOffer_ItemById(int _id)
        {
            return new DALOrder().getOrder_SpecialOffer_ItemById(_id);
        }
        public List<Order_SpecialOffer_Item> getListOfOrder_SpecialOffer_Item()
        {
            return new DALOrder().getListOfOrder_SpecialOffer_Item();
        }
        #endregion


        #region Order_Item
        public bool addOrder_Item(Order_Item _Order_Item)
        {
            return new DALOrder().addOrder_Item(_Order_Item);
        }
        public bool updateOrder_Item(Order_Item _Order_Item)
        {
            return new DALOrder().updateOrder_Item(_Order_Item);
        }

        public bool deleteOrder_Item(int _id)
        {
            return new DALOrder().deleteOrder_Item(_id);
        }

        public Order_Item getOrder_ItemById(int _id)
        {
            return new DALOrder().getOrder_ItemById(_id);
        }
        public List<Order_Item> getListOfOrder_Item()
        {
            return new DALOrder().getListOfOrder_Item();
        }

           public int getLastOrderItemId()
        {
            return new DALOrder().getLastOrderItemId();
        }
        #endregion

        #region Order_SpecialOffer
        public bool addOrder_SpecialOffer(Order_SpecialOffer _Order_SpecialOffer)
        {
            return new DALOrder().addOrder_SpecialOffer(_Order_SpecialOffer);
        }
        public bool updateOrder_SpecialOffer(Order_SpecialOffer _Order_SpecialOffer)
        {
            return new DALOrder().updateOrder_SpecialOffer(_Order_SpecialOffer);
        }

        public bool deleteOrder_SpecialOffer(int _id)
        {
            return new DALOrder().deleteOrder_SpecialOffer(_id);
        }

        public Order_SpecialOffer getOrder_SpecialOfferById(int _id)
        {
            return new DALOrder().getOrder_SpecialOfferById(_id);
        }
        public List<Order_SpecialOffer> getListOfOrder_SpecialOffer()
        {
            return new DALOrder().getListOfOrder_SpecialOffer();
        }
             public int getLastOrder_SpecialOfferId()
        {
            return new DALOrder().getLastOrder_SpecialOfferId();
        }
        #endregion

        #region Order_SpecialOffer_AddOn
        public bool addOrder_SpecialOffer_AddOn(Order_SpecialOffer_AddOn _Order_SpecialOffer_AddOn)
        {
            return new DALOrder().addOrder_SpecialOffer_AddOn(_Order_SpecialOffer_AddOn);
        }
        public bool updateOrder_SpecialOffer_AddOn(Order_SpecialOffer_AddOn _Order_SpecialOffer_AddOn)
        {
            return new DALOrder().updateOrder_SpecialOffer_AddOn(_Order_SpecialOffer_AddOn);
        }

        public bool deleteOrder_SpecialOffer_AddOn(int _id)
        {
            return new DALOrder().deleteOrder_SpecialOffer_AddOn(_id);
        }

        public Order_SpecialOffer_AddOn getOrder_SpecialOffer_AddOnById(int _id)
        {
            return new DALOrder().getOrder_SpecialOffer_AddOnById(_id);
        }
        public List<Order_SpecialOffer_AddOn> getListOfOrder_SpecialOffer_AddOn()
        {
            return new DALOrder().getListOfOrder_SpecialOffer_AddOn();
        }
        #endregion



        #region OrderItem_AddOn
        public bool addOrderItem_AddOn(OrderItem_AddOn _OrderItem_AddOn)
        {
            return new DALOrder().addOrderItem_AddOn(_OrderItem_AddOn);
        }
        public bool updateOrderItem_AddOn(OrderItem_AddOn _OrderItem_AddOn)
        {
            return new DALOrder().updateOrderItem_AddOn(_OrderItem_AddOn);
        }

        public bool deleteOrderItem_AddOn(int _id)
        {
            return new DALOrder().deleteOrderItem_AddOn(_id);
        }

        public OrderItem_AddOn getOrderItem_AddOnById(int _id)
        {
            return new DALOrder().getOrderItem_AddOnById(_id);
        }
        public List<OrderItem_AddOn> getListOfOrderItem_AddOn()
        {
            return new DALOrder().getListOfOrderItem_AddOn();
        }
        #endregion

        #region Order_Taxes
        public bool addOrder_Taxes(Order_Taxes _Order_Taxes)
        {
            return new DALOrder().addOrder_Taxes(_Order_Taxes);
        }
        public bool updateOrder_Taxes(Order_Taxes _Order_Taxes)
        {
            return new DALOrder().updateOrder_Taxes(_Order_Taxes);
        }

        public bool deleteOrder_Taxes(int _id)
        {
            return new DALOrder().deleteOrder_Taxes(_id);
        }

        public Order_Taxes getOrder_TaxesById(int _id)
        {
            return new DALOrder().getOrder_TaxesById(_id);
        }
        public List<Order_Taxes> getListOfOrder_Taxes()
        {
            return new DALOrder().getListOfOrder_Taxes();
        }
        #endregion


        #region Order_ExtraCharges
        public bool addOrder_ExtraCharges(Order_ExtraCharges _Order_ExtraCharges)
        {
            return new DALOrder().addOrder_ExtraCharges(_Order_ExtraCharges);
        }
        public bool updateOrder_ExtraCharges(Order_ExtraCharges _Order_ExtraCharges)
        {
            return new DALOrder().updateOrder_ExtraCharges(_Order_ExtraCharges);
        }

        public bool deleteOrder_ExtraCharges(int _id)
        {
            return new DALOrder().deleteOrder_ExtraCharges(_id);
        }

        public Order_ExtraCharges getOrder_ExtraChargesById(int _id)
        {
            return new DALOrder().getOrder_ExtraChargesById(_id);
        }
        public List<Order_ExtraCharges> getListOfOrder_ExtraCharges()
        {
            return new DALOrder().getListOfOrder_ExtraCharges();
        }
        #endregion





    }
}