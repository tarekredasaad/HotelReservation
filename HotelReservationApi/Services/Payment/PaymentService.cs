using Stripe;

namespace HotelReservationApi.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PaymentIntent> CreatePaymentIntent(double amount, string paymentMethodId = null)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long) (amount * 100),
                Currency = "usd",
                PaymentMethod = "card",

            };

            var service = new PaymentIntentService();
            return await service.CreateAsync(options);
        }
    }
}
