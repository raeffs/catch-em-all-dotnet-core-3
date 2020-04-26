using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Raefftec.CatchEmAll
{
    internal class DbMigrator : IDbMigrator
    {
        private readonly Context context;

        public DbMigrator(Context context)
        {
            this.context = context;
        }

        public async Task MigrateAsync(bool deleteDatabaseOnFailure)
        {
            try
            {
                await this.context.Database.MigrateAsync();
            }
            catch
            {
                if (deleteDatabaseOnFailure)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
