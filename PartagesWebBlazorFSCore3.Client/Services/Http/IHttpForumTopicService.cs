using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    /// <summary>
    /// Interface ForumTopics service
    /// </summary>
    interface IHttpForumTopicService
    {
        /// <summary>
        /// Get all ForumTopics from a ForumCategorieId
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> GetForumTopics(int id);
    }
}
