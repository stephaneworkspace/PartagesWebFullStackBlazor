using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    /// <summary>
    /// Interface ForumPost service
    /// </summary>
    interface IHttpForumPostService
    {
        /// <summary>
        /// Get all ForumPosts from a ForumSujetId
        /// </summary>
        /// <param name="id">ForumSujetId</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetForumPosts(int id);
    }
}
