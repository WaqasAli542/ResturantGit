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
    public class Food_AddOnAPIController : ApiController
    {
         // POST api/<controller>
        public Food_AddOnAPIController()
        {
            // Add the following code
            // problem will be solved

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }


        public Food_AddOn Food_AddOnById(int _Id)
        {
            Food_AddOn Food_AddOn= new BLFood().getFood_AddOnById(_Id);
            
            if (Food_AddOn != null)
            {
                Food_AddOn returnFood_AddOn = new Food_AddOn();
                returnFood_AddOn.Id = Food_AddOn.Id;
                returnFood_AddOn.AddOnId = Food_AddOn.AddOnId;
                returnFood_AddOn.FoodId = Food_AddOn.FoodId;            
                return returnFood_AddOn;
            }
            return Food_AddOn;
        }
        //api/<controller>
        public List<Food_AddOn> Food_AddOnList()
        {
            List<Food_AddOn> listOfFood_AddOn= new List<Food_AddOn>();    
             List<Food_AddOn> listOfFood_AddOn1=new BLFood().getListOfFood_AddOn();
            foreach(Food_AddOn Food_AddOn in listOfFood_AddOn1)
            {
                Food_AddOn returnFood_AddOn = new Food_AddOn();
                returnFood_AddOn.Id = Food_AddOn.Id;
                returnFood_AddOn.AddOnId = Food_AddOn.AddOnId;
                returnFood_AddOn.FoodId = Food_AddOn.FoodId;   
                listOfFood_AddOn.Add(returnFood_AddOn);
            }
            return listOfFood_AddOn;
        }
        
    public List<Food_AddOn> Food_AddOnListByFoodId(int foodId)
        {
            List<Food_AddOn> listOfFood_AddOn = new List<Food_AddOn>();
            List<Food_AddOn> listOfFood_AddOn1 = new BLFood().getListOfFood_AddOn().Where(food_Add=>food_Add.FoodId==foodId).ToList();
            foreach (Food_AddOn Food_AddOn in listOfFood_AddOn1)
            {
                Food_AddOn returnFood_AddOn = new Food_AddOn();
                returnFood_AddOn.Id = Food_AddOn.Id;
                returnFood_AddOn.AddOnId = Food_AddOn.AddOnId;
                returnFood_AddOn.FoodId = Food_AddOn.FoodId;
                listOfFood_AddOn.Add(returnFood_AddOn);
            }
            return listOfFood_AddOn;

        }
    }

    
}
