using System;
using System.Collections.Generic;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EVA.Infrastructure.Data.Abstractions.Context
{
    public static class EntityFrameworkAutofacContainerBuilderExtensions
    {
        public static ContainerBuilder AddDbContext<TContext>(this ContainerBuilder builder,
            Action<DbContextOptionsBuilder, IConfiguration> optionsAction = null) where TContext : DbContext
        {
            if (optionsAction != null)
            {
                builder.Register(p => DbContextOptionsFactory<TContext>(
                    optionsBuilder =>
                    {
                        var config = p.Resolve<IConfiguration>();
                        optionsAction(optionsBuilder, config);
                    }));
            }
            else
            {
                builder.Register(_ => DbContextOptionsFactory<TContext>(null));
            }

            builder.Register<DbContextOptions>(p => p.Resolve<DbContextOptions<TContext>>()).InstancePerLifetimeScope();
            builder.Register(p =>
            {
                var serviceProvider = p.Resolve<IServiceProvider>();
                var settings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>();                
                return Activator.CreateInstance(typeof(TContext), settings) as TContext;                                                
            }).InstancePerDependency();
            
            return builder;
        }

        private static DbContextOptions<TContext> DbContextOptionsFactory<TContext>(
            Action<DbContextOptionsBuilder> optionsAction) where TContext : DbContext
        {
            var options = new DbContextOptions<TContext>(new Dictionary<Type, IDbContextOptionsExtension>());
            if (optionsAction != null)
            {
                var builder = new DbContextOptionsBuilder<TContext>(options);
                optionsAction(builder);
                options = builder.Options;
            }

            return options;
        }
    }
}