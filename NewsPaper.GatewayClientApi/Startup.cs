using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NewsPaper.GatewayClientApi.Configure;
using NewsPaper.GatewayClientApi.ConfigureServices;
using NewsPaper.GatewayClientApi.Infrastructure.DependencyInjection;

namespace NewsPaper.GatewayClientApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureServicesBase.ConfigureServices(services);
            ConfigureServicesControllers.ConfigureServices(services);
            ConfigureServicesSwagger.ConfigureServices(services);
            DependencyContainerRegistrations.Common(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureCommon.Configure(app, env);
            ConfigureEndpoints.Configure(app);
        }
    }
}
