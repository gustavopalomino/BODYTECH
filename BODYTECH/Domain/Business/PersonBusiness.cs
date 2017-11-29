using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Business
{
    public interface IPersonaBusiness
    {
        string ValidarPersona(Person entity);
    }
    public class PersonaBusiness
    {
        public string ValidarPersona(Person entity)
        {
            if (entity.NumeroIdentificacion.Length < 8 || entity.NumeroIdentificacion.Length > 10)
            {
                return "El numero de documento debe tener entre 8 y 10 caracteres";
            }

            if (entity.Nombres.Length < 3 || entity.Nombres.Length > 50)
            {
                return "El nombre debe tener minimo 3 caracteres y maximo 50";
            }

            if (entity.Telefono.Length < 7 || entity.Telefono.Length > 10)
            {
                return "El telefono debe tener minimo 7 caracteres y maximo 10";
            }

            if (entity.Direccion.Length < 10 || entity.Direccion.Length > 50)
            {
                return "La direccion debe tener minimo 10 caracteres y maximo 50";
            }

            if (entity.Sexo.Length < 5 || entity.Sexo.Length > 15)
            {

                return "El sexo debe tener minimo 5 caracteres y maximo 15";
            }
            return "Persona registrada exitosamente!";
        }

    }
}
