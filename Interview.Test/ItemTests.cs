using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assert = NUnit.Framework.Assert;

namespace Interview.Test
{
    [TestFixture]
    public class ItemTests
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
    }
}
