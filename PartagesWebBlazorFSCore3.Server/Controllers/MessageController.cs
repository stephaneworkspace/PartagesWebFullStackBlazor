using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSwag.Annotations;
using PartagesWebBlazorFSCore3.Server.Data;
using PartagesWebBlazorFSCore3.Server.Helpers;
using PartagesWebBlazorFSCore3.Server.Helpers.PagedParams;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Message.ForList;
using PartagesWebBlazorFSCore3.Shared.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartagesWebBlazorFSCore3.Server.Controllers
{
    /// <summary>
    /// Message controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Message", Description = "Message controller")]
    public class MessageController : Controller
    {
        private readonly IMessageRepository _repo;
        private readonly IUserRepository _repoUser;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        /// <summary>  
        /// Constructor
        /// </summary> 
        /// <param name="repo">Private message repository</param>
        /// <param name="config">Configuration</param>
        /// <param name="mapper">Automapp</param>
        public MessageController(IMessageRepository repo, IUserRepository repoUser, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _repoUser = repoUser;
            _config = config;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(MessageForListDto[]), Description = "Ok")]
        public async Task<IActionResult> GetMessages([FromQuery] MessageParams messageParams, int id)
        {
            var items = await _repo.GetMessages(messageParams, id);
            /// No automapp because computed field
            List<MessageForListDto> newDto = new List<MessageForListDto>();
            foreach (var item in items)
            {
                User sendByUser = await _repoUser.GetUser(item.SendByUserId ?? default(int));
                MessageForListDto dto = new MessageForListDto()
                {
                    Id = item.Id,
                    SendByUserId = item.SendByUserId,
                    SendByUser = _mapper.Map<UserForMessageForListDto>(sendByUser), // automapp
                    Subject = item.Subject,
                    SwRead = item.SwRead
                };
                newDto.Add(dto);
            }
            Response.AddPagination(items.CurrentPage, items.PageSize, items.TotalCount, items.TotalPages);
            return Ok(newDto);
        }
    }
}
