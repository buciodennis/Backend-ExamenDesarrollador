using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactoController : ControllerBase
    {

        private readonly Context _context;

        public ContactoController(Context context)
        {
            _context = context;
        }



        [HttpGet("obtenerUContactos{idUbicacion}")]
        public IActionResult GetContactos(int idUbicacion)
        {
            var ubicaciones = from c in _context.Contactos
                              join u in _context.Ubicaciones
                              on c.idUbicacion equals u.idUbicacion
                              where u.idUbicacion == idUbicacion
                              && u.eliminado==false
                              select new { c.idContacto, c.nombre, c.telefono, c.email, c.sitio };

            if (ubicaciones == null)
            {
                return NotFound();
            }

            return Ok(ubicaciones);
        }



        [HttpPost("agregarContacto")]
        public IActionResult PostContacto([FromBody] Contacto value)
        {
            var nuevoContacto = new Contacto
            {
                email=value.email,
                telefono=value.telefono,
                sitio=value.sitio,
                idUbicacion= value.idUbicacion,
                eliminado=false

            };
            _context.Add(nuevoContacto);
            _context.SaveChanges();
            return Ok(nuevoContacto.idContacto);
        }


        [HttpPut("eliminarContacto")]
        public IActionResult PutContacto([FromBody] Contacto value)
        {
            var contactoEliminado = new Contacto
            {
                idContacto=value.idContacto,
                email = value.email,
                telefono = value.telefono,
                sitio = value.sitio,
                idUbicacion = value.idUbicacion, 
                eliminado=true

            };
            _context.Update(contactoEliminado);
            _context.SaveChanges();
            return Ok("contacto eliminado");
        }
    }
 }
