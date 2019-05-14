//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace PartagesWebBlazorFSCore3.Shared.Models
{
    /// <summary>
    /// Model
    /// </summary>
    public class ForumPost
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// FK ForumTopic
        /// </summary>
        public int ForumTopicId { get; set; }
        /// <summary>
        /// Relation with ForumTopic
        /// </summary>
        public virtual ForumTopic ForumTopic { get; set; }
        /// <summary>
        /// FK User
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Relation with User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Date post
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Content post
        /// </summary>
        public string Content { get; set; }
    }
}
