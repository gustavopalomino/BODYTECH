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
        List<Person> listPerson;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IPersonRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new PersonService(_mockUnitWork.Object, _mockRepository.Object);
            listPerson = new List<Person>()
            {
                new Person () {Id=1, NumeroIdentificacion="1064117532", Nombres="Ronal Varela", Celular="3193765643", Direccion="Calle 15 #14-44"},
                new Person () {Id=2, NumeroIdentificacion="1064114331", Nombres="Javier Nuñes", Celular="3162739391", Direccion="Carrera 18 #12-14"},
                new Person () {Id=3, NumeroIdentificacion="1064145663", Nombres="Jeffri Ortiz", Celular="3193756753", Direccion="Calle 9 #2-65"},
                new Person () {Id=4, NumeroIdentificacion="1064116666", Nombres="Gustavo Palomino", Celular="3195643421", Direccion="Calle 2 #29-50"},
                new Person () {Id=5, NumeroIdentificacion="1064116563", Nombres="Luis Ovalle", Celular="3195640001", Direccion="Calle 3 #37-55"},
                new Person () {Id=6, NumeroIdentificacion="1064116777", Nombres="Andrea Garcia", Celular="3195643342", Direccion="Calle 19 #1-10"},

            };
        }

        [Test]
        public void Person_Get_All()
        {
            //Arranque
            _mockRepository.Setup(x => x.GetAll()).Returns(listPerson);

            //Actuar
            List<Person> results = _service.GetAll() as List<Person>;

            //Resultado
            Assert.IsNotNull(results);
            Assert.AreEqual(6, results.Count);
        }

        [Test]
        public void Add_Person()
        {
            //Arranque
            int Id = 1;
            Person p = new Person() { Id = 1, NumeroIdentificacion = "1076543652", Nombres = "Ronal Varela", Celular = "3005678765", Direccion = "Calle 5 # 6-20" };
            _mockRepository.Setup(m => m.Add(p)).Returns((Person pe) =>
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
