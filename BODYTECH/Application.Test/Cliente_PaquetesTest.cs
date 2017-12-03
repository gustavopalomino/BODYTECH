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
    public class Cliente_PaquetesTest
    {
        private Mock<ICliente_PaquetesRepository> _mockRepository;
        private ICliente_PaquetesService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Cliente_Paquetes> listCliente_Paquetes;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<ICliente_PaquetesRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new Cliente_PaquetesService(_mockUnitWork.Object, _mockRepository.Object);
            listCliente_Paquetes = new List<Cliente_Paquetes>()
            {
                new Cliente_Paquetes () {FechaPago= Convert.ToDateTime("12 / 11 / 2017"), FechaInicio= Convert.ToDateTime("12 / 11 / 2017"), FechaFinal = Convert.ToDateTime("12 / 12 / 2017"), IdCliente=1, IdPaquetes=1},
                new Cliente_Paquetes () {FechaPago= Convert.ToDateTime("11 / 09 / 2017"), FechaInicio= Convert.ToDateTime("12 / 11 / 2017"), FechaFinal = Convert.ToDateTime("12 / 12 / 2017"), IdCliente=1, IdPaquetes=1},
                new Cliente_Paquetes () {FechaPago= Convert.ToDateTime("12 / 08 / 2017"), FechaInicio= Convert.ToDateTime("12 / 11 / 2017"), FechaFinal = Convert.ToDateTime("12 / 11 / 2017"), IdCliente=1, IdPaquetes=1},
                new Cliente_Paquetes () {FechaPago= Convert.ToDateTime("1 / 07 / 2017"), FechaInicio= Convert.ToDateTime("12 / 11 / 2017"), FechaFinal = Convert.ToDateTime("12 / 12 / 2017"), IdCliente=1, IdPaquetes=1},
                new Cliente_Paquetes () {FechaPago= Convert.ToDateTime("9 / 05 / 2017"), FechaInicio= Convert.ToDateTime("12 / 11 / 2017"), FechaFinal = Convert.ToDateTime("12 / 11 / 2017"), IdCliente=1, IdPaquetes=1},
                new Cliente_Paquetes () {FechaPago= Convert.ToDateTime("4 / 04 / 2017"), FechaInicio= Convert.ToDateTime("12 / 11 / 2017"), FechaFinal = Convert.ToDateTime("4 / 12 / 2017"), IdCliente=1, IdPaquetes=1}
            };
        }


        [Test]
        public void Cliente_Paquetes_Get_All()
        {
            //Arranque
            _mockRepository.Setup(x => x.GetAll()).Returns(listCliente_Paquetes);

            //Actuar
            List<Cliente_Paquetes> results = _service.GetAll() as List<Cliente_Paquetes>;

            //Resultado
            Assert.IsNotNull(results);
            Assert.AreEqual(6, results.Count);
        }

        [Test]
        public void Add_Cliente_Paquetes()
        {
            //Arranque
            int Id = 1;
            Cliente_Paquetes p = new Cliente_Paquetes() { FechaPago = Convert.ToDateTime("12 / 11 / 2017"), FechaInicio = Convert.ToDateTime("12 / 11 / 2017"), FechaFinal = Convert.ToDateTime("12 / 12 / 2017"), IdCliente = 1, IdPaquetes = 1 };
            _mockRepository.Setup(m => m.Add(p)).Returns((Cliente_Paquetes pe) =>
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
