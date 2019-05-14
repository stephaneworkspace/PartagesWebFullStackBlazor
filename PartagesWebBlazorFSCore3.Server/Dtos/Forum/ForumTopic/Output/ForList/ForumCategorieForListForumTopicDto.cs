//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Dtos.Forum.ForumTopic.Output.ForList
{
    /// <summary>
    /// Dto
    /// </summary>
    public class ForumCategorieForListForumTopicDto
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
