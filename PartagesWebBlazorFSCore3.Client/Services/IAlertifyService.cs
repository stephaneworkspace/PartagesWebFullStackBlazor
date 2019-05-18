using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services
{
    public enum Type
    {
        Success,
        Error,
        Warning,
        Default
    }

    public interface IAlertifyService
    {
        Type TypeEnum { get; set; }
        void Open(string message, Type type);
    }
}
