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
using NSwag.Annotations;
using PartagesWebBlazorFSCore3.Server.Data;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Auth;
using PartagesWebBlazorFSCore3.Shared.Dtos.Output.Auth.Login;
using PartagesWebBlazorFSCore3.Shared.Models;
using PartagesWebBlazorFSCore3.Shared.Helpers;

namespace PartagesWebBlazorFSCore3.Server.Controllers
{
    /// <summary>
    /// Authentification controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Auth", Description = "Authentification controller")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
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
        public AuthController(IAuthRepository repo, IMessageRepository repoMessage, IConfiguration config, IMapper mapper)
        {
            _config = config;
            _repo = repo;
            _repoMessage = repoMessage;
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
        public async Task<IActionResult> Register(UserForRegisterInputDto dto)
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
        [SwaggerResponse(HttpStatusCode.OK, typeof(void), Description = "Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Le champ « Nom d'utilisateur » est obligatoire.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Le champ « Mot de passe » est obligatoire.")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Pas autorisé à se connecter")]
        public async Task<IActionResult> Login(UserForLoginInputDto dto)
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
            LoginDto loginDto = new LoginDto
            {
                token = tokenHandler.WriteToken(token),
                user = _mapper.Map<UserForLoginDto>(userFromRepo),
                messagesUnread = await _repoMessage.GetCountMessagesUnread(userFromRepo.Id)
            };
            return Ok(loginDto);
        }

        /// <summary>
        /// Username available
        /// </summary>
        /// <param name="dto">Dto</param>
        [HttpPost("available")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Boolean), Description = "Ok")]
        public async Task<IActionResult> Available(UserForCheckIfAvailableDto dto)
        {
            Boolean swAvailable = await _repo.UserExists(dto.Username);
            return Ok(!swAvailable);
        }
    }
}
