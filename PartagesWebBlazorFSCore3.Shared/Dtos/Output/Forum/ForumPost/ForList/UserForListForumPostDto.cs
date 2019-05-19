//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumPost.ForList
{
    /// <summary>
    /// Dto from model User with a computed field, MessageCount
    /// </summary>
    public class UserForListForumPostDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Date created account
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Message count of user
        /// </summary>
        /// <remarks>Computed DTO field</remarks>
        public int MessageCount { get; set; }
    }
}
