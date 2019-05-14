using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartagesWebBlazorFSCore3.Shared.Models;
using PartagesWebBlazorFSCore3.Shared.Models.Message;

namespace PartagesWebBlazorFSCore3.Server.Data
{
    public class DataContext: DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        /// <summary>  
        /// Constructor
        /// </summary>  
        /// <param name="options">DbContextOptions</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        /// <summary>  
        /// Entity User
        /// </summary> 
        public DbSet<User> Users { get; set; }
        /// <summary>  
        /// Entity Message
        /// </summary> 
        public DbSet<Message> Messages { get; set; }
    }
}
