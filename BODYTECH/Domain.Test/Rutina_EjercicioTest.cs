using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using NUnit.Framework;

namespace Domain.Test
{
    public class Rutina_EjercicioTest
    {

        Rutina_EjercicioTest rutina_EjercicioTest;
        [SetUp]
        public void Initialize()
        {
            rutina_EjercicioTest = new Rutina_EjercicioTest();
        }

        //Persona

        [Test]
        public void RutinaEjercicio_Series_Incorrecto()
        {
            Rutina_Ejercicio entity = new Rutina_Ejercicio()
            {
                Series = 0,
                Repeticiones = 3
            };

            //Actuar
            string resultado = entity.ValidarRutinaEjercicio();

            //Afirmar
            Assert.AreEqual("Las series no pueden ser igual a cero o negativas", resultado);
        }


        [Test]
        public void RutinaEjercicio_Repeticiones_Incorrecto()
        {
            Rutina_Ejercicio entity = new Rutina_Ejercicio()
            {
                Series = 10,
                Repeticiones = 0

            };

            //Actuar
            string resultado = entity.ValidarRutinaEjercicio();

            //Afirmar
            Assert.AreEqual("Las repeticiones no pueden ser igual a cero o negativas", resultado);
        }

        [Test]
        public void RutinaEjercicio_Registro_Correcto()
        {
            Rutina_Ejercicio entity = new Rutina_Ejercicio()
            {
                Series = 10,
                Repeticiones = 10

            };

            //Actuar
            string resultado = entity.ValidarRutinaEjercicio();

            //Afirmar
            Assert.AreEqual("Registrado correctamente", resultado);
        }
    }
}
