using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{
    public class Entrenador : Person
    {
        //[Display(Name = "Id Persona")]
        //public int Numero_Identificacion { get; set; }

        //[ForeignKey("IdPersona")]
        //public virtual Persona Persona { get; set; }
        public int AniosExperiencia { get; set; }

        [Required]
        [MaxLength(2)]
        public string Certificado { get; set; }

        [Required]
        [MaxLength(30)]
        public string AreaTrabajo { get; set; }

    }
}
