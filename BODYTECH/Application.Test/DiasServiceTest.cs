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
using Application.Abstracts;

namespace Application.Test
{
    [TestFixture]
    public class DiasServiceTest
    {
        private Mock <IDiasRepositoty> _mockRepository;
        private  IDiasService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Dias> listDias;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IDiasRepositoty>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new DiasService(_mockUnitWork.Object, _mockRepository.Object);
            listDias = new List<Dias>()
            {
                new Dias() {Id=1, Nombre_Dia = "Pectorales"},
                new Dias() {Id=2, Nombre_Dia = "Gluteos"},
                new Dias() {Id=3, Nombre_Dia = "Espalda"},
                new Dias() {Id=4, Nombre_Dia = "Pantorrilla"},
                new Dias() {Id=5, Nombre_Dia = "Biceps"},
                new Dias() {Id=6, Nombre_Dia = "Triceps"},


            };
        }

        [Test]
        public void Dias_Get_All()
        {
            //Arranque
            _mockRepository.Setup(x => x.GetAll()).Returns(listDias);

            //Actuar
            List<Dias> results = _service.GetAll() as List<Dias>;

            //Resultado
            Assert.IsNotNull(results);
            Assert.AreEqual(6, results.Count);
        }

        [Test]
        public void Add_Dias()
        {
            //Arranque
            int Id = 1;
            Dias p = new Dias() { Id = 1, Nombre_Dia = "Pectorales"};
            _mockRepository.Setup(m => m.Add(p)).Returns((Dias pe) =>
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
