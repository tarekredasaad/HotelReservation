using Autofac;
using HotelReservationApi.Data;
using HotelReservationApi.Mediator.Reservations;
using HotelReservationApi.Mediator.Rooms;
using HotelReservationApi.Repository;
using HotelReservationApi.Services.FacilitiesSrv;
using HotelReservationApi.Services.PictureSrv;
using HotelReservationApi.Services.ReservationSrv;
using HotelReservationApi.Services.RoomFacilitySrv;
using HotelReservationApi.Services.RoomReservationSrv;
using HotelReservationApi.Services.RoomsSrv;

namespace HotelReservationApi
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoomService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IPictureService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IFacilitiesService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IPictureService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoomFacilityService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoomMediator).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IReservationService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoomReservationService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IReservationMediator).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
