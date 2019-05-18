using PartagesWebBlazorFSCore3.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services
{
    public interface IAlertifyService
    {
        TypeAlertify Type { get; set; }
        void Open(string message, TypeAlertify type);
    }
}
