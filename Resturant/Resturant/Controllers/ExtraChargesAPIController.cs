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
    public class ExtraChargesAPIController : ApiController
    {
        // POST api/<controller>
        public ExtraChargesAPIController()
        {
            // Add the following code
            // problem will be solved

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }


        public ExtraCharge ExtraChargesById(int _Id)
        {
            return new BLExtraCharges().getExtraChargesById(_Id);
        }
        //api/<controller>
        public List<ExtraCharge> ExtraChargesList()
        {
            return new BLExtraCharges().getListOfExtraCharges();

        }
    }
}