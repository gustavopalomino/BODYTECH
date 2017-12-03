using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using NUnit.Framework;

namespace Domain.Test
{
    public class EntrenadorTest
    {
        Entrenador entrenador;
        [SetUp]
        public void Initialize()
        {
            entrenador = new Entrenador();
        }

        //Entrenador

        [Test]
        public void Entrenador_Certificado_Incorrecto()
        {
            Entrenador entity = new Entrenador()
            {
                Certificado = "S",
                AreaTrabajo = "Aerobicos"

            };

            //Actuar
            string resultado = entity.ValidarEntrenador();

            //Afirmar
            Assert.AreEqual("El certificado solo puede tener 2 caracteres: Si o No", resultado);
        }

        [Test]
        public void Entrenador_Areatrabajo_Incorrecto()
        {
            Entrenador entity = new Entrenador()
            {
                Certificado = "Si",
                AreaTrabajo = "A"

            };

            //Actuar
            string resultado = entity.ValidarEntrenador();

            //Afirmar
            Assert.AreEqual("El area de trabajo debe tener entre 3 y 30 caracteres", resultado);
        }

        [Test]
        public void Entrenador_Registro_correcto()
        {
            Entrenador entity = new Entrenador()
            {
                Certificado = "Si",
                AreaTrabajo = "Aerobicos"

            };

            //Actuar
            string resultado = entity.ValidarEntrenador();

            //Afirmar
            Assert.AreEqual("Entrenador registrado correctamente!", resultado);
        }

    }
}
