//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Helpers
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Header for Application-Error used in Configure from Startup.cs
        /// </summary>
        /// <remarks>14.05.2019: For Angular/Asp.net Core back/front
        /// 15.05: Desactivate for udemy</remarks>
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            /*
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");*/
        }
        /// <summary>
        /// Pagination header
        /// </summary>
        /// <param name="response">Response http</param>
        /// <param name="currentPage">Current page</param>
        /// <param name="itemsPerPage">Items per pages</param>
        /// <param name="totalItems">Total items</param>
        /// <param name="totalPages">Total pages</param>
        public static void AddPagination(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            // This 2 line for .pagination near .result else is just for header
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // Fin comment
            response.Headers.Add("Pagination",
                JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
