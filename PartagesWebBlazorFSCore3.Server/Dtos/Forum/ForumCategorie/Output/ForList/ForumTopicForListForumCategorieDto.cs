﻿//-----------------------------------------------------------------------
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
    public class ForumTopicForListForumCategorieDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Foreignkey ForumCategorie
        /// </summary>
        public int ForumCategorieId { get; set; }
        /// <summary>
        /// Topic name
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Topic date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Number of view
        /// </summary>
        public int View { get; set; }
    }
}