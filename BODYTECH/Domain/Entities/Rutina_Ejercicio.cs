using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Rutina_Ejercicio
    {
        [Required]
        public int Series { get; set; }

        [Required]
        public int Repeticiones { get; set; }

        [Display(Name = "Rutina")]
        public int IdEntrenador { get; set; }

        [ForeignKey("IdRutina")]
        public virtual Rutina Rutina { get; set; }

        [Display(Name = "Ejercicio")]
        public int IdEjercicio { get; set; }

        [ForeignKey("IdEjercicio")]
        public virtual Ejercicio Ejercicio { get; set; }
    }
}
