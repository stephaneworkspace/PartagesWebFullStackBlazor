//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Helpers
{
    /// <summary>
    /// Pagination Header
    /// </summary>
    public class PaginationHeader
    {
        /// <summary>
        /// Current page
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Items per page
        /// </summary>
        public int ItemsPerPage { get; set; }
        /// <summary>
        /// Total items
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="currentPage">Current page</param>
        /// <param name="itemsPerPage">Items per page</param>
        /// <param name="totalItems">Total items</param>
        /// <param name="totalPages">Total pages</param>
        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            this.CurrentPage = currentPage;
            this.ItemsPerPage = itemsPerPage;
            this.TotalItems = totalItems;
            this.TotalPages = totalPages;
        }
    }
}
