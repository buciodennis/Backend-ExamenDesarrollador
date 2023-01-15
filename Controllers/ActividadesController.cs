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
    public class ActividadesController : ControllerBase
    {
        private readonly Context _context;

        public ActividadesController(Context context)
        {
            _context = context;
        }


        [HttpGet("obtenerActividades{idUsuario}")]
        public IActionResult GetActividades(int idUsuario)
        {
            var actividades = from act in _context.Actividades
                          where act.idUsuario==idUsuario && act.eliminado==false
                           select new { act.idActividad, act.actividad, act.descripcion, act.idUsuario };
            return Ok(actividades);

        }

        [HttpPost("agregarActividades")]
        public IActionResult PostActividades([FromBody] Actividades value)
        {
            var nuevaActividad = new Actividades
            {
                actividad = value.actividad,
                descripcion = value.descripcion,
                eliminado=value.eliminado,
                idUsuario= value.idUsuario
            };
            _context.Add(nuevaActividad);
            _context.SaveChanges();
            return Ok(nuevaActividad.idActividad);
        }

        [HttpPut("eliminarActividad")]
        public IActionResult PuAtividad([FromBody] Actividades value)
        {
            var actividadActualizar = new Actividades
            {
                idActividad= value.idActividad,
                actividad = value.actividad,
                descripcion = value.descripcion,
                eliminado= true,
                idUsuario = value.idUsuario
            };
            _context.Update(actividadActualizar);
            _context.SaveChanges();
            return Ok(actividadActualizar.idActividad);
        }
    }
}
