using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Business;

namespace Domain.Entities
{
    public class Dias : Entity<int>
    {
        [Required]
        [MaxLength(20)]
        public string Nombre_Dia { get; set; }
    }
}
