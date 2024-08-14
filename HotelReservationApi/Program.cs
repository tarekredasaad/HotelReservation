using HotelReservationApi.Data;
using HotelReservationApi.MapperProfile;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using HotelReservationApi.Helper;



namespace HotelReservationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<Context>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
                //.LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                //.EnableSensitiveDataLogging();

            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);
            //builder.Services.AddAutoMapper(typeof(UserProfile));
            builder.Services.AddLogging(builder => builder.AddDebug());

            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            MapperHelper.Mapper = app.Services.GetService<IMapper>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
