using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Actividades
    {
        [Key]
        public int idActividad { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string actividad { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string descripcion { get; set; }
        public int idUsuario { get; set; }
        public bool eliminado { get; set; }

        public virtual Usuarios usuario { get; set; }



    }
}
