//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumTopic.ForList
{
    /// <summary>
    /// Dto
    /// </summary>
    public class ForumTopicForListDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Foreign key ForumCategorie
        /// </summary>
        public int ForumCategorieId { get; set; }
        /// <summary>
        /// Relation with ForumCategorie
        /// </summary>
        public virtual ForumCategorieForListForumTopicDto ForumCategorie { get; set; }
        /// <summary>
        /// Topic name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Date from topic
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Number of views
        /// </summary>
        public int View { get; set; }
        /// <summary>
        /// Count of ForumPost
        /// </summary>
        public int CountForumPost { get; set; }
        /// <summary>
        /// Last ForumPost
        /// </summary>
        public ForumPostForListForumTopicDto LastForumPost { get; set; }
        /// <summary>
        /// Page of last ForumPost
        /// </summary>
        public int PageLastForumPost { get; set; }
    }
}
