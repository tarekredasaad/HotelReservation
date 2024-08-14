using Microsoft.EntityFrameworkCore;
using HotelReservationApi.Models;

namespace HotelReservationApi.Data
{
    public class Context :DbContext 
    {
        public Context( )  
        {
           ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public Context(DbContextOptions options) : base(options)
        { 
        
        }

        public DbSet<User> users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomBooking> RoomBookings { get; set; }
        public DbSet<RoomFacilities> RoomFacilities { get; set; }
        public DbSet<RoomOffer> RoomOffers { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }





    }
}
