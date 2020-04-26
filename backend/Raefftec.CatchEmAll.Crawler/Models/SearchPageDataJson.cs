using System;
using System.Collections.Generic;

namespace Raefftec.CatchEmAll.Models
{
    internal class SearchPageDataJson
    {
        public SearchPageDataJson_InitialState? InitialState { get; set; }
    }

    internal class SearchPageDataJson_InitialState
    {
        public SearchPageDataJson_Srp? Srp { get; set; }
    }

    internal class SearchPageDataJson_Srp
    {
        public int TotalArticlesCount { get; set; }
        public SearchPageDataJson_Config? Config { get; set; }
        public IEnumerable<SearchPageDataJson_Result>? Results { get; set; }
    }

    internal class SearchPageDataJson_Config
    {
        public int PageSize { get; set; }
    }

    internal class SearchPageDataJson_Result
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public bool HasBuyNow { get; set; }
        public bool HasAuction { get; set; }
        public decimal? BuyNowPrice { get; set; }
        public long CategoryId { get; set; }
        public decimal? BidPrice { get; set; }
        public int BidsCount { get; set; }
        public long SellerId { get; set; }
        public string? ConditionKey { get; set; }
        public string? Condition { get; set; }
    }
}
