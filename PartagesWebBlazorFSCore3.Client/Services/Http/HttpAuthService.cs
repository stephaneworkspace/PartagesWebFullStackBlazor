using Microsoft.JSInterop;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
// using Blazored.LocalStorage;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Auth.Login;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    public class HttpAuthService
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private readonly HttpClient _httpClient;
        private LocalStorage _storage;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient">Http client</param>
        public HttpAuthService(HttpClient httpClient, LocalStorage storage)
        {
            _httpClient = httpClient;
            _storage = storage;
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
            var response = await _httpClient.SendAsync(req);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Set local storage
                string content = await response.Content.ReadAsStringAsync();
                LoginDto _dto = Json.Deserialize<LoginDto>(content);
                _storage["token"] = _dto.token;
                // await _localStorage.SetItemAsync("token", _dto.token);
                //    messagesUnread
            }
            return response;
        }
    }
}