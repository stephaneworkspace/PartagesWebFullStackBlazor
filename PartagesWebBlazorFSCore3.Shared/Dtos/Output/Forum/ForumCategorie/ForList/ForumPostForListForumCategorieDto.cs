﻿//-----------------------------------------------------------------------
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
    /// Dto from model ForumPost
    /// </summary>
    public class ForumPostForListForumCategorieDto
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
        public virtual ForumTopicForListForumCategorieDto ForumTopic { get; set; }

        /// <summary>
        /// Foreign key User
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Relation with User
        /// </summary>
        public virtual UserForListForumCategorieDto User { get; set; }

        /// <summary>
        /// Date last ForumPost
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }
    }
}
