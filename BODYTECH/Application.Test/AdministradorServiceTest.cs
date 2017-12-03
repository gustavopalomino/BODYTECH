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
    public class AdministradorServiceTest
    {
        private Mock<IAdministradorRepository> _mockRepository;
        private IAdministradorService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Administrador> listAdministrador;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IAdministradorRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new AdministradorService(_mockUnitWork.Object, _mockRepository.Object);
            listAdministrador = new List<Administrador>()
            {
                new Administrador () {Id = 1, email="tavo951073@gmail.com", profesion="Ingeniero"},
                new Administrador () {Id = 2, email="joseph@gmail.com", profesion="Fisicoculturista"},
                new Administrador () {Id = 3, email="example1@gmail.com", profesion="Deportista"},
                new Administrador () {Id = 4, email="example2@gmail.com", profesion="Fisicoculturista"},
                new Administrador () {Id = 5, email="example3@gmail.com", profesion="Fisicoculturista"},
                new Administrador () {Id = 6, email="example4@gmail.com", profesion="Fisicoculturista"},
            };
        }

        [Test]
        public void Administrador_Get_All()
        {
            //Arranque
            _mockRepository.Setup(x => x.GetAll()).Returns(listAdministrador);

            //Actuar
            List<Administrador> results = _service.GetAll() as List<Administrador>;

            //Resultado
            Assert.IsNotNull(results);
            Assert.AreEqual(6, results.Count);
        }

        [Test]
        public void Add_Administrador()
        {
            //Arranque
            int Id = 1;
            Administrador p = new Administrador() { Id = 1, email = "tavo951073@gmail.com", profesion = "Ingeniero" };
            _mockRepository.Setup(m => m.Add(p)).Returns((Administrador pe) =>
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
