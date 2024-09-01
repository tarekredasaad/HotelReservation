using HotelReservationApi.Models;

namespace HotelReservationApi.Services.InvoiceSrv
{
    public interface IInvoiceService
    {
        Task<Invoice> AddInvoice(Invoice invoice);
    }
}
