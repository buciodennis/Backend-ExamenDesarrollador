using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Ubicacion
    {
        [Key]
        public int idUbicacion { get; set; }

        [Column(TypeName="nvarchar(25)")]
        public string calle { get; set; }
        public int numero { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string colonia { get; set; }

        public int cp { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string ciudad { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string estado { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string pais { get; set; }

        public bool eliminado { get; set; }
    }
}
