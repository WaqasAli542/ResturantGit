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

        public ActionResult Login()
        {
            return View();
        }

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
        [HttpGet]
        public string GetOrder()
        {
            Order o = new BLOrder().getOrderById((int)System.Web.HttpContext.Current.Session["orderId"]);
            return JsonConvert.SerializeObject(o, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        });

      
        }

    }
}
