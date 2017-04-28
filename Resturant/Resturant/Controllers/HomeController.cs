using Newtonsoft.Json;
using Resturant.BAL;
using Resturant.BAL.Order_Managament;
using Resturant.Models;
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

        OrderMgmt orderMgmt;

        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Session["orderId"] = null;
            System.Web.HttpContext.Current.Session["PresentId"] = null;
            DateTime today_date = Convert.ToDateTime(string.Format("{0:HH:mm:ss tt}", DateTime.Now));
            DateTime time = Convert.ToDateTime(today_date.TimeOfDay.ToString());

            DateTime date_of_starting = Convert.ToDateTime("04/10/2017");
            DateTime time2 = Convert.ToDateTime(date_of_starting.TimeOfDay.ToString());
            DateTime date_of_ending = Convert.ToDateTime("05/10/2017");
            TimeSpan startingTimeDiff = time.TimeOfDay - time2.TimeOfDay;
            TimeSpan endingTimeDiff = date_of_ending - today_date;
            List<Discount> discounts = new BLDiscount().getListOfDiscount();
            DateTime dt = Convert.ToDateTime(discounts.First().StartingTime.ToString());

            if ((startingTimeDiff.TotalMinutes > 0) && (endingTimeDiff.TotalMinutes > 0))
            {


            }
            List<Items> Items= new List<Items>();
            System.Web.HttpContext.Current.Session["Items"] = Items;
            return View();
        }
        public ActionResult Career()
        {
            return View();
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
        public string AddItems(string name,string price)
        {
            Items item = new Items(1, name, price);
            List<Items> items = (List<Items>)System.Web.HttpContext.Current.Session["Items"];
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
            FoodItem foodItem = new FoodItem { Size = temp.Size, Price = temp.Price };
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
            List<AddOn> addons = new List<AddOn>();


            List<Food_AddOn> food_addons = new BLFood().getListOfFood_AddOn().Where(foodAddon => foodAddon.FoodId == food.Id).ToList();
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
     
         
            
            
            foreach (SpecialOffer_Item item in temp)
           {
           //    List<Food> foods = new List<Food>();
           //       foreach (var f in item.Category.Foods)
           //{
           //    f.Category = null;
           //    f.Food_Ingredients = null;
           //    f.Tageline = null;
          
           //    List<FoodItem> fItems= new List<FoodItem>();
           //     foreach(FoodItem fi in f.FoodItems)
           //     {
           //         fi.Food = null;
           //         fi.FoodItem_AddOn = null;
           //         fi.Order_FoodItem = null;
           //         fi.Order_SpecialOffer_FoodItem = null;
           //         fi.Order_SpecialOffer_Item = null;
           //         fItems.Add(fi);
           //     }
           //     f.FoodItems=fItems;
           //     foods.Add(f);
           //}
           //       item.Category.Foods = foods;
           //       item.Category.Cousine = null;
           //       item.Category.Discounts = null;
           //       item.Food_Size = null;
           //       item.SpecialOffer = null;
           //       items.Add(item);
               SpecialOffer_Item it = new SpecialOffer_Item();
               Category ca = new Category { Id = item.Category.Id, Name = item.Category.Name };
               List<Food> foods = new List<Food>();
               foreach (Food f in item.Category.Foods)
               {
                   Food tempf = new Food { Id = f.Id, Name = f.Name };

                   if (f.FoodItems.Count > 0)
                   {
                       FoodItem tempFoodItem = f.FoodItems.First(fItems => fItems.Food_Size_Id == item.SizeId);
                       if (tempFoodItem != null)
                       {
                           FoodItem tempfi = new FoodItem { Id = tempFoodItem.Id, Size = tempFoodItem.Size, Price = tempFoodItem.Price };
                           tempf.FoodItems = new List<FoodItem>();
                           tempf.FoodItems.Add(tempfi);

                       }
                       foods.Add(tempf);
                   }
               }
               ca.Foods = foods;
               it.Category = ca;
                items.Add(it);


               
            }
        

           return JsonConvert.SerializeObject(items, Formatting.Indented,
              new JsonSerializerSettings()
              {
                  ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              });

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
            if (orderMgmt == null)
                orderMgmt = new OrderMgmt();

            orderMgmt.addFoodItem(foodItemId);

            List<AddOn> addons = new BLFood().getListOfAddon();
            foreach (AddOn ad in addons)
            {
                string valId = ad.Id.ToString();
                string val = Request.Form[valId];
                if (val != null)
                    orderMgmt.addAddOn(ad.Id);
            }
            return RedirectToAction("Menu");
        }

    }
}
