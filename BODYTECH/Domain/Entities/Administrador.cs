using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Administrador : Personas
    {
        [Required]
        [MaxLength(40)]
        public string email { get; set; }

        [Required]
        [MaxLength(30)]
        public string profesion { get; set; }

        public string ValidarAdministrador()
        {
            if (email.Length < 5 || email.Length > 40)
            {
                return "El email debe tener entre 5 y 60 caracteres";
            }

            if (profesion.Length < 3 || profesion.Length > 30)
            {
                return "La profesion debe tener maximo 30 caracteres";
            }
            return "Administrador registrado exitosamente!";
        }
    }
}
