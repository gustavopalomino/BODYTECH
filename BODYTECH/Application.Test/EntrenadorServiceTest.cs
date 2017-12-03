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
    public class EntrenadorServiceTest
    {
        private Mock<IEntrenadorRepository> _mockRepository;
        private IEntrenadorService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Entrenador> listEntrenador;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IEntrenadorRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new EntrenadorService(_mockUnitWork.Object, _mockRepository.Object);
            listEntrenador = new List<Entrenador>()
            {
                new Entrenador () {Id = 1, AniosExperiencia= 3, AreaTrabajo="Aerobicos"},
                new Entrenador () {Id = 2, AniosExperiencia= 2, AreaTrabajo="Piernas"},
                new Entrenador () {Id = 3, AniosExperiencia= 1, AreaTrabajo="Reduccion de peso"},
                new Entrenador () {Id = 4, AniosExperiencia= 0, AreaTrabajo="Nutricion"},
                new Entrenador () {Id = 5, AniosExperiencia= 5, AreaTrabajo="General"},
                new Entrenador () {Id = 6, AniosExperiencia= 7, AreaTrabajo="Rutinas especiales"}
            };
        }


        [Test]
        public void Entrenador_Get_All()
        {
            //Arranque
            _mockRepository.Setup(x => x.GetAll()).Returns(listEntrenador);

            //Actuar
            List<Entrenador> results = _service.GetAll() as List<Entrenador>;

            //Resultado
            Assert.IsNotNull(results);
            Assert.AreEqual(6, results.Count);
        }

        [Test]
        public void Add_Entrenador()
        {
            //Arranque
            int Id = 1;
            Entrenador p = new Entrenador() { Id = 1, AniosExperiencia = 3, AreaTrabajo = "Aerobicos" };
            _mockRepository.Setup(m => m.Add(p)).Returns((Entrenador pe) =>
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
