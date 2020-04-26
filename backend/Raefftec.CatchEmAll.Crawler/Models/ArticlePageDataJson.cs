using System;
using Newtonsoft.Json;

namespace Raefftec.CatchEmAll.Models
{
    internal class ArticlePageDataJson
    {
        public ArticlePageDataJson_InitialState? InitialState { get; set; }
    }

    internal class ArticlePageDataJson_InitialState
    {
        public ArticlePageDataJson_Pdp? Pdp { get; set; }
    }

    internal class ArticlePageDataJson_Pdp
    {
        public ArticlePageDataJson_Article? Article { get; set; }
        public ArticlePageDataJson_Bid? Bid { get; set; }
    }

    /// <summary>
    /// All the article properties that could be of interest.
    /// </summary>
    internal class ArticlePageDataJson_Article
    {
        public long Id { get; set; }
        [JsonProperty("user_id")]
        public long UserId { get; set; }
        [JsonProperty("product_id")]
        public long ProductId { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public int Condition { get; set; }
        [JsonProperty("condition_value")]
        public string? ConditionValue { get; set; }
        [JsonProperty("condition_key")]
        public string? ConditionKey { get; set; }
        [JsonProperty("creation_date")]
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// Probably 0 = open, 1 = closed or sold
        /// </summary>
        public int Status { get; set; }

        [JsonProperty("legacy_status")]
        public int LegacyStatus { get; set; }
        [JsonProperty("end_date")]
        public DateTimeOffset EndDate { get; set; }
        public ArticlePageDataJson_Offer? Offer { get; set; }
    }

    internal class ArticlePageDataJson_Offer
    {
        public decimal? Price { get; set; }
    }

    internal class ArticlePageDataJson_Bid
    {
        public ArticlePageDataJson_BidData? Data { get; set; }
    }

    internal class ArticlePageDataJson_BidData
    {
        [JsonProperty("next_minimum_bid")]
        public decimal NextMinimumBid { get; set; }
    }
}
