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
    public class UsersController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RequestClientCredentialsToken _retrieveToIdentityServer;

        public UsersController(IHttpClientFactory httpClientFactory, RequestClientCredentialsToken retrieveToIdentityServer)
        {
            _httpClientFactory = httpClientFactory;
            _retrieveToIdentityServer = retrieveToIdentityServer;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUsers()
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync("https://localhost:5001/api/user/getusers/")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<IEnumerable<UserViewModel>> operation = JsonConvert.DeserializeObject<OperationResult<IEnumerable<UserViewModel>>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }

        [HttpGet("[action]/{userGuid:Guid}")]
        public async Task<IActionResult> GetByIdUser(Guid userGuid)
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync($"https://localhost:5001/api/user/getbyiduser?userGuid={userGuid}")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<UserViewModel> operation = JsonConvert.DeserializeObject<OperationResult<UserViewModel>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }

        [HttpGet("[action]/{nikeNameUser}")]
        public async Task<IActionResult> GetGuidUser(string nikeNameUser)
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync($"https://localhost:5001/api/user/getguiduser?nikeNameUser={nikeNameUser}")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<Guid> operation = JsonConvert.DeserializeObject<OperationResult<Guid>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }

        [HttpGet("[action]/{userGuid:Guid}")]
        public async Task<IActionResult> GetNikeNameUser(Guid userGuid)
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync($"https://localhost:5001/api/user/getnikenameuser?userGuid={userGuid}")).EnsureSuccessStatusCode();

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
