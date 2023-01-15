using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Credenciales
    {

        public enum TipoUsuario
        {
            Usuario,
            Cliente,
            Owner
        }


        [Key]
        public int idCredencial { get; set; }

        [Column(TypeName="nvarchar(40)")]
        public string email { get; set; }

        [Column(TypeName = "nvarchar(70)")]
        public string contrasenia { get; set; }
        public bool eliminado { get; set; }

        public TipoUsuario tipo { get; set; }

        public int idUsuario { get; set; }
        public int idCliente { get; set; }


        public virtual Usuarios usuario { get; set; }

        public virtual Clientes cliente { get; set; }

    }
}
