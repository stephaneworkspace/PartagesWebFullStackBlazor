using Microsoft.JSInterop;
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
    public class AlertifyService: IAlertifyService
    {
        /// <summary>
        /// Javascript runtime
        /// </summary>
        private readonly IJSRuntime _jsRuntime;

        /// <summary>
        /// Type of toast
        /// </summary>
        public TypeAlertify Type { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jsRuntime">Javascript runtime</param>
        public AlertifyService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        /// <summary>
        /// Open alertify
        /// </summary>
        /// <param name="message">Message of toast</param>
        /// <param name="type">Type of toast</param>
        public async void Open(string message, TypeAlertify type)
        {
            switch (type)
            {
                case TypeAlertify.Success:
                    await this._jsRuntime.InvokeAsync<bool>("Alertify", message, "success", 5);
                    break;
                case TypeAlertify.Error:
                    await this._jsRuntime.InvokeAsync<bool>("Alertify", message, "error", 5);
                    break;
                case TypeAlertify.Warning:
                    await this._jsRuntime.InvokeAsync<bool>("Alertify", message, "warning", 5);
                    break;
                default:
                    await this._jsRuntime.InvokeAsync<bool>("Alertify", message, 5);
                    break;
            }
        }
    }
}
