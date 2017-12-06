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
    public class PaquetesRepositoryTest
    {
        DbConnection connection;
        SampleArchContextTest databaseContext;
        PaquetesRepository objRepo;

        [SetUp]
        public void Initialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext = new SampleArchContextTest(connection);
            objRepo = new PaquetesRepository(databaseContext);
        }

        [Test]
        public void Paquetes_Repository_Get_ALL()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Premium", result[0].Nombre);
            Assert.AreEqual("Push", result[1].Nombre);
            Assert.AreEqual("Flash", result[2].Nombre);
        }

        [Test]
        public void Paquetes_Repository_Create()
        {
            //Arrange
            Paquetes p = new Paquetes() { Nombre = "Premium", Precio=200, Descripcion="Paquete basico", Dias=90 };

            //Act
            objRepo.Add(p);
            databaseContext.SaveChanges();

            var lst = objRepo.GetAll().ToList();

            //Assert

            Assert.AreEqual(4, lst.Count);
            Assert.AreEqual("Premium", lst.Last().Nombre);
        }

    }
}
