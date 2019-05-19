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
        public string Token { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public UserForLoginDto User { get; set; }

        /// <summary>
        /// Number of messages unread
        /// </summary>
        public int MessagesUnread { get; set; }
    }
}
