﻿//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Dtos.Forum.ForumPost.Output.ForList
{
    /// <summary>
    /// Dto
    /// </summary>
    public class ForumCategorieForListForumPostDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Categorie name
        /// </summary>
        public string Name { get; set; }
    }
}