using Autofac;
using AutoMapper;
using FluentValidation;
using HotelReservationApi.Data;
using HotelReservationApi.MapperProfile;
using HotelReservationApi.Mediator.Reservations;
using HotelReservationApi.Mediator.Rooms;
using HotelReservationApi.Mediators.Facilities;
using HotelReservationApi.Mediators.Feedbacks;
using HotelReservationApi.Mediators.Rooms;
using HotelReservationApi.Mediators.Users;
using HotelReservationApi.Repositories;
using HotelReservationApi.Services.Facilities;
using HotelReservationApi.Services.Invoices;
using HotelReservationApi.Services.Pictures;
using HotelReservationApi.Services.Reservations;
using HotelReservationApi.Services.Roles;
using HotelReservationApi.Services.RoomFacilities;
using HotelReservationApi.Services.RoomReservations;
using HotelReservationApi.Services.Rooms;
using HotelReservationApi.Services.UserRoles;
using HotelReservationApi.Services.Users;
using HotelReservationApi.Validators;

namespace HotelReservationApi
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<UserRoleService>().As<IUserRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<RoomService>().As<IRoomService>().InstancePerLifetimeScope();
            builder.RegisterType<PictureService>().As<IPictureService>().InstancePerLifetimeScope();
            builder.RegisterType<FacilityService>().As<IFacilityService>().InstancePerLifetimeScope();
            builder.RegisterType<RoomFacilityService>().As<IRoomFacilityService>().InstancePerLifetimeScope();
            builder.RegisterType<RoomReservationService>().As<IRoomReservationService>().InstancePerLifetimeScope();
            builder.RegisterType<InvoiceService>().As<IInvoiceService>().InstancePerLifetimeScope();
            builder.RegisterType<ReservationService>().As<IReservationService>().InstancePerLifetimeScope();

            builder.RegisterType<UserMediator>().As<IUserMediator>().InstancePerLifetimeScope();
            builder.RegisterType<RoomMediator>().As<IRoomMediator>().InstancePerLifetimeScope();
            builder.RegisterType<FacilityMediator>().As<IFacilityMediator>().InstancePerLifetimeScope();
            builder.RegisterType<ReservationMediator>().As<IReservationMediator>().InstancePerLifetimeScope();
            builder.RegisterType<FeedbackMediator>().As<IFeedbackMediator>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<RoomProfile>();
                cfg.AddProfile<FacilityProfile>();
                cfg.AddProfile<PictureProfile>();
                cfg.AddProfile<ReservationProfile>();
                cfg.AddProfile<RoomReservationProfile>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(typeof(ConfirmReservationValidator).Assembly)
               .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
               .AsImplementedInterfaces();
        }
    }
}
