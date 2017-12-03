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
        public int IdRutina { get; set; }

        [ForeignKey("IdRutina")]
        public virtual Rutinas Rutinas { get; set; }

        [Display(Name = "Ejercicio")]
        public int IdEjercicio { get; set; }

        [ForeignKey("IdEjercicio")]
        public virtual Ejercicio Ejercicio { get; set; }

        public string ValidarRutinaEjercicio ()
        {

            if (Series < 1)
            {
                return "Las series no pueden ser igual a cero o negativas";
            }

            if (Repeticiones < 1)
            {
                return "Las repeticiones no pueden ser igual a cero o negativas";
            }

            return "Registrado correctamente";
        }


    }
}
