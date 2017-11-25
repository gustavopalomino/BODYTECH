using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Business
{
    public interface IPersonBusiness {
        string ValidatePerson(Person entity);
    }
    public class PersonBusiness
    {
        public string ValidatePerson(Person entity)
        {
            if (entity.NumeroIdentificacion.Length < 8 || entity.NumeroIdentificacion.Length > 10)
            {
                return "El numero de documento debe tener entre 8 y 10 caracteres";
            }

            if (entity.Nombres.Length < 3 || entity.Nombres.Length > 50)
            {
                return "El nombre debe tener minimo 3 caracteres y maximo 50";
            }
            
            if(entity.Celular.Length < 7 || entity.Celular.Length > 10)
            {
                return "El celular debe tener minimo 7 caracteres y maximo 10";
            }
            
            if (entity.Direccion.Length < 10 || entity.Direccion.Length > 50)
            {
                return "La direccion debe tener minimo 10 caracteres y maximo 50";
            }

            if (entity.Sexo.Length < 5 || entity.Sexo.Length > 15)
            {

                return "El sexo debe tener minimo 5 caracteres y maximo 15";
            }
            if (entity.Altura < 50 || entity.Altura > 300)
            {
                return "La altura minima es 50 Cm y maximo 300 Cm";

            }

            

            return "Persona registrada exitosamente!";
        }


        //public string SoloNumero(Person entity)
        //{

        //    bool EsEntero = decimal.TryParse(Console.ReadLine(), out entity.Altura);

        //    if (!EsEntero)
        //    {

        //    }

        //}


    }
}
