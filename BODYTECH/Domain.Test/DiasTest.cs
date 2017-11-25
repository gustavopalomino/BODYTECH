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
    public class DiasTest
    {
        DiasBusiness diasBusiness;
        [SetUp]
        public void Initialize()
        {
            diasBusiness = new DiasBusiness();
        }


        [Test]
        public void Dia_Nombre_Incorrecto()
        {
            Dias entity = new Dias()
            {
                Nombre_Dia = "Pe"

            };

            //Actuar
            string resultado = diasBusiness.ValidateDias(entity);

            //Afirmar
            Assert.AreEqual("El nombre del dia debe tener minimo 3 caracteres y maximo 20!", resultado);
        }

        [Test]
        public void Dia_Registro_Correcto()
        {
            Dias entity = new Dias()
            {
                Nombre_Dia = "Pectorales"

            };

            //Actuar
            string resultado = diasBusiness.ValidateDias(entity);

            //Afirmar
            Assert.AreEqual("Dia Regitrado correctamente!", resultado);
        }
    }
}
