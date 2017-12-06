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
    [TestFixture]

    public class PaquetesServiceTest 
    {

        private Mock<IPaquetesRepository> _mockRepository;
        private IPaquetesService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Paquetes> listPaquetes;


        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IPaquetesRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new PaquetesService(_mockUnitWork.Object, _mockRepository.Object);
            listPaquetes = new List<Paquetes>()
            {
                new Paquetes () { Id=1, Nombre = "Premium", Dias = 30, Descripcion = "Se tienen en cuenta sabados y domingos"},
                new Paquetes () { Id=2, Nombre = "Push", Dias = 40, Descripcion = "Se tienen en cuenta sabados y domingos"},
                new Paquetes () { Id=3, Nombre = "Flash", Dias = 15, Descripcion = "Se tienen en cuenta sabados y domingos"}
            };
        }

        [Test]
        public void Paquetes_Get_All()
        {
            //Arranque
            _mockRepository.Setup(x => x.GetAll()).Returns(listPaquetes);

            //Actuar
            List<Paquetes> results = _service.GetAll() as List<Paquetes>;

            //Resultado
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }

        [Test]
        public void Add_Paquetes()
        {
            //Arranque
            int Id = 1;
            Paquetes p = new Paquetes() { Id = 1, Nombre = "Premium", Dias = 30, Descripcion = "Se tienen en cuenta sabados y domingos" };
            _mockRepository.Setup(m => m.Add(p)).Returns((Paquetes pe) =>
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
