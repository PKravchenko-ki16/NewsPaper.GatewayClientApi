using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace NewsPaper.GatewayClientApi.Infrastructure
{
    public class RequestClientCredentialsToken
    {
        public async Task<HttpClient> RetrieveToIdentityServer(IHttpClientFactory httpClientFactory)
        {
            var authClient = httpClientFactory.CreateClient();

            var discoveryDocument = await authClient.GetDiscoveryDocumentAsync("https://localhost:10001");

            var tokenResponse = await authClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = "client_id",
                    ClientSecret = "client_secret",
                    Scope = "GatewayClientApi"
                });

            var articlesClient = httpClientFactory.CreateClient();

            articlesClient.SetBearerToken(tokenResponse.AccessToken);

            return articlesClient;
        }
    }
}