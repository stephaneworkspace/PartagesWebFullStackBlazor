using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Auth;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    public interface IHttpAuthService
    {
        /// <summary>
        /// Check if dto.Username is available
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Boolean> PostIsAvailable(UserForRegisterInputDto dto);

        /// <summary>
        /// Register a new User
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostRegister(UserForRegisterInputDto dto);

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostLogin(UserForLoginInputDto dto);
    }
}
