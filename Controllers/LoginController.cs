using Backend.Auth;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Backend.Controllers
{
     [ApiController]
    [Route("[controller]")]
    public class LoginController: ControllerBase
    {
        private readonly IJWTAuthManager jWTAuthManager;
        private readonly Context context;

        public LoginController(IJWTAuthManager jWTAuthManager, Context context)
        {
            this.jWTAuthManager = jWTAuthManager;
            this.context = context;
        }


        [HttpPost("autenticar")]
        public IActionResult Authenticate([FromBody] Credenciales userCred)
        {
            var authResponse = jWTAuthManager.Authenticate(userCred.email, userCred.contrasenia, context);
            if (authResponse == null) return BadRequest("No existe");

            var correo = User.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
            var tipo = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();

            return Ok(authResponse);
        }


    }
}
