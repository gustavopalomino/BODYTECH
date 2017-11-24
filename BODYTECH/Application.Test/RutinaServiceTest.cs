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


namespace Application.Test
{
   public class RutinaServiceTest
    {
        private Mock<IRutinaRepository> _mockRepository;
        private IRutinaService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Rutina> listRutina;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IRutinaRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new RutinaService(_mockUnitWork.Object, _mockRepository.Object);
            listRutina = new List<Rutina>()
            {
                new Rutina () {Id=1, Nombre_Rutina = "Rutina A"},
                new Rutina () {Id=2, Nombre_Rutina = "Rutina b"},
                new Rutina () {Id=3, Nombre_Rutina = "Rutina c"},
                new Rutina () {Id=4, Nombre_Rutina = "Rutina d"},
                new Rutina () {Id=5, Nombre_Rutina = "Rutina f"},
                new Rutina () {Id=6, Nombre_Rutina = "Rutina g"},
            };
        }

        [Test]
        public void Rutina_Get_All()
        {
            //Arranque
            _mockRepository.Setup(x => x.GetAll()).Returns(listRutina);

            //Actuar
            List<Rutina> results = _service.GetAll() as List<Rutina>;

            //Resultado
            Assert.IsNotNull(results);
            Assert.AreEqual(6, results.Count);
        }

        [Test]
        public void Add_Rutina()
        {
            //Arranque
            int Id = 1;
            Rutina p = new Rutina() { Id = 1, Nombre_Rutina = "Rutina A"};
            _mockRepository.Setup(m => m.Add(p)).Returns((Rutina pe) =>
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
