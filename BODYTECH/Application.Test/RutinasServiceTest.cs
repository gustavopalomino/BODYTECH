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
    public class RutinasServiceTest
    {
        private Mock<IRutinasRepository> _mockRepository;
        private IRutinasService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Rutinas> listRutinas;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IRutinasRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new RutinasService(_mockUnitWork.Object, _mockRepository.Object);
            listRutinas = new List<Rutinas>()
            {
                new Rutinas () { Id=1, Nombre = "Rutina 1",Tipo ="Muscular"},
                new Rutinas () { Id=2, Nombre = "Rutina 2",Tipo ="Tonificación"},
                new Rutinas () { Id=3, Nombre = "Rutina 3", Tipo ="Resistencia"},
                new Rutinas () { Id=4, Nombre = "Rutina 4", Tipo ="Tonificación"},
                new Rutinas () { Id=5, Nombre = "Rutina 5", Tipo ="Tonificación"}
            };
        }

        [Test]
        public void Rutinas_Get_All()
        {
            //Arranque
            _mockRepository.Setup(x => x.GetAll()).Returns(listRutinas);

            //Actuar
            List<Rutinas> results = _service.GetAll() as List<Rutinas>;

            //Resultado
            Assert.IsNotNull(results);
            Assert.AreEqual(5, results.Count);
        }

        [Test]
        public void Add_Rutinas()
        {
            //Arranque
            int Id = 1;
            Rutinas p = new Rutinas() { Id = 1, Nombre = "Rutina 1" };
            _mockRepository.Setup(m => m.Add(p)).Returns((Rutinas pe) =>
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
