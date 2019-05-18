//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
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
    /// Repository private message betwen User
    /// </summary>
    public class MessageRepository : IMessageRepository
    {
        /// <summary>
        /// DbContext
        /// </summary>
        private readonly DataContext _context;

        /// <summary>  
        /// Constructor
        /// </summary> 
        /// <param name="context">DataContext</param>
        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>  
        /// Add entity in DataContext
        /// </summary>  
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="entity">Free entity</param>
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        /// <summary>
        /// Update entity in DataContext
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="entity">Free entity</param>
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        /// <summary>  
        /// Delete entity in DataContext
        /// </summary>  
        /// <param name="entity">Free entity</param>
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        /// <summary>  
        /// Save all changes in DataContext
        /// </summary> 
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /**
         * Messagerie
         */

        /// <summary>  
        /// Check if switch read "SwRead" is turned on or off
        /// </summary>
        /// <param name="id">Message primary key</param>
        /// <returns></returns> 
        public async Task<bool> SwRead(int id)
        {
            var item = await _context.Messages.Where(x => x.Id == id).FirstOrDefaultAsync();
            item.SwRead = true;
            Update(item);
            return await SaveAll();
        }

        /// <summary>  
        /// Get a message by primary key
        /// </summary>
        /// <param name="id">Message primary key</param>
        /// <returns></returns> 
        public async Task<Message> GetMessage(int id)
        {
            var item = await _context.Messages.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item;
        }

        /// <summary>  
        /// Read all Message
        /// </summary>
        /// <param name="messageParams">Pagination params</param>
        /// <param name="userId">User [Authorize]</param>
        /// <returns></returns> 
        /// <remarks>User authentification by token</remarks>
        public async Task<PagedList<Message>> GetMessages(MessageParams messageParams, int userId)
        {
            var items = _context.Messages
                .OrderBy(u => u.Date).Where(x => x.UserId == userId).AsQueryable();
            return await PagedList<Message>.CreateAsync(items, messageParams.PageNumber, messageParams.PageSize);
        }
        
        /// <summary>
        /// Count unread message
        /// </summary>
        /// <param name="userId">Utilisateur [Authorize]</param>
        /// <returns></returns>
        public async Task<int> GetCountMessagesUnread(int userId)
        {
            var count = _context.Messages.Where(x => x.UserId == userId).Where(y => y.SwRead == false).Count();
            await Task.FromResult(count);
            return count;
        }

        ///<summary>
        ///Return User model for SendByUserId?
        ///</summary>
        /// <param name="sendByUserId">SendByUserId int?</param>
        /// <returns></returns>
        public async Task<User> GetSendByUser(int sendByUserId)
        {
            var user = await _context.Users.Where(x => x.Id == sendByUserId).FirstOrDefaultAsync();
            return user;
        }
    }
}
