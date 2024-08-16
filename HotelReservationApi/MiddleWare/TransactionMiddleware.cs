using HotelReservationApi.Data;
using HotelReservationApi.Models;

namespace HotelReservationApi.MiddleWare
{
    public class TransactionMiddleware
    {
        Context _context;
        RequestDelegate _next;

        public TransactionMiddleware(Context context, RequestDelegate next)
        {
            _context = context;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var method = httpContext.Request.Method.ToUpper();
            if (method == "POST" || method == "PUT" || method == "DELETE")
            {
                var transaction = _context.Database.BeginTransaction();
               
                try
                {
                    
                     await _next(httpContext);
                     _context.SaveChanges();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction?.RollbackAsync();
                    throw;
                }
            }
            else
            {
                await _next(httpContext);
            }
        }

    }
}
