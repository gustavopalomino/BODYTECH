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
    public class PersonTest
    {
        PersonaBusiness personaBusiness;
        [SetUp]
        public void Initialize()
        {
            personaBusiness = new PersonaBusiness();
        }

        //Persona

        [Test]
        public void Persona_NumeroDocumento_Incorrecto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "1234",
                Nombres = "Luis",
                Sexo = "Masculino",
                Telefono = "3193675413",
                Direccion = "Calle 13D # 11-55"

            };

            //Actuar
            string resultado = personaBusiness.ValidarPersona(entity);

            //Afirmar
            Assert.AreEqual("El numero de documento debe tener entre 8 y 10 caracteres", resultado);
        }

        [Test]
        public void Persona_Nombres_Incorrecto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "123456789",
                Nombres = "Lu",
                Sexo = "Masculino",
                Telefono = "3193675413",
                Direccion = "Calle 13D # 11-55"

            };

            //Actuar
            string resultado = personaBusiness.ValidarPersona(entity);

            //Afirmar
            Assert.AreEqual("El nombre debe tener minimo 3 caracteres y maximo 50", resultado);
        }

        [Test]
        public void Persona_Telefono_Incorrecto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "123456789",
                Nombres = "Luis Martinez",
                Sexo = "Masculino",
                Telefono = "31933",
                Direccion = "Calle 13D # 11-55"

            };

            //Actuar
            string resultado = personaBusiness.ValidarPersona(entity);

            //Afirmar
            Assert.AreEqual("El telefono debe tener minimo 7 caracteres y maximo 10", resultado);
        }

        [Test]
        public void Persona_Direccion_Incorrecto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "123456789",
                Nombres = "Luis Martinez",
                Sexo = "Masculino",
                Telefono = "3195617553",
                Direccion = "55"

            };

            //Actuar
            string resultado = personaBusiness.ValidarPersona(entity);

            //Afirmar
            Assert.AreEqual("La direccion debe tener minimo 10 caracteres y maximo 50", resultado);
        }

        [Test]
        public void Persona_Sexo_Incorrecto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "123456789",
                Nombres = "Luis Martinez",
                Telefono = "3195617553",
                Direccion = "Calle 13D # 11-55",
                Sexo = "masculino y femenino"

            };

            //Actuar
            string resultado = personaBusiness.ValidarPersona(entity);

            //Afirmar
            Assert.AreEqual("El sexo debe tener minimo 5 caracteres y maximo 15", resultado);
        }

        [Test]
        public void Persona_Registro_Correcto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "123456789",
                Nombres = "Luis Martinez",
                Telefono = "3195617553",
                Direccion = "Calle 13D # 11-55",
                Sexo = "masculino"

            };

            //Actuar
            string resultado = personaBusiness.ValidarPersona(entity);

            //Afirmar
            Assert.AreEqual("Persona registrada exitosamente!", resultado);
        }

    }
}
