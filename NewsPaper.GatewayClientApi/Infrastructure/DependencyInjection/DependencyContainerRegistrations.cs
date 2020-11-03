using Microsoft.Extensions.DependencyInjection;

namespace NewsPaper.GatewayClientApi.Infrastructure.DependencyInjection
{
    public class DependencyContainerRegistrations
    {
        public static void Common(IServiceCollection services)
        {
            services.AddTransient<RequestClientCredentialsToken>();
        }
    }
}
