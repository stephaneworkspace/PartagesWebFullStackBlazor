using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSwag.Annotations;
using PartagesWebBlazorFSCore3.Server.Data;
using PartagesWebBlazorFSCore3.Server.Helpers;
using PartagesWebBlazorFSCore3.Server.Helpers.PagedParams;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Message;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Message.ForList;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Message.ForSelect;
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
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(MessageForListDto[]), Description = "Ok")]
        public async Task<IActionResult> GetMessages([FromQuery] MessageParams messageParams)
        {
            // Find current user
            var currentUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var items = await _repo.GetMessages(messageParams, currentUser);
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
                    Date = item.Date,
                    SwRead = item.SwRead
                };
                newDto.Add(dto);
            }
            Response.AddPagination(items.CurrentPage, items.PageSize, items.TotalCount, items.TotalPages);
            return Ok(newDto);
        }

        /// <summary>  
        /// Get Message by primary key
        /// </summary> 
        /// <param name="id">Message primary key</param>
        [Authorize]
        [HttpGet("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(MessageForSelectDto), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Impossible de lire le message")]
        public async Task<IActionResult> GetMessage(int id)
        {
            // Find current user
            var currentUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // Get Message by primary key
            var item = await _repo.GetMessage(id);

            item.SwRead = true;

            User sendByUser = await _repoUser.GetUser(item.SendByUserId ?? default(int));

            MessageForSelectDto dto = new MessageForSelectDto()
            {
                Id = item.Id,
                SendByUserId = item.SendByUserId,
                SendByUser = _mapper.Map<UserForMessageForSelectDto>(sendByUser), // automapp
                Subject = item.Subject,
                Content = item.Content,
                Date = item.Date,
                SwRead = item.SwRead
            };

            // Update SwRead
            _repo.Update(item);          

            if (await _repo.SaveAll())
                return Ok(dto);

            return BadRequest("Impossible de lire le message");

        }

        /// <summary>
        /// New ForumTopic and ForumPost
        /// </summary>
        /// <param name="Dto">Dto Input</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(void), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Impossible d'envoyer le message")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "error.errors.Nom[0] == Le champ « Destinataire » est obligatoire.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "error.errors.Nom[0] == Le champ « Sujet » est obligatoire.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "error.errors.Nom[0] == Le champ « Contenu » est obligatoire.")]
        public async Task<IActionResult> PostMessage(MessageDto dto)
        {
            // Find current user
            var currentUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // Prepare message
            Message item = new Message
            {
                UserId = dto.UserId,
                SendByUserId = currentUser,
                Date = DateTime.Now,
                Subject = dto.Subject,
                Content = dto.Content,
                SwRead = false,
            };

            _repo.Add(item);

            if (await _repo.SaveAll())
                return Ok(item);

            return BadRequest("Impossible d'envoyer le message");
        }
    }
}
