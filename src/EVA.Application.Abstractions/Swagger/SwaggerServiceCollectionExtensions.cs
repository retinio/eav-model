using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EVA.Application.Swagger
{
    /// <summary>
    /// Helper functions for configuring Swagger services.
    /// </summary>
    public static class SwaggerServiceCollectionExtensions
    {
        /// <summary>
        /// Adds swagger
        /// </summary>
        /// <param name="services"></param>
        /// <param name="projectName"></param>
        /// <param name="setupAction"></param>
        public static void AddSwagger<T>(this IServiceCollection services, string projectName, Action<SwaggerGenOptions> setupAction = null)
        {            
            services.AddSwaggerGen(options =>
            {
                setupAction?.Invoke(options);

                using (var provider = services.BuildServiceProvider())
                {
                    var versionDescriptionProvider = provider.GetRequiredService<IApiVersionDescriptionProvider>();
                    
                    foreach (var description in versionDescriptionProvider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description, projectName));
                    }

                    var dir = new DirectoryInfo(Path.GetDirectoryName(typeof(T).GetTypeInfo().Assembly.Location) ?? throw new InvalidOperationException());
                    foreach (var fi in dir.EnumerateFiles("*.xml"))
                    {
                        options.IncludeXmlComments(fi.FullName);
                    }
                                                                           
                }
            });
        }


        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description, string projectName)
        {
            var info = new OpenApiInfo
            {
                Title = $"{projectName} {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}