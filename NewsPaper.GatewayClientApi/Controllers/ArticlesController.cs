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
    [Produces("application/json")]
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetArticles()
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync("https://localhost:5001/api/article/getarticles/")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<IEnumerable<ArticleViewModel>> operation = JsonConvert.DeserializeObject<OperationResult<IEnumerable<ArticleViewModel>>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }

        [HttpGet("[action]/{articleGuid:Guid}")]
        public async Task<IActionResult> GetArticleById(Guid articleGuid)
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync($"https://localhost:5001/api/article/getarticlebyid?articleGuid={articleGuid}")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<ArticleViewModel> operation = JsonConvert.DeserializeObject<OperationResult<ArticleViewModel>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }

        [HttpGet("[action]/{authorGuid:Guid}")]
        public async Task<IActionResult> GetArticlesByIdAuthor(Guid authorGuid)
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync($"https://localhost:5001/api/article/getarticlesbyidauthor?authorGuid={authorGuid}")).EnsureSuccessStatusCode();

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
