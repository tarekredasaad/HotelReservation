using Stripe;

namespace HotelReservationApi.Services.Payments
{
    public interface IPaymentService
    {
        Task<string> CreatePaymentIntent(double amount);
        Task<PaymentIntent> ConfirmPaymentIntent(string paymentIntentId);
    }
}
