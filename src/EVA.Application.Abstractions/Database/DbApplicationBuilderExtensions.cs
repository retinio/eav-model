using System;
using EVA.Infrastructure.Data.Abstractions.Migrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EVA.Application.Database
{
    public static class DbApplicationBuilderExtensions
    {
        public static void UseDbMigrations(this IApplicationBuilder app)
        {            
            var factory =  app.ApplicationServices.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger("DB");
            
            try
            {
                var migrationsProvider = app.ApplicationServices.GetService<IMigrationsProvider>();
                if (migrationsProvider.Migrate())
                {
                    logger.LogInformation("DB - {Migration} {Module}", "Schema updated from ", migrationsProvider.GetType().Assembly.GetName().Name);
                }
                else
                {
                    logger.LogCritical("DB -  {Migration} {Module}", "Schema updated error from ", migrationsProvider.GetType().Assembly.GetName().Name);
                }                
            }
            catch (Exception exception)
            {
                logger.LogCritical(exception, "DB - {Migration}", "Not DbInitialize");
            }
        }
    }
}