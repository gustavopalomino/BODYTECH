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
    public class Cliente : Personas
    {
        [MaxLength(40)]
        public string email { get; set; }

        [Required]
        [MaxLength(40)]
        public string discapacidad { get; set; }

        [Required]
        public double Estatura { get; set; }

        [Required]
        public double Peso { get; set; }

        public string ValidarCliente()
        {
            if (Estatura < 1 || Estatura > 3)
            {
                return "La estatura de un cliente debe estar entre 1 y 3 metros";
            }

            if (Peso < 0)
            {
                return "El peso de un cliente no puede ser negativo";
            }
            return "Cliente registrado exitosamente!";
        }
    }
}
