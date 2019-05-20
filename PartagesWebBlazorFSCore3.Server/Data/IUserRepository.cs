//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using PartagesWebBlazorFSCore3.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Data
{
    /// <summary>
    /// User repository (authentification)
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>  
        /// Login
        /// </summary>  
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        Task<User> Login(string username, string password);

        /// <summary>  
        /// Register
        /// </summary>  
        /// <param name="user">Model user</param>
        /// <param name="password">Password</param>        
        Task<User> Register(User user, string password);

        /// <summary>  
        /// Method if username exist in User model
        /// </summary>  
        /// <param name="username">Username</param>
        Task<bool> UserExists(string username);

        /// <summary>
        /// Get User model
        /// </summary>
        /// <param name="id">User primary key</param>
        /// <returns></returns>
        Task<User> GetUser(int id);
    }
}
