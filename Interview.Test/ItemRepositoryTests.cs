using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assert = NUnit.Framework.Assert;

namespace Interview.Test
{
    [TestFixture]
    public class ItemRepositoryTests
    {
        private IRepository<Item> subject;
        private IList<Item> itemsList;

        [SetUp]
        public void Setup()
        {
            itemsList = new List<Item>();
            subject = new ItemRepository<Item>(itemsList);
        }

        [Test]
        public void ItemIsAddedToListWhenSaveIsCalled()
        {
            //Arrange
            var item = new Item() { Id = 1 };

            //Act
            subject.Save(item);

            //Assert
            Assert.AreEqual(item, itemsList.FirstOrDefault());
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionIsThrownWhenItemIsAddedToListWhichAlreadyExists()
        {
            //Arrange
            var item = new Item() { Id = 1 };
            subject.Save(item);

            //Act and Assert
            Assert.That(() => subject.Save(item), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionIsThrownWhenNullItemIsAddedToList()
        {
            //Arrange
            var item = new Item();

            //Act and Assert
            Assert.That(() => subject.Save(item), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ItemIsReturnedCorrectlyWhenFindByIdIsCalled()
        {
            //Arrange
            var item = new Item() { Id = 1 };
            itemsList = new List<Item>();
            itemsList.Add(item);
            subject = new ItemRepository<Item>(itemsList);

            //Act
            var result = subject.FindById(item.Id);

            //Assert
            Assert.AreEqual(result, item);
        }


        [Test]
        [ExpectedException(typeof(Exception))]
        public void ExceptionIsThrownWhenFindByIdDoesNotFindAnyItem()
        {
            //Arrange
            var item = new Item() { Id = 1 };

            //Act and Assert
            Assert.That(() => subject.FindById(item.Id), Throws.TypeOf<Exception>());
        }

        [Test]
        public void ItemIsRemovedWhenDeleteIsCalled()
        {
            //Arrange
            var item = new Item() { Id = 1 };
            itemsList = new List<Item>();
            itemsList.Add(item);
            subject = new ItemRepository<Item>(itemsList);

            //Act
            subject.Delete(item.Id);

            //Assert
            Assert.AreEqual(0, itemsList.Count());
        }

    }
}
