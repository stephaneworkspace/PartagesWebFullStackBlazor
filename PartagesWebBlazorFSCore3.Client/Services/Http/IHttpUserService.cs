using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.User;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    /// <summary>
    /// Interface User service (authentification)
    /// </summary>
    interface IHttpUserService
    {
        /// <summary>
        /// Check if dto.Username is available
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Boolean> PostIsAvailable(UserForRegisterAvailableDto dto);

        /// <summary>
        /// Register a new User
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostRegister(UserForRegisterDto dto);

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostLogin(UserForLoginDto dto);

        /// <summary>
        /// Get User model
        /// </summary>
        /// <param name="id">Primary key User destination</param>
        /// <returns></returns>
        /// <remarks>Authentification required</remarks>
        Task<HttpResponseMessage> GetUser(int id);
    }
}
