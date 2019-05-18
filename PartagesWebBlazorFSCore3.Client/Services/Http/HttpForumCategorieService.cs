using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    public class HttpForumCategorieService : IHttpForumCategorieService
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private readonly HttpClient _httpClient;
        private readonly LocalStorage _storage;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient">Http client</param>
        public HttpForumCategorieService(HttpClient httpClient, LocalStorage storage)
        {
            _httpClient = httpClient;
            _storage = storage;
        }

        /// <summary>
        /// Get one ForumCategorie by primary key
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetForumCategorie(int id)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/ForumCategories/{id}");
            return await _httpClient.SendAsync(req);
        }

        /// <summary>
        /// Get all ForumCategorie
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetForumCategories()
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/ForumCategories/");
            return await _httpClient.SendAsync(req);
        }
    }
}
