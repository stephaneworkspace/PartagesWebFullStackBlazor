﻿//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartagesWebBlazorFSCore3.Shared.Models;

namespace PartagesWebBlazorFSCore3.Server.Data
{
    public class DataContext: DbContext
    {
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
        /// <summary>
        /// Entity ForumCategorie
        /// </summary>
        public DbSet<ForumCategorie> ForumCategories { get; set; }
        /// <summary>
        /// Entity ForumTopic
        /// </summary>
        public DbSet<ForumTopic> ForumTopics { get; set; }
        /// <summary>
        /// Entity ForumPost
        /// </summary>
        public DbSet<ForumPost> ForumPosts { get; set; }
    }
}
