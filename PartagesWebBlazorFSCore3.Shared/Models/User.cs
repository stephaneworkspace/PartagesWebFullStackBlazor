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
    /// Model User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password Hash
        /// </summary>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// Password Salt
        /// </summary>
        public byte[] PasswordSalt { get; set; }

        /// <summary>
        /// Date Created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Switch Deactivated
        /// </summary>
        public bool SwDeactivated { get; set; }
    }
}
