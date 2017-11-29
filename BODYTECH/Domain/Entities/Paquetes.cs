using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Paquetes : Entity<int>
    {
        [Required]
        [MaxLength(2)]
        public string Nombre { get; set; }

        [Required]
        public int Dias { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
