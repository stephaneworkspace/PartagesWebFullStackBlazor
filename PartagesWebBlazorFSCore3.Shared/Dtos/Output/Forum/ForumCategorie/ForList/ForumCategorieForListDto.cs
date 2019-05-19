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
    /// Dto from model ForumCategorie
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
        /// Page of last ForumPost
        /// </summary>
        public int PageLastForumPost { get; set; }
    }
}
