using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace EVA.Application.ApiVersioning
{
    public static class ApiVersioningServiceCollectionExtensions
    {
        public static void AddVersioning(this IServiceCollection services, ApiVersion version)
        {                            
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;

            });
            
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = version;
            });           
        }
    }
}