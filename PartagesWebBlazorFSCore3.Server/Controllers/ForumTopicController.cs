//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSwag.Annotations;
using PartagesWebBlazorFSCore3.Server.Data;
using PartagesWebBlazorFSCore3.Server.Dtos.Forum.ForumTopic.Output.ForList;
using PartagesWebBlazorFSCore3.Server.Helpers;
using PartagesWebBlazorFSCore3.Server.Helpers.PagedParams;

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
        [SwaggerResponse(HttpStatusCode.OK, typeof(ForumTopicForListDto[]), Description = "Liste des sujets")]
        public async Task<IActionResult> GetForumSujets([FromQuery] ForumTopicParams forumTopicParams, int id)
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
    }
}
