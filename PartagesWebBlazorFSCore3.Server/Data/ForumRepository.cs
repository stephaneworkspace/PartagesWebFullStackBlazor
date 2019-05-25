//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartagesWebBlazorFSCore3.Server.Helpers;
using PartagesWebBlazorFSCore3.Server.Helpers.PagedParams;
using PartagesWebBlazorFSCore3.Shared.Models;

namespace PartagesWebBlazorFSCore3.Server.Data
{
    public class ForumRepository : IForumRepository
    {
        /// <summary>
        /// DbContext
        /// </summary>
        private readonly DataContext _context;

        /// <summary>  
        /// Constructor
        /// </summary> 
        /// <param name="context">DataContext</param>
        public ForumRepository(DataContext context)
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
         * ForumCategorie
         **/

        /// <summary>  
        /// Get ForumCategories
        /// </summary>
        /// <returns></returns> 
        public async Task<List<ForumCategorie>> GetForumCategories()
        {
            var items = await _context.ForumCategories.OrderBy(u => u.Name).ToListAsync();
            return items;
        }

        /// <summary>  
        /// Get ForumCategire by primary key
        /// </summary>
        /// <param name="id">ForumCategorie primary key</param>
        /// <returns></returns> 
        public async Task<ForumCategorie> GetForumCategorie(int id)
        {
            var items = await _context.ForumCategories.Where(x => x.Id == id).FirstOrDefaultAsync();
            return items;
        }

        /// <summary>
        /// Count ForumTopics from a ForumCategorie
        /// </summary>
        /// <param name="id">ForumCategorie primary key</param>
        /// <returns></returns>
        public async Task<int> GetCountForumTopic(int id)
        {
            var count = _context.ForumTopics.Where(x => x.ForumCategorieId == id).Count();
            await Task.FromResult(count);
            return count;
        }

        /// <summary>
        /// Count ForumPostes from a ForumCategorie
        /// </summary>
        /// <param name="id">ForumCategorie primary key</param>
        /// <returns></returns>
        public async Task<int> GetCountForumPostFromForumCategorie(int id)
        {
            var items = _context.ForumTopics.Where(x => x.ForumCategorieId == id);
            var count = await Task.FromResult(0);
            foreach (var unite in items)
            {
                var countTempo = _context.ForumPosts.Where(x => x.ForumTopicId == unite.Id).Count();
                await Task.FromResult(countTempo);
                count += countTempo;
            }
            return count;
        }

        /// <summary>
        /// Last ForumPost from a ForumCategorie
        /// </summary>
        /// <param name="id">ForumCategirue primary key</param>
        /// <returns></returns>
        public async Task<ForumPost> GetLastForumPostFromForumCategorie(int id)
        {
            var item = await _context.ForumPosts.Where(x => x.ForumTopic.ForumCategorieId == id).OrderByDescending(x => x.Date).FirstOrDefaultAsync();
            return item;
        }
        
        /**
         * ForumTopic
         */

        /// <summary>  
        /// Get ForumTopic in paged list in a ForumCategorie
        /// </summary>
        /// <param name="forumTopicParams">Pagination params</param>
        /// <param name="id">ForumCategorie primary key</param>
        /// <returns></returns> 
        public async Task<PagedList<ForumTopic>> GetForumTopics(ForumTopicParams forumTopicParams, int id)
        {
            var items = _context.ForumTopics
                .OrderByDescending(u => u.Date).Where(x => x.ForumCategorieId == id).AsQueryable();
            return await PagedList<ForumTopic>.CreateAsync(items, forumTopicParams.PageNumber, forumTopicParams.PageSize);
        }
        
        /// <summary>  
        /// Get a ForumTopic by primary key
        /// </summary>
        /// <param name="id">ForumTopic primary key</param>
        /// <returns></returns> 
        public async Task<ForumTopic> GetForumTopic(int id)
        {
            var item = await _context.ForumTopics.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item;
        }
        
        /// <summary>
        /// Count ForumPost from a ForumTopic
        /// </summary>
        /// <param name="id">ForumTopic primary key</param>
        /// <returns></returns>
        public async Task<int> GetCountLastForumPostFromAForumTopic(int id)
        {
            var items = _context.ForumPosts.Where(x => x.ForumTopicId == id).Count();
            var count = await Task.FromResult(items);
            return count;
        }

        /// <summary>
        /// Get last ForumPost from a ForumTopic
        /// </summary>
        /// <param name="id">ForumTopic primary key</param>
        /// <returns></returns>
        public async Task<ForumPost> GetLastForumPostFromAForumTopic(int id)
        {
            var item = await _context.ForumPosts.Where(x => x.ForumTopic.Id == id).OrderByDescending(x => x.Date).FirstOrDefaultAsync();
            return item;
        }

        /// <summary>
        /// Increment a view in one ForumTopic
        /// </summary>
        /// <param name="id">ForumTopic primary key</param>
        public async Task<bool> IncViewForumTopic(int id)
        {
            var item = await _context.ForumTopics.Where(x => x.Id == id).FirstOrDefaultAsync();
            item.View++;
            Update(item);
            return await SaveAll();
        }

        /// <summary>
        /// Test if topic name is unique
        /// </summary>
        /// <param name="name">ForumTopic.Name</param>
        /// <returns></returns>
        public async Task<bool> ForumTopicExist(string name)
        {
            if (await _context.ForumTopics.AnyAsync(x => x.Name == name))
                return true;
            return false;
        }

        /**
         * ForumPost
         **/

        /// <summary>  
        /// Get ForumPosts paged
        /// </summary>
        /// <param name="forumPostParams">Pagination params</param>
        /// <param name="id">ForumTopic primary key</param>
        /// <returns></returns> 
        public async Task<PagedList<ForumPost>> GetForumPosts(ForumPostParams forumPostParams, int id)
        {
            var items = _context.ForumPosts
                .OrderBy(u => u.Date).Where(x => x.ForumTopicId == id).AsQueryable();
            return await PagedList<ForumPost>.CreateAsync(items, forumPostParams.PageNumber, forumPostParams.PageSize);
        }
        
        /// <summary>  
        /// Get ForumPost
        /// </summary>
        /// <param name="id">ForumPost primary key</param>
        /// <returns></returns> 
        public async Task<ForumPost> GetForumPost(int id)
        {
            var item = await _context.ForumPosts.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item;
        }
        
        /// <summary>
        /// Count post from a User
        /// </summary>
        /// <param name="id">User primary key</param>
        /// <returns></returns>
        public async Task<int> GetCountUserForumPost(int id)
        {
            var items = _context.ForumPosts.Where(x => x.UserId == id).Count();
            var count = await Task.FromResult(items);
            return count;
        }
    }
}
