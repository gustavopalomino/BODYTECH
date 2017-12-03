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
    public class Rutinas : Entity<int>
    {

        [Required]
        [MaxLength(40)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(40)]
        public string Tipo { get; set; }

        [Display(Name = "Entrenador")]
        public int IdEntrenador { get; set; }

        [ForeignKey("IdEntrenador")]
        public virtual Entrenador Entrenador { get; set; }

        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }

        public string ValidateRutina()
        {
            if (Nombre.Length < 3 || Nombre.Length > 40)
            {
                return "El nombre de la rutina debe tener minimo 3 caracteres y maximo 40";
            }

            return "Rutina registrada correctamente!";
        }
    }
}
