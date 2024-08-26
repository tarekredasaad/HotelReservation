using Autofac;
using AutoMapper;
using FluentValidation;
using HotelReservationApi.Data;
using HotelReservationApi.MapperProfile;
using HotelReservationApi.Mediator.Facilities;
using HotelReservationApi.Mediator.Reservations;
using HotelReservationApi.Mediator.Rooms;
using HotelReservationApi.Repository;
using HotelReservationApi.Services.AuthService;
using HotelReservationApi.Services.FacilitiesSrv;
using HotelReservationApi.Services.InvoiceSrv;
using HotelReservationApi.Services.Pictures;
using HotelReservationApi.Services.ReservationSrv;
using HotelReservationApi.Services.RoomFacilities;
using HotelReservationApi.Services.RoomReservationSrv;
using HotelReservationApi.Services.Rooms;
using HotelReservationApi.Services.RoomsSrv;
using HotelReservationApi.Validators;

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
            builder.RegisterType<InvoiceService>().As<IInvoiceService>().InstancePerLifetimeScope();
            builder.RegisterType<ReservationService>().As<IReservationService>().InstancePerLifetimeScope();
            builder.RegisterType<RoomFacilityService>().As<IRoomFacilityService>().InstancePerLifetimeScope();
            builder.RegisterType<RoomReservationService>().As<IRoomReservationService>().InstancePerLifetimeScope();

            builder.RegisterType<RoomMediator>().As<IRoomMediator>().InstancePerLifetimeScope();
            builder.RegisterType<FacilityMediator>().As<IFacilityMediator>().InstancePerLifetimeScope();
            builder.RegisterType<ReservationMediator>().As<IReservationMediator>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<RoomProfile>();
                cfg.AddProfile<PictureProfile>();
                cfg.AddProfile<FacilityProfile>();
                cfg.AddProfile<ReservationProfile>();
                cfg.AddProfile<RoomReservationProfile>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ReservationViewModelValidator).Assembly)
               .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
               .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(ConfirmReservationValidator).Assembly)
               .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
               .AsImplementedInterfaces();
        }
    }
}
