using System;

namespace Interview
{
    public class Item : IStoreable
    {
        public IComparable Id { get; set; }
    }
}
