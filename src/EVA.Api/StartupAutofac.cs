using Autofac;
using EVA.Application.Dto.Mapping;
using EVA.Infrastructure.Data;
using EVA.Infrastructure.Data.Abstractions.Context;
using EVA.Infrastructure.Data.Abstractions.Migrations;
using EVA.Infrastructure.Data.Context;
using EVA.Infrastructure.Data.Migrations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module = Autofac.Module;

namespace EVA.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class StartupAutofac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<MappingAutofac>();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.AddDbContext<EvaContext>();                                    
            builder.RegisterType<EvaMigrationsProvider>().As<IMigrationsProvider>().SingleInstance();
            builder.RegisterType<EvaUnitOfWork>().As<IEvaUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(ThisAssembly).AsClosedTypesOf(typeof(INotificationHandler<>));
            
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.IsSubclassOf(typeof(ControllerBase)))
                .PropertiesAutowired();
        }
    }
}