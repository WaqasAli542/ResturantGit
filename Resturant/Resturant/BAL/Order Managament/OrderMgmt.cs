using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Resturant.Models;
using Resturant.UtilityClasses;
using System.Web.Providers.Entities;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Resturant.BAL.Order_Managament
{

    public class OrderMgmt
    {
        Order order;
        BLFood blfood;
        BLOrder blorder;
        double total;
        double subTotal;

        public double Total {

            get{
                return total;
            }

            set{ 

                total = value; 
            }
        }
       public OrderMgmt(Order o)
        {
            this.order = o;
            blfood = new BLFood();
            blorder = new BLOrder();
            subTotal=total = 0;



        }



        public bool generateOrder(List<Items> itemstoBeAdded)
       {
           try
           {

               foreach (Items item in itemstoBeAdded)
               {
                   if (item.Name.Contains('-'))
                   {
                       string[] arr = item.Name.Split('-');
                       string food_item = arr[0];
                       string food = arr[1];



                       FoodItem fs = blfood.getListOfFoodItem().FirstOrDefault(f => f.Size == food_item && f.Food.Name == food);
                       Order_Item oI = new Order_Item()
                       {

                           FoodItemId = fs.Id,
                           Count = item.Quantitity,
                           OrderID = order.Id
                       };

                       total += fs.Price * oI.Count;

                       blorder.addOrder_Item(oI);
                       int orderItemId = blorder.getLastOrderItemId();

                       if (item.addOns.Contains(','))
                       {
                           string[] arrAddOns = item.addOns.Split(',');
                           if (arrAddOns.Length > 0)
                           {
                               foreach (string adOns in arrAddOns)
                               {
                                   if (!adOns.Equals(string.Empty))
                                   {
                                       int adOnId = Convert.ToInt32(adOns);
                                       AddOn temp = blfood.getAddOnById(adOnId);
                                       OrderItem_AddOn oiao = new OrderItem_AddOn()
                                       {
                                           AddOnId = adOnId,
                                           Order_ItemId = orderItemId
                                       };
                                       total += temp.Price * item.Quantitity;
                                       blorder.addOrderItem_AddOn(oiao);

                                   }
                               }
                           }

                       }






                   }

                       //in this first we get the addons
                   //we first get the special offfer
                   //then get the special offer addon
                   //then add it into order_specialoofer
                   else
                   {
                       string offerName = item.Name;
                       SpecialOffer so = blfood.getListOfSpecialOffers().FirstOrDefault(x => x.Name == offerName);
                       Order_SpecialOffer oso = new Order_SpecialOffer()
                       {
                           SpecialOfferId = so.Id,
                           OrderId = order.Id,
                           CountOfSpecialOffers = item.Quantitity
                       };

                       total += so.Price * item.Quantitity;



                       blorder.addOrder_SpecialOffer(oso);

                       Order_SpecialOffer finalOrder_SpecialOffer = blorder.getOrder_SpecialOfferById(blorder.getLastOrder_SpecialOfferId());
                       if (item.addOns.Contains(','))
                       {
                           string[] arrAddOns = item.addOns.Split(',');
                           if (arrAddOns.Length > 0)
                           {
                               foreach (string adOns in arrAddOns)
                               {
                                   if (!adOns.Equals(string.Empty))
                                   {
                                       AddOn adOn = so.SpecialOffer_AddOn.FirstOrDefault(soAddOn => soAddOn.AddonID == Convert.ToInt32(adOns)).AddOn;



                                       Order_SpecialOffer_AddOn oiao = new Order_SpecialOffer_AddOn()
                                       {
                                           SpecialOffer_AddOnId = adOn.Id,
                                           Order_SpecialOfferId = finalOrder_SpecialOffer.Id

                                       };

                                       total = total + adOn.Price;
                                       blorder.addOrder_SpecialOffer_AddOn(oiao);

                                   }
                               }
                           }

                       }
                       if (item.FoodItems.Contains(','))
                       {
                           string[] foodItems = item.FoodItems.Split(',');
                           if (foodItems.Length > 0)
                           {
                               foreach (string foodItem in foodItems)
                               {
                                   if (!foodItem.Equals(string.Empty))
                                   {

                                       Food foodObject = blfood.getFoodById(Convert.ToInt32(foodItem));
                                       int specialOffer_ItemId = blfood.getListOfSpecialOffer_Item().FirstOrDefault(x => x.SpecialOfferID == so.Id && x.CategoryId == foodObject.CategoryId).Id;

                                       Order_SpecialOffer_Item osi = new Order_SpecialOffer_Item()
                                       {
                                           FoodId = foodObject.Id,
                                           SpecialOffer_ItemId = specialOffer_ItemId,
                                           Order_SpecialOfferId = finalOrder_SpecialOffer.Id
                                       };

                                       blorder.addOrder_SpecialOffer_Item(osi);



                                   }

                               }

                           }

                       }

                   }
               }

           } catch(Exception e)
           {
               return false;
           }

           subTotal = total;
           return true;
       }

        public bool addTaxes()
        {
            try
            {
                List<Tax> taxes = new BLTax().getListOfTax().Where(x => x.IsAvailable == 1).ToList();
                foreach (Tax item in taxes)
                {
                    Order_Taxes ot = new Order_Taxes()
                      {
                          TaxesID = item.Id,
                          OrderID = order.Id
                      };

                    blorder.addOrder_Taxes(ot);
                    total = total+subTotal * item.Percentage / 100;

                }

            }catch(Exception e)
            {
                return false;
            }
            return true;

        }

        public bool addExtraCharges()
        {
            try
            {
                List<ExtraCharge> discounts = new BLExtraCharges().getListOfExtraCharges().Where(x => x.IsAvailable == 1).ToList();
                foreach (ExtraCharge item in discounts)
                {
                    if (item.Maximum_Amount < subTotal || item.Minimum_Amount > subTotal)
                    {
                        Order_ExtraCharges oec = new Order_ExtraCharges()
                        {
                            ExtraChargesID = item.Id,
                            OrderID = order.Id
                        };
                        blorder.addOrder_ExtraCharges(oec);
                        total = total + item.Price;
                    }
                }
            } catch(Exception e)
            {
                return false;
            }
            return true;
         
        }


   
        public bool sendMail(string email)
        {
            MailMessage msg = new MailMessage();

            string text = "<link href='https://fonts.googleapis.com/css?family=Bree+Serif' rel='stylesheet'><style>  * {";
            text += "  font-family: 'Bree Serif', serif; }";
            text += " .list-group-item {       border: none;  }    .hor {      border-bottom: 5px solid black;   }";
            text += " .line {       margin-bottom: 20px; }";


            msg.From = new MailAddress("info@ubssols.com");
            msg.To.Add("uzair.aslamansari02@gmail.com");
            msg.Subject = "test";
            msg.IsBodyHtml = true;
            msg.Body = generateEmail();

            //msg.Priority = MailPriority.High;


            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("info@ubssols.com", "delta@O27");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msg);
            }

       


 
     
            return true;

        }


    
        public string generateEmail()
        {
            string text = "<link href='https://fonts.googleapis.com/css?family=Bree+Serif' rel='stylesheet'><style>  * {";
            text += "  font-family: 'Bree Serif', serif; }";
            text += " .list-group-item {       border: none;  }    .hor {      border-bottom: 5px solid black;   }";
            text += " .line {       margin-bottom: 20px; } </style>";
            text+="<div class='container'>   <div class='row'>       <div class='col-md-offset-2 col-md-8'>'";
            text += " <h2 class='page-header'>Order #"+ order.Id+"</h2>            <h3>Customer Name: <small>"+ order.Customer.FirstName +" "+order.Customer.LastName+"</small></h3>";
            text+="<h3>Customer Address: <small>"+order.Customer.Address+"</small></h3>";
             text+="<h3>Status: <small>"+order.Status+"</small></h3>";
            text+=" <h3 class='text-danger'>Delivery Time: <small>"+order.DeliveryTime+"</small></h3>";
           text+="  <div class='list-group'>";
            return null;
        }


    }
}