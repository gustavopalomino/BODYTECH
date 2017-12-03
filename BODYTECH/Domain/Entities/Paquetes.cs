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
        [MaxLength(30)]
        public string Nombre { get; set; }

        [Required]
        public int Dias { get; set; }

        [MaxLength(100)]
        public string Descripcion { get; set; }

        [Required]
        public int Precio { get; set; }

        public string ValidarPaquetes()
        {
            if (Nombre.Length < 3 || Nombre.Length > 30)
            {
                return "El nombre del paquete debe tener entre 3 y 30 caracteres";
            }
            if(Dias < 1)
            {
                return "Los dias no pueden ser 0 o negativos";
            }
            if (Descripcion.Length < 3 || Descripcion.Length > 100)
            {
                return "La descripcion debe tener entre 3 y 100 caracteres";
            }
            if (Precio < 0)
            {
                return "El precio de los paquetes no puede ser negativo";
            }
            return "Paquete registrado correctamente!";
        }
    }

}
