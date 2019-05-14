//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Dtos.Forum.ForumPost.Output.ForSelect
{
    /// <summary>
    /// Dto
    /// </summary>
    public class ForumPostForSelectDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Foreign key ForumTopic
        /// </summary>
        public int ForumTopicId { get; set; }
        /// <summary>
        /// Relation with ForumTopic
        /// </summary>
        public virtual ForumTopicForSelectForumPostDto ForumTopic { get; set; }
        /// <summary>
        /// Foreign key User
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Relation with User
        /// </summary>
        public virtual UserForSelectForumPostDto User { get; set; }
        /// <summary>
        /// Date of post
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Content of post
        /// </summary>
        public string Content { get; set; }
    }
}
