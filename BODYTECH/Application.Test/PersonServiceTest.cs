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
    public class PersonServiceTest
    {
        private Mock<IPersonRepository> _mockRepository;
        private IPersonService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Personas> listPerson;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IPersonRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new PersonService(_mockUnitWork.Object, _mockRepository.Object);
            listPerson = new List<Personas>()
            {
                new Personas () {Id=1, NumeroIdentificacion="1064117532", Nombres="Ronal Varela", Telefono="3193765643", Direccion="Calle 15 #14-44"},
                new Personas () {Id=2, NumeroIdentificacion="1064114331", Nombres="Javier Nuñes", Telefono="3162739391", Direccion="Carrera 18 #12-14"},
                new Personas () {Id=3, NumeroIdentificacion="1064145663", Nombres="Jeffri Ortiz", Telefono="3193756753", Direccion="Calle 9 #2-65"},
                new Personas () {Id=4, NumeroIdentificacion="1064116666", Nombres="Gustavo Palomino", Telefono="3195643421", Direccion="Calle 2 #29-50"},
                new Personas () {Id=5, NumeroIdentificacion="1064116563", Nombres="Luis Ovalle", Telefono="3195640001", Direccion="Calle 3 #37-55"},
                new Personas () {Id=6, NumeroIdentificacion="1064116777", Nombres="Andrea Garcia", Telefono="3195643342", Direccion="Calle 19 #1-10"},

            };
        }

        [Test]
        public void Person_Get_All()
        {
            //Arranque
            _mockRepository.Setup(x => x.GetAll()).Returns(listPerson);

            //Actuar
            List<Personas> results = _service.GetAll() as List<Personas>;

            //Resultado
            Assert.IsNotNull(results);
            Assert.AreEqual(6, results.Count);
        }

        [Test]
        public void Add_Person()
        {
            //Arranque
            int Id = 1;
            Personas p = new Personas() { Id = 1, NumeroIdentificacion = "1076543652", Nombres = "Ronal Varela", Telefono = "3005678765", Direccion = "Calle 5 # 6-20" };
            _mockRepository.Setup(m => m.Add(p)).Returns((Personas pe) =>
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
