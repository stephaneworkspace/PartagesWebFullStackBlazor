//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
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
using PartagesWebBlazorFSCore3.Server.Dtos.Forum.ForumPost.Input.ForReply;
using PartagesWebBlazorFSCore3.Server.Dtos.Forum.ForumPost.Output.ForList;
using PartagesWebBlazorFSCore3.Server.Dtos.Forum.ForumPost.Output.ForSelect;
using PartagesWebBlazorFSCore3.Server.Helpers;
using PartagesWebBlazorFSCore3.Server.Helpers.PagedParams;
using PartagesWebBlazorFSCore3.Shared.Models;

namespace PartagesWebBlazorFSCore3.Server.Controllers
{
    /// <summary>
    /// ForumPost controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("ForumPost", Description = "ForumPost controller")]
    public class ForumPostController : Controller
    {
        private readonly IForumRepository _repo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        /// <summary>  
        /// Cette méthode est le constructeur 
        /// </summary>  
        /// <param name="repo">Forum Repository</param>
        /// <param name="mapper">AutoMapp</param>
        /// <param name="config">Configuration</param>
        public ForumPostController(IForumRepository repo, IMapper mapper, IConfiguration config)
        {
            _config = config;
            _mapper = mapper;
            _repo = repo;
        }
        /// <summary>  
        /// Get paged ForumPosts
        /// </summary> 
        /// <param name="forumPostParams">Pagination param</param>
        /// <param name="id">ForumTopic Foreign key</param>
        /// <remarks>
        /// ForumPostForListDto => For Automap
        /// ForumPostForListDtoWithVirtual => With extra field
        /// </remarks>
        [HttpGet("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ForumPostForListDtoWithVirtual[]), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Impossible de mettre à jour le nombre de vue du sujet")]
        public async Task<IActionResult> GetForumPosts([FromQuery] ForumPostParams forumPostParams, int id)
        {
            var boolTrue = await _repo.IncViewForumTopic(id);
            if (!boolTrue)
            {
                return BadRequest("Impossible de mettre à jour le nombre de vue du sujet");
            }
            var items = await _repo.GetForumPosts(forumPostParams, id);
            var itemsDto = _mapper.Map<List<ForumPostForListDto>>(items);
            Response.AddPagination(items.CurrentPage, items.PageSize, items.TotalCount, items.TotalPages);
            var itemsDtoFinal = new List<ForumPostForListDtoWithVirtual>();
            foreach (var itemDto in itemsDto)
            {
                var itemDtoWithVirtual = new ForumPostForListDtoWithVirtual();
                itemDtoWithVirtual.Id = itemDto.Id;
                itemDtoWithVirtual.ForumTopic = itemDto.ForumTopic;
                itemDtoWithVirtual.ForumTopicId = itemDto.ForumTopicId;
                itemDtoWithVirtual.User.Id = itemDto.User.Id;
                itemDtoWithVirtual.User.Username = itemDto.User.Username;
                itemDtoWithVirtual.User.Created = itemDto.User.Created;
                itemDtoWithVirtual.UserId = itemDto.UserId;
                itemDtoWithVirtual.Content = itemDto.Content;
                itemDtoWithVirtual.Date = itemDto.Date;
                var UserIdCurrent = 0;
                if (User.Identity.IsAuthenticated)
                {
                    UserIdCurrent = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                }
                if (UserIdCurrent == itemDto.UserId)
                {
                    itemDtoWithVirtual.SwCurrentUser = true;
                }
                else
                {
                    itemDtoWithVirtual.SwCurrentUser = false;
                }
                itemDtoWithVirtual.User.MessageCount = await _repo.GetCountUserForumPost(itemDto.UserId);
                itemsDtoFinal.Add(itemDtoWithVirtual);
            }
            return Ok(itemsDtoFinal);
        }
        /// <summary>
        /// Response to a ForumPost
        /// </summary>
        /// <param name="Dto">Dto Input</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ForumPost), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Impossible de répondre à ce poste")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "error.errors.Nom[0] == Le champ « Contenu » est obligatoire.")]
        public async Task<IActionResult> ReplyForumPoste(ForumPostForReplyDto Dto)
        {
            // Trouver l'utilisateur actuel
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            // Préparation du model
            var Item = new ForumPost
            {
                ForumTopicId = Dto.ForumTopicId,
                UserId = userId,
                Date = DateTime.Now,
                Content = Dto.Content
            };

            _repo.Add(Item);

            if (await _repo.SaveAll())
                return Ok(Item);

            return BadRequest("Impossible de répondre à ce poste");
        }
        /// <summary>  
        /// Get ForumPost
        /// </summary> 
        /// <param name="id">ForumPost primary key</param>
        [HttpGet("ForumPostId/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ForumPostForSelectDto), Description = "Ok")]
        public async Task<IActionResult> GetForumPost(int id)
        {
            var item = await _repo.GetForumPost(id);
            ForumPostForSelectDto newDto = new ForumPostForSelectDto();
            var itemDto = _mapper.Map<ForumPostForSelectDto>(item);
            return Ok(itemDto);
        }
    }
}
