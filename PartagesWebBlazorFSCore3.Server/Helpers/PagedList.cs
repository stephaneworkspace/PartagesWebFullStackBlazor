//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Helpers
{
    /// <summary>
    /// Pagination
    /// </summary>
    /// <typeparam name="T">Entity choice</typeparam>
    public class PagedList<T> : List<T>
    {
        /// <summary>
        /// Current page
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Total count
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">List type free <t> of items "t"</t></param>
        /// <param name="count">Total element all pages</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }
        /// <summary>
        /// Create async
        /// </summary>
        /// <param name="source">Source entity IQueryable T of choice</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
