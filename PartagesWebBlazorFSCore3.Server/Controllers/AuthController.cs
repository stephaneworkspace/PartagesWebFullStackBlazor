//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartagesWebBlazorFSCore3.Server.Controllers
{
    /// <summary>
    /// Authentification controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Auth", Description = "Authentification controller")]
    public class AuthController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
