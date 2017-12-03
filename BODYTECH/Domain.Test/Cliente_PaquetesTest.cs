using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using NUnit.Framework;

namespace Domain.Test
{
    class Cliente_PaquetesTest
    {
        Cliente_Paquetes cliente_paquetes;
        [SetUp]
        public void Initialize()
        {
            cliente_paquetes = new Cliente_Paquetes();
        }

        [Test]
        public void Cliente_Paquetes_Fechas_Incorrecto()
        {
            Cliente_Paquetes entity = new Cliente_Paquetes()
            {
                FechaPago = Convert.ToDateTime("12 / 11 / 2017"),
                FechaInicio = Convert.ToDateTime("12 / 11 / 2017"),
                FechaFinal = Convert.ToDateTime("11 / 11 / 2017")
            };

            //Actuar
            string resultado = entity.ValidarClientePaquete();

            //Afirmar
            Assert.AreEqual("La fecha final debe ser mayor a la fecha inicio", resultado);
        }

        [Test]
        public void Cliente_Paquetes_correcto()
        {
            Cliente_Paquetes entity = new Cliente_Paquetes()
            {
                FechaPago =Convert.ToDateTime("12 / 11 / 2017"),
                FechaInicio = Convert.ToDateTime("12 / 11 / 2017"),
                FechaFinal = Convert.ToDateTime("12 / 12 / 2017")
            };

            //Actuar
            string resultado = entity.ValidarClientePaquete();

            //Afirmar
            Assert.AreEqual("Registro correcto", resultado);
        }
    }
}
