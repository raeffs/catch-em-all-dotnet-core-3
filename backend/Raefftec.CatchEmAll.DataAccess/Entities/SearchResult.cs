using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raefftec.CatchEmAll.Entities
{
    public class SearchResult : IHasIdentifier
    {
        public Guid Id { get; private set; }

        public Guid QueryId { get; private set; }

        [ForeignKey(nameof(QueryId))]
        public SearchQuery Query { get; private set; }

        public Guid ArticleId { get; private set; }

        [ForeignKey(nameof(ArticleId))]
        public Article Article { get; private set; }

        private SearchResult()
        {
            this.Query = null!;
            this.Article = null!;
        }

        public SearchResult(SearchQuery query, Article article)
        {
            this.Query = query;
            this.QueryId = query.Id;
            this.Article = article;
            this.ArticleId = article.Id;
        }
    }
}
