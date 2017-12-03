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
    public class Ejercicio : Entity<int>
    {
        [Required]
        [MaxLength(40)]
        public string Nombre { get; set; }

        public string ValidarEjercicio()
        {
            if (Nombre.Length < 3 || Nombre.Length > 40)
            {
                return "El nombre del ejercicio debe tener minimo 3 y maximo 40 caracteres";
            }

            return "Ejercicio registrado exitosamente!";
        }
    }

}
