using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class AgregarCredencialRequest
    {
        public string email { get; set; }
        public string contrasenia { get; set; }
        public string tipo { get; set; }
        public int idUsuario { get; set; }
        public int idCliente { get; set; }
    }
}
