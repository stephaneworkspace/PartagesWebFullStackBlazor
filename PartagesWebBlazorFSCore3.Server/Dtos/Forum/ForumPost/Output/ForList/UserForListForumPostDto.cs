//-----------------------------------------------------------------------
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
    public class UserForListForumPostDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id;
        /// <summary>
        /// Username
        /// </summary>
        public string Username;
        /// <summary>
        /// Date created account
        /// </summary>
        public DateTime Created { get; set; }
    }
}
