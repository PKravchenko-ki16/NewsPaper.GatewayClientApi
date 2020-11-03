using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace NewsPaper.GatewayClientApi.ConfigureServices
{
    public class ConfigureServicesSwagger
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options => 
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Description = "Swagger UI GatewayClientApi",
                    Title = "Swagger use Gateway with IdentityServer4",
                    Version = "1.0.0"
                }));
            services.AddSwaggerGenNewtonsoftSupport();
        }
    }
}
