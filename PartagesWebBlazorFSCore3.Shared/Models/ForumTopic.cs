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
    public class ForumTopic
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// FK ForumCategorie
        /// </summary>
        public int ForumCategorieId { get; set; }

        /// <summary>
        /// Relation with ForumCategorie
        /// </summary>
        public virtual ForumCategorie ForumCategorie { get; set; }

        /// <summary>
        /// Topic name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date from topic or last post
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Number of views
        /// </summary>
        public int View { get; set; }
    }
}
