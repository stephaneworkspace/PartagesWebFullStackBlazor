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
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Forum.ForumTopic.ForNewTopic;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumTopic.ForList;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumTopic.ForSingleSelect;
using PartagesWebBlazorFSCore3.Shared.Models;

namespace PartagesWebBlazorFSCore3.Server.Controllers
{
    /// <summary>
    /// ForumTopic controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("ForumTopic", Description = "ForumTopic controller")]
    public class ForumTopicController : Controller
    {
        private readonly IForumRepository _repo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        /// <summary>  
        /// Constructor
        /// </summary>  
        /// <param name="repo">Repository Forum</param>
        /// <param name="mapper">AutoMapp</param>
        /// <param name="config">Configuration</param>
        public ForumTopicController(IForumRepository repo, IMapper mapper, IConfiguration config)
        {
            _config = config;
            _mapper = mapper;
            _repo = repo;
        }
        /// <summary>  
        /// Get paged list of ForumTopic
        /// </summary> 
        /// <param name="forumTopicParams">Pagination params</param>
        /// <param name="id">ForumCategorie primary key</param>
        [HttpGet("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ForumTopicForListDto[]), Description = "Ok")]
        public async Task<IActionResult> GetForumTopics([FromQuery] ForumTopicParams forumTopicParams, int id)
        {
            var items = await _repo.GetForumTopics(forumTopicParams, id);
            List<ForumTopicForListDto> newDto = new List<ForumTopicForListDto>();
            foreach (var unite in items)
            {
                ForumTopicForListDto Dto = new ForumTopicForListDto
                {
                    Id = unite.Id,
                    Name = unite.Name,
                    ForumCategorieId = unite.ForumCategorieId,
                    ForumCategorie = _mapper.Map<ForumCategorieForListForumTopicDto>(unite.ForumCategorie),
                    Date = unite.Date,
                    View = unite.View
                };
                Dto.CountForumPost = await _repo.GetCountLastForumPostFromAForumTopic(unite.Id);
                newDto.Add(Dto);
            }
            Response.AddPagination(items.CurrentPage, items.PageSize, items.TotalCount, items.TotalPages);
            return Ok(newDto);
        }
        /// <summary>  
        /// Get ForumTopic
        /// </summary> 
        /// <param name="id">ForumTopic primary key</param>
        [HttpGet("ForumTopicId/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ForumTopicForSelectDto), Description = "Ok")]
        public async Task<IActionResult> GetForumTopic(int id)
        {
            var item = await _repo.GetForumTopic(id);
            ForumTopicForSelectDto newDto = new ForumTopicForSelectDto();
            var itemDto = _mapper.Map<ForumTopicForSelectDto>(item);
            return Ok(itemDto);
        }
        /// <summary>
        /// New ForumTopic and ForumPost
        /// </summary>
        /// <param name="Dto">Dto Input</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ForumPost), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Impossible de créer le sujet")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "error.errors.Nom[0] == Le champ « Contenu » est obligatoire.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "error.errors.Nom[0] == Le champ « Nom du sujet » est obligatoire.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "error.errors.Nom[0] == Le champ « Catégorie du sujet » est obligatoire.")]
        public async Task<IActionResult> NouveauSujetEtPoste(ForumPostForNewForumTopicDto Dto)
        {
            // Prepare ForumTopic
            var ItemForumTopic = new ForumTopic
            {
                Date = DateTime.Now,
                ForumCategorieId = Dto.ForumCategorieId,
                Name = Dto.NameTopic,
                View = 0
            };

            _repo.Add(ItemForumTopic);

            if (!await _repo.SaveAll())
            {
                return BadRequest("Impossible de créer le sujet");
            }

            // Find current user
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // Prepare ForumPost
            var Item = new ForumPost
            {
                ForumTopicId = ItemForumTopic.Id,
                UserId = userId,
                Date = DateTime.Now,
                Content = Dto.Content
            };

            _repo.Add(Item);

            if (await _repo.SaveAll())
                return Ok(Item);

            return BadRequest("Impossible de créer le sujet");
        }
    }
}
