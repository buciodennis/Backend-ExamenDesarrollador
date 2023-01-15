using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Contacto
    {
        [Key]
        public int idContacto { get; set; }

        [Column(TypeName = "nvarchar(35)")]
        public string nombre { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string telefono { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string email { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string sitio { get; set; }
        public int idUbicacion { get; set; }

        public bool eliminado { get; set; }

        public virtual Ubicacion Ubicacion { get; set; }

    }
}
