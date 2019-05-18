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
using PartagesWebBlazorFSCore3.Server.Helpers.PagedParams;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumCategorie.ForList;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumCategorie.ForSingleSelect;

namespace PartagesWebBlazorFSCore3.Server.Controllers
{
    /// <summary>
    /// ForumCategorie controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("ForumCategorie", Description = "ForumCategorie controller")]
    public class ForumCategorieController : Controller
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
        public ForumCategorieController(IForumRepository repo, IMapper mapper, IConfiguration config)
        {
            _config = config;
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>  
        /// Get ForumCategories
        /// </summary> 
        /// <remarks>No paged</remarks>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ForumCategorieForListDto[]), Description = "Ok")]
        public async Task<IActionResult> GetForumCategories()
        {
            var items = await _repo.GetForumCategories();
            List<ForumCategorieForListDto> newDto = new List<ForumCategorieForListDto>();
            foreach (var unite in items)
            {
                ForumCategorieForListDto Dto = new ForumCategorieForListDto
                {
                    Id = unite.Id,
                    Name = unite.Nom
                };
                Dto.CountForumTopic = await _repo.GetCountForumTopic(unite.Id);
                Dto.CountForumPost = await _repo.GetCountForumPostFromForumCategorie(unite.Id);
                var lastForumPost = await _repo.GetLastForumPosteFromForumCategorie(unite.Id);
                Dto.LastForumPost = _mapper.Map<ForumPostForListForumCategorieDto>(lastForumPost);
                if (lastForumPost != null)
                {
                    Dto.CountLastForumPost = await _repo.GetCountLastForumPostFromAForumTopic(lastForumPost.ForumTopicId);
                    var pageSize = new ForumPostParams();
                    double calc = Dto.CountLastForumPost / pageSize.PageSize;
                    Dto.PageLastForumPost = Convert.ToInt32(Math.Ceiling(calc)) + 1;
                }
                else
                {
                    Dto.CountLastForumPost = 0;
                    Dto.PageLastForumPost = 0;
                }

                newDto.Add(Dto);
            }
            return Ok(newDto);
        }

        /// <summary>  
        /// Get ForumCategorie
        /// </summary> 
        [HttpGet("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ForumCategorieForSingleSelectDto[]), Description = "Ok")]
        public async Task<IActionResult> GetForumCategorie(int id)
        {
            var item = await _repo.GetForumCategorie(id);
            var itemDto = _mapper.Map<ForumCategorieForSingleSelectDto>(item);
            return Ok(itemDto);
        }
    }
}

