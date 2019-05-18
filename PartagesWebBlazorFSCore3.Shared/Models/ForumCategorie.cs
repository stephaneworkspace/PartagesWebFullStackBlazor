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
    public class ForumCategorie
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Categorie name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// List of topics
        /// </summary>
        public virtual ICollection<ForumTopic> ForumTopics { get; set; }
    }
}
