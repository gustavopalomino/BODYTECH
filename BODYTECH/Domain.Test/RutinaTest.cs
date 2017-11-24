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
    public class RutinaTest
    {
        RutinaBusiness rutinaBusiness;
        [SetUp]
        public void Initialize()
        {
            rutinaBusiness = new RutinaBusiness();
        }


        [Test]
        public void Rutina_Nombre_Incorrecto()
        {
            Rutina entity = new Rutina()
            {
                Nombre_Rutina = "ro"

            };

            //Actuar
            string resultado = rutinaBusiness.ValidateRutina(entity);

            //Afirmar
            Assert.AreEqual("El nombre de la rutina debe tener minimo 3 caracteres y maximo 40", resultado);
        }

        [Test]
        public void Rutina_Registro_Correcto()
        {
            Rutina entity = new Rutina()
            {
                Nombre_Rutina = "Rutina A"

            };

            //Actuar
            string resultado = rutinaBusiness.ValidateRutina(entity);

            //Afirmar
            Assert.AreEqual("Rutina registrada correctamente!", resultado);
        }
    }
}
