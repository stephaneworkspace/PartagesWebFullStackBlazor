using System;
using System.Collections.Generic;
using System.Text;

namespace PartagesWebBlazorFSCore3.Shared.Dtos.Output.User.LoginReturn
{
    /// <summary>
    /// Dto
    /// </summary>
    public class LoginReturnDto
    {
        /// <summary>
        /// Jwt token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public UserForLoginReturnDto User { get; set; }

        /// <summary>
        /// Number of messages unread
        /// </summary>
        public int MessagesUnread { get; set; }
    }
}
