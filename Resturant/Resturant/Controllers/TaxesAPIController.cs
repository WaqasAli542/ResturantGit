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
    public class TaxesAPIController : ApiController
    {
        // POST api/<controller>
        public TaxesAPIController()
        {
            // Add the following code
            // problem will be solved

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }


        public Tax TaxById(int _Id)
        {
            return new BLTax().getTaxById(_Id);
        }
        //api/<controller>
        public List<Tax> TaxList()
        {
            return new BLTax().getListOfTax();

        }
    }
}