using Backend.Auth;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CredencialesController: ControllerBase
    {

        private readonly Context _context;

        public CredencialesController(Context context)
        {
            _context = context;
        }


        [HttpGet("obtenerCredenciales")]
        public IActionResult GetIdCredenciales()
        {
            var credenciales = from cred in _context.Credenciales
                             select new { cred.email };

            if (credenciales == null)
            {
                return NotFound();
            }

            return Ok(credenciales);
        }

        [HttpGet("obtenerIdCredencial{idUsuario}")]
        public IActionResult GetIdCredencial(int idUsuario)
        {
            var credencial = from cred in _context.Credenciales
                             where cred.idUsuario.Equals(idUsuario)
                             select new { cred.idCredencial } ;

            if (credencial == null)
            {
                return NotFound();
            }

            return Ok(credencial);
        }

        [HttpGet("obtenerIdClienteCredencial{idCliente}")]
        public IActionResult GetIdClienteCredencial(int idCliente)
        {
            var credencial = from cred in _context.Credenciales
                             where cred.idCliente.Equals(idCliente)
                             select new { cred.idCredencial };

            if (credencial == null)
            {
                return NotFound();
            }

            return Ok(credencial);
        }



        [HttpGet("obtenerCredencial{email}")]
        public IActionResult GetCredencial(string email)
        {
            var credencial = from cred in _context.Credenciales
                             where cred.email.Equals(email)
                             select new { cred.email, cred.contrasenia, cred.tipo };

            if (credencial == null)
            {
                return NotFound();
            }

            return Ok(credencial);
        }

        [HttpPost("agregarCredencial")]
        public IActionResult PostCredencial([FromBody] Credenciales value)
        {
            
            var nuevaCredencial = new Credenciales
            {
                email = value.email,
                contrasenia = JWTAuthManager.getStringHash(value.contrasenia).ToLower(),
                eliminado=false,
                tipo= value.tipo,
                idUsuario=value.idUsuario,
                idCliente= value.idCliente,
            };
            _context.Add(nuevaCredencial);
            _context.SaveChanges();
            
            return Ok("Credencial agregada correctamente");
        }

        [HttpPut("modificarCredencial")]
        public IActionResult PutCredencial([FromBody] Credenciales value)
        {
            var credencialActualizar = new Credenciales
            {
                idCredencial=value.idCredencial,
                email = value.email,
                contrasenia = JWTAuthManager.getStringHash(value.contrasenia).ToLower(),
                eliminado = false,
                tipo = value.tipo,
                idUsuario = value.idUsuario,
                idCliente = value.idCliente
            };
            _context.Update(credencialActualizar);
            _context.SaveChanges();


            return Ok("Credencial actualizada correctamente");
        }

        [HttpPut("eliminarCredencial")]
        public IActionResult DeleteCredncial([FromBody] Credenciales value)
        {
            var credencialActualizar = new Credenciales
            {
                idCredencial = value.idCredencial,
                email = value.email,
                contrasenia = value.contrasenia,
                eliminado = true,
                tipo = value.tipo,
                idUsuario = value.idUsuario,
                idCliente = value.idCliente
            };
            _context.Update(credencialActualizar);
            _context.SaveChanges();
            return Ok("Usuario actualizado correctamente");
        }


    }
}
