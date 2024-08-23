﻿using HotelReservationApi.Data;
using HotelReservationApi.Models;

namespace HotelReservationApi.MiddleWare
{
    public class TransactionMiddleware
    {

        //private readonly Context _context;
        RequestDelegate _next;

        public TransactionMiddleware(
            //Context context,
            RequestDelegate next)
        {
            //_context = context;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, Context context)
        {
            var method = httpContext.Request.Method.ToUpper();
            if (method == "POST" || method == "PUT" || method == "DELETE")
            {
                var transaction = context.Database.BeginTransaction();
               
                try
                {
                    
                     await _next(httpContext);
                    await context.SaveChangesAsync();
                   
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction?.RollbackAsync();
                    throw ex;
                }
            }
            else
            {
                await _next(httpContext);
            }
        }

    }
}
