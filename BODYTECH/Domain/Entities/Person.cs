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
    public class Person : Entity<int>
    {
        [Key]
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

        public string ValidarPersona(IPersonaBusiness strategy)
        {
            return strategy.ValidarPersona(this);
        }
    }


}
