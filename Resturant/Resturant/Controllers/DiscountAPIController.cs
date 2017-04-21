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
    public class DiscountAPIController : ApiController
    {
        // POST api/<controller>
        public DiscountAPIController()
        {
            // Add the following code
            // problem will be solved

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }


        public Discount DiscountById(int _Id)
        {
            return new BLDiscount().getDiscountById(_Id);
        }
        public Discount DiscountByCategoryId(int _DiscountId)
        {
            Discount discount= new BLDiscount().getDiscountByCategoryId(_DiscountId);
            return discount;
               
        }
        //api/<controller>
        public List<Discount> DiscountList()
        {
            return new BLDiscount().getListOfDiscount();

        }
    }
}