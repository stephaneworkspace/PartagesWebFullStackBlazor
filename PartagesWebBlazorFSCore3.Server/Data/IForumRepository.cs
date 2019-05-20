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
    /// Repository
    /// </summary>
    public interface IForumRepository
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
         * ForumCategorie
         **/

        /// <summary>  
        /// Get ForumCategories
        /// </summary>
        /// <returns></returns> 
        Task<List<ForumCategorie>> GetForumCategories();

        /// <summary>  
        /// Get ForumCategire by primary key
        /// </summary>
        /// <param name="id">ForumCategorie primary key</param>
        /// <returns></returns> 
        Task<ForumCategorie> GetForumCategorie(int id);

        /// <summary>
        /// Count ForumTopics from a ForumCategorie
        /// </summary>
        /// <param name="id">ForumCategorie primary key</param>
        /// <returns></returns>
        Task<int> GetCountForumTopic(int id);

        /// <summary>
        /// Count ForumPostes from a ForumCategirue
        /// </summary>
        /// <param name="id">ForumCategorie primary key</param>
        /// <returns></returns>
        Task<int> GetCountForumPostFromForumCategorie(int id);

        /// <summary>
        /// Last ForumPost from a ForumCategorie
        /// </summary>
        /// <param name="id">ForumCategirue primary key</param>
        /// <returns></returns>
        Task<ForumPost> GetLastForumPostFromForumCategorie(int id);

        /**
         * ForumTopic
         */

        /// <summary>  
        /// Get ForumTopic in paged list in a ForumCategorie
        /// </summary>
        /// <param name="forumTopicParams">Pagination params</param>
        /// <param name="id">ForumCategorie primary key</param>
        /// <returns></returns> 
        Task<PagedList<ForumTopic>> GetForumTopics(ForumTopicParams forumTopicParams, int id);

        /// <summary>  
        /// Get a ForumTopic by primary key
        /// </summary>
        /// <param name="id">ForumTopic primary key</param>
        /// <returns></returns> 
        Task<ForumTopic> GetForumTopic(int id);

        /// <summary>
        /// Count ForumPost from a ForumTopic
        /// </summary>
        /// <param name="id">ForumTopic primary key</param>
        /// <returns></returns>
        Task<int> GetCountLastForumPostFromAForumTopic(int id); 

        /// <summary>
        /// Get last ForumPost from a ForumTopic
        /// </summary>
        /// <param name="id">ForumTopic primary key</param>
        /// <returns></returns>
        Task<ForumPost> GetLastForumPostFromAForumTopic(int id);

        /// <summary>
        /// Increment a view in one ForumTopic
        /// </summary>
        /// <param name="id">ForumTopic primary key</param>
        Task<bool> IncViewForumTopic(int id);

        /// <summary>
        /// Test if topic name is unique
        /// </summary>
        /// <param name="name">ForumTopic.Name</param>
        /// <returns></returns>
        Task<bool> ForumTopicExist(string name);

        /**
         * ForumPost
         **/

        /// <summary>  
        /// Get ForumPosts paged
        /// </summary>
        /// <param name="forumPostParams">Pagination params</param>
        /// <param name="id">ForumTopic primary key</param>
        /// <returns></returns> 
        Task<PagedList<ForumPost>> GetForumPosts(ForumPostParams forumPostParams, int id);

        /// <summary>  
        /// Get ForumPost
        /// </summary>
        /// <param name="id">ForumPost primary key</param>
        /// <returns></returns> 
        Task<ForumPost> GetForumPost(int id);

        /// <summary>
        /// Count post from a User
        /// </summary>
        /// <param name="id">User primary key</param>
        /// <returns></returns>
        Task<int> GetCountUserForumPost(int id);
    }
}
