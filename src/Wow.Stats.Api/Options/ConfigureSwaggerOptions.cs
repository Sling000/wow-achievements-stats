using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Wow.Stats.Api.Options
{
    /// <summary>Configures the Swagger generation options.</summary>
    /// <remarks>This allows API versioning to define a Swagger document per API version after the
    /// <see cref="T:Microsoft.AspNetCore.Mvc.ApiExplorer.IApiVersionDescriptionProvider" /> service has been resolved from the service container.</remarks>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wow.Stats.Api.Options.ConfigureSwaggerOptions" /> class.
        /// </summary>
        /// <param name="provider">The <see cref="T:Microsoft.AspNetCore.Mvc.ApiExplorer.IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this._provider = provider;

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var versionDescription in this._provider.ApiVersionDescriptions)
                options.SwaggerDoc(versionDescription.GroupName, CreateInfoForApiVersion(versionDescription));
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var openApiInfo = new OpenApiInfo
            {
                Title = "WOW achievement stats API",
                Version = description.ApiVersion.ToString(),
                Contact = new OpenApiContact
                {
                    Name = "Yuriy Burda",
                    Email = "sling000@gmail.com"
                },
            };
            if (description.IsDeprecated)
                openApiInfo.Description += " This API version has been deprecated.";
            return openApiInfo;
        }
    }
}
