using Stripe;

namespace HotelReservationApi.Services.Payment
{
    public interface IPaymentService
    {
        Task<PaymentIntent> CreatePaymentIntent(double amount, string paymentMethodId = null);
    }
}
