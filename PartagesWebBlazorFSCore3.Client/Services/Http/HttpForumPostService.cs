using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using Microsoft.JSInterop;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Forum.ForumPost.ForReply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    /// <summary>
    /// ForumPost Service
    /// </summary>
    public class HttpForumPostService : IHttpForumPostService
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
        public HttpForumPostService(HttpClient httpClient, LocalStorage storage)
        {
            _httpClient = httpClient;
            _storage = storage;
        }

        /// <summary>
        /// Get all ForumPosts from a ForumSujetId
        /// </summary>
        /// <param name="id">ForumSujetId</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetForumPosts(int id, int page)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/ForumPost/{id}?pageNumber={page}");
            return await _httpClient.SendAsync(req);
        }

        /// <summary>
        /// Post a replay to ForumPosts
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostReplyForumPoste(ForumPostForReplyDto dto)
        {
            var requestJson = Json.Serialize(dto);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, $"{Constants.URL_BASE}api/ForumPost");
            req.Headers.Add("Authorization", $"Bearer {_storage["token"]}");
            req.Content = new StringContent(requestJson, Encoding.Default, "application/json");
            return await _httpClient.SendAsync(req);
        }

        /// <summary>
        /// Get a ForumPost from primary key
        /// </summary>
        /// <param name="id">ForumPost primary key</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetForumPost(int id)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/ForumPost/ForumPostId/{id}");
            return await _httpClient.SendAsync(req);
        }
    }
}
