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
    public class EditorsController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RequestClientCredentialsToken _retrieveToIdentityServer;

        public EditorsController(IHttpClientFactory httpClientFactory, RequestClientCredentialsToken retrieveToIdentityServer)
        {
            _httpClientFactory = httpClientFactory;
            _retrieveToIdentityServer = retrieveToIdentityServer;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditors()
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync("https://localhost:5001/api/editor/geteditors/")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<IEnumerable<EditorViewModel>> operation = JsonConvert.DeserializeObject<OperationResult<IEnumerable<EditorViewModel>>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }

        [HttpGet("[action]/{editorGuid:Guid}")]
        public async Task<IActionResult> GetByIdEditor(Guid editorGuid)
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync($"https://localhost:5001/api/editor/getbyideditor?editorGuid={editorGuid}")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<EditorViewModel> operation = JsonConvert.DeserializeObject<OperationResult<EditorViewModel>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }

        [HttpGet("[action]/{nikeNameEditor}")]
        public async Task<IActionResult> GetGuidEditor(string nikeNameEditor)
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync($"https://localhost:5001/api/editor/getguideditor?nikeNameEditor={nikeNameEditor}")).EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OperationResult<Guid> operation = JsonConvert.DeserializeObject<OperationResult<Guid>>(responseBody);

            if (operation.Exception != null)
            {
                return Ok($"{operation.Exception.Message} + {operation.Exception.GetType()}");
            }
            return Ok(operation.Result);
        }

        [HttpGet("[action]/{editorGuid:Guid}")]
        public async Task<IActionResult> GetNikeNameEditor(Guid editorGuid)
        {
            HttpClient articlesClient = await _retrieveToIdentityServer.RetrieveToIdentityServer(_httpClientFactory);

            HttpResponseMessage response =
                (await articlesClient.GetAsync($"https://localhost:5001/api/editor/getnikenameeditor?editorGuid={editorGuid}")).EnsureSuccessStatusCode();

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
