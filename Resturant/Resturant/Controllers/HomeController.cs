using Newtonsoft.Json;
using Resturant.BAL;
using Resturant.BAL.Order_Managament;
using Resturant.Models;
using Resturant.Models.DTO;
using Resturant.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant.Controllers
{
    public class HomeController : Controller
    {


        
        //
        // GET: /Home/
        public ActionResult Index()
        {
           
            System.Web.HttpContext.Current.Session["orderId"] = null;
            System.Web.HttpContext.Current.Session["PresentId"] = null;

         
            return View();
        }
        public ActionResult loginrequest(string Email, string Password)
        {
            // database check

            Customer isLogin = new BLCustomer().Login(Email, Password);
            if(isLogin.Id > 0)
            {
                System.Web.HttpContext.Current.Session["LoginCustomer"] = isLogin;
                return RedirectToAction("Location");
            }
            return RedirectToAction("Login");
        }
        public ActionResult Check_Out()
        {


            List<Items> items = (List<Items>)System.Web.HttpContext.Current.Session["Items"];
            if(items==null)
            {
                return RedirectToAction("Menu");
            }
            Payments payment = new Payments();




            ViewBag.extracharges = new BLExtraCharges().getListOfExtraCharges();
            ViewBag.Taxes = new BLTax().getListOfTax();
 
            ViewBag.Customer = new BLCustomer().getCustomersById(2);



            ////Discounts

            //List<Discount> discounts =new BLDiscount().getListOfDiscount();
            //List<Discount> temp = new List<Discount>();
            // DateTime today_date = Convert.ToDateTime(string.Format("{0:HH:mm:ss tt}", DateTime.Now));
            //DateTime today_time = Convert.ToDateTime(today_date.TimeOfDay.ToString());
            //int i = 0;
            //foreach(Discount  discount in discounts)
            //{
            //    if ((today_date - discount.StartingDate).TotalMinutes > 0 && (discount.EndingDate - today_date).TotalMinutes > 0)
            //    {
            //          TimeSpan t=(TimeSpan)(TimeSpan.FromTicks(today_time.Ticks)-discount.StartingTime) ;
            //          temp.Add(discount);
            //    }
            //    else
            //    {
            //        discounts.RemoveAt(i);
            //    }
            //    i++;
            //}

            return View(items);
        }

        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult SaveCustomer(Customer customer)
        {
           bool check= new BLCustomer().addCustomers(customer);
            return RedirectToAction("index");
        }
        public ActionResult LoginFromCheckOut(string Email, string Password)
        {

            Customer isLogin = new BLCustomer().Login(Email, Password);
            if (isLogin.Id > 0)
            {
                System.Web.HttpContext.Current.Session["LoginCustomer"] = isLogin;
            }
            return RedirectToAction("Check_Out");
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Menu()
        {
            ViewBag.Session = "alpha";
            List<Cousine> cousine = new BLFood().getListOfCousine().ToList();
            return View(cousine[0]);
        }
        public ActionResult SpecialOffers()
        {
            ViewBag.Session = "alpha";
            List<SpecialOffer> specialOffers = new BLFood().getListOfSpecialOffers();
            return View(specialOffers);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Catering()
        {
            return View();
        }
        public ActionResult Location()
        {
            return View();
        }
        public ActionResult OrderOnline()
        {
            return View();
        }

        // ---------------------------------------This region is all about the simple cousine items----------------------------------
        #region Simple-offer
        //getItems
        [HttpGet]
        public string getItems(string Test)
        {
            List<Items> items = (List<Items>)System.Web.HttpContext.Current.Session["Items"];
            return JsonConvert.SerializeObject(items, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        });

        }
        //AddItems
        [HttpGet]
        public string AddItems(string name,string price,string addon,string fitem)
        {

            Double actualPrice = Convert.ToDouble(price);

            Items item = new Items(1, name, actualPrice, addon, fitem);
            List<Items> items = (List<Items>)System.Web.HttpContext.Current.Session["Items"];
            if (items == null)
                items = new List<Items>();
            items.Add(item);
            System.Web.HttpContext.Current.Session["Items"] = items;
            return JsonConvert.SerializeObject(null, Formatting.Indented,
             new JsonSerializerSettings()
             {
                 ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             });

        }
        //UpdateItemQuantities
        [HttpGet]
        public string UpdateItemQuantities(string Quantities)
        {
           
            Quantities = Quantities.Substring(0, Quantities.Length - 1);
            int i=0;
            string[] a = Quantities.Split(',');
            Array.Reverse(a);
            List<Items> items = (List<Items>)System.Web.HttpContext.Current.Session["Items"];
            if(items== null)
            {
                items = new List<Items>();
            }
            foreach (Items item in items)
            {
                string np = item.Name + item.price;
                if (np.Equals(Quantities))
                { }
                else
                {
                    item.Quantitity = Int32.Parse(a[i]);
                    i++;
                }
            }
            System.Web.HttpContext.Current.Session["Items"] = items;
            return JsonConvert.SerializeObject(null, Formatting.Indented,
             new JsonSerializerSettings()
             {
                 ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             });

        }

        //DeleteItem
        [HttpGet]
        public string DeleteItem(string name)
        {
            int i = 0;
                List<Items> items = (List<Items>)System.Web.HttpContext.Current.Session["Items"];
                foreach (Items item in items)
                {
                    string np = item.Name + item.price;
                    if (np.Equals(name))
                    {
                        items.RemoveAt(i);
                        break;
                    }
                    i++;
                }
         
          
            return JsonConvert.SerializeObject(null, Formatting.Indented,
             new JsonSerializerSettings()
             {
                 ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             });

        }
        [HttpGet]
        public string GetFoodItem(int foodItemID)
        {
            ViewBag.Session = "alpha";
            FoodItem temp = new BLFood().getFoodItemById(foodItemID);
            FoodItem foodItem = new FoodItem { Size = temp.Size, Price = temp.Price, Food=new Food {Name=temp.Food.Name} };
            return JsonConvert.SerializeObject(foodItem, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        });
           
        }

        [HttpGet]
        public string GetAddOnByFoodId(int foodItemID)
        {
            ViewBag.Session = "alpha";
            BLFood blfood = new BLFood();
            Food food = blfood.getFoodItemById(foodItemID).Food;
            FoodItem foodItem = blfood.getFoodItemById(foodItemID);
            List<AddOn> addons = new List<AddOn>();


            List<Food_AddOn> food_addons = new BLFood().getListOfFood_AddOn().Where(foodAddon => foodAddon.FoodId == food.Id && foodAddon.FoodSizeId == foodItem.Food_Size_Id&&foodAddon.AddOn.IsAvailable==1).ToList();
            List<Food_AddOn> temp = new BLFood().getListOfFood_AddOn().Where(foodAddon => foodAddon.FoodId == food.Id && foodAddon.FoodSizeId == null && foodAddon.AddOn.IsAvailable == 1).ToList();

            if(temp.Count>0)
            food_addons.AddRange(temp);

            foreach (var item in food_addons)
            {
                addons.Add(new AddOn(){Name=item.AddOn.Name,Id=item.AddOn.Id,Price=item.AddOn.Price});
            }


            return JsonConvert.SerializeObject(addons, Formatting.Indented,
             new JsonSerializerSettings()
             {
                 ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             });
        }
        #endregion

        #region Special-offer
        //[HttpGet]
        //public string getItems(string Test)
        //{
        //    List<Items> items = (List<Items>)System.Web.HttpContext.Current.Session["Items"];
        //    return JsonConvert.SerializeObject(items, Formatting.Indented,
        //                new JsonSerializerSettings()
        //                {
        //                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //                });

        //}
        ////AddItems
        //[HttpGet]
        //public string AddItems(string name, string price)
        //{
        //    Items item = new Items(1, name, price);
        //    List<Items> items = (List<Items>)System.Web.HttpContext.Current.Session["Items"];
        //    items.Add(item);
        //    System.Web.HttpContext.Current.Session["Items"] = items;
        //    return JsonConvert.SerializeObject(null, Formatting.Indented,
        //     new JsonSerializerSettings()
        //     {
        //         ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //     });

        //}
        ////UpdateItemQuantities
        //[HttpGet]
        //public string UpdateItemQuantities(string Quantities)
        //{

        //    Quantities = Quantities.Substring(0, Quantities.Length - 1);
        //    int i = 0;
        //    string[] a = Quantities.Split(',');
        //    Array.Reverse(a);
        //    List<Items> items = (List<Items>)System.Web.HttpContext.Current.Session["Items"];
        //    foreach (Items item in items)
        //    {
        //        string np = item.Name + item.price;
        //        if (np.Equals(Quantities))
        //        { }
        //        else
        //        {
        //            item.Quantitity = Int32.Parse(a[i]);
        //            i++;
        //        }
        //    }
        //    System.Web.HttpContext.Current.Session["Items"] = items;
        //    return JsonConvert.SerializeObject(null, Formatting.Indented,
        //     new JsonSerializerSettings()
        //     {
        //         ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //     });

        //}

        ////DeleteItem
        //[HttpGet]
        //public string DeleteItem(string name)
        //{
        //    int i = 0;
        //    List<Items> items = (List<Items>)System.Web.HttpContext.Current.Session["Items"];
        //    foreach (Items item in items)
        //    {
        //        string np = item.Name + item.price;
        //        if (np.Equals(name))
        //        {
        //            items.RemoveAt(i);
        //            break;
        //        }
        //        i++;
        //    }


        //    return JsonConvert.SerializeObject(null, Formatting.Indented,
        //     new JsonSerializerSettings()
        //     {
        //         ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //     });

        //}
        [HttpGet]
        public string GetSpecialOfferItem(int SpecialOfferID)
        {
            ViewBag.Session = "alpha";
            List<SpecialOffer_Item> items = new List<SpecialOffer_Item>();
            SpecialOffer offer= new BLFood().getSpecialOffersById(SpecialOfferID);
        
            List<SpecialOffer_Item> temp = new BLFood().getListOfSpecialOffer_Item().Where(x=>x.SpecialOfferID==SpecialOfferID).ToList();
            List<SpecialOffer_ItemDTO> soiDTO = new List<SpecialOffer_ItemDTO>();
         
            
            
            foreach (SpecialOffer_Item item in temp)
           {
          
               SpecialOffer_ItemDTO it = new SpecialOffer_ItemDTO(item);
               CategoryDTO ca = new CategoryDTO(item.Category);
               List<FoodDTO> foods = new List<FoodDTO>();
               foreach (Food f in item.Category.Foods)
               {
                   FoodDTO tempf = new FoodDTO(f); 

                   if (f.FoodItems.Count > 0)
                   {
                       List<FoodItemDTO> foodItems = new List<FoodItemDTO>();
                       FoodItem tempFoodItem = f.FoodItems.First(fItems => fItems.Food_Size_Id == item.SizeId);
                       if (tempFoodItem != null)
                       {
                           foodItems.Add(new FoodItemDTO(tempFoodItem));

                       }
                       tempf.FoodItems =foodItems;
                   }
                   foods.Add(tempf);
               }
               ca.Foods = foods;
               it.Category = ca;
               soiDTO.Add(it);  
            }            return JsonConvert.SerializeObject(soiDTO, Formatting.Indented,
              new JsonSerializerSettings()
              {
                  ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              });

        }

        //GetSpecialOffer
        [HttpGet]
        public string GetSpecialOffer(int SpecialOfferID)
        {
            ViewBag.Session = "alpha";
            var specialOffer = new BLFood().getSpecialOffersById(SpecialOfferID);
            string json = JsonConvert.SerializeObject(specialOffer, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            return json;
        }


        [HttpGet]
        public string GetAddOnBySpecialOfferId(int sId)
        {
            ViewBag.Session = "alpha";
            var sAddOn = new BLFood().getListOfSpecialOffer_AddOn().Where(x=>x.SpecialOfferID==sId);
            string json = JsonConvert.SerializeObject(sAddOn, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            return json;
        }
        #endregion
        public ActionResult Login()
        {
            return View();
        }

        //This is adding to database but it is not usefull now ------------------------------- remmove this functionality--------------------
        public ActionResult AddtoOrder(int foodItemId)
        {
            //if (orderMgmt == null)
            //    orderMgmt = new OrderMgmt();

            //orderMgmt.addFoodItem(foodItemId);

            //List<AddOn> addons = new BLFood().getListOfAddon();
            //foreach (AddOn ad in addons)
            //{
            //    string valId = ad.Id.ToString();
            //    string val = Request.Form[valId];
            //    if (val != null)
            //        orderMgmt.addAddOn(ad.Id);
            //}
            return RedirectToAction("Menu");
            
        }


        public ActionResult payment(FormCollection collection)
        {


                                                                                                  
            Customer cust;
            BLCustomer blcustomer = new BLCustomer();
            string idCheck=collection["id"];
            string postCode = collection["PostCode"];
            string address = collection["Address"];
            string phoneNumber = collection["PhoneNumber"];
            string email = collection["email"];
            string last_name = collection["last_name"];
            string FirstName = collection["FirstName"];
            string password = collection["password"];
            string instructions = collection["instructions"];
            int id;
            string timeFromForm =collection["time"];
             string Time;
             TimeSpan ts;
             DateTime date;

            if(idCheck != null)
            {
               id = Convert.ToInt32(idCheck);
                cust = blcustomer.getCustomersById(id);

            }
            else
            {
                cust = new Customer()
                {
                    FirstName = FirstName,
                    LastName = last_name,
                    Password = password,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Address = address,
                    PostCode = postCode
                };

                blcustomer.addCustomers(cust);
                id = blcustomer.getLastAddedCustomer();

            }

            //this check is here if there is too much traffic on the site and two customers register at the same time
            //so this is for security measures

            Customer finalCustomer=blcustomer.getListOfCustomers().FirstOrDefault(x=>x.Id==id && x.FirstName==FirstName && x.LastName==last_name);

            if(!timeFromForm.Equals("ASAP"))
            {
             var split = timeFromForm.Split(':');
          
            ts = new TimeSpan(Convert.ToInt32(split[0]), Convert.ToInt32(split[0]), Convert.ToInt32(split[2]));
            
            }
            else
            {
                ts = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            }

            Order order = new Order()
            {
                DeliveryTime = ts,
                Status = (int)Resturant.UtilityClasses.ProjectEnums.OrderStatus.NotPiad,
                PaymentMethodId = 1,
                OrderDate=DateTime.Now,
                OrderArea=address,
                Instructions=instructions,
                CustomerId=finalCustomer.Id
            };

            new BLOrder().addOrder(order);
            Order finalOrder = new BLOrder().getListOfOrder().FirstOrDefault(x => x.CustomerId == finalCustomer.Id && x.DeliveryTime == ts);
            OrderMgmt om = new OrderMgmt(finalOrder);
            List<Items> items = (List<Items>)System.Web.HttpContext.Current.Session["Items"];
            om.generateOrder(items);
            om.addExtraCharges();
            om.addTaxes();
           
        


            Payments payments = new Payments();
             string nonceFromTheClient = collection["payment_method_nonce"];

             if (payments.proceedPayment(nonceFromTheClient,om.Total))
             {

                 System.Web.HttpContext.Current.Session["Items"] = null;
                 order.Status = (int)Resturant.UtilityClasses.ProjectEnums.OrderStatus.Paid;
                 om.sendMail("hello");
                 new BLOrder().updateOrder(order);
                 

                 return RedirectToAction("OrderReceived", new { val = "Thank you your order has been received. In case of any Query contact us on our Phone." });
             }
             else
                 return RedirectToAction("OrderReceived", new { val = "Sorry for inconvinience, an error occured while receiving your order. Please try again and if the problem presist please contact us at Phone Number" });
    
        }


        public ActionResult logOut()
        {
            System.Web.HttpContext.Current.Session["LoginCustomer"] = null;

            List<Items> Items = new List<Items>();
            System.Web.HttpContext.Current.Session["Items"] = Items;
            return RedirectToAction("Index");
        }
        public ActionResult OrderReceived (String val)
        {
            ViewBag.val = val;
            return View("OrderDelivered");
        }





        //CustomError Pages
        public ActionResult Error404()
        {
            return View();
        }
    }
}
