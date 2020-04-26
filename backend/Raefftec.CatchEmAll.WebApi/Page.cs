using System.Collections.Generic;

namespace Raefftec.CatchEmAll
{
    internal class Page<T>
    {
        public List<T> Items { get; set; } = new List<T>();
    }
}
