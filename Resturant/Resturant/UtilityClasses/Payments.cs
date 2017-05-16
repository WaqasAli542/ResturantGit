using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Resturant.UtilityClasses
{
    public class Payments
    {


        BraintreeGateway gateway = new BraintreeGateway
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = "hqwcfx2kb4whc6x5",
            PublicKey = "dvrc3tdbs9df3gwy",
            PrivateKey = "7f0b093ee5f0b7c4c481e0f1694c5689"
        };



        public  Payments()
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            var clientToken = gateway.ClientToken.generate();
            System.Web.HttpContext.Current.Session["token"] = clientToken;
        }


        public bool proceedPayment(string nonce,double amount)
        {
          string nonceFromTheClient = nonce;
            // Use payment method nonce here
            var request = new TransactionRequest
            {
                Amount =Convert.ToDecimal(amount),
                PaymentMethodNonce = nonceFromTheClient,
           
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }

        
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);
            if (result.IsSuccess())
            {
                Transaction transaction = result.Target;
                TransactionStatus status = transaction.Status;
                return true;
                // TransactionStatus.AUTHORIZED
            }
            return false;
        
        }

    }
}