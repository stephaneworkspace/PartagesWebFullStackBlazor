//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumCategorie.ForSelect
{
    /// <summary>
    /// Dto from model ForumCategorie
    /// </summary>
    public class ForumCategorieForSelectDto
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
