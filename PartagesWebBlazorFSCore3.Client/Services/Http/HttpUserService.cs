using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.User;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.User.LoginReturn;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    /// <summary>
    /// User service (authentification)
    /// </summary>
    public class HttpUserService: IHttpUserService
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
        public HttpUserService(HttpClient httpClient, LocalStorage storage)
        {
            _httpClient = httpClient;
            _storage = storage;
        }

        /// <summary>
        /// Check if dto.Username is available
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        public async Task<Boolean> PostIsAvailable(UserForRegisterAvailableDto dto)
        {
            Boolean swAvailable = false;
            if (dto.Username != "" && dto.Username.Length > 2 && dto.Username.Length < 30)
            {
                var requestJson = Json.Serialize(dto);
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}api/User/available");
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
        public async Task<HttpResponseMessage> PostRegister(UserForRegisterDto dto)
        {
            var requestJson = Json.Serialize(dto);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}api/User/register");
            req.Content = new StringContent(requestJson, Encoding.Default, "application/json");
            return await _httpClient.SendAsync(req);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostLogin(UserForLoginDto dto)
        {
            _storage.RemoveItem("token");
            _storage.RemoveItem("username");
            var requestJson = Json.Serialize(dto);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}api/User/login");
            req.Content = new StringContent(requestJson, Encoding.Default, "application/json");
            var response = await _httpClient.SendAsync(req);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Set local storage
                string content = await response.Content.ReadAsStringAsync();
                LoginReturnDto _dto = Json.Deserialize<LoginReturnDto>(content);
                _storage["token"] = _dto.Token;
                _storage["username"] = _dto.User.Username;
            }
            return response;
        }

        /// <summary>
        /// Get User info to post a new message
        /// </summary>
        /// <param name="id">Primary key User destination</param>
        /// <returns></returns>
        /// <remarks>Authentification required</remarks>
        public async Task<HttpResponseMessage> GetUser(int id)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/User/{id}");
            req.Headers.Add("Authorization", $"Bearer {_storage["token"]}");
            return await _httpClient.SendAsync(req);
        }
    }
}