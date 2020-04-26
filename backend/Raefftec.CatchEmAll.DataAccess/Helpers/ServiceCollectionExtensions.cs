using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Raefftec.CatchEmAll
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
        {
            return services
                .AddDbContext<Context>(dbOptions =>
                {
                    dbOptions.UseSqlServer(connectionString, sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    });
                }, ServiceLifetime.Transient)
                .AddTransient<IDbContext>(s => s.GetRequiredService<Context>())
                .AddTransient<IContextFactory, ContextFactory>()
                .AddTransient<IDbMigrator, DbMigrator>();
        }
    }
}
