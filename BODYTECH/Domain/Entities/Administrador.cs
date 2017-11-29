using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Administrador : Person
    {
        [Required]
        [MaxLength(40)]
        public string email { get; set; }

        [Required]
        [MaxLength(30)]
        public string profesion { get; set; }
    }
}
