using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Context:DbContext {

        public Context(DbContextOptions<Context> options): base(options)
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Credenciales> Credenciales { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Actividades> Actividades { get; set; }


    }
}
