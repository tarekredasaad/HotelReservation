using Stripe;

namespace HotelReservationApi.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreatePaymentIntent(double amount)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];

            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100),
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" },
            };

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.CreateAsync(options);

            return paymentIntent.Id;
        }

        public async Task<PaymentIntent> ConfirmPaymentIntent(string paymentIntentId)
        {
            throw new NotImplementedException();
        }
    }
}
