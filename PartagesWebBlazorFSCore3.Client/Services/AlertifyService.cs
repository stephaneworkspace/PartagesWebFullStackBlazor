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

        public enum Type
        {
            Success,
            Error,
            Warning,
            Default
        }

        public AlertifyService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async void Open(string message, Type type)
        {
            switch (type)
            {
                case Type.Success:
                    await this._jsRuntime.InvokeAsync<bool>("Alertify", message, "success", 5);
                    break;
                case Type.Error:
                    await this._jsRuntime.InvokeAsync<bool>("Alertify", message, "error", 5);
                    break;
                case Type.Warning:
                    await this._jsRuntime.InvokeAsync<bool>("Alertify", message, "warning", 5);
                    break;
                default:
                    await this._jsRuntime.InvokeAsync<bool>("Alertify", message, 5);
                    break;
            }
            var syncJsRunTime = await this._jsRuntime.InvokeAsync<bool>("Alertify", message, type, 5);
        }
    }
}
