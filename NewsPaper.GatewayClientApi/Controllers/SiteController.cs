using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Calabonga.OperationResults;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using NewsPaper.GatewayClientApi.ViewModels;
using Newtonsoft.Json;

namespace NewsPaper.GatewayClientApi.Controllers
{
    [Route("[controller]")]
    public class SiteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SiteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public async Task<ViewResult> GetArticles()
        {
            // retrieve to IdentityServer
            var authClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await authClient.GetDiscoveryDocumentAsync("https://localhost:10001");

            var tokenResponse = await authClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = "client_id",
                    ClientSecret = "client_secret",
                    Scope = "GatewayClientApi"
                });


            // retrieve to articles
            var articlesClient = _httpClientFactory.CreateClient();

            articlesClient.SetBearerToken(tokenResponse.AccessToken);

            HttpResponseMessage response =
                (await articlesClient.GetAsync("https://localhost:5001/articles/getarticlesbyauthor?authorGuid=b0d4ce5d-2757-4699-948c-cfa72ba94f86")).EnsureSuccessStatusCode();
            
            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<IEnumerable<ArticleViewModel>> operation = JsonConvert.DeserializeObject<OperationResult<IEnumerable<ArticleViewModel>>>(responseBody);

            if (operation.Exception!=null)
            {
                ViewBag.Exception = operation.Exception.Message;
                ViewBag.TypeException = operation.Exception.GetType();
                return View();
            }
            return View(operation.Result);
        }
    }
}
