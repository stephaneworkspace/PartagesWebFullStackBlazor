//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumCategorie.ForList
{
    /// <summary>
    /// Dto from model ForumCategorie with computed fields: CountForumTopic, CountForumPost, LastForumPost, PageLastForumPost
    /// </summary>
    public class ForumCategorieForListDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of ForumTopics
        /// </summary>
        /// <remarks>Computed field</remarks>/// 
        public int CountForumTopic { get; set; }

        /// <summary>
        /// Number of ForumPosts
        /// </summary>
        /// <remarks>Computed field</remarks>/// 
        public int CountForumPost { get; set; }

        /// <summary>
        /// Last ForumPost
        /// </summary>
        /// <remarks>Computed field</remarks>
        public ForumPostForListForumCategorieDto LastForumPost { get; set; }

        /// <summary>
        /// Page of last ForumPost
        /// </summary>
        /// /// <remarks>Computed field</remarks>
        public int PageLastForumPost { get; set; }
    }
}
