//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PartagesWebBlazorFSCore3.Server.Dtos.Input.Seed.Forum.ForumPost.ForSeed;
using PartagesWebBlazorFSCore3.Server.Dtos.Input.Seed.Forum.ForumTopic.ForSeed;
using PartagesWebBlazorFSCore3.Server.Helpers;
using PartagesWebBlazorFSCore3.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Data
{
    /// <summary>
    /// Data Seed
    /// </summary>
    public class Seed
    {
        /// <summary>
        /// DataContext
        /// </summary>
        private readonly DataContext _context;

        /// <summary>  
        /// Constructor
        /// </summary>  
        /// <param name="context">DataContext</param>
        public Seed(DataContext context)
        {
            _context = context;
        }

        /// <summary>  
        /// Seed User
        /// </summary> 
        /// <remarks>
        /// Code in comment don't compile, so the solution for unique data is comment this method in Startup.cs
        /// </remarks>
        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("Data/Seed/UsersSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                // var userQuery = await _context.Users.FirstOrDefaultAsync(x => x.Username == user.Username);
                // if (userQuery == null)
                // if (!await _context.Users.AnyAsync(x => x.Username == user.Username))
                // {
                PasswordGenerate passwordGenerate = new PasswordGenerate();
                passwordGenerate.CreatePasswordHash("password", out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();

                _context.Users.Add(user);
                // }
            }

            _context.SaveChanges();
        }

        ///<summary>
        /// Seed ForumCategorie
        ///</summary>
        public async void SeedForumCategorie()
        {
            var itemData = System.IO.File.ReadAllText("Data/Seed/ForumCategoriesSeedData.json", Encoding.GetEncoding("iso-8859-1"));
            var items = JsonConvert.DeserializeObject<List<ForumCategorie>>(itemData);
            foreach (var item in items)
            {
                if (!_context.ForumCategories.Any(x => x.Name.ToLower() == item.Name.ToLower()))
                {
                    _context.ForumCategories.Add(item);
                }
                await _context.SaveChangesAsync();
            }
        }

        ///<summary>
        /// Seed ForumTopic
        ///</summary>
        public async void SeedForumTopic()
        {
            var itemData = System.IO.File.ReadAllText("Data/Seed/ForumTopicsSeedData.json", Encoding.GetEncoding("iso-8859-1"));
            var items2 = JsonConvert.DeserializeObject<List<ForumTopicForSeedDto>>(itemData);
            foreach (var item in items2)
            {
                if (!_context.ForumTopics.Any(x => x.Name.ToLower() == item.Name.ToLower()))
                {
                    ForumCategorie forumCategorie = _context.ForumCategories.Where(x => x.Name == item.NameForumCategorie).First();
                    ForumTopic forumTopic = new ForumTopic
                    {
                        ForumCategorieId = forumCategorie.Id,
                        Name = item.Name,
                        Date = item.Date,
                        View = item.View
                    };
                    _context.ForumTopics.Add(forumTopic);
                    await _context.SaveChangesAsync();
                }
            }
        }

        ///<summary>
        /// Seed ForumPost
        ///</summary>
        public async void SeedForumPost()
        {
            var itemData = System.IO.File.ReadAllText("Data/Seed/ForumPostsSeedData.json", Encoding.GetEncoding("iso-8859-1"));
            var items3 = JsonConvert.DeserializeObject<List<ForumPostForSeedDto>>(itemData);
            foreach (var item in items3)
            {
                if (!_context.ForumPosts.Any(x => x.Content.ToLower() == item.Content.ToLower()))
                {
                    ForumTopic forumTopic = _context.ForumTopics.Where(x => x.Name == item.NameForumTopic).First();
                    User userPost = _context.Users.Where(x => x.Username == item.Username).First();
                    ForumPost forumPost = new ForumPost
                    {
                        ForumTopicId = forumTopic.Id,
                        UserId = userPost.Id,
                        Date = item.Date,
                        Content = item.Content
                    };
                    _context.ForumPosts.Add(forumPost);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}