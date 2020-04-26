using Microsoft.EntityFrameworkCore;
using Raefftec.CatchEmAll.Exceptions;

namespace Raefftec.CatchEmAll.Types
{
    [Owned]
    public class PriceInfo
    {
        public decimal? BidPrice { get; private set; }

        public decimal? PurchasePrice { get; private set; }

        public decimal? FinalPrice { get; private set; }

        public PriceInfo(
            decimal? bidPrice,
            decimal? purchasePrice,
            decimal? finalPrice)
        {
            InvalidPriceException.AssertValid(nameof(bidPrice), bidPrice);
            InvalidPriceException.AssertValid(nameof(purchasePrice), purchasePrice);
            InvalidPriceException.AssertValid(nameof(finalPrice), finalPrice);

            this.BidPrice = bidPrice;
            this.PurchasePrice = purchasePrice;
            this.FinalPrice = finalPrice;
        }
    }
}
