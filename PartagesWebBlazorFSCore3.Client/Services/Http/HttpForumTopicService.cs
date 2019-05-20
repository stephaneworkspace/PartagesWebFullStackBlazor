using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using Microsoft.JSInterop;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Forum.ForumTopic.ForNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    /// <summary>
    /// ForumTopic Service
    /// </summary>
    public class HttpForumTopicService : IHttpForumTopicService
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
        public HttpForumTopicService(HttpClient httpClient, LocalStorage storage)
        {
            _httpClient = httpClient;
            _storage = storage;
        }

        /// <summary>
        /// Get all ForumTopics from a ForumCategorie
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetForumTopics(int id, int page)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/ForumTopic/{id}?pageNumber={page}");
            return await _httpClient.SendAsync(req);
        }

        /// <summary>
        /// Get a selected ForumTopic
        /// </summary>
        /// <param name="id">ForumTopic primary key</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetForumTopic(int id)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/ForumTopic/ForumTopicId/{id}");
            return await _httpClient.SendAsync(req);
        }

        /// <summary>
        /// Post a new ForumTopic
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostForumTopic(ForumPostForNewForumTopicDto dto)
        {
            var requestJson = Json.Serialize(dto);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}api/ForumTopic");
            req.Headers.Add("Authorization", $"Bearer {_storage["token"]}");
            req.Content = new StringContent(requestJson, Encoding.Default, "application/json");
            return await _httpClient.SendAsync(req);
        }
    }
}
