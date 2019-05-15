using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Dtos.Input.Seed.Forum.ForumPost.ForSeed
{
    /// <summary>
    /// Dto
    /// </summary>
    public class ForumPostForSeedDto
    {
        /// <summary>
        /// ForumTopic name unique (for seed)
        /// </summary>
        public string NameForumTopic { get; set; }
        /// <summary>
        /// Username in User
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Date from post
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }
    }
}
