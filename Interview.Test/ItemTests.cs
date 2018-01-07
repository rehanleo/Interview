using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

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
    }
}
