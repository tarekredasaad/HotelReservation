using HotelReservationApi.Models;

namespace HotelReservationApi.Services.Invoices
{
    public interface IInvoiceService
    {
        Task<Invoice> AddInvoice(Invoice invoice);
    }
}
