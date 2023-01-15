using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class LoginResponse
    {

        public enum TipoUsuario
        {
            Usuario,
            Cliente,
            Owner
        }
        public string email { get; set; }
        public TipoUsuario tipo { get; set; }
        public string token { get; set; }
        public string nombre { get; set; }
        public int id { get; set; }
    }
}
