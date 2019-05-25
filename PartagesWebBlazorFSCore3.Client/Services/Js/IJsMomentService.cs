using PartagesWebBlazorFSCore3.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Js
{
    /// <summary>
    /// Moment javascript service
    /// https://momentjs.com/
    /// </summary>
    public interface IJsMomentService
    {
        /// <summary>
        /// Return date from now in French
        /// </summary>
        /// <param name="date">Date string</param>
        /// <returns></returns>
        Task<string> FromNow(string date);

        /// <summary>
        /// Return date formated in French
        /// </summary>
        /// <param name="date">Date string</param>
        /// <returns></returns>
        Task<string> Format(string date);
    }
}
