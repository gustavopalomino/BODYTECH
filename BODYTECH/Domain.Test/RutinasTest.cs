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
    public class RutinasTest
    {
        RutinasBusiness rutinasBusiness;
        [SetUp]
        public void Initialize()
        {
            rutinasBusiness = new RutinasBusiness();
        }


        [Test]
        public void Rutina_Nombre_Incorrecto()
        {
            Rutinas entity = new Rutinas()
            {
                Nombre = "ro"

            };

            //Actuar
            string resultado = rutinasBusiness.ValidateRutina(entity);

            //Afirmar
            Assert.AreEqual("El nombre de la rutina debe tener minimo 3 caracteres y maximo 40", resultado);
        }

        [Test]
        public void Rutina_Registro_Correcto()
        {
            Rutinas entity = new Rutinas()
            {
                Nombre = "Rutina A"

            };

            //Actuar
            string resultado = rutinasBusiness.ValidateRutina(entity);

            //Afirmar
            Assert.AreEqual("Rutina registrada correctamente!", resultado);
        }
    }
}
