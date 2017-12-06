using Domain.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //[Table("Person")]
    public class Personas : Entity<int>
    {
        //[Key]
        [Required] 
        [MaxLength(10)]
        public string NumeroIdentificacion { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(9)]
        public string Sexo { get; set; }


        [Required]
        [MaxLength(10)]
        public string Telefono { get; set; }


        [MaxLength(40)]
        public string Direccion { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public string ValidarPersona()
        {
            if (NumeroIdentificacion.Length < 8 || NumeroIdentificacion.Length > 10)
            {
                return "El numero de documento debe tener entre 8 y 10 caracteres";
            }

            if (Nombres.Length < 3 || Nombres.Length > 50)
            {
                return "El nombre debe tener minimo 3 caracteres y maximo 50";
            }

            if (Telefono.Length < 7 || Telefono.Length > 10)
            {
                return "El telefono debe tener minimo 7 caracteres y maximo 10";
            }

            if (Direccion.Length < 10 || Direccion.Length > 50)
            {
                return "La direccion debe tener minimo 10 caracteres y maximo 50";
            }

            if (Sexo.Length < 5 || Sexo.Length > 15)
            {

                return "El sexo debe tener minimo 5 caracteres y maximo 15";
            }
            return "Persona registrada exitosamente!";
        }
    }


}
