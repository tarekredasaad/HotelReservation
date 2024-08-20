using Autofac;
using AutoMapper;
using HotelReservationApi.Data;
using HotelReservationApi.MapperProfile;
using HotelReservationApi.Mediators.Facilities;
using HotelReservationApi.Mediators.Rooms;
using HotelReservationApi.Repository;
using HotelReservationApi.Services.AuthService;
using HotelReservationApi.Services.Facilities;
using HotelReservationApi.Services.Pictures;
using HotelReservationApi.Services.RoomFacilities;
using HotelReservationApi.Services.RoomReservations;
using HotelReservationApi.Services.Rooms;

namespace HotelReservationApi
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<RoomService>().As<IRoomService>().InstancePerLifetimeScope();
            builder.RegisterType<PictureService>().As<IPictureService>().InstancePerLifetimeScope();
            builder.RegisterType<FacilityService>().As<IFacilityService>().InstancePerLifetimeScope();
            builder.RegisterType<RoomFacilityService>().As<IRoomFacilityService>().InstancePerLifetimeScope();
            builder.RegisterType<RoomReservationService>().As<IRoomReservationService>().InstancePerLifetimeScope();

            builder.RegisterType<RoomMediator>().As<IRoomMediator>().InstancePerLifetimeScope();
            builder.RegisterType<FacilityMediator>().As<IFacilityMediator>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<RoomProfiler>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
