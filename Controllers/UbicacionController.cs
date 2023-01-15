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
    public class UbicacionController: ControllerBase 
    {
        private readonly Context _context;

        public UbicacionController(Context context)
        {
            _context = context;
        }

        [HttpPost("agregarUbicacion")]
        public IActionResult PostUbicacion([FromBody] Ubicacion value)
        {
            var nuevaUbicacion = new Ubicacion
            {
               
                calle= value.calle,
                numero= value.numero,
                colonia= value.colonia,
                cp= value.cp,
                ciudad= value.ciudad,
                estado= value.estado,
                pais= value.pais

            };
            _context.Add(nuevaUbicacion);
            _context.SaveChanges();
            return Ok(nuevaUbicacion.idUbicacion);
        }

        [HttpPut("modificarUbicacion")]
        public IActionResult PutUbicacion([FromBody] Ubicacion value)
        {
            var clienteActualizar = new Ubicacion
            {
                idUbicacion= value.idUbicacion,
                calle = value.calle,
                numero = value.numero,
                colonia = value.colonia,
                cp = value.cp,
                ciudad = value.ciudad,
                estado = value.estado,
                pais = value.pais
            };
            _context.Update(clienteActualizar);
            _context.SaveChanges();

            return Ok("Ubicacion actualizado correctamente");
        }
        
        
    }
}
