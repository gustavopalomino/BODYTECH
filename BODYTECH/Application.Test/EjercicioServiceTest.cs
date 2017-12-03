using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Application.Implements;
using Application.Abstract;
using Domain.Abstracts;
using Domain.Entities;
using Application.Contracts;

namespace Application.Test
{
    [TestFixture]
    public class EjercicioServiceTest
    {
        private Mock<IEjercicioRepository> _mockRepository;
        private IEjercicioService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Ejercicio> listEjercicio;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IEjercicioRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new EjercicioService(_mockUnitWork.Object, _mockRepository.Object);
            listEjercicio = new List<Ejercicio>()
            {
                new Ejercicio () {Id = 1, Nombre="Pectorales"},
                new Ejercicio () {Id = 2, Nombre="Pres plano"},
                new Ejercicio () {Id = 3, Nombre="Sentadillas"},
                new Ejercicio () {Id = 4, Nombre="Avanzadas"},
                new Ejercicio () {Id = 5, Nombre="Polea de cuadriceps"},
                new Ejercicio () {Id = 6, Nombre="Rompe craneo"}
            };
        }

        [Test]
        public void Ejercicio_Get_All()
        {
            //Arranque
            _mockRepository.Setup(x => x.GetAll()).Returns(listEjercicio);

            //Actuar
            List<Ejercicio> results = _service.GetAll() as List<Ejercicio>;

            //Resultado
            Assert.IsNotNull(results);
            Assert.AreEqual(6, results.Count);
        }

        [Test]
        public void Add_Ejercicio()
        {
            //Arranque
            int Id = 1;
            Ejercicio p = new Ejercicio() { Id = 1, Nombre = "Pectorales" };
            _mockRepository.Setup(m => m.Add(p)).Returns((Ejercicio pe) =>
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
