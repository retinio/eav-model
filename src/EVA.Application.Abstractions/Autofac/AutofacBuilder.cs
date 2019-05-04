using System;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using EVA.Application.Autofac.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace EVA.Application.Autofac
{
    internal class AutofacBuilder<T> where T : IModule, new()
    {
        private readonly IMvcBuilder _mvcBuilder;        

        public AutofacBuilder(IMvcBuilder mvcBuilder)
        {
            _mvcBuilder = mvcBuilder;            
        }

        public IServiceProvider GetServiceProvider()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(_mvcBuilder.Services);            
            containerBuilder.RegisterModule<MediatorModule>();
            containerBuilder.RegisterModule(new T());
            return new AutofacServiceProvider(containerBuilder.Build());
        }
    }
}