using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Business
{
    public interface IClienteBusiness
    {
        string ValidarCliente(Cliente entity);
    }
    public class ClienteBusiness
    {
        public string ValidarCliente(Cliente entity)
        {
            if (entity.Estatura < 1 || entity.Estatura > 3)
            {
                return "La estatura de un cliente debe estar entre 1 y 3 metros";
            }

            if (entity.Peso < 0)
            {
                return "El peso de un cliente no puede ser negativo";
            }
            return "Cliente registrado exitosamente!";
        }
    }
}
