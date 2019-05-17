using Microsoft.JSInterop;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    public class HttpAuthService
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient">Http client</param>
        public HttpAuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Register a new User
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostRegister(UserForRegisterInputDto dto)
        {
            var requestJson = Json.Serialize(dto);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}api/Auth/register");
            // req.Headers.Add("Authorization", $"bearer {bearer}");
            req.Content = new StringContent(requestJson, Encoding.Default, "application/json");
            return await _httpClient.SendAsync(req);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostLogin(UserForLoginInputDto dto)
        {
            var requestJson = Json.Serialize(dto);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}api/Auth/login");
            req.Content = new StringContent(requestJson, Encoding.Default, "application/json");
            return await _httpClient.SendAsync(req);
        }
    }
}