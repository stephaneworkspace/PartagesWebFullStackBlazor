//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PartagesWebBlazorFSCore3.Server.Dtos.Input.Seed.Forum.ForumTopic.ForSeed;
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
                CreatePasswordHash("password", out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();

                _context.Users.Add(user);
                // }
            }

            _context.SaveChanges();
        }
        /// <summary>  
        /// Create Password "Hash"
        /// </summary> 
        /// <remarks>
        /// Copy/Past AuthRepository
        /// </remarks>
        /// <param name="password">Password</param>
        /// <param name="passwordHash">(Out) Hash</param>
        /// <param name="passwordSalt">(Out) Salt</param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
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
                if (!_context.ForumCategories.Any(x => x.Nom.ToLower() == item.Nom.ToLower()))
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
                    ForumCategorie forumCategorie = _context.ForumCategories.Where(x => x.Nom == item.NameForumCategorie).First();
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
    }
}