using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Domain.Business
{
    public interface IEjercicioBusiness
    {
        string ValidarEjercicio(Ejercicio entity);
    }
    public class EjercicioBusiness
    {
        public string ValidarEjercicio(Ejercicio entity)
        {
            if (entity.Nombre.Length < 3 || entity.Nombre.Length > 40)
            {
                return "El nombre del ejercicio debe tener minimo 3 y maximo 40 caracteres";
            }

            return "Ejercicio registrado exitosamente!";
        }
    }
}
