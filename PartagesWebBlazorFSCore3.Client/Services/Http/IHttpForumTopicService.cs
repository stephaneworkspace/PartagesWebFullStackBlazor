using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    /// <summary>
    /// Interface ForumTopic service
    /// </summary>
    interface IHttpForumTopicService
    {
        /// <summary>
        /// Get all ForumTopics from a ForumCategorieId
        /// </summary>
        /// <param name="id">ForumCategorieId</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetForumTopics(int id, int page);

        /// <summary>
        /// Get a selected ForumTopic
        /// </summary>
        /// <param name="id">ForumTopic primary key</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetForumTopic(int id);
    }
}
