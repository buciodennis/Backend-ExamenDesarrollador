using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Clientes
    {
        [Key]
        public int idClientes { get; set; }

        [Column(TypeName="nvarchar(35)")]
        public string nombre { get; set; }
        public int idUbicacion { get; set; }
        public virtual  Ubicacion ubicacion { get; set; }

        public bool eliminado { get; set; }
    }
}
