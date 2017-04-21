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
    public class IngredientsAPIController : ApiController
    {
        // POST api/<controller>
        public IngredientsAPIController()
        {
            // Add the following code
            // problem will be solved

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }


        public Ingredient IngredientsById(int _Id)
        {
            return new BLFood().getIngredientById(_Id);
        }
        //api/<controller>
        public List<Ingredient> IngredientsList()
        {
            return new BLFood().getListOfIngredients();

        }
    }
}