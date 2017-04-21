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
    public class AddOnAPIController : ApiController
    {
        // POST api/<controller>
        public AddOnAPIController()
        {
            // Add the following code
            // problem will be solved

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }


        public AddOn AddOnById(int _Id)
        {
            AddOn addon= new BLFood().getAddOnById(_Id);
            
            if (addon != null)
            {
                AddOn returnAddOn = new AddOn();
                returnAddOn.Id = addon.Id;
                returnAddOn.Name = addon.Name;
                returnAddOn.Price = addon.Price;
                returnAddOn.Category = addon.Category;
                return returnAddOn;
            }
            return addon;
        }
        //api/<controller>
        public List<AddOn> AddOnList()
        {
            List<AddOn> listOfAddOn= new List<AddOn>();    
             List<AddOn> listOfAddOn1=new BLFood().getListOfAddon();
            foreach(AddOn addon in listOfAddOn1)
            {
                AddOn returnAddOn = new AddOn();
                returnAddOn.Id = addon.Id;
                returnAddOn.Name = addon.Name;
                returnAddOn.Price = addon.Price;
                returnAddOn.Category = addon.Category;
                listOfAddOn.Add(returnAddOn);
            }
            return listOfAddOn;
        }

        public List<AddOn> AddOnListByFoodItemId(int foodItemId)
        {
            BLFood blfood= new BLFood();
            Food food = blfood.getFoodItemById(foodItemId).Food;
            List<Food_AddOn> listOfFood_AddOn = new List<Food_AddOn>();
            List<Food_AddOn> listOfFood_AddOn1 = blfood.getListOfFood_AddOn().Where(food_Add => food_Add.FoodId == food.Id).ToList();

            List<AddOn> addons = new List<AddOn>();
            foreach(Food_AddOn fa in listOfFood_AddOn1)
            {
                AddOn ao = new AddOn();
                AddOn temp =blfood.getAddOnById(fa.AddOnId);
             
                if (temp != null)
                {
                    ao.Id = temp.Id;
                    ao.Name = temp.Name;
                    ao.Price = temp.Price;
                    addons.Add(ao);
                }
            }
            return addons;
        }
    }
}