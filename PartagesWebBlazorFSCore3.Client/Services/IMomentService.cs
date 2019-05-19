﻿using PartagesWebBlazorFSCore3.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services
{
    public interface IMomentService
    {
        /// <summary>
        /// Return date from now in french
        /// </summary>
        /// <param name="date">Date format c# entity</param>
        /// <returns></returns>
        Task<string> FromNow(string date);
        /// <summary>
        /// Return date formated in french
        /// </summary>
        /// <param name="date">Date format c# entity</param>
        /// <returns></returns>
        Task<string> Format(string date);
    }
}
