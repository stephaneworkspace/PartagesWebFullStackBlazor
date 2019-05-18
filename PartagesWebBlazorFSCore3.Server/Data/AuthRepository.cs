//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using PartagesWebBlazorFSCore3.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Server.Data
{
    /// <summary>
    /// Authtification repository
    /// </summary>
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        /// <summary>  
        /// Constructor
        /// </summary>  
        /// <param name="context">DataContext</param>
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>  
        /// Login
        /// </summary>  
        /// <param name="username">Username</param>
        /// <param name="password">Mot de passe</param>
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }

        /// <summary>  
        /// Verifiy Password
        /// </summary>  
        /// <param name="password">Password</param>
        /// <param name="passwordHash">Hash</param>
        /// <param name="passwordSalt">Salt</param>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        /// <summary>  
        /// Register
        /// </summary>  
        /// <param name="user">Model User</param>
        /// <param name="password">Password</param>
        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <summary>  
        /// Create password hash
        /// </summary>  
        /// <param name="password">Password</param>
        /// <param name="passwordHash"> (Out) Hash</param>
        /// <param name="passwordSalt"> (Out) Salt</param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>  
        /// If user in model User exists
        /// </summary>  
        /// <param name="username">Username</param>
        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;
            return false;
        }
    }
}
