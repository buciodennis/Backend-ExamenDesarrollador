using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Usuarios
    {
        [Key]
        public int idUsuario { get; set; }

        [Column(TypeName="nvarchar(35)")]
        public string nombre { get; set; }

        public bool eliminado { get; set; }

        public bool owner { get; set; }


    }
}
