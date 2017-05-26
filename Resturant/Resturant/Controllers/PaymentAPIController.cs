using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Resturant.UtilityClasses;

namespace Resturant.Controllers
{
    public class PaymentAPIController : ApiController
    {
       
        public PaymentAPIController()
        {
            // Add the following code
            // problem will be solved

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
               .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        BraintreeGateway gateway = new BraintreeGateway
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = "hqwcfx2kb4whc6x5",
            PublicKey = "dvrc3tdbs9df3gwy",
            PrivateKey = "7f0b093ee5f0b7c4c481e0f1694c5689"
        };

        // GET api/<controller>/5
        public string Token()
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string clientToken = gateway.ClientToken.generate();
            return clientToken;
        }
        //public string Nonce(string token)
        //{
         
        //    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
        //    Result<PaymentMethodNonce> result = gateway.PaymentMethodNonce.Create(token);
        //    String nonce = result.Target.Nonce;
        //    return nonce;
        //}
    }
}