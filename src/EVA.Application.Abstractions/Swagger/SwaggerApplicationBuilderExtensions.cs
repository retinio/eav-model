using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

namespace EVA.Application.Swagger
{
    public static class SwaggerApplicationBuilderExtensions
    {
        public static void UseApiSwagger(this IApplicationBuilder app, string basePath)
        {
            var provider = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>();

            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    o.SwaggerEndpoint($"{basePath}/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
        }
    }
}