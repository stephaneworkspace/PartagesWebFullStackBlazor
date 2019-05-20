//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using NSwag.Annotations;
using PartagesWebBlazorFSCore3.Server.Data;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.User;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.User.LoginReturn;
using PartagesWebBlazorFSCore3.Shared.Models;
using PartagesWebBlazorFSCore3.Shared.Helpers;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.User.ForSelect;

namespace PartagesWebBlazorFSCore3.Server.Controllers
{
    /// <summary>
    /// Authentification controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("User", Description = "User controller (authentification)")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMessageRepository _repoMessage;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        /// <summary>  
        /// Constructor
        /// </summary> 
        /// <param name="repo">Auth repository</param>
        /// <param name="repoMessage">Private message repository</param>
        /// <param name="config"> Configuration</param>
        /// <param name="mapper">Automapp</param>
        public UserController(IUserRepository repo, IMessageRepository repoMessage, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _repoMessage = repoMessage;
            _config = config;
            _mapper = mapper;
        }

        /// <summary>  
        /// Register
        /// </summary> 
        /// <param name="userForRegisterDto">Dto</param>
        [HttpPost("register")]
        [SwaggerResponse(HttpStatusCode.Created, typeof(void), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "L'utilisateur « {dto.Username.CapitalizeFirst()} » existe déjà")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Le champ « Nom d'utilisateur » est obligatoire.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Vous devez spécifier un nom d'utilisateur entre 2 et 30 caractères")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Le champ « Mot de passe » est obligatoire.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Vous devez spécifier un mot de passe entre 4 et 8 caractères")]
        public async Task<IActionResult> Register(UserForRegisterDto dto)
        {
            dto.Username = dto.Username.ToLower();
            if (await _repo.UserExists(dto.Username))
                return BadRequest($"L'utilisateur « {dto.Username.CapitalizeFirst()} » existe déjà");
            var userToCreate = new User
            {
                Username = dto.Username
            };
            _ = await _repo.Register(userToCreate, dto.Password);
            return StatusCode(201);
        }

        /// <summary>  
        /// Login
        /// </summary> 
        /// <param name="dto">Dto</param>
        [HttpPost("login")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(LoginReturnDto), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Le champ « Nom d'utilisateur » est obligatoire.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Le champ « Mot de passe » est obligatoire.")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Pas autorisé à se connecter")]
        public async Task<IActionResult> Login(UserForLoginDto dto)
        {
            var userFromRepo = await _repo.Login(dto.Username.ToLower(), dto.Password);
            if (userFromRepo == null)
                return Unauthorized("Pas autorisé à se connecter");
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginReturnDto loginDto = new LoginReturnDto
            {
                Token = tokenHandler.WriteToken(token),
                User = _mapper.Map<UserForLoginReturnDto>(userFromRepo),
                MessagesUnread = await _repoMessage.GetCountMessagesUnread(userFromRepo.Id)
            };
            return Ok(loginDto);
        }

        /// <summary>
        /// Username available
        /// </summary>
        /// <param name="dto">Dto</param>
        [HttpPost("available")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Boolean), Description = "Ok")]
        public async Task<IActionResult> Available(UserForRegisterAvailableDto dto)
        {
            Boolean swAvailable = await _repo.UserExists(dto.Username);
            return Ok(!swAvailable);
        }

        /// <summary>
        /// Get user info for post a message
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(UserForSelectDto), Description = "Ok")]
        public async Task<IActionResult> GetUser(int id)
        {
            User item = await _repo.GetUser(id);
            return Ok(_mapper.Map<UserForSelectDto>(item));
         }
    }
}
