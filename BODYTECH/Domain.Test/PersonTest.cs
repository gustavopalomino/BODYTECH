﻿using System;
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
        PersonBusiness personBusiness;
        [SetUp]
        public void Initialize()
        {
            personBusiness = new PersonBusiness();
        }

        //Cliente

        [Test]
        public void Person_NumeroDocumento_Incorrecto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "1234",
                Nombres = "Luis",
                Celular = "3193675413",
                Direccion = "Calle 13D # 11-55",
                Altura = 55,
                Pecho = 60,
                Cintura = 30,
                Cadena = "Cadena",
                Nota = "Problemas de corazón"
            };

            //Actuar
            string resultado = personBusiness.ValidatePerson(entity);

            //Afirmar
            Assert.AreEqual("El numero de documento debe tener entre 8 y 10 caracteres", resultado);
        }
 
        [Test]
        public void Person_Nombres_Incorrecto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "123456789",
                Nombres = "Lu",
                Celular = "3193675413",
                Direccion = "Calle 13D # 11-55",
                Altura = 55,
                Pecho = 60,
                Cintura = 30,
                Cadena = "Cadena",
                Nota = "Problemas de corazón"
            };

            //Actuar
            string resultado = personBusiness.ValidatePerson(entity);

            //Afirmar
            Assert.AreEqual("El nombre debe tener minimo 3 caracteres y maximo 50", resultado);
        }
        [Test]
        public void Person_Celular_Incorrecto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "123456789",
                Nombres = "Luis Martinez",
                Celular = "3193",
                Direccion = "Calle 13D # 11-55",
                Altura = 55,
                Pecho = 60,
                Cintura = 30,
                Cadena = "Cadena",
                Nota = "Problemas de corazón"
            };

            //Actuar
            string resultado = personBusiness.ValidatePerson(entity);

            //Afirmar
            Assert.AreEqual("El celular debe tener minimo 7 caracteres y maximo 10", resultado);
        }
        [Test]
        public void Person_Direccion_Incorrecto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "123456789",
                Nombres = "Luis Martinez",
                Celular = "3195617553",
                Direccion = "55",
                Altura = 55,
                Pecho = 60,
                Cintura = 30,
                Cadena = "Cadena",
                Nota = "Problemas de corazón"
            };

            //Actuar
            string resultado = personBusiness.ValidatePerson(entity);

            //Afirmar
            Assert.AreEqual("La direccion debe tener minimo 10 caracteres y maximo 50", resultado);
        }


        [Test]
        public void Person_Sexo_Incorrecto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "123456789",
                Nombres = "Luis Martinez",
                Celular = "3195617553",
                Direccion = "Calle 13D # 11-55",
                Sexo = "masculino y femenino",
                Altura = 55,
                Pecho = 60,
                Cintura = 30,
                Cadena = "Cadena",
                Nota = "Problemas de corazón"
            };

            //Actuar
            string resultado = personBusiness.ValidatePerson(entity);

            //Afirmar
            Assert.AreEqual("El sexo debe tener minimo 5 caracteres y maximo 15", resultado);
        }


        [Test]
        public void Person_AlturaInferior_Incorrecto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "123456789",
                Nombres = "Luis Martinez",
                Celular = "3195617553",
                Direccion = "Calle 13D # 11-55",
                Sexo = "masculino",
                Altura = 49,
                Pecho = 60,
                Cintura = 30,
                Cadena = "Cadena",
                Nota = "Problemas de corazón"
            };

            //Actuar
            string resultado = personBusiness.ValidatePerson(entity);

            //Afirmar
            Assert.AreEqual("La altura minima es 50 Cm y maximo 300 Cm", resultado);
        }

        [Test]
        public void Person_AlturaSuperior_Incorrecto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "123456789",
                Nombres = "Luis Martinez",
                Celular = "3195617553",
                Direccion = "Calle 13D # 11-55",
                Sexo = "masculino",
                Altura = 301,
                Pecho = 60,
                Cintura = 30,
                Cadena = "Cadena",
                Nota = "Problemas de corazón"
            };

            //Actuar
            string resultado = personBusiness.ValidatePerson(entity);

            //Afirmar
            Assert.AreEqual("La altura minima es 50 Cm y maximo 300 Cm", resultado);
        }




        [Test]
        public void Person_Registro_Correcto()
        {
            Person entity = new Person()
            {
                NumeroIdentificacion = "123456789",
                Nombres = "Luis Martinez",
                Celular = "3195617553",
                Direccion = "Calle 13D # 11-55",
                Sexo = "masculino",
                Altura = 55,
                Pecho = 60,
                Cintura = 30,
                Cadena = "Cadena",
                Nota = "Problemas de corazón"
            };

            //Actuar
            string resultado = personBusiness.ValidatePerson(entity);

            //Afirmar
            Assert.AreEqual("Persona registrada exitosamente!", resultado);
        }
    }
}
