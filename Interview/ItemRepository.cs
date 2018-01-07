using System;
using System.Collections.Generic;
using System.Linq;

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
            return _itemsList;
        }

        public void Delete(IComparable id)
        {
            var result = FindById(id);
            _itemsList.Remove(result);
        }

        public T FindById(IComparable id)
        {
            var result = _itemsList.FirstOrDefault(x => x.Id.CompareTo(id) == 0);

            if (result == null)
                throw new Exception($"No item found for id: {id}");

            return result;
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
