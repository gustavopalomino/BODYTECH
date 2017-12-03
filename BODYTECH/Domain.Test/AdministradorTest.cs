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
    public class AdministradorTest
    {
        Administrador administrador;
        [SetUp]
        public void Initialize()
        {
            administrador = new Administrador();
        }

        //Administrador

        [Test]
        public void Administrador_Email_Incorrecto()
        {
            Administrador entity = new Administrador()
            {
                email = "tom",
                profesion = "ingeniero en sistemas"

            };

            //Actuar
            string resultado = entity.ValidarAdministrador();

            //Afirmar
            Assert.AreEqual("El email debe tener entre 5 y 60 caracteres", resultado);
        }

        [Test]
        public void Administrador_Profesion_Incorrecto()
        {
            Administrador entity = new Administrador()
            {
                email = "tavo951073@gmail.com",
                profesion = "in"

            };

            //Actuar
            string resultado = entity.ValidarAdministrador();

            //Afirmar
            Assert.AreEqual("La profesion debe tener maximo 30 caracteres", resultado);
        }

        [Test]
        public void Administrador_Registro_correcto()
        {
            Administrador entity = new Administrador()
            {
                email = "tavo951073@gmail.com",
                profesion = "ingeniero en sistemas"

            };

            //Actuar
            string resultado = entity.ValidarAdministrador();

            //Afirmar
            Assert.AreEqual("Administrador registrado exitosamente!", resultado);
        }

    }
}
