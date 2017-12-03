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

        public string ValidateDias()
        {
            if (Nombre_Dia.Length < 3 || Nombre_Dia.Length > 20)
            {
                return "El nombre del dia debe tener minimo 3 caracteres y maximo 20!";
            }

            return "Dia Regitrado correctamente!";
        }
    }
}
