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
    /// Model Message
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ForeignKey User receiver
        /// </summary>
        /// <remarks>
        /// By default DeleteCascade if the User is Deleted
        /// </remarks>
        public int UserId { get; set; }

        /// <summary>
        /// Relation User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Sender User key
        /// </summary>
        /// <remarks>
        /// This can be null, if User is deleted from the DB
        /// </remarks>
        public int? SendByUserId { get; set; }

        /// <summary>
        /// Date of the message
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Content of the message
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Switch if message is read
        /// </summary>
        public Boolean SwRead { get; set; }
    }
}
