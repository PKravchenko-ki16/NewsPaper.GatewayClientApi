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
    public class AuthorsController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RequestClientCredentialsToken _retrieveToIdentityServer;

        public AuthorsController(IHttpClientFactory httpClientFactory, RequestClientCredentialsToken retrieveToIdentityServer)
        {
            _httpClientFactory = httpClientFactory;
            _retrieveToIdentityServer = retrieveToIdentityServer;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAuthors()
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync("https://localhost:5001/api/author/getauthors/")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<IEnumerable<AuthorViewModel>> operation = JsonConvert.DeserializeObject<OperationResult<IEnumerable<AuthorViewModel>>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }

        [HttpGet("[action]/{authorGuid:Guid}")]
        public async Task<IActionResult> GetByIdAuthor(Guid authorGuid)
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync($"https://localhost:5001/api/author/getbyidauthor?authorGuid={authorGuid}")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<AuthorViewModel> operation = JsonConvert.DeserializeObject<OperationResult<AuthorViewModel>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }

        [HttpGet("[action]/{nikeNameAuthor}")]
        public async Task<IActionResult> GetGuidAuthor(string nikeNameAuthor)
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync($"https://localhost:5001/api/author/getguidauthor?nikeNameAuthor={nikeNameAuthor}")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<Guid> operation = JsonConvert.DeserializeObject<OperationResult<Guid>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }

        [HttpGet("[action]/{authorGuid:Guid}")]
        public async Task<IActionResult> GetNikeNameAuthor(Guid authorGuid)
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync($"https://localhost:5001/api/author/getnikenameauthor?authorGuid={authorGuid}")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<string> operation = JsonConvert.DeserializeObject<OperationResult<string>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }
    }
}
