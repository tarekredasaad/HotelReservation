using Microsoft.EntityFrameworkCore;

namespace HotelReservationApi.Data
{
    public class Context :DbContext 
    {
        public Context( )  { }
        public Context(DbContextOptions options) : base(options)
        { }






    }
}
