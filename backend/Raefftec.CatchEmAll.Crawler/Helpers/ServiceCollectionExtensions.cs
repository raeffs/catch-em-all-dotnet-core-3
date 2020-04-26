using Microsoft.Extensions.DependencyInjection;

namespace Raefftec.CatchEmAll
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCrawler(this IServiceCollection services)
        {
            return services
                .AddTransient<ICrawler, Crawler>();
        }
    }
}
