using System;
using Autofac.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EVA.Application.Autofac
{
    public static class AutofacServiceCollectionExtensions
    {
        public static IServiceProvider AddAutofac<T>(this IMvcBuilder mvcBuilder) where T : IModule, new() 
        {            
            var builder = new AutofacBuilder<T>(mvcBuilder);
            return builder.GetServiceProvider();
        }
    }
}