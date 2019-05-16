using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services
{
    public class AlertifyService
    {
        private readonly IJSRuntime _jsRuntime;

        public AlertifyService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async void Open(string message)
        {
            var syncJsRunTime = await this._jsRuntime.InvokeAsync<bool>("Alertify", message, "success", 5);
        }
    }
}
