using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Forum.ForumPost.ForReply;
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
        Task<HttpResponseMessage> GetForumPosts(int id, int page);

        /// <summary>
        /// Post a replay to ForumPosts
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostReplyForumPoste(ForumPostForReplyDto dto);

        /// <summary>
        /// Get a ForumPost from primary key
        /// </summary>
        /// <param name="id">ForumPost primary key</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetForumPost(int id);
    }
}
