using EVA.Application.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace EVA.Api.Swagger.SchemaFilter
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IHostingEnvironment environment)
        {
            if (!environment.IsStaging() && !environment.IsProduction())
            {
                services.AddSwagger<Startup>("EVA API", options =>
                {                    
                    options.EnableAnnotations();
                });
            }

            return services;
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder applicationBuilder, IHostingEnvironment environment)
        {
            if (!environment.IsStaging() && !environment.IsProduction())
            {
                applicationBuilder.UseApiSwagger("/api/eva");
            }

            return applicationBuilder;
        }
    }
}