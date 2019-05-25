using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    /// <summary>
    /// Interface ForumCategorie service
    /// </summary>
    interface IHttpForumCategorieService
    {
        /// <summary>
        /// Get one ForumCategorie by primary key
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> GetForumCategorie(int id);

        /// <summary>
        /// Get all ForumCategorie
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> GetForumCategories();
    }
}
