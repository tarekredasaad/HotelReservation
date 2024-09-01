using HotelReservationApi.Models;
using HotelReservationApi.Repository;

namespace HotelReservationApi.Services.InvoiceSrv
{
    public class InvoiceService : IInvoiceService
    {
        IRepository<Invoice> _invoiceRepository;

        public InvoiceService(IRepository<Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> AddInvoice(Invoice invoice)
        {
            Invoice invoice1 = await _invoiceRepository.Add(invoice);
            return invoice1;

        }
        
    }
}
