using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Raefftec.CatchEmAll
{
    internal class ArticleUpdateFunctions
    {
        private readonly ILogger<ArticleUpdateFunctions> logger;
        private readonly ICrawler crawler;
        private readonly IContextFactory factory;
        private readonly Options options;

        public ArticleUpdateFunctions(
            ILogger<ArticleUpdateFunctions> logger,
            ICrawler crawler,
            IContextFactory factory,
            IOptions<Options> options)
        {
            this.logger = logger;
            this.crawler = crawler;
            this.factory = factory;
            this.options = options.Value;
        }

        [FunctionName("UpdateArticles")]
        public async Task Update([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo trigger)
        {
            try
            {
                await this.InternalUpdate();
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "Execution of function failed");
            }
        }

        private async Task InternalUpdate()
        {
            var ids = await this.LoadOutdatedArticlesAsync();
            foreach (var id in ids)
            {
                try
                {
                    var result = await this.crawler.AnalyzeArticlePageAsync(new AnalyzeArticlePageArguments
                    {
                        ExternalId = id
                    });

                    await this.UpdateArticleAsync(id, result.Article);
                }
                catch (Exception exception)
                {
                    this.logger.LogError(exception, "Failed to update article with {id}", id);
                    await this.RelaseArticleAsync(id);
                }
            }
        }

        private async Task<IEnumerable<long>> LoadOutdatedArticlesAsync()
        {
            using var context = this.factory.GetContext();

            var now = DateTimeOffset.Now;
            var lastUpdatedBefore = now.Add(TimeSpan.FromHours(this.options.UpdateIntervalInHours * -1));

            var entities = await context.Articles.AsTracking()
                .Where(x => !x.ArticleInfo.IsClosed && !x.UpdateInfo.IsLocked)
                .Where(x => x.UpdateInfo.Updated <= lastUpdatedBefore || x.ArticleInfo.Ends <= now)
                .OrderBy(x => x.UpdateInfo.Updated)
                .Take(this.options.BatchSize)
                .ToListAsync();

            foreach (var entity in entities)
            {
                entity.Lock();
            }

            await context.SaveAsync();

            return entities.Select(x => x.ExternalId).ToList();
        }

        private async Task UpdateArticleAsync(long id, ArticleData data)
        {
            using var context = this.factory.GetContext();

            var entity = await context.Articles.AsTracking()
                .SingleAsync(x => x.ExternalId == id);

            entity.Update(data.GetArticleInfo(), data.GetPriceInfo());

            await context.SaveAsync();
        }

        private async Task RelaseArticleAsync(long id)
        {
            using var context = this.factory.GetContext();

            var entity = await context.Articles.AsTracking()
                .SingleAsync(x => x.ExternalId == id);

            entity.Release();

            await context.SaveAsync();
        }
    }
}
