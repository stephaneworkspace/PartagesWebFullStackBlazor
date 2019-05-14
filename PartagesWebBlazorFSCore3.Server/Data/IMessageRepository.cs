//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using PartagesWebBlazorFSCore3.Server.Helpers;
using PartagesWebBlazorFSCore3.Server.Helpers.PagedParams;
using PartagesWebBlazorFSCore3.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Data
{
    /// <summary>
    /// Private message repository
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>  
        /// Add entity in DataContext
        /// </summary>  
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="entity">Free entity</param>
        void Add<T>(T entity) where T : class;
        /// <summary>
        /// Update entity in DataContext
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="entity">Free entity</param>
        void Update<T>(T entity) where T : class;
        /// <summary>  
        /// Delete entity in DataContext
        /// </summary>  
        /// <param name="entity">Free entity</param>
        void Delete<T>(T entity) where T : class;
        /// <summary>  
        /// Save all changes in DataContext
        /// </summary> 
        Task<bool> SaveAll();
        /**
         * Messages
         **/
        /// <summary>  
        /// Check if switch read "SwRead" is turned on or off
        /// </summary>
        /// <param name="id">Message primary key</param>
        /// <returns></returns> 
        Task<bool> SwRead(int id);
        /// <summary>  
        /// Get a message by primary key
        /// </summary>
        /// <param name="id">Message primary key</param>
        /// <returns></returns> 
        Task<Message> GetMessage(int id);
        /// <summary>  
        /// Read all Message
        /// </summary>
        /// <param name="messageParams">Pagination</param>
        /// <param name="userId">User [Authorize]</param>
        /// <returns></returns> 
        /// <remarks>User authentification by token</remarks>
        Task<PagedList<Message>> GetMessages(MessageParams messageParams, int userId);
        /// <summary>
        /// Count unread message
        /// </summary>
        /// <param name="userId">Utilisateur [Authorize]</param>
        /// <returns></returns>
        Task<int> GetCountMessagesUnread(int userId);
        ///<summary>
        ///Return User model for SendByUserId?
        ///</summary>
        /// <param name="sendByUserId">SendByUserId int?</param>
        /// <returns></returns>
        Task<User> GetSendByUser(int sendByUserId);
    }
}