using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSwag.Annotations;
using PartagesWebBlazorFSCore3.Server.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartagesWebBlazorFSCore3.Server.Controllers
{
    /// <summary>
    /// Message controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Auth", Description = "Authentification controller")]
    public class MessageController : Controller
    {
        private readonly IMessageRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        /// <summary>  
        /// Constructor
        /// </summary> 
        /// <param name="repo">Private message repository</param>
        /// <param name="config">Configuration</param>
        /// <param name="mapper">Automapp</param>
        public MessageController(IMessageRepository repo, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
        }

    }
}
