using Microsoft.Extensions.DependencyInjection;

namespace NewsPaper.GatewayClientApi.ConfigureServices
{
    public class ConfigureServicesControllers
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }
    }
}
