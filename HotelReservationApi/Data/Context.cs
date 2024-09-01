using Microsoft.EntityFrameworkCore;
using HotelReservationApi.Models;

namespace HotelReservationApi.Data
{
    public class Context : DbContext 
    {
        public Context( )  
        {

        }
        public Context(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<User> users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<RoomReservationFacility> RoomReservationFacilities { get; set; }
        public DbSet<RoomFacility> RoomFacilities { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
