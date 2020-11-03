using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Calabonga.OperationResults;
using Microsoft.AspNetCore.Mvc;
using NewsPaper.GatewayClientApi.Infrastructure;
using NewsPaper.GatewayClientApi.ViewModels;
using Newtonsoft.Json;

namespace NewsPaper.GatewayClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RequestClientCredentialsToken _retrieveToIdentityServer;

        public ArticlesController(IHttpClientFactory httpClientFactory, RequestClientCredentialsToken retrieveToIdentityServer)
        {
            _httpClientFactory = httpClientFactory;
            _retrieveToIdentityServer = retrieveToIdentityServer;
        }

        //[HttpGet("getarticles")]
        //public async Task<IActionResult> GetArticles()
        //{
        //    return Ok();
        //}

        //[HttpGet("getarticlebyid")]
        //public async Task<IActionResult> GetArticleById(Guid articleGuid)
        //{
        //    return Ok();
        //}

        [HttpGet("getarticlesbyauthor")]
        public async Task<IActionResult> GetArticlesByAuthor(Guid authorGuid)
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync("https://localhost:5001/api/articles/getarticlesbyauthor?authorGuid=b0d4ce5d-2757-4699-948c-cfa72ba94f86")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<IEnumerable<ArticleViewModel>> operation = JsonConvert.DeserializeObject<OperationResult<IEnumerable<ArticleViewModel>>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }
    }
}
