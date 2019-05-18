﻿using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    public class HttpForumTopicService : IHttpForumTopicService
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient">Http client</param>
        public HttpForumTopicService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Get all ForumTopics from a ForumCategorie
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetForumTopics(int id)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{Constants.URL_BASE}api/ForumTopic/{id}");
            return await _httpClient.SendAsync(req);
        }
    }
}