using System;
using System.Collections.Generic;

namespace Interview
{
    public class ItemRepository<T> : IRepository<T> where T : IStoreable
    {
        private IList<T> _itemsList;

        public ItemRepository(IList<T> itemsList)
        {
            _itemsList = itemsList;
        }

        public IEnumerable<T> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(IComparable id)
        {
            throw new NotImplementedException();
        }

        public T FindById(IComparable id)
        {
            throw new NotImplementedException();
        }

        public void Save(T item)
        {
            if (item.Id == null)
                throw new ArgumentNullException("Id","Parameter 'Id' cannot be null.");

            if (_itemsList.Contains(item))
                throw new ArgumentException("Item already exists.");

            _itemsList.Add(item);
        }
    }
}
