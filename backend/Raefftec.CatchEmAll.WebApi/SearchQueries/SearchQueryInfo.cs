using System;

namespace Raefftec.CatchEmAll.SearchQueries
{
    internal class SearchQueryInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public int NumberOfResults { get; set; }

        public DateTimeOffset Updated { get; set; }
    }
}
