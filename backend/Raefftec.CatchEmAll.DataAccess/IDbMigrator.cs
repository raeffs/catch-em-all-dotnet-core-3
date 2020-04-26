using System.Threading.Tasks;

namespace Raefftec.CatchEmAll
{
    public interface IDbMigrator
    {
        public Task MigrateAsync(bool deleteDatabaseOnFailure);
    }
}
