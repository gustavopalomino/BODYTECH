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
        [Required]
        [MaxLength(10)]
        public string NumeroIdentificacion { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(20)]
        public string Celular { get; set; }

        [Required]
        [MaxLength(100)]
        public string Direccion { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public string ValidatePerson(IPersonBusiness strategy)
        {
            return strategy.ValidatePerson(this);
        }
    }


}
