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
    public class FoodAPIController : ApiController
    {
        // POST api/<controller>
        public FoodAPIController()
        {
            // Add the following code
            // problem will be solved

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
        public Food FoodById(int _Id)
        {
            return new BLFood().getFoodById(_Id);
        }
        //api/<controller>
        public List<Food> FoodList()
        {
            return new BLFood().getListOfFood();

        }
        public List<Food> FoodListByCategoryId(int _CatefgoryId)
        {
            return new BLFood().getListOfFoodByCategoryId(_CatefgoryId);

        }
    }
}