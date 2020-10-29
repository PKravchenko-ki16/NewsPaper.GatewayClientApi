using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using NewsPaper.GatewayClientApi.ViewModels;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
                    Scope = "OrdersAPI"
                });


            // retrieve to articles
            var articlesClient = _httpClientFactory.CreateClient();

            articlesClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await articlesClient.GetStringAsync("https://localhost:5001/articles/getarticlesbyauthor?authorGuid=b0d4ce5d-2757-4699-948c-cfa72ba94f86").ConfigureAwait(false);

            //if (!response.IsSuccessStatusCode)
            //{
            //    ViewBag.Message = response.StatusCode.ToString();
            //    return View();
            //}
            //response.EnsureSuccessStatusCode();
            //if (response.Content is object)
            //{
            //    var stream = await response.Content.ReadAsStreamAsync();
            //    var data = await JsonSerializer.DeserializeAsync<IEnumerable<ArticleViewModel>>(stream);
            //    return View(data);
            //}
            var data = JsonConvert.DeserializeObject<IEnumerable<ArticleViewModel>>(response);
            return View(data);
        }
    }
}
