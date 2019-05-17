using System;
using System.Collections.Generic;
using System.Text;

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Output.Auth.Login
{
    /// <summary>
    /// Dto
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// Jwt token
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// User
        /// </summary>
        public UserForLoginDto user { get; set; }
        /// <summary>
        /// Number of messages unread
        /// </summary>
        public int messagesUnread { get; set; }
    }
}
