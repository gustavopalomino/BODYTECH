using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Business;
using NUnit.Framework;
namespace Domain.Test
{
    [TestFixture]
    public class ClienteTest
    {
        Cliente cliente;
        [SetUp]
        public void Initialize()
        {
            cliente = new Cliente();
        }

        //Cliente

        [Test]
        public void Cliente_Estatura_Incorrecta()
        {
            Cliente entity = new Cliente()
            {
                Estatura = 40

            };

            //Actuar
            string resultado = entity.ValidarCliente();

            //Afirmar
            Assert.AreEqual("La estatura de un cliente debe estar entre 1 y 3 metros", resultado);
        }

        [Test]
        public void Cliente_Peso_Incorrecta()
        {
            Cliente entity = new Cliente()
            {
                Estatura = 1.7,
                Peso = -1

            };

            //Actuar
            string resultado = entity.ValidarCliente();

            //Afirmar
            Assert.AreEqual("El peso de un cliente no puede ser negativo", resultado);
        }

        [Test]
        public void Cliente_Registro_Correcto()
        {
            Cliente entity = new Cliente()
            {
                Estatura = 1.7,
                Peso = 60

            };

            //Actuar
            string resultado = entity.ValidarCliente();

            //Afirmar
            Assert.AreEqual("Cliente registrado exitosamente!", resultado);
        }
    }
}
