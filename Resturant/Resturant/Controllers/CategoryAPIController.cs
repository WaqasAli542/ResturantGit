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
    public class CategoryAPIController : ApiController
    {
         public CategoryAPIController()
        {
            // Add the following code
            // problem will be solved
          
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

         public List<Category> CategoryListByCousineId(int _CousineId)
         {
             return new BLFood().getListOfCategoryByCousineId(_CousineId);
         }
        public Category CategoryById(int _Id)
        {
            return new BLFood().getCategoryById(_Id);
        }
        //api/<controller>
        public List<Category> CategoryList()
        {
            return new BLFood().getListOfCategory();

        }
      
    }
}