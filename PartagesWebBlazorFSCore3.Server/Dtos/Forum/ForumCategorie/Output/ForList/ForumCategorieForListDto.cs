//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Dtos.Forum.ForumCategorie.Output.ForList
{
    /// <summary>
    /// Dto
    /// </summary>
    public class ForumCategorieForListDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Categorie name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Number of ForumTopics
        /// </summary>
        public int CountForumTopic { get; set; }
        /// <summary>
        /// Number of ForumPosts
        /// </summary>
        public int CountForumPost { get; set; }
        /// <summary>
        /// Last ForumPost
        /// </summary>
        public ForumPostForListForumCategorieDto LastForumPost { get; set; }
        /// <summary>
        /// Number of ForumPost in last ForumPost
        /// </summary>
        public int CountLastForumPost { get; set; }
        /// <summary>
        /// Page of last ForumPost
        /// </summary>
        public int PageLastForumPost { get; set; }
    }
}
