using System;
using Raefftec.CatchEmAll.Types;

namespace Raefftec.CatchEmAll.Entities
{
    public class Article : IHasIdentifier
    {
        public Guid Id { get; private set; }

        public long ExternalId { get; private set; }

        public ArticleInfo ArticleInfo { get; private set; }

        public PriceInfo PriceInfo { get; private set; }

        public UpdateInfo UpdateInfo { get; private set; }

        private Article()
        {
            this.ArticleInfo = null!;
            this.PriceInfo = null!;
            this.UpdateInfo = null!;
        }

        public Article(long externalId, ArticleInfo articleInfo, PriceInfo priceInfo)
        {
            this.ExternalId = externalId;
            this.ArticleInfo = articleInfo;
            this.PriceInfo = priceInfo;
            this.UpdateInfo = new UpdateInfo();
        }

        public void Lock()
        {
            this.UpdateInfo = this.UpdateInfo.Lock();
        }

        public void Update(ArticleInfo articleInfo, PriceInfo priceInfo)
        {
            this.ArticleInfo = articleInfo;
            this.PriceInfo = priceInfo;
            this.UpdateInfo = this.UpdateInfo.MarkAsSuccessful();
        }

        public void Release()
        {
            this.UpdateInfo = this.UpdateInfo.MarkAsFailed();
        }
    }
}
