using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using Microsoft.JSInterop;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Forum.ForumPost.ForReply;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartagesWebBlazorFSCore3.Client.Services.Http
{
    /// <summary>
    /// Message Service
    /// </summary>
    interface IHttpMessageService
    {
        /// <summary>
        /// Get all Messages
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> GetMessages(int page);

        /// <summary>
        /// Post a message
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostMessage(MessageDto dto);

        /// <summary>
        /// Get a Message from primary key
        /// </summary>
        /// <param name="id">Message primary key</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetMessage(int id);
    }
}
