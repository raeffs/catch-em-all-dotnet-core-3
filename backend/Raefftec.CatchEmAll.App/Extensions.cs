using Raefftec.CatchEmAll.Types;

namespace Raefftec.CatchEmAll
{
    internal static class Extensions
    {
        public static ArticleInfo GetArticleInfo(this ArticleData data) => new ArticleInfo(
                data.Name,
                data.Created,
                data.Ends,
                data.IsClosed,
                data.IsSold);

        public static PriceInfo GetPriceInfo(this ArticleData data) => new PriceInfo(
                data.BidPrice,
                data.PurchasePrice,
                data.FinalPrice);
    }
}
