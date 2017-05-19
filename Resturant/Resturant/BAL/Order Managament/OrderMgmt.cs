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
            msg.To.Add(order.Customer.Email);
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
            string b="xcv";
            string text = "<!DOCTYPE html><html><head><title></title></head><body><h1 style='text-align: center;'>Thank you for Ordering</h1><br><br><br><h3 style='margin-left:5px;'>Dear Customer, your order has been recieved. The delivery time of your order is <b>"+order.DeliveryTime+"</b></h3><br><h1 style='margin-left:10px;'>Here is the Detail of your order</h1>";
            text += "  <table width='1000px' style='border: 1px solid #34C38A; border-collapse: collapse;'><thead style='background-color: #34C38A; color: white;'>";
            text += " <tr style='padding: 5px; border: 1px solid #34C38A;'style='padding: 5px;'><td style='padding: 5px; border: 1px solid #34C38A;'>Item</td><td style='padding: 5px; border: 1px solid #34C38A;'>Quntity</td><td style='padding: 5px; border: 1px solid #34C38A;'>Unit Price</td><td style='padding: 5px; border: 1px solid #34C38A;'>Price</td></tr></thead><tbody>";
            foreach (Order_SpecialOffer os in order.Order_SpecialOffer.ToList())
            {
                double sub = os.SpecialOffer.Price * os.CountOfSpecialOffers;
                text += "<tr><td style='padding: 5px; border: 1px solid #34C38A;'>" +os.SpecialOffer.Name  + "</td>";
                text += "<td style='padding: 5px; border: 1px solid #34C38A;'>" + os.CountOfSpecialOffers+ "</td>";
                text += "<td style='padding: 5px; border: 1px solid #34C38A;'>£ " + os.SpecialOffer.Price + "</td>";
                text += "<td style='padding: 5px; border: 1px solid #34C38A;'>£ " + sub + "</td></tr>";   
            }
            foreach (Order_Item oi in order.Order_Item.ToList())
            {
                double sub = oi.Count*oi.FoodItem.Price;
                text += "<tr><td style='padding: 5px; border: 1px solid #34C38A;'>" + oi.FoodItem.Size + "</td>";
                text += "<td style='padding: 5px; border: 1px solid #34C38A;'>" + oi.Count + "</td>";
                text += "<td style='padding: 5px; border: 1px solid #34C38A;'>£ " + oi.FoodItem.Price + "</td>";
                text += "<td style='padding: 5px; border: 1px solid #34C38A;'>£ " + sub + "</td></tr>";
            }
            text += "<tr ><td style='padding: 5px; border: 1px solid #34C38A; text-align: right;' colspan='3'>Sub-Total</td><td style='padding: 5px; border: 1px solid #34C38A;'>";
            text+="£ "+subTotal+"</td></tr>";


            foreach (Order_ExtraCharges oe in order.Order_ExtraCharges.ToList())
            {
                text += "<tr ><td style='padding: 5px; border: 1px solid #34C38A; text-align: right;' colspan='3'>"+oe.ExtraCharge.Name+"</td><td style='padding: 5px; border: 1px solid #34C38A;'>";
                text += "£ "+oe.ExtraCharge.Price + "</td></tr>";
            }
            foreach (Order_Taxes ot in order.Order_Taxes.ToList())
            {
                text += "<tr ><td style='padding: 5px; border: 1px solid #34C38A; text-align: right;' colspan='3'>"+ot.Tax.Name+"</td><td style='padding: 5px; border: 1px solid #34C38A;'>";
                text += ot.Tax.Percentage + "% </td></tr>";
            }

            foreach (Order_Discount oe in order.Order_Discount.ToList())
            {
                text += "<tr ><td style='padding: 5px; border: 1px solid #34C38A; text-align: right;' colspan='3'>"+oe.Discount.Name+"</td><td style='padding: 5px; border: 1px solid #34C38A;'>";
                text += oe.Discount.Percentage + "%</td></tr>";
            }

            text += "<tr ><td style='padding: 5px; border: 1px solid #34C38A; text-align: right;' colspan='3'>Total</td><td style='padding: 5px; border: 1px solid #34C38A;'>";
            text += "£ " + total + "</td></tr>";
            text += "</tbody></table></body></html>";
            return text;
        }


       


    }
}