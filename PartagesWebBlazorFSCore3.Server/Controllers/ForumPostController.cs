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
using PartagesWebBlazorFSCore3.Server.Helpers;
using PartagesWebBlazorFSCore3.Server.Helpers.PagedParams;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Forum.ForumPost.ForReply;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumPost.ForList;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumPost.ForSelect;
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
        [SwaggerResponse(HttpStatusCode.OK, typeof(ForumPostForListDto[]), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Impossible de mettre à jour le nombre de vue du sujet")]
        public async Task<IActionResult> GetForumPosts([FromQuery] ForumPostParams forumPostParams, int id)
        {
            var boolTrue = await _repo.IncViewForumTopic(id);
            if (!boolTrue)
            {
                return BadRequest("Impossible de mettre à jour le nombre de vue du sujet");
            }
            var items = await _repo.GetForumPosts(forumPostParams, id);
            /// No automapp because computed field
            List<ForumPostForListDto> itemsDtoFinal = new List<ForumPostForListDto>();
            foreach (var item in items)
            {
                var UserIdCurrent = 0;
                if (User.Identity.IsAuthenticated)
                {
                    UserIdCurrent = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                }
                /// No automapp because computed field
                var userWithVirtual = new UserForListForumPostDto
                {
                    Id = item.User.Id,
                    Username = item.User.Username,
                    Created = item.User.Created,
                    MessageCount = await _repo.GetCountUserForumPost(item.UserId)
                };
                /// No automapp because computed field
                var itemDtoWithVirtual = new ForumPostForListDto
                {
                    Id = item.Id,
                    ForumTopic = _mapper.Map<ForumTopicForListForumPostDto>(item.ForumTopic), // automapp, no change
                    ForumTopicId = item.ForumTopicId,
                    User = userWithVirtual,
                    UserId = item.UserId,
                    Content = item.Content,
                    Date = item.Date,
                    SwCurrentUser = UserIdCurrent == item.UserId
                };
                itemsDtoFinal.Add(itemDtoWithVirtual);
            }
            Response.AddPagination(items.CurrentPage, items.PageSize, items.TotalCount, items.TotalPages);
            return Ok(itemsDtoFinal);
        }
        
        /// <summary>
        /// Response to a ForumPost
        /// </summary>
        /// <param name="Dto">Dto Input</param>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ForumPost), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Impossible de répondre à ce poste")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "error.errors.Nom[0] == Le champ « Contenu » est obligatoire.")]
        public async Task<IActionResult> ReplyForumPoste(ForumPostForReplyDto Dto)
        {
            // Trouver l'utilisateur actuel
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // Préparation du model
            var Item = new ForumPost
            {
                ForumTopicId = Dto.ForumTopicId,
                UserId = userId,
                Date = DateTime.Now,
                Content = Dto.Content
            };

            _repo.Add(Item);

            if (! await _repo.SaveAll())
                return BadRequest("Impossible de répondre à ce poste");

            var ItemTopic = await _repo.GetForumTopic(Dto.ForumTopicId);
            ItemTopic.Date = Item.Date;
            _repo.Update(ItemTopic);

            if (!await _repo.SaveAll())
                return BadRequest("Impossible de modifier la date du sujet");

            return Ok(Item);
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
