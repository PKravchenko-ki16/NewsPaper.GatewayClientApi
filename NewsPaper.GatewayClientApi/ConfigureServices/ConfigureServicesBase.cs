using Microsoft.Extensions.DependencyInjection;

namespace NewsPaper.GatewayClientApi.ConfigureServices
{
    public class ConfigureServicesBase
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
        }
    }
}
