using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Auth;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Auth.Login;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    /// <summary>
    /// Auth service
    /// </summary>
    public class HttpAuthService: IHttpAuthService
    {
        /// <summary>
        /// Http client
        /// </summary>
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Local storage
        /// </summary>
        private readonly LocalStorage _storage;

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
        /// Check if dto.Username is available
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Boolean> PostIsAvailable(UserForRegisterAvailableInputDto dto)
        {
            Boolean swAvailable = false;
            if (dto.Username != "" && dto.Username.Length > 2 && dto.Username.Length < 30)
            {
                var requestJson = Json.Serialize(dto);
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}api/Auth/available");
                req.Content = new StringContent(requestJson, Encoding.Default, "application/json");
                var response = await _httpClient.SendAsync(req);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    swAvailable = Convert.ToBoolean(await response.Content.ReadAsStringAsync());
                } 
            }
            return swAvailable;
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