using Domain.Entities;
using Infraestructure.Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Test
{
    [TestFixture]
    public class PersonRepositoryTest
    {
        DbConnection connection;
        SampleArchContextTest databaseContext;
        PersonRepository objRepo;

        [SetUp]
        public void Initialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext = new SampleArchContextTest(connection);
            objRepo = new PersonRepository(databaseContext);
        }

        //[Test]
        //public void Person_Repository_Get_ALL()
        //{
        //    //Act
        //    var result = objRepo.GetAll().ToList();

        //    //Assert

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(3, result.Count);
        //    Assert.AreEqual("123", result[0].NumeroIdentificacion);
        //    Assert.AreEqual("1234", result[1].NumeroIdentificacion);
        //    Assert.AreEqual("12345", result[2].NumeroIdentificacion);
        //}

        //[Test]
        //public void Person_Repository_Create()
        //{
        //    //Arrange
        //    Personas p = new Personas() {NumeroIdentificacion="123", Nombres = "Andres Calamardo", Sexo = "M", Telefono = "314567878", Direccion = "Calle 13C # 12-23" };

        //    //Act
        //    objRepo.Add(p);
        //    databaseContext.SaveChanges();

        //    var lst = objRepo.GetAll().ToList();

        //    //Assert

        //    Assert.AreEqual(4, lst.Count);
        //    Assert.AreEqual("Andres Calamardo", lst.Last().Nombres);
        //}

    }
}
