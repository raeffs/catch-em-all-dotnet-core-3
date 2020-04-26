using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raefftec.CatchEmAll.Entities;

namespace Raefftec.CatchEmAll
{
    class Program
    {
        private static ServiceProvider? services;

        static async Task Main()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.development.json", optional: true)
                .Build();

            services = new ServiceCollection()
                .AddDataAccess(configuration.GetConnectionString("default"))
                .AddCrawler()
                .BuildServiceProvider();

            var migrator = services.GetService<IDbMigrator>();
            await migrator.MigrateAsync(true);

            await SearchAsync();

            await AddOrUpdateArticleAsync(1114842544);
            await AddOrUpdateArticleAsync(1114195386);
        }

        static async Task SearchAsync()
        {
            var crawler = services.GetService<ICrawler>();
            var result = await crawler.AnalyzeSearchPageAsync(new AnalyzeSearchPageArguments
            {
                SearchTerm = "neu"
            });

            var ids = result.Articles.Select(x => x.Id).ToList();

            var context = services.GetService<IDbContext>();
            var entities = await context.Articles.Where(x => ids.Contains(x.ExternalId)).ToListAsync();
            foreach (var article in result.Articles)
            {
                var entity = entities.SingleOrDefault(x => x.ExternalId == article.Id);

                if (entity == null)
                {
                    await context.Articles.AddAsync(new Article(article.Id, article.GetArticleInfo(), article.GetPriceInfo()));
                }
                else
                {
                    entity.Update(article.GetArticleInfo(), article.GetPriceInfo());
                }
            }

            await context.SaveAsync();
        }

        static async Task AddOrUpdateArticleAsync(long id)
        {
            var context = services.GetService<IDbContext>();

            var entity = await context.Articles.SingleOrDefaultAsync(x => x.ExternalId == id);

            if (entity != null)
            {
                entity.Lock();
                await context.SaveAsync();
            }

            var crawler = services.GetService<ICrawler>();
            var result = await crawler.AnalyzeArticlePageAsync(new AnalyzeArticlePageArguments { ExternalId = id });

            if (entity == null)
            {
                await context.Articles.AddAsync(new Article(id, result.Article.GetArticleInfo(), result.Article.GetPriceInfo()));
            }
            else
            {
                entity.Update(result.Article.GetArticleInfo(), result.Article.GetPriceInfo());
            }

            await context.SaveAsync();
        }
    }
}
