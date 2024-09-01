using HotelReservationApi.Models;
using HotelReservationApi.Repositories;

namespace HotelReservationApi.Services.Invoices
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
            Invoice invoice1 = await _invoiceRepository.AddAsync(invoice);
            return invoice1;

        }
        
    }
}
