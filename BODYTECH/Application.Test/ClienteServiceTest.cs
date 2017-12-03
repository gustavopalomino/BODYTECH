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
    public class ClienteServiceTest
    {
        private Mock<IClienteRepository> _mockRepository;
        private IClienteService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Cliente> listCliente;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IClienteRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new ClienteService(_mockUnitWork.Object, _mockRepository.Object);
            listCliente = new List<Cliente>()
            {
                new Cliente () {email="example1@gmail.com", discapacidad="ninguna", Estatura=1.7, Peso= 70.5},
                new Cliente () {email="example2@gmail.com", discapacidad="ninguna", Estatura=1.8, Peso= 60.5},
                new Cliente () {email="example3@gmail.com", discapacidad="zordera", Estatura=1.72, Peso= 64.5},
                new Cliente () {email="example4@gmail.com", discapacidad="poca vision", Estatura=1.71, Peso= 61.5},
                new Cliente () {email="example5@gmail.com", discapacidad="física", Estatura=1.78, Peso= 62.5},
                new Cliente () {email="example6@gmail.com", discapacidad="ninguna", Estatura=1.73, Peso= 90.5},
            };
        }

        [Test]
        public void Cliente_Get_All()
        {
            //Arranque
            _mockRepository.Setup(x => x.GetAll()).Returns(listCliente);

            //Actuar
            List<Cliente> results = _service.GetAll() as List<Cliente>;

            //Resultado
            Assert.IsNotNull(results);
            Assert.AreEqual(6, results.Count);
        }

        [Test]
        public void Add_Cliente()
        {
            //Arranque
            int Id = 1;
            Cliente p = new Cliente() { email = "example1@gmail.com", discapacidad = "ninguna", Estatura = 1.7, Peso = 70.5 };
            _mockRepository.Setup(m => m.Add(p)).Returns((Cliente pe) =>
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
