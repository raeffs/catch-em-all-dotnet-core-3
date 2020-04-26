using System;

namespace Raefftec.CatchEmAll.SearchQueries
{
    internal class SearchQueryDetails
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = null!;
        public string WithAllTheseWords { get; set; } = null!;
    }
}
