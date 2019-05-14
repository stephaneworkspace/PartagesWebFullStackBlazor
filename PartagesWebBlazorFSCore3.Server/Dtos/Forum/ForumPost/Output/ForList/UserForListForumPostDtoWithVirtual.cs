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
    public class UserForListForumPostDtoWithVirtual
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
        /// <summary>
        /// Message count of user
        /// </summary>
        /// <remarks>Virtual DTO field</remarks>
        public int MessageCount { get; set; }
    }
}
