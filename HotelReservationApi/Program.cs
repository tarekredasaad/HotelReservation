using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using HotelReservationApi.Data;
using HotelReservationApi.Helper;
using HotelReservationApi.Middlewares;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace HotelReservationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Add services to the container.
           builder.Services.AddDbContext<Context>(option =>
           {
               option.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
               .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
               .EnableSensitiveDataLogging();
           });

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
                builder.RegisterModule(new AutoFacModule()));


            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddLogging(builder => builder.AddDebug());

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            MapperHelper.Mapper = app.Services.GetService<IMapper>();

            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();


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
