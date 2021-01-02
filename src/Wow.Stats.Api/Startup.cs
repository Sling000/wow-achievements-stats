using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Wow.Stats.Api
{
    /// <summary>
    /// Startup definition
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddApiVersioning()
                .AddVersionedApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            services.AddSwagger();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="applicationBuilder">The application builder.</param>
        /// <param name="webHostEnvironment">The web host environment.</param>
        /// <param name="apiVersionDescriptionProvider">The API version description provider.</param>
        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseSwagger();
                applicationBuilder.UseSwaggerUI(options =>
                {
                    foreach (var versionDescription in apiVersionDescriptionProvider.ApiVersionDescriptions.OrderBy(x => x.ApiVersion))
                    {
                        options.SwaggerEndpoint("/swagger/" + versionDescription.GroupName + "/swagger.json", versionDescription.GroupName.ToUpper());
                    }
                });
            }

            applicationBuilder.UseHttpsRedirection();

            applicationBuilder.UseRouting();

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
