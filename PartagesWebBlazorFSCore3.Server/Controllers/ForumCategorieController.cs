﻿//-----------------------------------------------------------------------
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
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Forum.ForumCategorie.ForSelect;

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
                ForumCategorieForListDto dto = new ForumCategorieForListDto
                {
                    Id = unite.Id,
                    Name = unite.Name
                };
                dto.CountForumTopic = await _repo.GetCountForumTopic(unite.Id);
                dto.CountForumPost = await _repo.GetCountForumPostFromForumCategorie(unite.Id);
                var lastForumPost = await _repo.GetLastForumPostFromForumCategorie(unite.Id);
                dto.LastForumPost = _mapper.Map<ForumPostForListForumCategorieDto>(lastForumPost);
                if (lastForumPost != null)
                {
                    var countLastForumPost = await _repo.GetCountLastForumPostFromAForumTopic(lastForumPost.ForumTopicId);
                    var pageSize = new ForumPostParams();
                    double calc = (countLastForumPost + pageSize.PageSize - 1) / pageSize.PageSize;
                    dto.PageLastForumPost = Convert.ToInt32(Math.Ceiling(calc));
                }
                else
                {
                    dto.PageLastForumPost = 0;
                }

                newDto.Add(dto);
            }
            return Ok(newDto);
        }

        /// <summary>  
        /// Get ForumCategorie
        /// </summary> 
        [HttpGet("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ForumCategorieForSelectDto[]), Description = "Ok")]
        public async Task<IActionResult> GetForumCategorie(int id)
        {
            var item = await _repo.GetForumCategorie(id);
            var itemDto = _mapper.Map<ForumCategorieForSelectDto>(item);
            return Ok(itemDto);
        }
    }
}

