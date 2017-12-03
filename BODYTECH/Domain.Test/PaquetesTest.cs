using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using NUnit.Framework;


namespace Domain.Test
{
    public class PaquetesTest
    {
        Paquetes paquetes;
        [SetUp]
        public void Initialize()
        {
            paquetes = new Paquetes();
        }

        [Test]
        public void Paquetes_Nombre_Incorrecto()
        {
            Paquetes entity = new Paquetes()
            {
               Nombre="e",
               Dias = 30,
               Descripcion = "Ejercicios basicos",
               Precio= 2000  
            };

            //Actuar
            string resultado = entity.ValidarPaquetes();

            //Afirmar
            Assert.AreEqual("El nombre del paquete debe tener entre 3 y 30 caracteres", resultado);
        }

        [Test]
        public void Paquetes_Dias_Incorrecto()
        {
            Paquetes entity = new Paquetes()
            {
                Nombre = "Paquete Basico",
                Dias = -2,
                Descripcion = "Ejercicios basicos",
                Precio = 2000
            };

            //Actuar
            string resultado = entity.ValidarPaquetes();

            //Afirmar
            Assert.AreEqual("Los dias no pueden ser 0 o negativos", resultado);
        }

        [Test]
        public void Paquetes_Descripcion_Incorrecto()
        {
            Paquetes entity = new Paquetes()
            {
                Nombre = "Paquete Basico",
                Dias = 30,
                Descripcion = "E",
                Precio = 2000
            };

            //Actuar
            string resultado = entity.ValidarPaquetes();

            //Afirmar
            Assert.AreEqual("La descripcion debe tener entre 3 y 100 caracteres", resultado);
        }

        [Test]
        public void Paquetes_Pagos_Incorrecto()
        {
            Paquetes entity = new Paquetes()
            {
                Nombre = "Paquete Basico",
                Dias = 30,
                Descripcion = "Ejercicios basicos",
                Precio = -2000
            };

            //Actuar
            string resultado = entity.ValidarPaquetes();

            //Afirmar
            Assert.AreEqual("El precio de los paquetes no puede ser negativo", resultado);
        }

        [Test]
        public void Paquetes_Registro_Correcto()
        {
            Paquetes entity = new Paquetes()
            {
                Nombre = "Paquete Basico",
                Dias = 30,
                Descripcion = "Ejercicios basicos",
                Precio = 2000
            };

            //Actuar
            string resultado = entity.ValidarPaquetes();

            //Afirmar
            Assert.AreEqual("Paquete registrado correctamente!", resultado);
        }

    }
}
