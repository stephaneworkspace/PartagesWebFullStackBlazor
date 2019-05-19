using PartagesWebBlazorFSCore3.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Js
{
    /// <summary>
    /// Alertify javascript service
    /// https://alertifyjs.com
    /// </summary>
    public interface IJsAlertifyService
    {
        /// <summary>
        /// Type of toast
        /// </summary>
        TypeAlertify Type { get; set; }

        /// <summary>
        /// Open alertify
        /// </summary>
        /// <param name="message">Message of toast</param>
        /// <param name="type">Type of toast</param>
        void Open(string message, TypeAlertify type);
    }
}
