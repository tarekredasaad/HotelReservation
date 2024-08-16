﻿using Autofac;
using HotelReservationApi.Data;
using HotelReservationApi.Models;
using HotelReservationApi.Repository;
using HotelReservationApi.Services.AuthService;

namespace HotelReservationApi
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(Repository<User>)).As(typeof(IRepository<User>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IAuthService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRepository<User>).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            //builder.RegisterAssemblyTypes(typeof(IExamQuestionService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
