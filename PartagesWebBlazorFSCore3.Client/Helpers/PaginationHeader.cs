//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Helpers
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
    }
}