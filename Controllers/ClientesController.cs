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
    public class ClientesController: ControllerBase
    { 


         private readonly Context _context;

    public ClientesController(Context context)
    {
        _context = context;
    }


    [HttpGet("obtenerClientes")]
    public IActionResult GetClientes()
    {
        var clientes = from cred in _context.Credenciales
                       join c in _context.Clientes
                       on cred.idCliente equals c.idClientes
                       join u in _context.Ubicaciones
                       on c.idUbicacion equals u.idUbicacion
                       where c.eliminado!=true
                       select new { c.idClientes, c.nombre, cred.email, u.idUbicacion, u.calle, u.numero, u.colonia, u.cp, u.ciudad, u.estado, u.pais };
        return Ok(clientes);

    }

    [HttpGet("obtenerCliente{id}")]
    public IActionResult GetCliente(int id)
    {
            var clientes = from cred in _context.Credenciales
                           join c in _context.Clientes
                           on cred.idCliente equals c.idClientes
                           join u in _context.Ubicaciones
                           on c.idUbicacion equals u.idUbicacion
                           where c.idClientes.Equals(id)
                           select new { c.idClientes, c.nombre, cred.email, u.idUbicacion, u.calle, u.numero, u.colonia, u.cp, u.ciudad, u.estado, u.pais };


            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(clientes);
        }



        [HttpGet("obtenerUbicacion{idCliente}")]
        public IActionResult getUbicacion(int idCliente)
        {
            var ubicacion = from c in _context.Clientes
                            where c.idClientes.Equals(idCliente)
                            select new { c.idUbicacion };

            if (ubicacion == null)
            {
                return NotFound();
            }

            return Ok(ubicacion);
        }


        [HttpPost("agregarCliente")]
    public IActionResult PostCliente([FromBody] Clientes value)
    {
        var nuevoCliente = new Clientes
        {
            nombre = value.nombre,
            idUbicacion = value.idUbicacion,
            eliminado = value.eliminado

        };
        _context.Add(nuevoCliente);
        _context.SaveChanges();
        return Ok(nuevoCliente.idClientes);
    }

    [HttpPut("modificarCliente")]
    public IActionResult PutCliente([FromBody] Clientes value)
    {
        var clienteActualizar = new Clientes
        {
            idClientes = value.idClientes,
            nombre = value.nombre,
            idUbicacion = value.idUbicacion,
            eliminado = false
        };
        _context.Update(clienteActualizar);
        _context.SaveChanges();

       

        return Ok("Cliente actualizado correctamente");
    }

    [HttpPut("eliminarCliente")]
    public IActionResult DeleteUsuario([FromBody] Clientes value)
    {
        var clienteEliminar = new Clientes
        {
            idClientes = value.idClientes,
            nombre = value.nombre,
            idUbicacion = value.idUbicacion,
            eliminado = true
        };
        _context.Update(clienteEliminar);
        _context.SaveChanges();
        return Ok("Cliente actualizado correctamente");
    }


}
}
