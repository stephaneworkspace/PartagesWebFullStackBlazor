using Microsoft.JSInterop;
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
    public class JsMomentService : IJsMomentService
    {
        /// <summary>
        /// Javascript runtime
        /// </summary>
        private readonly IJSRuntime _jsRuntime;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jsRuntime">Javascript runtime</param>
        public JsMomentService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        /// <summary>
        /// Return date from now in french
        /// </summary>
        /// <param name="date">Date string</param>
        /// <returns></returns>
        public async Task<string> FromNow(string date)
        {
            return await _jsRuntime.InvokeAsync<string>("MomentJsFormNow", date);
        }

        /// <summary>
        /// Return date formated in french
        /// </summary>
        /// <param name="date">Date string</param>
        /// <returns></returns>
        public async Task<string> Format(string date)
        {
            return await _jsRuntime.InvokeAsync<string>("MomentJsFormat", date);
        }
    }
}
