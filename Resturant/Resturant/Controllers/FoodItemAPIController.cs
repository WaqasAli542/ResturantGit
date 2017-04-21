using Resturant.BAL;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Resturant.Controllers
{
    public class FoodItemAPIController : ApiController
    {
        // POST api/<controller>
        public FoodItemAPIController()
        {
            // Add the following code
            // problem will be solved

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        public List<FoodItem> FoodItemListByFoodId(int _FoodId)
        {
            return new BLFood().getListOfFoodItemByFoodId(_FoodId);

        }
        public FoodItem FoodItemById(int _Id)
        {
            return new BLFood().getFoodItemById(_Id);
        }
        //api/<controller>
        public List<FoodItem> FoodItemList()
        {
            return new BLFood().getListOfFoodItem();

        }
    }
}