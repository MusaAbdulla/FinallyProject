using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.BL.External_Service
{
   public  class StripeService:IStripeService
    {
        private readonly string _secretKey = "sk_test_51Qo7yWR7px2OdMyS43x1itFIJw6rH5jvWQOg4D8Aih7DYPhDUDsEgJV7dapZtWbIYXe88YW0iKS5cKE1p7Ip2QTv007PPJMsul";

        public StripeService()
        {
            StripeConfiguration.ApiKey = _secretKey;
        }

        public async Task<string> CreateCheckoutSession(decimal amount, string currency)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
         {
             new SessionLineItemOptions
             {
                 PriceData = new SessionLineItemPriceDataOptions
                 {
                     Currency = currency,
                     UnitAmount = (long)(amount * 100),
                     ProductData = new SessionLineItemPriceDataProductDataOptions
                     {
                         Name = "Order Payment"
                     }
                 },
                 Quantity = 1
             }
         },
                Mode = "payment",
                SuccessUrl = "https://yourwebsite.com/payment-success",
                CancelUrl = "https://yourwebsite.com/payment-failed",
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);
            return session.Url; // Redirect üçün URL qaytarır
        }

    }
}
