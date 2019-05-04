using System;
using System.IO;
using EVA.Api.Swagger.SchemaFilter;
using EVA.Application.ApiVersioning;
using EVA.Application.Autofac;
using EVA.Application.Database;
using EVA.Infrastructure.Data.Abstractions.Context;
using EVA.Infrastructure.Data.Context;
using EVA.Infrastructure.Log;
using EVA.Infrastructure.Log.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EVA.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        public IHostingEnvironment Environment { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)                
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Environment = env;            
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<DatabaseSettings>(Configuration.GetSection("Database"));
         
            services.AddVersioning(new ApiVersion(1, 0));
            services.AddSwagger(Environment);
            services.AddSerilog();
            services.AddCors();            

            services.AddMvcCore()
                .AddApiExplorer();

            var mvcBuilder = services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddControllersAsServices();
            return mvcBuilder.AddAutofac<StartupAutofac>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
            }

            app.UseMiddleware<LoggingMiddleware>();
            app.UseDbMigrations();
            app.UsePathBase("/api/eva");
            app.UseMvc();
            app.UseSwagger(Environment);
        }
    }
}
