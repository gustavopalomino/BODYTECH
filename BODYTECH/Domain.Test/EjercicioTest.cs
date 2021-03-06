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
    public class EjercicioTest
    {
        Ejercicio ejercicio;
        [SetUp]
        public void Initialize()
        {
            ejercicio = new Ejercicio();
        }

        //Persona

        [Test]
        public void Ejercicio_Nombre_Incorrecto()
        {
            Ejercicio entity = new Ejercicio()
            {
                Nombre = "Pp",

            };

            //Actuar
            string resultado = entity.ValidarEjercicio();

            //Afirmar
            Assert.AreEqual("El nombre del ejercicio debe tener minimo 3 y maximo 40 caracteres", resultado);
        }

        [Test]
        public void Ejercicio_Registro_Correcto()
        {
            Ejercicio entity = new Ejercicio()
            {
                Nombre = "Avanzadas",
            };

            //Actuar
            string resultado = entity.ValidarEjercicio();

            //Afirmar
            Assert.AreEqual("Ejercicio registrado exitosamente!", resultado);
        }
    }

}
