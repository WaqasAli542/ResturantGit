//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Resturant.Models;
//using Resturant.UtilityClasses;
//using System.Web.Providers.Entities;

//namespace Resturant.BAL.Order_Managament
//{
    
//    public class OrderMgmt
//    {
//        BLOrder blOrder;
//        public OrderMgmt()
//        {
//            blOrder = new BLOrder();
//        }

//        public void addFoodItem(int foodItemId)
//        {
            
//            if (System.Web.HttpContext.Current.Session["orderId"] == null)
//            {
//                Order order = new Order();
//                //----------------------------------------------Customr iD is HARD CODED-----------------------------------
//                order.CustomerId = 1;
//                int orderId = blOrder.addOrder(order);
//                System.Web.HttpContext.Current.Session["orderId"] = orderId;
//                addTaxes(orderId);
//                addExtraCharges(orderId);
//            }
            
//            Order_Item oi = new Order_Item();
//            oi.OrderID =(int)System.Web.HttpContext.Current.Session["orderId"];
//            oi.IDType = (int)ProjectEnums.IdType.FoodItem;
//            oi.FoodItemId = foodItemId;
//            oi.Count = 1;
//            System.Web.HttpContext.Current.Session["PresentId"] = blOrder.addOrder_Item(oi);

//        }

       
//        public void addAddOn(int AddOnId)
//        {
//            OrderItem_AddOn orderItemAddon = new OrderItem_AddOn();
//            orderItemAddon.Order_ItemId = (int)System.Web.HttpContext.Current.Session["PresentId"];
//            orderItemAddon.AddOnId=AddOnId;
//            blOrder.addOrderItem_AddOn(orderItemAddon);
//        }

//        public void addTaxes(int orderId)
//        {
//            List<Tax> taxes = new BLTax().getListOfTax();
//            foreach (var item in taxes)
//            {
//                Order_Taxes or = new Order_Taxes();
//                or.TaxesID = item.Id;
//                or.OrderID = orderId;
//                blOrder.addOrder_Taxes(or);
//            }
//        }
//        public void addExtraCharges(int orderId)
//        {
//            List<ExtraCharge> Extra_Chargeses = new BLExtraCharges().getListOfExtraCharges();
//            foreach (var item in Extra_Chargeses)
//            {
//                Order_ExtraCharges or = new Order_ExtraCharges();
//                or.ExtraChargesID= item.Id;
//                or.OrderID = orderId;
//                blOrder.addOrder_ExtraCharges(or);
//            }
//        }
//    }
//}