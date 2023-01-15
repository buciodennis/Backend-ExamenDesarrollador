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
    public class UsuariosController : ControllerBase
    {

        private readonly Context _context;

        public UsuariosController(Context context)
        {
            _context = context;
        }


        [HttpGet("obtenerUsuarios")]
        public IActionResult GetUsuarios()
        {
            var usuarios = from cred in _context.Credenciales
                           join us in _context.Usuarios
                           on cred.idUsuario equals us.idUsuario
                           where us.eliminado!=true
                           && us.owner==false
                           select new { us.idUsuario, us.nombre, cred.email };
            return Ok(usuarios);

        }

        [HttpGet("obtenerUsuario{id}")]
        public IActionResult GetUsuario(int id)
        {
            var usuarios = from cred in _context.Credenciales
                           join us in _context.Usuarios
                           on cred.idUsuario equals us.idUsuario
                           where us.idUsuario==id
                           select new { us.idUsuario, us.nombre, cred.email };
                           
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }


       

        [HttpPost("agregarUsuario")]
        public IActionResult PostUsuario([FromBody] Usuarios value)
        {
            var nuevoUsuario = new Usuarios
            {
                nombre = value.nombre,
                eliminado= false,
                owner = false
            };
            _context.Add(nuevoUsuario);
            _context.SaveChanges();
            return Ok(nuevoUsuario.idUsuario);
        }

        [HttpPut("modificarUsuario")]
        public IActionResult PutUsuario([FromBody] Usuarios us)
        {
            var usuarioActualizar = new Usuarios
            {
                idUsuario = us.idUsuario,
                nombre = us.nombre,
                eliminado = false,
                owner =false
            };
            _context.Update(usuarioActualizar);
            _context.SaveChanges();


            return Ok("Usuario actualizado correctamente");
        }

        [HttpPut("eliminarUsuario")]
        public IActionResult DeleteUsuario([FromBody] Usuarios value)
        {
            var usuarioActualizar = new Usuarios
            {
                idUsuario = value.idUsuario,
                nombre= value.nombre,
                eliminado = true,
                owner = false
            };
            _context.Update(usuarioActualizar);
            _context.SaveChanges();
            return Ok("Usuario actualizado correctamente");
        }
    }
}
