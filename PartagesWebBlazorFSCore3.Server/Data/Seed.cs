//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PartagesWebBlazorFSCore3.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Seed users in db
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
    }
}
