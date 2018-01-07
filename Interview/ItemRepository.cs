using System;
using System.Collections.Generic;

namespace Interview
{
    public class ItemRepository<T> : IRepository<T> where T : IStoreable
    {
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
            throw new NotImplementedException();
        }
    }
}
