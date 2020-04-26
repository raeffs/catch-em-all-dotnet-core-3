using System;

namespace Raefftec.CatchEmAll
{
    public class ArticleData
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Ends { get; set; }
        public bool IsClosed { get; set; }
        public bool IsSold { get; set; }
        public decimal? BidPrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? FinalPrice { get; set; }
    }
}
