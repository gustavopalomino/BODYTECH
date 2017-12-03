using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Cliente_Paquetes : Entity<int>
    {
        [Required]
        public DateTime FechaPago { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFinal { get; set; }

        [Display(Name = "Cliente")]
        public int CiudadId { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }

        [Display(Name = "Paquetes")]
        public int IdPaquetes { get; set; }

        [ForeignKey("IdPaquetes")]
        public virtual Paquetes Paquetes { get; set; }

        public string ValidarClientePaquete()
        {
            if (FechaInicio > FechaFinal)
            {
                return "La fecha final debe ser mayor a la fecha inicio";  
            }

            return "Registro correcto";

        }

        }
        }

