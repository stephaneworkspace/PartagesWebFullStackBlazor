//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumPost.ForSelect
{
    /// <summary>
    /// Dto from model ForumTopic
    /// </summary>
    public class ForumTopicForSelectForumPostDto
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
        public virtual ForumCategorieForSelectForumPostDto ForumCategorie { get; set; }

        /// <summary>
        /// Name of topic
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date of topic
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Number of views
        /// </summary>
        public int View { get; set; }
    }
}
