using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Application.Implements;
using Application.Abstracts;
using Domain.Abstracts;
using Domain.Entities;
using Application.Contracts;

namespace Application.Test
{
    public class Rutina_EjercicioServiceTest
    {
        private Mock<IRutina_EjercicioRepository> _mockRepository;
        private IRutina_EjercicioService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Rutina_Ejercicio> listRutina_Ejercicio;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IRutina_EjercicioRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new Rutina_EjercicioService(_mockUnitWork.Object, _mockRepository.Object);
            listRutina_Ejercicio = new List<Rutina_Ejercicio>()
            {
               new Rutina_Ejercicio { Series = 9, Repeticiones = 3, IdRutina = 111, IdEjercicio = 11  },
               new Rutina_Ejercicio { Series = 7, Repeticiones = 2, IdRutina = 222, IdEjercicio = 22  },
               new Rutina_Ejercicio { Series = 7, Repeticiones = 5, IdRutina = 333, IdEjercicio = 33  },
               new Rutina_Ejercicio { Series = 3, Repeticiones = 2, IdRutina = 444, IdEjercicio = 44  },
               new Rutina_Ejercicio { Series = 5, Repeticiones = 3, IdRutina = 555, IdEjercicio = 55  }
            };
        }

        [Test]
        public void Rutina_Ejercicio_Get_All()
        {
            //Arranque
            _mockRepository.Setup(x => x.GetAll()).Returns(listRutina_Ejercicio);

            //Actuar
            List<Rutina_Ejercicio> results = _service.GetAll() as List<Rutina_Ejercicio>;

            //Resultado
            Assert.IsNotNull(results);
            Assert.AreEqual(5, results.Count);
        }

        [Test]
        public void Add_Rutina_Ejercicio()
        {
            //Arranque
            int Id = 1;
            Rutina_Ejercicio p = new Rutina_Ejercicio() { Series = 9, Repeticiones = 3, IdRutina = 111, IdEjercicio = 11 };
            _mockRepository.Setup(m => m.Add(p)).Returns((Rutina_Ejercicio pe) =>
            {
                pe.Id = Id;
                return pe;
            });

            //Actuar
            _service.Create(p);

            //Resultado

            Assert.AreEqual(Id, p.Id);
            _mockUnitWork.Verify(m => m.Commit(), Times.Once);
        }

    }
}
