using Resturant.BAL;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Resturant.UtilityClasses;

namespace Resturant.Controllers
{
    public class CousineAPIController : ApiController
    {
        // POST api/<controller>
        public CousineAPIController()
        {
            // Add the following code
            // problem will be solved
          
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }


        public Cousine CousineById(int _Id)
        {
            return new BLFood().getCousineById(_Id);
        }

        public string Token()
        {
            Payments p = new Payments();
            return p.TokenforApi();
        }
        //api/<controller>
        //public List<Cousine> CousineList()
        //{
        //    return new BLFood().getListOfCousine();

        //}
    }
}