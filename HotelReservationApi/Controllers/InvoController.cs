using HotelReservationApi.Configration;
using HotelReservationApi.Data;
using HotelReservationApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoController : ControllerBase
    {
        public readonly StripeSettings _stripeSettings;
        //Context _context;

        public InvoController(
            IOptions<StripeSettings> stripeSettings
            //,Context context
            )
        {
            _stripeSettings = stripeSettings.Value;
            //_context = context;
        }
        [HttpPost("charge")]
        public ActionResult CreateCheckOut(long amount)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100),
                Currency = "usd",
                PaymentMethod = "pm_card_visa",

            };  //_stripeSettings.SecretKey;//
            StripeConfiguration.ApiKey = "sk_test_51PqW8S01MqAl9mk4G6qYv1fym30xCJqVD8RhU3ZUGV9fd8WVw9L6sWM1RbmxIpUI9jPyL63KykSr8S3gsKankoL900CmF3Bs1W";
            var service = new PaymentIntentService();
            PaymentIntent response = service.Create(options);
            PaymentMethod paymentMethod = new PaymentMethod();
            var optionsCheckout = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = response.Currency,
                            UnitAmount = response.Amount,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = " H23",
                                Description = " Room in Global Hotel 5 star"
                            }

                        },
                        Quantity = 1

                    }

                },
                Mode = "payment",
                SuccessUrl = "http://www.google.co.uk",
                CancelUrl = "https://localhost:5255/"
            };
            var SussionService = new SessionService();
            var session = SussionService.Create(optionsCheckout);
  
            return Ok(  session.Url);
        }
    }
}
