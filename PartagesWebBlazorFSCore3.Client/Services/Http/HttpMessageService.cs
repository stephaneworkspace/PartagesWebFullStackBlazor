using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using Microsoft.JSInterop;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Forum.ForumPost.ForReply;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    /// <summary>
    /// Message Service
    /// </summary>
    public class HttpMessageService : IHttpMessageService
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
        public HttpMessageService(HttpClient httpClient, LocalStorage storage)
        {
            _httpClient = httpClient;
            _storage = storage;
        }

        /// <summary>
        /// Get all Messages
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetMessages(int page)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/Message?pageNumber={page}");
            req.Headers.Add("Authorization", $"Bearer {_storage["token"]}");
            return await _httpClient.SendAsync(req);
        }

        /// <summary>
        /// Post a message
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostMessage(MessageDto dto)
        {
            var requestJson = Json.Serialize(dto);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}api/Message");
            req.Headers.Add("Authorization", $"Bearer {_storage["token"]}");
            req.Content = new StringContent(requestJson, Encoding.Default, "application/json");
            return await _httpClient.SendAsync(req);
        }

        /// <summary>
        /// Get a Message from primary key
        /// </summary>
        /// <param name="id">Message primary key</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetMessage(int id)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/Message/{id}");
            req.Headers.Add("Authorization", $"Bearer {_storage["token"]}");
            return await _httpClient.SendAsync(req);
        }

        /// <summary>
        /// Get count of unread message
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetCountUnread()
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/Message/countUnread");
            req.Headers.Add("Authorization", $"Bearer {_storage["token"]}");
            return await _httpClient.SendAsync(req);
        }
    }
}
