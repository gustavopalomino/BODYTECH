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
    public class Cliente : Person
    {
        [MaxLength(40)]
        public string email { get; set; }

        [Required]
        [MaxLength(40)]
        public string discapacidad { get; set; }

        [MaxLength(40)]
        public double Estatura { get; set; }

        [Required]
        [MaxLength(40)]
        public double Peso { get; set; }

        public string ValidarCliente(IClienteBusiness strategy)
        {
            return strategy.ValidarCliente(this);
        }
    }
}
