using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    /// <summary>
    /// ForumCategorie service
    /// </summary>
    public class HttpForumCategorieService : IHttpForumCategorieService
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient">Http client</param>
        public HttpForumCategorieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Get one ForumCategorie by primary key
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetForumCategorie(int id)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/ForumCategorie/{id}");
            return await _httpClient.SendAsync(req);
        }

        /// <summary>
        /// Get all ForumCategorie
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetForumCategories()
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/ForumCategorie/");
            return await _httpClient.SendAsync(req);
        }
    }
}
