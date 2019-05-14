//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Helpers.PagedParams
{
    /// <summary>
    /// Pagination params for Message entity
    /// </summary>
    public class MessageParams
    {
        /// <summary>
        /// Maximum page size
        /// </summary>
        private const int MaxPageSize = 50;
        /// <summary>
        /// Numéro de pages
        /// </summary>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        /// Page size
        /// </summary>
        private int pageSize = 5;
        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }
}
