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
    public class SpecialOfferAPIController : ApiController
    {
        // POST api/<controller>
        public SpecialOfferAPIController()
        {
            // Add the following code
            // problem will be solved

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }


        public SpecialOffer SpecialOfferById(int _Id)
        {
            return new BLFood().getSpecialOffersById(_Id);
        }
        //api/<controller>
        public List<SpecialOffer> SpecialOfferList()
        {
            return new BLFood().getListOfSpecialOffers();

        }
    }
}