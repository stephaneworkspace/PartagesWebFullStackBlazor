﻿//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumTopic.ForSingleSelect
{
    /// <summary>
    /// Dto for model ForumCategorie
    /// </summary>
    public class ForumCategorieForSelectForumTopicDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of categorie
        /// </summary>
        public string Name { get; set; }
    }
}
